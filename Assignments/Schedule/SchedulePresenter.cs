using Assignments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class SchedulePresenter
    {
        private readonly TalkService _talkService;
        private readonly SessionService _sessionService;
        private readonly TrackService _trackService;

        public SchedulePresenter()
        {
            _talkService = new TalkService();
            _sessionService = new SessionService();
            _trackService = new TrackService();
                       
        }

        public string SubmitSchedule(string proposedTalks)
        {
            _talkService.Reset();
            foreach (var line in proposedTalks.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                _talkService.HasAddTalk(line.Trim());
            }

            _sessionService.CreateSessions(_talkService.GetTalks());

            return _trackService.CreateSchedule(_sessionService.GetSessions());
        }
    }
}
