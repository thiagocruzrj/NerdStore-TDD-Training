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

        public Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}