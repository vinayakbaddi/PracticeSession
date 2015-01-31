using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.Schedule
{
    public interface ISchedulePresenter
    {
        /// <summary>
        /// SubmitSchedule
        /// </summary>
        /// <param name="proposedTalks"></param>
        /// <returns></returns>
        string SubmitSchedule(string proposedTalks);
    }
}
