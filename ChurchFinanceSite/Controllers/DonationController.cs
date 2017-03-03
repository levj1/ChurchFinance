﻿using ChurchFinanceSite.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using ChurchFinanceSite.ViewModels;
using System.Collections.Generic;

namespace ChurchFinanceSite.Controllers
{
    public class DonationController : Controller
    {
        private ApplicationDbContext _context;
        public DonationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Donation
        public ActionResult Index()
        {
            var donations = _context.Donations.Include(x => x.Giver).Include(x => x.DonationType);
            return View(donations);
        }

        public ActionResult Detail(int id)
        {
            var donation = _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).SingleOrDefault(c => c.ID == id);
            if (donation == null)
                return HttpNotFound();
            return View(donation);
        }

        public ActionResult DonationForm()
        {
            var viewModel = new DonationFormViewModel
            {
                DonationTypes = GetDonationTypes(),
                Givers = GetGivers()

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DonationForm(DonationFormViewModel donationVM)
        {
            if (ModelState.IsValid)
            {
                //_context.Donations.Add(donation);
                //_context.SaveChanges();
                return RedirectToAction("Index", "Donation");
            }
            return View();
        }

        
        public ActionResult Create()
        {
            var donationTypeList = _context.DonationType.ToList();
            var giverList = _context.Givers.ToList();
            var viewModel = new DonationFormViewModel
            {
                Giver = giverList,
                DonationType = donationTypeList
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            _context.Donations.SingleOrDefault(x => x.ID == id);

            return View();
        }

        private IEnumerable<SelectListItem> GetDonationTypes()
        {
            var donationTypes = _context.DonationType.Select(
                x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                });
            return new SelectList(donationTypes, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetGivers()
        {
            var givers = _context.Givers.Select(
                x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.FirstName + " " + x.Middle + " " + x.LastName
                });
            return new SelectList(givers, "Value", "Text");
        }

    }
}