using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Decorators
{
    [TestFixture]
    class CombinatorialParameterValueTest
    {
        [Test]
        public void IsEvenNumner([Values(2, 3, 4, 5)] int val)
        {
            Assert.That(val % 2 == 0, "Odd number");
        }

        //MyTest(1, "A")
        //MyTest(1, "B")
        //MyTest(2, "A")
        //MyTest(2, "B")
        //MyTest(3, "A")
        //MyTest(3, "B")
        [Test, Combinatorial]
        public void MyTest([Values(1, 2, 3)] int x, [Values("A", "B")] string s)
        {
            Assert.Pass(x.ToString() + "," + s);
        }

        //by default generates for all values of enum and bool 
        [Test]
        public void MyEnumTest([Values] MyEnumType x, [Values] bool y)
        {
            Assert.Pass(x.ToString() + "," + y.ToString());
        }
        public enum MyEnumType
        {
            Value1,
            Value2,
            Value3
        }

        [Test]
        public void RangeTest([Range(1, 1000, 200)] int val)
        {

        }

        [Test]
        public void RandomTest([Random(-1.0, 1.0, 5)] int val)
        {

        }
    }
}
