using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Test.Decorators
{
    [TestFixture]
    class SequentialParameterValue
    {
        //MyTest(1, "A")
        //MyTest(2, "B")
        //MyTest(3, null)
        [Test, Sequential]
        public void SequentialTest([Values(1, 2, 3)] int x, [Values("A", "B")] string s)
        {

        }

        [Test, Pairwise]
        public void PairWiseTest([Values("a", "b", "c","d")] string a,
                           [Values("+", "-","*")] string b,
                           [Values("x", "y")] string c)
        {
            Console.WriteLine("{0} {1} {2}", a, b, c);
        }

    }
}
