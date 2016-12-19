using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.ViewModels
{
    public class DonationViewModel
    {
        public List<Giver> Givers { get; set; }
        public List<Donation> Donations { get; set; }
    }
}