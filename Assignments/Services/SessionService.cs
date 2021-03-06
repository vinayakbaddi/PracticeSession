﻿using Assignments.Domain;
using Assignments.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.Schedule;

namespace Assignments.Services
{
    public class SessionService : ISessionService
    {
        IList<Session> _sessions;

        public IEnumerable<Session> CreateSessions(IEnumerable<Talk> talks)
        {
            _sessions = new List<Session>();

            Load(talks);

            return _sessions;
        }

        private void Load(IEnumerable<Talk> talks)
        {
            IList<Talk> listTalks = new List<Talk>(talks);

            IScheduler scheduler = new Scheduler(GetUniqueSessionMaxSizesPerTrack(), listTalks.Select(t => t.Duration).ToArray());
            scheduler.Load();

            while (!scheduler.AreResultsReady() && talks.Count()>0) ;

            ScheduleResults results = scheduler.Results();

            IList<ResultContainer> resultGroup = results.OptimizedResults ?? results.CurrentBestResults;
            
            _sessions = Mapper.Map(_sessions, listTalks, resultGroup);
        }

        private static int[] GetUniqueSessionMaxSizesPerTrack()
        {
            var stringCollection = Settings.Default.UniqueSessionMaxSize;
            var sizes = new string[stringCollection.Count];
            stringCollection.CopyTo(sizes, 0);

            return sizes.Select(int.Parse).ToArray();
        }


        /// <summary>
        /// Get Sessions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Session> GetSessions()
        {
            return _sessions;
        } 
    }
}
