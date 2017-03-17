using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChurchFinanceSite.Controllers.Api
{
    public class DonationsController : ApiController
    {
        private ApplicationDbContext _context;
        public DonationsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get api/Donations
        public IEnumerable<Donation> GetDonations()
        {
            return _context.Donations.ToList();
        }

        // Post 
        [HttpPost]
        public Donation CreateDonation(Donation donation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return donation;
        }

        // Put 
        public void UpdateDonation(int id, Donation donation)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbDonation = _context.Donations.FirstOrDefault(x => x.ID == id);
            if (donation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbDonation.Amount = donation.Amount;
            dbDonation.DonationDate = donation.DonationDate;
            dbDonation.DonationTypeID = donation.DonationTypeID;
            dbDonation.GiverID = donation.GiverID;

            _context.SaveChanges();
        }

        public void DeleteDonation(int id)
        {
            var donationToDelete = _context.Donations.FirstOrDefault(x => x.ID == id);
            if (donationToDelete == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Donations.Remove(donationToDelete);
            _context.SaveChanges();
        }
    }
}
