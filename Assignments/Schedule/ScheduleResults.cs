using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class ScheduleResults
    {
        public IList<ResultContainer> OptimizedResults { get; set; }
        public IList<ResultContainer> CurrentBestResults { get; set; }
    }
}
