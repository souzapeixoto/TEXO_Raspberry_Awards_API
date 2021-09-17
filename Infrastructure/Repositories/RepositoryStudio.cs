
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryStudio : RepositoryBase<Studio>, IRepositoryStudio
    {
        public RepositoryStudio(ApplicationDbContext context)
            : base(context)
        {
            
        }

        public Studio GetByName(string name)
        {
            return Context.Studios.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public override ICollection<Studio> GetAll()
        {
            return Context.Studios.Include(x => x.Movies).AsNoTracking().ToList();
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
