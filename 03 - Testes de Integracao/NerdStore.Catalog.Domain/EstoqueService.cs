using MediatR;
using NerdStore.Core.DomainObjects;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly Mediator _mediator;

        public EstoqueService(IProdutoRepository produtoRepository, Mediator mediator)
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            if (!await DebitarItemEstoque(produtoId, quantidade)) return false;
            return await _produtoRepository.UnitOfWork.Commit();
        }

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if(!produto.PossuiEstoque(quantidade))
            {
                await _mediator.Publish(new DomainNotification("Estoque", $"Produto - {produto.Nome} sem estoque"));
                return false;
            }

            produto.DebitarEstoque(quantidade);
            _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            if (!await ReporEstoque(produtoId, quantidade)) return false;
            return await _produtoRepository.UnitOfWork.Commit();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}