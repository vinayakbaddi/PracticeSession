using Assignments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.Services
{
    interface ITrackService
    {
        /// <summary>
        /// Create Schedule
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
        string CreateSchedule(IEnumerable<Session> sessions);

    }
}
