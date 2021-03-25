using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TheoryAssumption
{
    // C.U.T.
    public class ComplexCalcultor
    {
        public int Add(int x, int y) { return x + y; }
        public int Divide(int x, int y) { return x / y; }
    }

    [TestFixture]
    public class ComplexCalcultorTest
    {

        public struct AdditionData
        {
            public int First { get; set; }
            public int Second { get; set; }
        }
        [Datapoints]
        private AdditionData[] _points = new AdditionData[]
        {
        new AdditionData{First=20, Second=10},
        new AdditionData{First=-10, Second=0}
        };


        public struct DivisionData
        {
            public int First { get; set; }
            public int Second { get; set; }
        }

        [Datapoints]
        private DivisionData[] _points2 = new DivisionData[]
        {
        new DivisionData{First=20, Second=10},
        new DivisionData{First=20, Second=0},
        };

        [Theory]
        public void AddTheory(AdditionData point)
        {
            Assume.That((long)point.First + (long)point.Second < (long)int.MaxValue);
            Assert.That(point.First + point.Second, Is.EqualTo(new ComplexCalcultor().Add(point.First, point.Second)));
        }

        [Theory]
        public void DivideTheory(DivisionData point)
        {
            Assume.That(point.Second != 0);
            Assert.That(point.First / point.Second, Is.EqualTo(new ComplexCalcultor().Divide(point.First, point.Second)));
        }

    }
}
