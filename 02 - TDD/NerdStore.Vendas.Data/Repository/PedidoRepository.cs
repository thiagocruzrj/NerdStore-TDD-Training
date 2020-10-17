﻿using NerdStore.Core.Data;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }
    }
}