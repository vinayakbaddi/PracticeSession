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
        private readonly short[] _sessionSize;
        private readonly short[] _talkSize;
        private readonly CancellationTokenSource _tokenSource;
        private readonly CancellationToken _cancelToken;
        private ScheduleResults _results;
        private Task[] _tasks;

        public Scheduler(short[] sessionSize, short[] talkSize) 
        {
            _sessionSize = sessionSize;
            _talkSize = talkSize;
        }

        public void Load()
        {
            _results = new ScheduleResults();

            var data = Task<ScheduleResults>.Factory.StartNew(()=> new PackageSchedule(_sessionSize,_talkSize).
        }
      }
}
