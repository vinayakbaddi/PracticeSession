using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Domain
{
    public class Session
    {
        public IList<Talk> Talks { get; set; }

        public short Duration { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
               
    }
}
