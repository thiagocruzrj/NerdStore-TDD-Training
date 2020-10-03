using NerdStore.Core.DomainObjects;
using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoTests
    {
        private readonly Pedido _pedido;
        public PedidoTests()
        {
            _pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
        }

        [Fact(DisplayName = "Adicionar Item Novo Pedido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            // Arrange
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "ProdutoTeste", 5, 100);

            // Act
            _pedido.AdicionarItem(pedidoItem);

            // Assert
            Assert.Equal(500, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Adicionar Item Pedido Existente")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValores()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", 5, 100);
            _pedido.AdicionarItem(pedidoItem);
            var pedidoItem2 = new PedidoItem(pedidoId, "ProdutoTeste", 5, 100);

            // Act
            _pedido.AdicionarItem(pedidoItem2);

            // Assert
            Assert.Equal(1000, _pedido.ValorTotal);
            Assert.Equal(1, _pedido.PedidoItens.Count);
            Assert.Equal(10, _pedido.PedidoItens.FirstOrDefault(p => p.ProdutoId == pedidoId).Quantidade);
        }

        [Fact(DisplayName = "Adicionar Item Pedido acima do permitido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AdicionarItemPedido_UnidadesItemAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM + 1, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AdicionarItem(pedidoItem));
        }

        [Fact(DisplayName = "Adicionar Item Pedido existente acima do permitido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AdicionarItemPedido_ItemExistenteSomarUnidadesAcimaDoPermitido_DeveRetornarUmaException()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(pedidoId, "ProdutoTeste", 5, 100);
            _pedido.AdicionarItem(pedidoItem);
            var pedidoItem2 = new PedidoItem(pedidoId, "ProdutoTeste", Pedido.MAX_UNIDADES_ITEM, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AdicionarItem(pedidoItem2));
        }

        [Fact(DisplayName = "Atualizar Item Pedido Inexistente")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItemNaoExisteNaLista_DeveRetornarException()
        {
            // Arrange
            var pedidoItemAtualizado = new PedidoItem(Guid.NewGuid(), "Pedido teste", 5, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AtualizarItem(pedidoItemAtualizado));
        }

        [Fact(DisplayName = "Atualizar Item Pedido Valido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItemValido_DeveAtualizarQuantidade()
        {
            // Arrange
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Pedido teste", 5, 100);
            _pedido.AdicionarItem(pedidoItem);
            var pedidoItemAtualizado = new PedidoItem(produtoId, "Pedido teste", 10, 100);
            var novaQuantidade = pedidoItemAtualizado.Quantidade;

            // Act
            _pedido.AtualizarItem(pedidoItemAtualizado);

            // Act & Assert
            Assert.Equal(novaQuantidade, _pedido.PedidoItens.FirstOrDefault(p => p.ProdutoId == produtoId).Quantidade);
        }

        [Fact(DisplayName = "Atualizar Item Pedido Validar Total")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AtualizarItemPedido_PedidoComProdutosDiferentes_DeveAtualizarValorTotal()
        {
            // Arrange
            var produtoId = Guid.NewGuid();
            var pedidoItemExistente1 = new PedidoItem(Guid.NewGuid(), "Pedido xpto", 5, 100);
            var pedidoItemExistente2 = new PedidoItem(produtoId, "Pedido teste", 10, 100);
            _pedido.AdicionarItem(pedidoItemExistente1);
            _pedido.AdicionarItem(pedidoItemExistente2);

            var pedidoItemAtualizado = new PedidoItem(produtoId, "Produto teste", 2, 100);
            var totalPedido = pedidoItemExistente1.Quantidade * pedidoItemExistente1.ValorUnitario +
                              pedidoItemAtualizado.Quantidade * pedidoItemAtualizado.ValorUnitario;

            // Act
            _pedido.AtualizarItem(pedidoItemAtualizado);

            // Act & Assert
            Assert.Equal(totalPedido, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Atualizar Item Pedido Quantidade acima do permitido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItemUnidadesAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var produtoId = Guid.NewGuid();
            var pedidoItemExistente1 = new PedidoItem(produtoId, "Produto Teste", 3, 15);
            _pedido.AdicionarItem(pedidoItemExistente1);

            var pedidoItemAtualizado = new PedidoItem(produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM + 1, 15);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AtualizarItem(pedidoItemAtualizado));
        }

        [Fact(DisplayName = "Remover Item Pedido Inexistente")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void RemoverItemPedido_ItemNaoExisteNaLista_DeveRetornarException()
        {
            // Arrange
            var pedidoItemRemover = new PedidoItem(Guid.NewGuid(), "Produto Teste", 3, 15);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.RemoverItem(pedidoItemRemover));
        }

        [Fact(DisplayName = "Remover Item Pedido deve calcular valor total")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void RemoverItemPedido_ItemExistente_DeveAtualizarValorTotal()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 3, 15);
            var pedidoItem2 = new PedidoItem(pedidoId, "Produto Teste", 7, 15);
            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var totalPedido = pedidoItem2.Quantidade * pedidoItem2.ValorUnitario;

            // Act
            _pedido.RemoverItem(pedidoItem1);

            // Act & Assert
            Assert.Equal(totalPedido, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Valido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_VoucherValido_DeveRetornarSemErros()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Aplicar Voucher Invalido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_VoucherInvalido_DeveRetornarComErros()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(-1), true, false);

            // Act
            var result = _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Aplicar Voucher Tipo Valor Desconto")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_VoucherTipoValorDesconto_DeveDescontarValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 3, 15);
            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 7, 15);
            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(15), true, false);

            var valorComDesconto = _pedido.ValorTotal - voucher.ValorDesconto;

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(valorComDesconto, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Tipo Porcentagem Desconto")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_rVoucherTipoPorcentagemDesconto_DeveDescontarValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 3, 15);
            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 7, 15);
            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var voucher = new Voucher("PROMO-15-PORCENTO", 15, null, TipoDescontoVoucher.Porcentagem, 1, DateTime.Now.AddDays(15), true, false);

            var valorDesconto = (_pedido.ValorTotal * voucher.PercentualDesconto) / 100;
            var valorComDesconto = _pedido.ValorTotal - valorDesconto;

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(valorComDesconto, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Tipo Valor excede valor total")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_VoucherTipoValorDesconto_PedidoDeveTerValorZero()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 10, 10);
            _pedido.AdicionarItem(pedidoItem1);

            var voucher = new Voucher("PROMO-110-110OFF", null, 110, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(0, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher recalcular desconto na modificação do pedido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_ModificarItensPedido_DeveCalcularDescontoValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 2, 100);
            _pedido.AdicionarItem(pedidoItem1);

            var voucher = new Voucher("PROMO-110-110OFF", null, 110, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(15), true, false);
            _pedido.AplicarVoucher(voucher);

            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto xpto", 2, 100);

            // Act
            _pedido.AdicionarItem(pedidoItem2);

            // Assert
            var totalEsperado = _pedido.PedidoItens.Sum(i => i.Quantidade * i.ValorUnitario) - voucher.ValorDesconto;

            Assert.Equal(totalEsperado, _pedido.ValorTotal);
        }
    }
}