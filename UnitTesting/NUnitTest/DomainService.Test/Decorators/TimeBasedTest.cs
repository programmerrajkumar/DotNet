using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Decorators
{
    [TestFixture, Timeout(10000)]
    class TimeBasedTest
    {
        //does not cancel the test if the time is exceeded
        // compares the elapsed time to the specified maximum. 
        [Test, MaxTime(800), Category("Short Running Task")]
        public void PerformanceTracker()
        {
            Task.Delay(500).Wait();
        }


        //timeot includes time taken by setup ,method itself,teardown
        // while debugging the timeout is not enforced.
        [Test, Timeout(800), Category("Short Running Task")]
        public void TimedTest()
        {
            Task.Delay(200).Wait();
        }

        [Test, MaxTime(800), Category("Long Running Task")]
        public void PerformanceTracker_Long()
        {
            Task.Delay(1000).Wait();
        }


     
        [Test, Timeout(1000), Category("Long Running Task")]
        public void TimedTest_Long()
        {
            Task.Delay(2000).Wait();
        }

    }
}
