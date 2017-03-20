using AutoMapper;
using ChurchFinanceSite.Models;
using ChurchFinanceSite.Models.DTOs;
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
        public IEnumerable<DonationDto> GetDonations()
        {
            return _context.Donations.ToList().Select(Mapper.Map<Donation, DonationDto>);
        }

        public IHttpActionResult GetDonation(int? id)
        {
            var donation = _context.Donations.Where(x => x.ID == id).SingleOrDefault();
            if (donation == null)
                return NotFound();

            return Ok(Mapper.Map<Donation, DonationDto>(donation));
        }

        // Post 
        [HttpPost]
        public IHttpActionResult CreateDonation(DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var donation = Mapper.Map<DonationDto, Donation>(donationDto);
            _context.Donations.Add(donation);
            _context.SaveChanges();

            donationDto.ID = donation.ID;
            return Created(new Uri(Request.RequestUri + "/" + donation.ID), donationDto);
        }

        // Put 
        public void UpdateDonation(int id, DonationDto donationDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbDonation = _context.Donations.FirstOrDefault(x => x.ID == id);
            if (dbDonation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(donationDto, dbDonation);

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
