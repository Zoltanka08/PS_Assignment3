using Repository.DatabaseContext;
using System;

namespace ElectroShopRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        OnlineClinicEntities DbContext { get; }
        void SaveChanges();
    }
}
