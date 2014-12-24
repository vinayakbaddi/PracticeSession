using Assignments.Properties;
using Assignments.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Domain
{
    public static class Mapper
    {
        /// <summary>
        /// Maps the talks and teh resultcontainer to the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="talks">The talks.</param>
        /// <param name="resultContainer">The result container.</param>
        /// <returns></returns>
        public static IList<Session> Map(IList<Session> container, IList<Talk> talks, IList<ResultContainer> resultContainer)
        {
            IList<Talk> disposableTalks = new List<Talk>(talks.Select(t => t));

            foreach (var result in resultContainer)
            {
                var session = new Session { Talks = new List<Talk>() };
                MapSessionDurationToTime(session, result.ContainerSize);
                session.Duration = result.ContainerSize;
                MapTalkDurationToTime(disposableTalks, session, result);
                container.Add(session);
            }

            return container;
        }

        private static void MapTalkDurationToTime(IList<Talk> talks, Session session, ResultContainer result)
        {

            foreach (var talkDuration in result.ScheduledSizes)
            {
                Talk talk = talks.First(t => t.Duration == talkDuration);

                talk.StartTime = session.Talks.Count <= 0 ? session.StartTime : session.Talks.Last().StartTime.AddMinutes(session.Talks.Last().Duration);

                session.Talks.Add(talk);
                talks.Remove(talk);
            }
        }
        private static void MapSessionDurationToTime(Session session, int containerSize)
        {
            DateTime mmin = Convert.ToDateTime(Settings.Default.MorningMinTime);
            DateTime mmax = Convert.ToDateTime(Settings.Default.MorningMaxTime);
            TimeSpan mspan = mmax.Subtract(mmin);
            if (mspan == TimeSpan.FromMinutes(containerSize))
            {
                session.StartTime = mmin;
                session.EndTime = mmax;
                return;
            }

            DateTime amin = Convert.ToDateTime(Settings.Default.AfternoonMinTime);
            DateTime amax = Convert.ToDateTime(Settings.Default.AfternoonMaxTime);
            TimeSpan aspan = amax.Subtract(amin);
            if (aspan == TimeSpan.FromMinutes(containerSize))
            {
                session.StartTime = amin;
                session.EndTime = amax;
                return;
            }

            if (aspan.Minutes > mspan.Minutes)
            {
                if (containerSize < mspan.Minutes)
                {
                    session.StartTime = mmin;
                    session.EndTime = mmax;
                    return;
                }
            }

            session.StartTime = amin;
            session.EndTime = amax;
            return;
        }
    }
}
