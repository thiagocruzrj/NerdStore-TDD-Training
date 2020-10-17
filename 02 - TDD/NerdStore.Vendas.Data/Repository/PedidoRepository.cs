using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly VendasContext _context;

        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }
        
        public IUnitOfWork UnitOfWork => _context;

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId) =>
            await _context.PedidoItems.FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);

        public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId) =>
            await _context.Pedidos.AsNoTracking().Where(p => p.ClienteId == clienteId).ToListAsync();

        public Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}