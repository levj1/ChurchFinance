using ChurchFinanceSite.Models;
using ChurchFinanceSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            var donations = new List<Donation>
            {
                new Donation { Amount = 100.45M, DonationDate = Convert.ToDateTime("2016-09-19"), DonationType = DonationType.Offering },
                new Donation { Amount = 98.45M, DonationDate = Convert.ToDateTime("2016-10-19"), DonationType = DonationType.Tithe },
                new Donation { Amount = 10.00M, DonationDate = Convert.ToDateTime("2016-12-09"), DonationType = DonationType.Offering }

            };

            var donationVM = new DonationViewModel
            {
                Donations = donations
            };
            return View(donationVM);
        }
    }
}