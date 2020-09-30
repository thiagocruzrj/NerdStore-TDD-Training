using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.Vendas.Domain
{
    public class Pedido
    {
        public Pedido()
        {
            _pedidoItens = new List<PedidoItem>();
        }

        private readonly List<PedidoItem> _pedidoItens;

        public decimal ValorTotal { get; private set; }
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens;

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            if(_pedidoItens.Any(p => p.ProdutoId == pedidoItem.ProdutoId))
            {
                var itemExistente = _pedidoItens.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);
                itemExistente.AdicionarUnidades(pedidoItem.Quantidade);

                pedidoItem = itemExistente;

                _pedidoItens.Remove(itemExistente);
            }

            _pedidoItens.Add(pedidoItem);
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItens.Sum(i => i.CalcularValor());
        }
    }

    public enum PedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 4,
        Entregue = 5,
        Cancelado = 6
    }

    public class PedidoItem
    {
        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal decimal CalcularValor()
        {
            return ValorUnitario * Quantidade;
        }
    }
}