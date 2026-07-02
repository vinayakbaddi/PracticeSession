<#
PowerShell script to purge large files from repository history using git-filter-repo.

Usage:
  1. Open PowerShell as your normal user (no admin required normally).
  2. Place this script anywhere and run from your local repo (it auto-detects origin remote).
	 Or run from repo root: .\remove-large-files-filter-repo.ps1

Note: This rewrites history and force-pushes. All collaborators must re-clone or reset after this.
Back up the repository before running.
#>

param(
	[string]$LocalRepo = (Get-Location).Path,
	[string[]]$PathsToRemove = @(
		'packages/Aspose.PDF.20.5.0/Aspose.PDF.20.5.0.nupkg',
		'packages/Aspose.Slides.NET.20.12.0/Aspose.Slides.NET.20.12.0.nupkg'
	),
	[string]$TempDir = "$env:TEMP\filter-repo-$(Get-Date -Format yyyyMMddHHmmss)",
	[switch]$DryRun
)

function Write-ErrAndExit($msg) {
	Write-Error $msg
	exit 1
}

# Ensure git exists
$gitCmd = $null
try {
	$gitCmd = (Get-Command git -ErrorAction Stop).Source
} catch {
	# try common Git install location
	$candidate = 'C:\Program Files\Git\cmd\git.exe'
	if (Test-Path $candidate) { $gitCmd = $candidate } else { Write-ErrAndExit 'git not found on PATH. Install Git and re-run.' }
}
Write-Host "Using git: $gitCmd"

# Get origin URL
Push-Location $LocalRepo
$origin = & $gitCmd config --get remote.origin.url 2>$null
if ([string]::IsNullOrWhiteSpace($origin)) {
	Pop-Location
	Write-ErrAndExit 'Could not determine remote origin URL. Ensure this is a git repository with a remote named origin.'
}
Write-Host "Remote origin: $origin"

# Ensure git-filter-repo is available (try command, then python module)
$gitFilterRepoCmd = $null
if (Get-Command git-filter-repo -ErrorAction SilentlyContinue) {
	$gitFilterRepoCmd = 'git-filter-repo'
} else {
	# try python -m git_filter_repo
	$pythonCmdObj = Get-Command python -ErrorAction SilentlyContinue
	if (-not $pythonCmdObj) { $pythonCmdObj = Get-Command py -ErrorAction SilentlyContinue }
	$pythonCmd = $null
	if ($pythonCmdObj) { $pythonCmd = $pythonCmdObj.Source }
	if ($pythonCmd) {
		# test module
		try {
			& $pythonCmd -c "import importlib.util,sys; importlib.util.find_spec('git_filter_repo') or sys.exit(2)"
			if ($LASTEXITCODE -eq 0) { $gitFilterRepoCmd = "$pythonCmd -m git_filter_repo" }
		} catch {
			# not installed
		}
	}
}

if (-not $gitFilterRepoCmd) {
	Write-Host "git-filter-repo not found. Attempting to install via pip (current user)."
	$pipCmdObj = Get-Command pip -ErrorAction SilentlyContinue
	$pipCmd = $null
	if ($pipCmdObj) { $pipCmd = $pipCmdObj.Source }
	if (-not $pipCmd) {
		Write-Host "pip not found. Will fall back to using 'git filter-branch' (slower, deprecated) to purge history."
		$useFilterBranch = $true
	}
	if (-not $useFilterBranch) {
		Write-Host "Installing git-filter-repo via pip..."
		& $pipCmd install --user git-filter-repo
		if ($LASTEXITCODE -ne 0) { Pop-Location; Write-ErrAndExit 'pip install git-filter-repo failed. Install manually and re-run.' }
	} else {
		Write-Host "Skipping pip install because pip not available; will use git filter-branch fallback."
	}
	# try locating git-filter-repo again
	if (Get-Command git-filter-repo -ErrorAction SilentlyContinue) { $gitFilterRepoCmd = 'git-filter-repo' } else {
		# fallback to python -m
		$pythonCmdObj = Get-Command python -ErrorAction SilentlyContinue
		if (-not $pythonCmdObj) { $pythonCmdObj = Get-Command py -ErrorAction SilentlyContinue }
		$pythonCmd = $null
		if ($pythonCmdObj) { $pythonCmd = $pythonCmdObj.Source }
		if ($pythonCmd) { $gitFilterRepoCmd = "$pythonCmd -m git_filter_repo" }
	}
}

if (-not $gitFilterRepoCmd) { Pop-Location; Write-ErrAndExit 'git-filter-repo still not found after install. Install it manually and re-run.' }
Write-Host "Using git-filter-repo: $gitFilterRepoCmd"

# Confirm targets
Write-Host "Paths to remove from history:"
$PathsToRemove | ForEach-Object { Write-Host "  $_" }

if ($DryRun) {
	Write-Host "Dry-run requested. Exiting after checks."; Pop-Location; exit 0
}

# Prepare temp working dir
if (Test-Path $TempDir) { Remove-Item -Recurse -Force $TempDir }
New-Item -ItemType Directory -Path $TempDir | Out-Null
$mirrorDir = Join-Path $TempDir 'mirror-repo.git'

Write-Host "Mirror-cloning repository to $mirrorDir (this may take a while)..."
& $gitCmd clone --mirror $origin $mirrorDir
if ($LASTEXITCODE -ne 0) { Pop-Location; Write-ErrAndExit 'git clone --mirror failed' }

Push-Location $mirrorDir

# Build git-filter-repo args
# We will pass multiple --path entries and use --invert-paths to remove them from history
$filterArgs = @()
foreach ($p in $PathsToRemove) { $filterArgs += '--path'; $filterArgs += $p }
$filterArgs += '--invert-paths'

if ($useFilterBranch) {
	Write-Host "git-filter-repo not available; using git filter-branch to remove paths (this may be slow)..."
	foreach ($p in $PathsToRemove) {
		Write-Host "Running git filter-branch to remove: $p"
		# Use index-filter to remove the path
		$indexFilter = 'git rm --cached --ignore-unmatch "' + $p + '"'
		& $gitCmd filter-branch --force --index-filter $indexFilter --prune-empty --tag-name-filter cat -- --all
		if ($LASTEXITCODE -ne 0) { Pop-Location; Pop-Location; Write-ErrAndExit "git filter-branch failed for $p" }
	}
} else {
	Write-Host "Running git-filter-repo to purge specified paths from history..."
	# If git-filter-repo is a python -m invocation, invoke differently
	if ($gitFilterRepoCmd -like '* -m *') {
		$parts = $gitFilterRepoCmd -split ' '
		$exe = $parts[0]
		$moduleArg = $parts[1..($parts.Length-1)] -join ' '
		& $exe -m git_filter_repo @filterArgs
	} else {
		& $gitFilterRepoCmd @filterArgs
	}
	if ($LASTEXITCODE -ne 0) { Pop-Location; Pop-Location; Write-ErrAndExit 'git-filter-repo failed' }
}

Write-Host "Expiring reflog and running git gc..."
& $gitCmd reflog expire --expire=now --all
& $gitCmd gc --prune=now --aggressive

Write-Host "Force-pushing cleaned history to remote..."
& $gitCmd push --force --all
if ($LASTEXITCODE -ne 0) { Pop-Location; Pop-Location; Write-ErrAndExit 'git push --force --all failed' }
& $gitCmd push --force --tags

Pop-Location

# Update local working copy to avoid reintroducing files
Write-Host "Updating local working copy at $LocalRepo to remove files from index and add .gitignore entries..."
Push-Location $LocalRepo
foreach ($p in $PathsToRemove) {
	& $gitCmd rm --cached --ignore-unmatch -- "$p"
}

# Ensure packages/ is in .gitignore
if (-not (Test-Path '.gitignore')) { New-Item -ItemType File -Path '.gitignore' | Out-Null }
$gitignoreText = Get-Content .gitignore -Raw
if ($gitignoreText -notmatch '(^|\r?\n)\s*packages/') {
	Add-Content -Path .gitignore -Value "`n# Ignore nuget packages folder`npackages/"
	& $gitCmd add .gitignore
}

# Commit local cleanup (allow-empty to ensure branch heads fast-forward)
& $gitCmd add -A
& $gitCmd commit -m "Remove large Aspose package files from index and add packages/ to .gitignore" --allow-empty

# Try to rebase/pull latest and push
& $gitCmd pull --rebase origin HEAD
& $gitCmd push origin HEAD

Pop-Location

Write-Host "
DONE: The specified files have been purged from repository history and remote has been updated (force-pushed).
IMPORTANT: All collaborators must re-clone the repository or reset their local clones to match the rewritten history.

Suggested collaborator instructions:
1) Backup any local changes (stash or save patches).
2) git fetch origin
3) git reset --hard origin/master   # or origin/<branch>
4) Re-apply or re-create any local branches as needed

If you want a BFG variant or to also migrate these files to Git LFS, tell me and I will generate that script.
"

Pop-Location
