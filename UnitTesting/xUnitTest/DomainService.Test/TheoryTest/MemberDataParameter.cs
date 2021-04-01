using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TheoryTest
{
    public class MemberDataParameter : IDisposable
    {
        Calculator calculator;
        public MemberDataParameter()
        {
            calculator = new Calculator();
        }
        [Theory]
        [MemberData(nameof(TestDataForAdd))]
        public void TestAdd_Inside(int a, int b, int expectedResult)
        {
            Assert.Equal(expectedResult, calculator.Add(a, b));
        }


        [Theory]
        [MemberData(nameof(AdditionTestData.GetTestDataForAdd), parameters: 3, MemberType = typeof(AdditionTestData))]
        public void TestAdd_Outside(int a, int b, int expectedResult)
        {
            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        public static IEnumerable<object[]> TestDataForAdd =>
            new List<object[]> {
                new object[] {1,2,3},
                new object[] {4,5,9},
                new object[] {6,7,13},
            };

        public void Dispose()
        {
            calculator = null;
        }
    }

    public class AdditionTestData
    {
        public static IEnumerable<object[]> GetTestDataForAdd(int numberOfCases)
        {
            for (int i = 0; i < numberOfCases; i++)
            {
                int a = new Random().Next();
                int b = new Random().Next();
                yield return new object[] { a, b, a + b };
            }
        }

    }
}
