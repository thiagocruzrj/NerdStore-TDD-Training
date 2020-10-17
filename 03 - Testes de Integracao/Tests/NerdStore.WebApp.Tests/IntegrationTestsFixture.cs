using NerdStore.WebApp.MVC;
using NerdStore.WebApp.Tests.Config;
using System;
using System.Net.Http;
using Xunit;

namespace NerdStore.WebApp.Tests
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupWebTests>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>> { }

    public class IntegrationTestsFixture<IStartup> : IDisposable where IStartup : class
    {
        public readonly LojaAppFactory<IStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            Factory = new LojaAppFactory<IStartup>();
            Client = Factory.CreateClient();
        }

        public void Dispose() 
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}