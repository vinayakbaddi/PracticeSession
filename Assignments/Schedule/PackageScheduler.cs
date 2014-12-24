using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class PackageScheduler
    {
        private int[] _sessionSize;
        private List<int> _talkSize;
        private List<int> _packedSchedule; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionSize"></param>
        /// <param name="talkSize"></param>
        public PackageScheduler(int[] sessionSize, IEnumerable<int> talkSize) 
        {
            _sessionSize = sessionSize;
            _talkSize = new List<int>(talkSize.OrderByDescending(x => x));
            _packedSchedule = new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public ScheduleResults OrganizeSchedule(ScheduleResults results, CancellationToken cancelToken)
        {
            IList<ResultContainer> containers = new List<ResultContainer>();
            while (_talkSize.Count > 0)
            {
                foreach (var containerSize in _sessionSize)
                {
                    if (cancelToken.IsCancellationRequested) return results;

                    var resultContainer = new ResultContainer { ContainerSize = containerSize };

                    int i;
                    bool firstPass = true;
                    for (i = 0; i < _talkSize.Count; )
                    {
                        if (cancelToken.IsCancellationRequested) return results;

                        int talk = _talkSize[i];
                        int sumScheduleSize = resultContainer.ScheduledSizes == null ? 0 : resultContainer.ScheduledSizes.Sum();

                        if ((resultContainer.ScheduledSizes == null || resultContainer.ScheduledSizes.Count <= 0 || (resultContainer.ScheduledSizes.Last() > talk || !firstPass))
                             && sumScheduleSize + talk <= containerSize)
                        {
                            resultContainer.ScheduledSizes.Add(talk);
                            _packedSchedule.Add(talk);
                            _talkSize.RemoveAt(i);

                            if (resultContainer.ScheduledSizes.Sum(x=>(int)x) == containerSize) i = _talkSize.Count; //int circuit inner for loop
                            continue;
                        }

                        i++;
                        //if we get to the end and we still have room enough for at least the smallest of our packages, then reset and go from 
                        //largest to smallest, again.  until our smallest sized parcel remaining is bigger than the container delta.
                        if (i >= _talkSize.Count && sumScheduleSize < containerSize && containerSize - sumScheduleSize >= _talkSize.Last())
                        {
                            firstPass = false;
                            i = 0;
                        }
                    }

                    containers.Add(resultContainer);
                }
            }

            if (IsMoreOptimal(containers, results.CurrentBestResults))
            {
                results.CurrentBestResults = containers;
            }

            return results;
        }

        private bool IsMoreOptimal(IList<ResultContainer> containers, IList<ResultContainer> currentBestResults)
        {
            if (currentBestResults == null || currentBestResults.Count <= 0) return true;

            if (containers == null || containers.Count <= 0) return false;

            return
                containers.Count <= currentBestResults.Count 
                &&
                containers.Sum(a => a.ScheduledSizes.Count) >= currentBestResults.Sum(a => a.ScheduledSizes.Count) /*more or same talks*/
                &&
                _talkSize.Count <= 0;
        }
    }
}
