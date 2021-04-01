using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TheoryTest
{
    public class ClassDataParameter : IDisposable
    {
        Calculator calculator;
        public ClassDataParameter()
        {
            calculator = new Calculator();
        }
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void TestAdd(int a, int b, int expectedResult)
        {

            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        public void Dispose()
        {
            calculator = null;
        }
    }
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -4, -6, -10 };
            yield return new object[] { -2, 2, 0 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
