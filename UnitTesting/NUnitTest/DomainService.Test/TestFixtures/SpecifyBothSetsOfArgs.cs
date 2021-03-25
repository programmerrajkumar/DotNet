using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestFixtures
{
    [TestFixture(typeof(double), typeof(int), 100.0, 42)]
    [TestFixture(33, 3, TypeArgs = new Type[] { typeof(double), typeof(int) })]
    [TestFixture(5, 7)]
    public class SpecifyBothSetsOfArgs<T1, T2>
    {
        T1 t1;
        T2 t2;

        public SpecifyBothSetsOfArgs(T1 t1, T2 t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }

        [TestCase(5.2, 7)]
        public void TestMyArgTypes(T1 t1, T2 t2)
        {
            Assert.That(t1, Is.TypeOf<T1>());
            Assert.That(t2, Is.TypeOf<T2>());
        }
    }
}
