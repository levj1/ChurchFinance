using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChurchFinanceSite.Models;
using System.Data.Entity;

namespace ChurchFinanceSite.Controllers.Repository
{
    public class GiverReposistory : IGiverRepository
    {
        private ApplicationDbContext _context;
        private bool disposed;

        public GiverReposistory(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void DeleteGiver(int giverID)
        {
            Giver toDelete = _context.Givers.Find(giverID);
            _context.Givers.Remove(toDelete);
        }

        public Giver GetGiverByID(int id)
        {
            return _context.Givers.Find(id);
        }

        public IEnumerable<Giver> GetGivers()
        {
            return _context.Givers.ToList();
        }

        public void InsertGiver(Giver giver)
        {
            _context.Givers.Add(giver);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateGiver(Giver giver)
        {
            _context.Entry(giver).State = EntityState.Modified;
        }

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