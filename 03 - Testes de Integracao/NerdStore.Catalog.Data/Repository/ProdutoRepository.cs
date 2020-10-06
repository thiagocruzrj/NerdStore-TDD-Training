using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogContext;

        public ProdutoRepository(CatalogoContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public IUnitOfWork UnitOfWork => _catalogContext;

        public void Adicionar(Produto produto)
        {
            _catalogContext.Produtos.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _catalogContext.Categorias.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _catalogContext.Produtos.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogContext.Categorias.Update(categoria);
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _catalogContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _catalogContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogContext.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _catalogContext.Produtos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _catalogContext?.Dispose();
        }
    }
}