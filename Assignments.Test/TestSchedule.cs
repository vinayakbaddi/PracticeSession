using Assignments.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignments.Test
{
    [TestClass]
    public class TestSchedule
    {
        [TestMethod]
        public void TestSubmitSchedule() 
        {
            string testDataToGenerateMoreThenOneTrack = "Writing Fast Tests Against Enterprise Rails 100min\r\nOverdoing it in Python lightning\r\nLua for the Masses 90min\r\nRuby Errors from Mismatched Gem Versions 45min\r\nRuby on Rails: Why We Should Move On 60min\r\nCommon Ruby Errors 45min\r\nPair Programming vs Noise 45min\r\nProgramming in the Boondocks of Seattle 30min\r\nRuby vs. Clojure for Back-End Development 30min\r\nUser Interface CSS in Rails Apps 30min";

            string testDataToGenerateOneTrack = "Ruby on Rails: Why We Should Move On 80min\r\nCommon Ruby Errors 55min\r\nPair Programming vs Noise lightning\r\nProgramming in the Boondocks of Seattle 30min\r\nRuby vs. Clojure for Back-End Development 30min\r\nUser Interface CSS in Rails Apps 30min";

            TestHelperSubmitSchedule(testDataToGenerateMoreThenOneTrack);

            TestHelperSubmitSchedule(testDataToGenerateOneTrack);

        }

        [TestMethod]
        public void TestSubmitErrorScheduleData()
        {
            string testErrorData = "Writing Fast Tests Against Enterprise Rails";

            TestHelperSubmitErrorScheduleData(testErrorData);
        }

        private void TestHelperSubmitErrorScheduleData(string testErrorData)
        {
            //Setup
            ISchedulePresenter schedulePresenter = new SchedulePresenter();

            //Act
            var results = schedulePresenter.SubmitSchedule(testErrorData);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(results));
        }


        private void TestHelperSubmitSchedule(string testData)
        {
            //Setup
            ISchedulePresenter schedulePresenter = new SchedulePresenter();

            //Act
            var results = schedulePresenter.SubmitSchedule(testData);

            //Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Contains("Track"));
            Assert.IsTrue(results.Contains("Lunch"));
            Assert.IsTrue(results.Contains("Networking Event"));

        }
    }
}
