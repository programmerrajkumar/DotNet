using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TraitTest
{
    [Trait("Release 1", "Category")]
    public class IntermediateTrait
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void Test2()
        {

        }

        [Fact]
        [Trait("Release 2", "Category")]
        public void Test3()
        {

        }
    }
}
