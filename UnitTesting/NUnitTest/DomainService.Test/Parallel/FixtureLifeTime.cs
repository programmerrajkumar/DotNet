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
    class FixtureLifeTime
    {
        private string UniqueId;
        private string UniqueIdCopy;
        public FixtureLifeTime()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        [Test]
        [Order(1)]
        [NonParallelizable]
        public void Test1()
        {
            UniqueIdCopy = UniqueId;
        }
        [Test]
        [Order(2)]
        [NonParallelizable]
        public void Test2()
        {
            Assert.That(UniqueIdCopy == UniqueId);
        }
    }
}
