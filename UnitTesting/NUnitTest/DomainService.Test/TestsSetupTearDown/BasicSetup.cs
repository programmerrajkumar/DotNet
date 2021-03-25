using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestsSetupTearDown
{
    [TestFixture]
    class BasicSetup
    {
        int result;
        int[] numbers;
        [OneTimeSetUp]
        public void OneTimeExecutionThroughOutAllTestCase()
        {
            result = -1;
            numbers = new int[2];
        }

        [SetUp]
        public void PreExecutionOfEachTestCase()
        {
            result = 0;
            numbers = new int[3];

        }

        //can have duplicate but order is not gauranted
        //[SetUp]
        //public void PreTestCaseExecution_1()
        //{
        //    result = 1;
        //}

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void Add(int val1, int val2)
        {
            Assert.AreEqual(0, result);
            result = val1 + val2;
        }


        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void subtract(int val1, int val2)
        {
            Assert.AreEqual(0, result);
            result = val1 - val2;
        }
    }
}
