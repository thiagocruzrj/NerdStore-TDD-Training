using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Adicionar Item Novo Pedido")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "ProdutoTeste", 5, 100);

            // Act
            pedido.AdicionarItem(pedidoItem);

            // Assert
            Assert.Equal(500, pedido.ValorTotal);
        }

        [Fact(DisplayName = "Adicionar Item Pedido Existente")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValores()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", 5, 100);
            pedido.AdicionarItem(pedidoItem);
            var pedidoItem2 = new PedidoItem(pedidoId, "ProdutoTeste", 5, 100);

            // Act
            pedido.AdicionarItem(pedidoItem2);

            // Assert
            Assert.Equal(1000, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItens.Count);
            Assert.Equal(10, pedido.PedidoItens.FirstOrDefault(p => p.ProdutoId == pedidoId).Quantidade);
        }

        [Fact(DisplayName = "Adicionar Item Pedido acima de 15")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_ItemAcimaDe15Unidades_DeveRetornarException()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", 16, 100);

            // Act & Assert
            pedido.AdicionarItem(pedidoItem);
            Assert.Throws<DomainException>(() => pedido.AdicionarItem(pedidoItem));
        }
    }
}