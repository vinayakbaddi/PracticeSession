using System.Text.RegularExpressions;
using Assignments.Properties;

namespace Assignments.Services.ValidateStrategies
{
	/// <summary>
	/// concrete validator strategy
	/// </summary>
	public class RawTime : IValidator
	{
		public bool IsValid(string candidate)
		{
			var regex = new Regex(Settings.Default.TalkTimePattern);
			return regex.IsMatch(candidate.Trim()) || candidate.Trim().ToUpper().EndsWith(Settings.Default.TalkTimeKeyword);
		}
	}
}