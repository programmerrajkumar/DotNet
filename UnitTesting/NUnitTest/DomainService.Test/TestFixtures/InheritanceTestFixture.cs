using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestFixtures
{
    [TestFixture]
    public abstract class BaseClass
    {
        // ...
    }

    class InheritanceTestFixture : BaseClass
    {
        [Test]
        public void TestFromDerived()
        {
            
        }
    }

}
