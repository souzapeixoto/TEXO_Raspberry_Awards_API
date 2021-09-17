using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryMovie : IRepositoryBase<Movie>, IDisposable
    {
    }
}
