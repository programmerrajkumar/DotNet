using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Parallel
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    class MultiThreadedTest
    {
        [Test, Repeat(10)]
        public void ParallelTest1()
        {
            Task.Delay(100).Wait();
            Assert.Pass(DateTime.Now.ToString());
        }

        [Test, Repeat(10)]
        public void ParallelTest2()
        {
            Task.Delay(100).Wait();
            Assert.Pass(DateTime.Now.ToString());
        }
    }
}
