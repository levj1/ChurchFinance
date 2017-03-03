using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.ViewModels
{
    public class DonationViewModel
    {
        public List<Giver> Givers { get; set; }
        public List<Donation> Donations { get; set; }
    }
}