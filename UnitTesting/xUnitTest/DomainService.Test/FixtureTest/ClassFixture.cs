using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainService.Test.FixtureTest
{
    public class ClassFixture : IClassFixture<DataSourceConnection>
    {
        static DataSourceConnection databaseConectionCache;
        private readonly DataSourceConnection databaseConnection;

        public ClassFixture(DataSourceConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
            if (databaseConectionCache == null)
                databaseConectionCache = databaseConnection;
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(databaseConectionCache, databaseConnection);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(databaseConectionCache, databaseConnection);
        }
    }


    public class DataSourceConnection : IDisposable
    {

        public string ConnectionId { get; set; } = Guid.NewGuid().ToString();

        public void Dispose()
        {

        }
    }
}
