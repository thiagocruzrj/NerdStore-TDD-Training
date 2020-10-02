using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Domain;
using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Application.Tests.Pedidos
{
    public class AdicionarItemPedidoCommandTests
    {
        [Fact(DisplayName = "Adicionar Item Command Valido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_CommandoEstaValido_DevePassarNaValidacao()
        {
            // Arrange
            var command = new AdicionarItemPedidoCommand(Guid.NewGuid(), Guid.NewGuid(), "ProdutoTeste", 2, 100);

            // Act
            var result = command.EhValido();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Item Command Inalido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_CommandoEstaInalido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var command = new AdicionarItemPedidoCommand(Guid.Empty, Guid.Empty, "", 0, 0);

            // Act
            var result = command.EhValido();

            // Assert
            Assert.False(result);
            Assert.Contains(AdicionarItemPedidoValidation.IdClienteErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.IdProdutoErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.NomeErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.QtdMinErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.ValorErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Adicionar Item Command unidades acima do permitido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_CommandoUnidadesSuperiorAoPermitido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var command = new AdicionarItemPedidoCommand(Guid.NewGuid(), Guid.NewGuid(), "ProdutoTeste", Pedido.MAX_UNIDADES_ITEM + 1, 100);

            // Act
            var result = command.EhValido();

            // Assert
            Assert.False(result);
            Assert.Contains(AdicionarItemPedidoValidation.QtdMaxErroMsg, command.ValidationResult.Errors.Select(c => c.ErrorMessage));
        }
    }
}