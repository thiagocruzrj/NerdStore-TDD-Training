﻿using NerdStore.Core.DomainObjects;
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
            // Arrange Act & Assert
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(), "ProdutoTeste", Pedido.MAX_UNIDADES_ITEM + 1, 100));
        }

        [Fact(DisplayName = "Adicionar Item Pedido abaixo do permitido")]
        [Trait("Categoria", "Pedido Item Tests")]
        public void AdicionarItemPedido_ItemAbaixoDoPermitido_DeveRetornarException()
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(), "ProdutoTeste", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }
    }
}