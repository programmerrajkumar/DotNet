using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.TestsSetupTearDown
{
    class ParentFixture
    {
        [SetUp]
        public virtual void BaseSetup()
        {

        }

        [SetUp]
        public virtual void BaseSetup_1()
        {

        }
    }
    class InheritedSetup : ParentFixture
    {
        
        //follows normal inheritance principle
        public override void BaseSetup()
        {
            base.BaseSetup();
        }

        [Test]
        public void Add()
        {

        }
    }
}
