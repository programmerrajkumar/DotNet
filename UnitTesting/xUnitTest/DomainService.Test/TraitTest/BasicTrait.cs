using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TraitTest
{
    //choose Group By option in test explorer
    public class BasicTrait
    {
        [Fact]
        [Trait("Release 1", "Category")]
        public void Test1()
        {

        }
    }
}
