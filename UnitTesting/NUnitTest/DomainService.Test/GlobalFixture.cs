using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test
{
    [SetUpFixture]
    class GlobalFixture
    {

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Assert.Warn("Invoked once before any of the fixtures contained in its namespace");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Assert.Warn("Invoked after any other teardown test case in other fixtures");
        }

    }
}
