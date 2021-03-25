using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Tests
{
    [TestFixture]
    class InlineStaticParameterTestCase
    {
        [TestCase(10, 4, ExpectedResult = 40)]
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        [TestCase(Ignore = "Ignored by dev")]
        public void Multiply_Ignore()
        {

        }

        [TestCaseSource(nameof(DivideCases))]
        public void Divide(decimal val1, decimal val2, decimal expected)
        {
            Assert.AreEqual(expected, val1 / val2);
        }

        [TestCaseSource(nameof(TestStrings), new object[] { true })]
        public void TestSourceWithParameter(string name)
        {
            Assert.That(name.Length, Is.GreaterThan(5));
            bool hasEvenNumOfCharacters = (name.Length / 2) == 0;
        }

        //should be static,IEnumerable , Each item should match method signature
        static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };

        static IEnumerable<string> TestStrings(bool generateLongTestCase)
        {
            if (generateLongTestCase)
                yield return "ThisIsAVeryLongNameThisIsAVeryLongName";
            yield return "SomeName";
            yield return "YetAnotherName";
        }
    }
}
