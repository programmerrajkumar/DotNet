using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.FactTest
{
    public class BasicFact
    {
        private int count;
        public BasicFact()
        {
            count++;
        }

        [Fact()]
        public void Fact1()
        {
            Assert.True(count == 1);
        }

        [Fact(DisplayName = "Basic Test Fact.Custom Name")]
        public void Fact2()
        {
            Assert.True(count == 1);
        }

        [Fact(Skip = "Will be fixed in next release")]
        public void Fact3()
        {
            Assert.True(count == 1);
        }
    }
}
