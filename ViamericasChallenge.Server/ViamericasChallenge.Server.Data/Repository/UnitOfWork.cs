using System;
using ViamericasChallenge.Server.Data.Models;

namespace ViamericasChallenge.Server.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViamericasChallengeContext _context;

        private GenericRepository<Agency> agencia;
        private GenericRepository<City> city;
        private GenericRepository<State> state;
        private GenericRepository<Status> status;

        public UnitOfWork(ViamericasChallengeContext contexto)
        {
            _context = contexto;
        }

        public UnitOfWork()
        {
            _context = new ViamericasChallengeContext();
        }

        public GenericRepository<Agency> AgencyRepository
        {
            get
            {
                if (agencia == null)
                {
                    agencia = new GenericRepository<Agency>(_context);
                }
                return agencia;
            }
        }

        public GenericRepository<City> CityRepository
        {
            get
            {
                if (city == null)
                {
                    city = new GenericRepository<City>(_context);
                }
                return city;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {
                if (status == null)
                {
                    status = new GenericRepository<Status>(_context);
                }
                return status;
            }
        }


        public GenericRepository<State> StateRepository
        {
            get
            {
                if (state == null)
                {
                    state = new GenericRepository<State>(_context);
                }
                return state;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
