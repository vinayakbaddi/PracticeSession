using Assignments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.Services
{
    interface ISessionService
    {
        /// <summary>
        /// Create Sessions
        /// </summary>
        /// <param name="talks"></param>
        /// <returns></returns>
        IEnumerable<Session> CreateSessions(IEnumerable<Talk> talks);

        /// <summary>
        /// Get Sessions
        /// </summary>
        /// <returns></returns>
        IEnumerable<Session> GetSessions();
    }
}
