using NerdStore.Vendas.Application.Queries.ViewModels;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Queries
{
    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}