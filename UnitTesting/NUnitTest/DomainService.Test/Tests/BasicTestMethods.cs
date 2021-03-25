using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Tests
{
    [TestFixture]
    class BasicTestMethods
    {

        [Test]
        public void Add()
        {
            Assert.AreEqual(2, 1 + 1);
        }


        [Test(ExpectedResult = 100)]
        public int Divide()
        {
            return 1000 / 10;
        } 
    }
}
