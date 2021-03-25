using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TheoryAssumption
{
    [TestFixture]
    public class Calculator
    {

      
        [Theory]
        public void Divide(double a, double b)

        {
            Assume.That(b != 0);

            Assert.Pass();
        }

        [Datapoints]
        public double[] values1 = new double[] { 0.0, 1.0, -1.0, 42.0 };

        [Theory]
        public void SquareRootDefinition(double num)
        {
            Assume.That(num >= 0.0);

            double sqrt = Math.Sqrt(num);

            Assert.That(sqrt >= 0.0);
            Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
        }
    }
}
