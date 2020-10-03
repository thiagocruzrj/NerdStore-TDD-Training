using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using System;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    }
}