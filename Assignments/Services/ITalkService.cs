using Assignments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.Services
{
    interface ITalkService
    {
        /// <summary>
        /// Resets all the talks to Zero
        /// </summary>
        void Reset();

        /// <summary>
        /// Get the list of Talks
        /// </summary>
        /// <returns></returns>
        IEnumerable<Talk> GetTalks();

        /// <summary>
        /// Method to AddTalk
        /// </summary>
        /// <param name="rawTalksData"></param>
        /// <returns></returns>
        bool IsAddTalk(string rawTalksData);

    }
}
