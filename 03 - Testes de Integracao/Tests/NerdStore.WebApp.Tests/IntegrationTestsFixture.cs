using NerdStore.WebApp.MVC;
using System;
using Xunit;

namespace NerdStore.WebApp.Tests
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupWebTests>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>> { }

    public class IntegrationTestsFixture<IStartup> : IDisposable where IStartup : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}