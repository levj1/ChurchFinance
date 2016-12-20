using ChurchFinanceSite.Models;
using ChurchFinanceSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.Controllers
{
    public class DonationController : Controller
    {
        List<Donation> donations = new List<Donation>();
        DonationViewModel donationVM = new DonationViewModel();
        // GET: Donation
        public ActionResult Index()
        {
            donations.Add(new Donation {ID = 1, GiverID = 1, Amount = 100.45M, DonationDate = Convert.ToDateTime("2016-09-19"), DonationType = DonationType.Offering});
            donations.Add(new Donation { ID = 2, GiverID = 1, Amount = 100.45M, DonationDate = Convert.ToDateTime("2016-09-19"), DonationType = DonationType.Offering });
            donations.Add(new Donation { ID = 3, GiverID = 1, Amount = 98.45M, DonationDate = Convert.ToDateTime("2016-10-19"), DonationType = DonationType.Tithe });
            donations.Add(new Donation { ID = 4, GiverID = 3, Amount = 9.0M, DonationDate = Convert.ToDateTime("2016-11-09"), DonationType = DonationType.Mission });
            donations.Add(new Donation { ID = 5, GiverID = 2, Amount = 10.00M, DonationDate = Convert.ToDateTime("2016-12-09"), DonationType = DonationType.Offering });
            donations.Add(new Donation { ID = 6, GiverID = 2, Amount = 140.00M, DonationDate = Convert.ToDateTime("2016-12-09"), DonationType = DonationType.Tithe });

            var givers = new List<Giver>
            {
                new Giver { ID = 1, FirstName = "James", LastName = "Leveille"},
                new Giver { ID = 2, FirstName = "Emma", LastName = "Jean Pierre"},
                new Giver { ID = 3, FirstName = "James", LastName = "Leveille"}
            };

            donations.Add(new Donation { GiverID = 3, Amount = 12.45M, DonationDate = Convert.ToDateTime("2016-09-19"), DonationType = DonationType.Offering });
            donations.Add(new Donation { GiverID = 3, Amount = 88.45M, DonationDate = Convert.ToDateTime("2016-10-19"), DonationType = DonationType.Tithe });
           
            donationVM = new DonationViewModel
            {
                Givers = givers,
                Donations = donations
            };
            return View(donationVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Donation donation)
        {
            donations.Add(donation);
            return View();
        }
        public ActionResult Edit(int donationId, int giverId)
        {
            return Content(string.Format("Donationid = {0} - GiverId = {1}", donationId, giverId));
        }
    }
}