using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain
{
    public class EstoqueService : IEstoqueService
    {
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