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


        public PackageScheduler(int[] sessionSize, IEnumerable<int> talkSize) 
        {
            _sessionSize = sessionSize;
            _talkSize = new List<int>(talkSize.OrderByDescending(x => x));
            _packedSchedule = new List<int>();
        }

        public ScheduleResults Pack(ScheduleResults results, CancellationToken cancelToken)
        {
            IList<ResultContainer> containers = new List<ResultContainer>();
            while (_talkSize.Count > 0)
            {
                foreach (var containerSize in _sessionSize)
                {
                    if (cancelToken.IsCancellationRequested) return results;

                    var conveyer = new ResultContainer { ContainerSize = containerSize };

                    int i;
                    bool firstPass = true;
                    for (i = 0; i < _talkSize.Count; )
                    {
                        if (cancelToken.IsCancellationRequested) return results;

                        int parcel = _talkSize[i];
                        int sumParcelSizes = conveyer.ScheduledSizes == null ? 0 : conveyer.ScheduledSizes.Sum();

                        if ((conveyer.ScheduledSizes == null || conveyer.ScheduledSizes.Count <= 0 || (conveyer.ScheduledSizes.Last() > parcel || !firstPass))
                             && sumParcelSizes + parcel <= containerSize)
                        {
                            conveyer.ScheduledSizes.Add(parcel);
                            _packedSchedule.Add(parcel);
                            _talkSize.RemoveAt(i);

                            if (conveyer.ScheduledSizes.Sum(x=>(int)x) == containerSize) i = _talkSize.Count; //int circuit inner for loop
                            continue;
                        }

                        i++;
                        //if we get to the end and we still have room enough for at least the smallest of our packages, then reset and go from 
                        //largest to smallest, again.  until our smallest sized parcel remaining is bigger than the container delta.
                        if (i >= _talkSize.Count && sumParcelSizes < containerSize && containerSize - sumParcelSizes >= _talkSize.Last())
                        {
                            firstPass = false;
                            i = 0;
                        }
                    }

                    containers.Add(conveyer);
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
                containers.Count <= currentBestResults.Count /*fewer or equal sessions*/
                &&
                containers.Sum(a => a.ScheduledSizes.Count) >= currentBestResults.Sum(a => a.ScheduledSizes.Count) /*more or same talks*/
                &&
                _talkSize.Count <= 0 /*all current parcels were packed*/;
        }
    }
}
