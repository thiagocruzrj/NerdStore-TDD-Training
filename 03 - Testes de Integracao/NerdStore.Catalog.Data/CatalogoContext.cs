using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public Task<bool> Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}