using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoItemTests
    {
        [Fact(DisplayName = "Adicionar Item Pedido acima do permitido")]
        [Trait("Categoria", "Pedido Item Tests")]
        public void AdicionarItemPedido_ItemAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", Pedido.MAX_UNIDADES_ITEM + 1, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => pedido.AdicionarItem(pedidoItem));
        }

        [Fact(DisplayName = "Adicionar Item Pedido abaixo do permitido")]
        [Trait("Categoria", "Pedido Item Tests")]
        public void AdicionarItemPedido_ItemAbaixoDoPermitido_DeveRetornarException()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", Pedido.MIN_UNIDADES_ITEM - 1, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => pedido.AdicionarItem(pedidoItem));
        }
    }
}