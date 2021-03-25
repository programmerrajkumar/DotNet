using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Decorators
{
    [TestFixture, Order(1)]
    class RepeationTest
    {
        //Repeations wil be stopped if test case fail.
        [Repeat(3)]
        [TestCase(33)]
        public void NumberPredictorNoMercy(int userinput)
        {
            Assert.AreEqual(new Random().Next(1, 200), userinput);
        }

        //If failed retry to run testcases
        [Retry(3)]
        [TestCase(33)]
        public void NumberPredictorWithRetry(int userinput)
        {
            Assert.AreEqual(new Random().Next(1, 200), userinput);
        }
    }
}
