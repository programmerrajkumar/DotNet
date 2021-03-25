using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestsSetupTearDown
{
    [TestFixture]
    class BasicTearDown
    {

        [Test]
        public void Add()
        {

        }

        [TearDown]
        public void PostExecutionOfEachTestCase()
        {

        }

        [OneTimeTearDown]
        public void PostExecutionAfterAllTestCaseCompleted()
        {

        }
    }
}
