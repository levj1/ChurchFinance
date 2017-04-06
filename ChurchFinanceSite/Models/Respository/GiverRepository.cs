using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models.Respository
{
    interface IGiverRepository: IDisposable
    {
        IEnumerable<Giver> GetGivers();
        Giver GetGiver();
        void UpdateGiver();
        void DeleteGiver();
        void Save();
    }
    public class GiverRepository: IGiverRepository
    {
        ApplicationDbContext _context;
        public GiverRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteGiver()
        {
            throw new NotImplementedException();
        }
        
        public Giver GetGiver()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giver> GetGivers()
        {
            var givers = _context.Givers;
            return givers.ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateGiver()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
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