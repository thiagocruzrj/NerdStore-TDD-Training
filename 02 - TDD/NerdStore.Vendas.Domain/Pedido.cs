using System;

namespace NerdStore.Vendas.Domain
{
    public class Pedido
    {
        public decimal ValorTotal { get; set; }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            ValorTotal = pedidoItem.ValorUnitario * pedidoItem.Quantidade;
        }
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

        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}