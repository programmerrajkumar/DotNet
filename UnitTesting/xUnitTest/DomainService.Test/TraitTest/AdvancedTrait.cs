﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.TraitTest
{
    [Trait("Release 2","Category")]
    public class AdvancedTrait
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}
