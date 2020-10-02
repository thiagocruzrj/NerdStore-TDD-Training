using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand
    {
        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}