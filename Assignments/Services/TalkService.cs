using Assignments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.Properties;
using System.Text.RegularExpressions;

namespace Assignments.Services
{
    public class TalkService
    {
        IList<Talk> _talks = new List<Talk>();

        public IEnumerable<Talk> GetTalks()
        {
            return _talks;
        }

        public void AddTalk(string rawTalksData)
        {
            try
            {
                var parsedTalkData = ParseRawTalkData(rawTalksData);
                _talks.Add(parsedTalkData);
            }
            catch 
            { 
                //log Exception
                Console.WriteLine("Something went wrong, Please verify the data");
            }
        }

        Talk ParseRawTalkData(string rawTalksData)
        {
            string upperClean = rawTalksData.Trim().ToUpper();

            if (upperClean.EndsWith(Settings.Default.TalkTimeKeyword))
            {
                return new Talk()
                {
                    Id = _talks.Count,
                    Duration = Settings.Default.LightningValue,
                    Title = rawTalksData.Substring(0, upperClean.LastIndexOf(Settings.Default.TalkTimeKeyword))
                };
            }

            var regex = new Regex(Settings.Default.TalkTimePattern);
            var match = regex.Match(rawTalksData);

            return new Talk()
            {
                Id = _talks.Count,
                Duration = short.Parse(match.Groups["time"].Value),
                Title = rawTalksData.Substring(0, match.Index).Trim()
            };
        }
    }
}
