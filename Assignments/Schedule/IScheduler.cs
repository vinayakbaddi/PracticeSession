﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public interface IScheduler
    {
        void Load();

        ScheduleResults Results();
        
        void Cancel();
        
        bool AreRunsFinished();
        
        bool AreResultsReady();
    }
}
