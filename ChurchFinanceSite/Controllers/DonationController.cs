using ChurchFinanceSite.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using ChurchFinanceSite.ViewModels;
using System.Collections.Generic;
using System;
using System.Net;

namespace ChurchFinanceSite.Controllers
{
    [Authorize(Roles = RoleName.CanManageFinance)]
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

        [AllowAnonymous]
        // GET: Donation
        public ActionResult Index()
        {
            var donations = _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).ToList();
            var userId = User.Identity.Name;
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == userId);
            if(User.IsInRole(RoleName.CanManageFinance))
                return View("Index", donations);

            return View("IndexReadOnly", donations);
        }

        [AllowAnonymous]
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
                donationVM.Donation.DonationUpdatedDate = DateTime.Now;
                donationVM.Donation.DonationTypeID = donationVM.SelectedDonationTypeId;
                donationVM.Donation.GiverID = donationVM.SelectedGiverId;

                try
                {
                    _context.Donations.Add(donationVM.Donation);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
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
            var donation = _context.Donations.Where(x => x.ID == id).SingleOrDefault();
            if (id == null || donation == null)
                return HttpNotFound();


            var donationVM = new EditDonation
            {
                SelectedDonationTypeId = donation.DonationTypeID,
                Donation = donation,
                Giver = _context.Givers.Where(x => x.ID == donation.GiverID).SingleOrDefault(),
                SelectListDonationTypes = GetDonationTypes()
            };
            return View(donationVM);
        }

        [HttpPost]
        public ActionResult Edit(EditDonation donationVM)
        {
            if (ModelState.IsValid)
            {
                if (donationVM.Donation.Amount == 0)
                {
                    ModelState.AddModelError(string.Empty, "Amount can't be zero.");
                }
                else
                {
                    // update db
                    var dbDonation = _context.Donations.Where(x => x.ID == donationVM.Donation.ID).SingleOrDefault();
                    dbDonation.Amount = donationVM.Donation.Amount;
                    donationVM.Donation.DonationUpdatedDate = DateTime.Now;
                    dbDonation.DonationUpdatedDate = donationVM.Donation.DonationUpdatedDate;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            var EditDonationVM = new EditDonation
            {
                SelectedDonationTypeId = donationVM.Donation.DonationTypeID,
                Giver = _context.Givers.Where(x => x.ID == donationVM.Donation.GiverID).SingleOrDefault(),
                Donation = donationVM.Donation,
                SelectListDonationTypes = GetDonationTypes()
            };
            return View(EditDonationVM);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var donationToDelete = _context.Donations.FirstOrDefault(x => x.ID == id);

            if (donationToDelete == null)
                return HttpNotFound();

            try
            {
                _context.Donations.Remove(donationToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
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