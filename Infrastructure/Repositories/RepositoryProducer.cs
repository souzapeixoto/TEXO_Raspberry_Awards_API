
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryProducer : RepositoryBase<Producer>, IRepositoryProducer
    {
        public RepositoryProducer(ApplicationDbContext context)
            : base(context)
        {
            
        }
        public override ICollection<Producer> GetAll()
        {
            return Context.Producers.Include(x => x.Movies).AsNoTracking().ToList();
        }

        public Producer GetByName(string name)
        {
            return Context.Producers.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        void IDisposable.Dispose()
        {
            if (Context != null)
            {
                ((IDisposable)Context).Dispose();
            }
        }
    }
}
