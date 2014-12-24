using Assignments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class SchedulePresenter : ISchedulePresenter
    {
        private readonly ITalkService _talkService;
        private readonly ISessionService _sessionService;
        private readonly ITrackService _trackService;

        public SchedulePresenter()
        {
            _talkService = new TalkService();
            _sessionService = new SessionService();
            _trackService = new TrackService();
                       
        }

        /// <summary>
        /// Submit Schedule
        /// </summary>
        /// <param name="proposedTalks"></param>
        /// <returns></returns>
        public string SubmitSchedule(string proposedTalks)
        {
            _talkService.Reset();

            foreach (var line in proposedTalks.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                _talkService.IsAddTalk(line.Trim());
            }

            _sessionService.CreateSessions(_talkService.GetTalks());

            return _trackService.CreateSchedule(_sessionService.GetSessions());
        }
    }
}
