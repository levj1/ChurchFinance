using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChurchFinanceSite.Models;
using System.Data.Entity;

namespace ChurchFinanceSite.Controllers.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private ApplicationDbContext _context;
        private bool disposed = false;
        public DonationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Donation> GetDonations()
        {
            return _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).ToList();
        }
        public Donation GetDonationByID(int id)
        {
            return _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).SingleOrDefault(c => c.ID == id);
        }

        public void InsertDonation(Donation donation)
        {
            _context.Donations.Add(donation);
        }
        public void UpdateDonation(Donation donation)
        {
            // simple way to update
            //_context.Entry(donation).State = EntityState.Modified;
            Donation donationFromDb = _context.Donations.Find(donation.ID);
            donationFromDb.Amount = donation.Amount;
            donationFromDb.DonationDate = donation.DonationDate;
            donationFromDb.DonationType = donation.DonationType;
            donationFromDb.DonationTypeID = donation.DonationTypeID;
            donationFromDb.DonationUpdatedDate = DateTime.Now;
            donationFromDb.GiverID = donation.GiverID;
            donationFromDb.Giver = donation.Giver;
        }
        public void DeleteDonation(int donationID)
        {
            Donation donDelete = _context.Donations.Find(donationID);
            _context.Donations.Remove(donDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
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