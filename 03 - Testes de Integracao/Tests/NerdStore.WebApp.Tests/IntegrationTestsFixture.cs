using System;

namespace NerdStore.WebApp.Tests
{
    public class IntegrationTestsFixture<IStartup> : IDisposable where IStartup : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}