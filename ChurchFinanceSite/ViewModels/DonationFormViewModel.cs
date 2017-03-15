using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.ViewModels
{
    public class DonationFormViewModel
    {
        public Donation Donation { get; set; }
        
        public List<DonationType> DonationType { get; set; }
        public List<Giver> Giver { get; set; }

        [Display(Name = "Donation Type")]
        public int SelectedDonationTypeId { get; set; }
        public IEnumerable<SelectListItem> DonationTypes { get; set; }

        [Display(Name = "Giver's Name")]
        public int SelectedGiverId { get; set; }
        public IEnumerable<SelectListItem> Givers { get; set; }

        public DonationFormViewModel()
        {
        }
    }
}