using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestFixtures
{
    //Ctor args
    [TestFixture("hello", "hello", "goodbye")]
    [TestFixture("zip", "zip")]
    [TestFixture(42, 42, 99)]
    [TestFixtureSource(nameof(FixtureArgs))]
    public class InlineStaticParameterTestFixture
    {
        private string eq1;
        private string eq2;
        private string neq;

        public InlineStaticParameterTestFixture(string eq1, string eq2, string neq)
        {
            this.eq1 = eq1;
            this.eq2 = eq2;
            this.neq = neq;
        }

        public InlineStaticParameterTestFixture(string eq1, string eq2)
            : this(eq1, eq2, null) { }

        public InlineStaticParameterTestFixture(int eq1, int eq2, int neq)
        {
            this.eq1 = eq1.ToString();
            this.eq2 = eq2.ToString();
            this.neq = neq.ToString();
        }

        [Test]
        public void TestEquality()
        {
            Assert.AreEqual(eq1, eq2);
            if (eq1 != null && eq2 != null)
                Assert.AreEqual(eq1.GetHashCode(), eq2.GetHashCode());
        }

        [Test]
        public void TestInequality()
        {
            Assert.AreNotEqual(eq1, neq);
            if (eq1 != null && neq != null)
                Assert.AreNotEqual(eq1.GetHashCode(), neq.GetHashCode());
        }

        static object[] FixtureArgs = {
            new object[] { "hello", "hello", "goodbye" },
            new object[] { "zip", "zip" },
            new object[] { 42, 42, 99 }
        };
    }
}
