using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        public Task AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}