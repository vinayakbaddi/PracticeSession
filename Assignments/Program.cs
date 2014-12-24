using Assignments.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments
{
    class Program
    {
        public static void Main()
        {
            SchedulePresenter schedulePresenter = new SchedulePresenter();

            string data = "Writing Fast Tests Against Enterprise Rails 100min\r\nOverdoing it in Python lightning\r\nLua for the Masses 90min\r\nRuby Errors from Mismatched Gem Versions 45min\r\nRuby on Rails: Why We Should Move On 60min\r\nCommon Ruby Errors 45min\r\nPair Programming vs Noise 45min\r\nProgramming in the Boondocks of Seattle 30min\r\nRuby vs. Clojure for Back-End Development 30min\r\nUser Interface CSS in Rails Apps 30min";

            var results = schedulePresenter.SubmitSchedule(data);
            Console.WriteLine(results);

            Console.ReadKey();
        }
    }
}
