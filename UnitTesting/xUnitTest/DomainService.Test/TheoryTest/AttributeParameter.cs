using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace DomainService.Test.TheoryTest
{

    public class AttributeParameter : IDisposable
    {
        Calculator calculator;
        public AttributeParameter()
        {
            calculator = new Calculator();
        }
        [Theory]
        [CalculatorAdditionTestCases]
        public void TestAdd(int a, int b, int expectedResult)
        {

            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        public void Dispose()
        {
            calculator = null;
        }
    }

    class CalculatorAdditionTestCasesAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < 5; i++)
            {
                int a = new Random().Next();
                int b = new Random().Next();
                yield return new object[] { a, b, a + b };
            }
        }
    }
}
