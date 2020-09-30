using System;
using ViamericasChallenge.Server.Data.Models;

namespace ViamericasChallenge.Server.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Agency> AgencyRepository { get; }
        GenericRepository<City> CityRepository { get; }
        GenericRepository<State> StateRepository { get; }
        GenericRepository<Status> StatusRepository { get; }
        void Save();
    }
}
