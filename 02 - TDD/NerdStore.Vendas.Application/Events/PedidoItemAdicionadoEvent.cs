using MediatR;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public PedidoItemAdicionadoEvent(Guid clienteId, Guid pedidoId, Guid produtoId, string produtNome, decimal valorUnitario, int quantidade)
        {
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            ProdutNome = produtNome;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        public Guid ClienteId { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public string ProdutNome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}