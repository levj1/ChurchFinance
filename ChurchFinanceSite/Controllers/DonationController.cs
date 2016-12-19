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
                new Donation { GiverID = 1, Amount = 100.45M, DonationDate = Convert.ToDateTime("2016-09-19"), DonationType = DonationType.Offering },
                new Donation { GiverID = 1, Amount = 98.45M, DonationDate = Convert.ToDateTime("2016-10-19"), DonationType = DonationType.Tithe },
                new Donation { GiverID = 2, Amount = 10.00M, DonationDate = Convert.ToDateTime("2016-12-09"), DonationType = DonationType.Offering },
                new Donation { GiverID = 2, Amount = 140.00M, DonationDate = Convert.ToDateTime("2016-12-09"), DonationType = DonationType.Tithe }
            };

            var givers = new List<Giver>
            {
                new Giver { ID = 1, FirstName = "James", LastName = "Leveille"},
                new Giver { ID = 2, FirstName = "Emma", LastName = "Jean Pierre"}
            };

            var donationVM = new DonationViewModel
            {
                Givers = givers,
                Donations = donations
            };
            return View(donationVM);
        }
    }
}