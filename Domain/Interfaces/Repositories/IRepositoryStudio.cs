using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryStudio : IRepositoryBase<Studio>, IDisposable
    {
        public Studio GetByName(string name);
    }
}
