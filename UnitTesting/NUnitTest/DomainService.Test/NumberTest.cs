using NUnit.Framework;

namespace DomainService.Test
{
    public class NumberTest
    {
        Number number;
        [SetUp]
        public void Setup()
        {
            number = new Number();
        }

        [Test]
        public void Test1()
        {
            var isEven = number.IsEven(22);
            Assert.AreEqual(true, isEven);
        }
    }
}