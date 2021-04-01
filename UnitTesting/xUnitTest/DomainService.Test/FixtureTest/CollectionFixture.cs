using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.FixtureTest
{
    //when you want to create a single test context and share it among tests in several test classes,
    //and have it cleaned up after all the tests in the test classes have finished.

    public static class LocalCache
    {
        public static DataConnection Fixture { get; set; }
    }

    [Collection("Database collection")]
    public class CollectionFixtureTest1
    {
        DataConnection fixture;

        public CollectionFixtureTest1(DataConnection fixture)
        {
            this.fixture = fixture;
            if (LocalCache.Fixture is null)
                LocalCache.Fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(LocalCache.Fixture, fixture);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(LocalCache.Fixture, fixture);

        }
    }

    [Collection("Database collection")]
    public class CollectionFixtureTest2
    {
        DataConnection fixture;

        public CollectionFixtureTest2(DataConnection fixture)
        {
            this.fixture = fixture;
            if (LocalCache.Fixture is null)
                LocalCache.Fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(LocalCache.Fixture, fixture);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(LocalCache.Fixture, fixture);

        }
    }


    [CollectionDefinition("Database collection")]
    public class DataConnectionFixture : ICollectionFixture<DataConnection>
    {

    }

    public class DataConnection : IDisposable
    {

        public string ConnectionId { get; set; } = Guid.NewGuid().ToString();

        public void Dispose()
        {

        }
    }
}
