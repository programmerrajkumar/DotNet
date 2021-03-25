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
    class TypedParameterTestCase
    {
        [TestCaseSource(typeof(MyTestCases), nameof(MyTestCases.DivideCases))]
        public void TestSourceFromAnotherClass(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        [TestCaseSource(typeof(DivideCases))]
        public void TestSourceFromIEnumerableClass(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }


        [TestCaseSource(typeof(MyTestCases), nameof(MyTestCases.CollectionOfTestCaseData))]
        public int TypedTestData(int n, int d)
        {
            return n / d;
        }

        // should have default constructor and implement IEnumerable
        class MyTestCases
        {
            public static object[] DivideCases =
            {
                new object[] { 12, 3, 4 },
                new object[] { 12, 2, 6 },
                new object[] { 12, 4, 3 }
            };

            public static IEnumerable CollectionOfTestCaseData
            {
                get
                {
                    yield return new TestCaseParameters(new object[] { 3, 1 }) { ExpectedResult = 3 };
                    yield return new TestCaseData(2, 1).Returns(2).Explicit();
                    yield return new TestCaseData(3, 1) { ExpectedResult = 3 };
                }
            }
        }
        class DivideCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { 12, 3, 4 };
                yield return new object[] { 12, 2, 6 };
                yield return new object[] { 12, 4, 3 };
            }
        }
    }
}
