
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryMovie : RepositoryBase<Movie>, IRepositoryMovie
    {
        public RepositoryMovie(ApplicationDbContext context)
            : base(context)
        {
            
        }
        public override ICollection<Movie> GetAll()
        {
            return Context.Movies.Include(x=>x.Producers).Include(x=>x.Studios).AsNoTracking().ToList();
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
