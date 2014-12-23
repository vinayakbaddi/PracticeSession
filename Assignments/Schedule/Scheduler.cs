using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    class Scheduler : ILoader
    {
        private readonly int[] _sessionSize;
        private readonly int[] _talkSize;
        private readonly CancellationTokenSource _tokenSource;
        private readonly CancellationToken _cancelToken;
        private ScheduleResults _results;
        private Task[] _tasks;

        public Scheduler(int[] sessionSize, int[] talkSize) 
        {
            _sessionSize = sessionSize;
            _talkSize = talkSize;
        }

        public void Load()
        {
            _results = new ScheduleResults();

            var data = Task<ScheduleResults>.Factory.StartNew(() => new PackageSchedule(_sessionSize, _talkSize).Pack(_results, _cancelToken), _cancelToken);

            var brute = new Task<ScheduleResults>(()=> new Solver(_sessionSize,_talkSize).Pack(_results,_cancelToken), TaskCreationOptions.LongRunning);

            brute.Start();

            _tasks = new Task[] { data, brute };
        }

        public ScheduleResults Results()
        {
            return _results;
        }
        public bool AreResultsReady()
        {
            return _results.CurrentBestResults != null && _results.CurrentBestResults.Any();
        }
        public bool AreRunsFinished()
        {
            return _tasks.All(t => t.IsCompleted);
        }
        public void Cancel()
        {
            if (!_tokenSource.IsCancellationRequested) _tokenSource.Cancel();
        }
      }
}
