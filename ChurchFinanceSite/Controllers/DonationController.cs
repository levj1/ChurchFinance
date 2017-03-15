using ChurchFinanceSite.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using ChurchFinanceSite.ViewModels;
using System.Collections.Generic;
using System;

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
            var donations = _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).ToList();
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
                donationVM.Donation.DonationDate = DateTime.Now;
                donationVM.Donation.DonationTypeID = donationVM.SelectedDonationTypeId;
                donationVM.Donation.GiverID = donationVM.SelectedGiverId;

                _context.Donations.Add(donationVM.Donation);
                _context.SaveChanges();
                return RedirectToAction("Index", "Donation");
            }
            var viewModel = new DonationFormViewModel
            {
                SelectedDonationTypeId = donationVM.SelectedDonationTypeId,
                SelectedGiverId = donationVM.SelectedGiverId,
                DonationTypes = GetDonationTypes(),
                Givers = GetGivers()

            };
            return View("DonationForm", viewModel);
        }

        
        public ActionResult Edit(int? id)
        {
            var donation = _context.Donations.Where(x => x.ID == id).Include(x => x.Giver).Include(x => x.DonationType).SingleOrDefault();
            if (id == null || donation == null)
                return HttpNotFound();

            return View(donation);
        }

        [HttpPost]
        public ActionResult Edit(Donation donation)
        {
            if (ModelState.IsValid)
            {
                // update db
                RedirectToAction("Index");
            }
            return Edit(donation);
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