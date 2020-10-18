using System.Threading.Tasks;
using Features.Tests;
using NerdStore.WebApp.MVC;
using NerdStore.WebApp.Tests.Config;
using Xunit;

namespace NerdStore.WebApp.Tests
{
    public class UsuarioTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _testsFixture;

        public UsuarioTests(IntegrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Realizar cadastro com sucesso"), TestPriority(1)]
        [Trait("Categoria", "Integração Web - Usuário")]
        public async Task Usuario_RealizarCadastro_DeveExecutarComSucesso()
        {
            // Arrange
            // Act 
            // Assert
        }
    }
}