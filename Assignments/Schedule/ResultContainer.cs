using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Schedule
{
    public class ResultContainer
    {

        private IList<short> _scheduledSizes = new List<short>();

        public short ContainerSize { get; set; }

        public IList<short>  ScheduledSizes
        {
            get { return _scheduledSizes; }
            set { _scheduledSizes = value; }
        }

    }
}
