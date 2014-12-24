using Assignments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.Properties;
using System.Text.RegularExpressions;
using Assignments.Services.Validator;

namespace Assignments.Services
{
    public class TalkService : ITalkService
    {
        IList<Talk> _talks = new List<Talk>();
        
        /// <summary>
        /// Resets all the talks to Zero
        /// </summary>
        public void Reset()
        {
            _talks = new List<Talk>();
        }

        /// <summary>
        /// Get the list of Talks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Talk> GetTalks()
        {
            return _talks;
        }

        /// <summary>
        /// Method to AddTalk
        /// </summary>
        /// <param name="rawTalksData"></param>
        /// <returns></returns>
        public bool IsAddTalk(string rawTalksData)
        {
            if (!IsValidData(rawTalksData)) return false;

            try
            {
                var parsedTalkData = ParseRawTalkData(rawTalksData);
                _talks.Add(parsedTalkData);
            }
            catch 
            { 
                //log Exception
                Console.WriteLine("Something went wrong, Please verify the data");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Process Raw String Data
        /// </summary>
        /// <param name="rawTalksData"></param>
        /// <returns></returns>
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
                Duration = int.Parse(match.Groups["time"].Value),
                Title = rawTalksData.Substring(0, match.Index).Trim()
            };
        }

        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        private bool IsValidData(string rawData)
        {
            var validateTime = new ValidateContext(new RawTime());
            var validateTitle = new ValidateContext(new RawTitle());

            return validateTime.IsValid(rawData) && validateTitle.IsValid(rawData);
        }
    }
}
