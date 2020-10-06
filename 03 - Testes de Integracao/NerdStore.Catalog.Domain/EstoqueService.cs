using MediatR;
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
            if (!await DebitarEstoque(produtoId, quantidade)) return false;
            return await _produtoRepository.UnitOfWork.Commit();
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