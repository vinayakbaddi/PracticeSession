using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Domain
{
    public class Talk
    {

        public int Id { get; set; }

        /// <summary>
        /// Duration In Minutes
        /// </summary>
        public short Duration { get; set; }

        public DateTime StartTime { get; set; }

        public string Title { get; set; }
    }
}
