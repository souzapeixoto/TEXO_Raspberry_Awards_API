using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryProducer : IRepositoryBase<Producer>, IDisposable
    {
        public Producer GetByName(string name);
    }
}
