using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TheoryTest
{
    public class InlineParameter : IDisposable
    {
        Calculator calculator;
        public InlineParameter()
        {
            calculator = new Calculator();
        }
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        [InlineData(1000, -1, 1000 - 1)]
        public void TestAdd(int a, int b, int expectedResult)
        {

            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        public void Dispose()
        {
            calculator = null;
        }
    }
}
