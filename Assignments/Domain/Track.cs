using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.Properties;

namespace Assignments.Domain
{
    public class Track
    {
        public IList<Session> Sessions { get; set; }
        
        public DateTime LunchStart { get; set; }
        
        public string Title { get; set; }

        public string LunchTitle { get { return Settings.Default.LunchTitle; } }
        
        public DateTime NetworkingEventStart { get; set; }

        public string NetworkingEventTitle { get { return "Networking Event"; } }

    }
}
