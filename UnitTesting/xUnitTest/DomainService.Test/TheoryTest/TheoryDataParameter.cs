using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TheoryTest
{
    public class TheoryDataParameter : IDisposable
    {
        Calculator calculator;
        public TheoryDataParameter()
        {
            calculator = new Calculator();
        }
        [Theory]
        [ClassData(typeof(CalcParamter))]
        public void TestAdd_Class(int a, int b, int expectedResult)
        {
            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        [Theory]
        [MemberData(nameof(TestDataForAdd))]
        public void TestAdd_Methods(int a, int b, int expectedResult)
        {
            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        [Theory]
        [MemberData(nameof(Data))]

        public void TestAdd_Property(int a, int b, int expectedResult)
        {
            Assert.Equal(expectedResult, calculator.Add(a, b));
        }

        public static TheoryData<int, int, int> TestDataForAdd() =>
         new TheoryData<int, int, int> {
                {1,2,3},
                 { 4,5,9},
                {6,7,13},
         };

        public static TheoryData<int, int, int> Data
        {
            get
            {
                var data = new TheoryData<int, int, int>();
                data.Add(1, 2, 3);
                data.Add(-4, -6, -10);
                data.Add(-2, 2, 0);
                data.Add(int.MinValue, -1, int.MaxValue);
                // data.Add(1.5, 2.3m, "The value"); // won't compile
                return data;
            }
        }

        public void Dispose()
        {
            calculator = null;
        }
    }

    public class CalcParamter : TheoryData<int, int, int>
    {
        public CalcParamter()
        {
            for (int i = 0; i < 5; i++)
            {
                int a = new Random().Next();
                int b = new Random().Next();
                AddRow(a, b, a + b);
            }
        }
    }
}
