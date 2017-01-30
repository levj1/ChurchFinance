using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.ViewModels
{
    public class DonationFormViewModel
    {
        public Donation Donation { get; set; }
        public IEnumerable<DonationType> DonationType { get; set; }
        public IEnumerable<Giver> Giver { get; set; }
    }
}