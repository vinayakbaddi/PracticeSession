using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class ResultContainer
    {

        private IList<int> _scheduledSizes = new List<int>();

        public int ContainerSize { get; set; }

        public IList<int>  ScheduledSizes
        {
            get { return _scheduledSizes; }
            set { _scheduledSizes = value; }
        }

    }
}
