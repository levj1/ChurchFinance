using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.ViewModels
{
    public class EditDonation
    {
        public Donation Donation { get; set; }
        public Giver Giver { get; set; }

        [Required]
        [Display(Name = "Donation Type")]
        public int SelectedDonationTypeId { get; set; }
        public IEnumerable<SelectListItem> SelectListDonationTypes { get; set; }

        public EditDonation()
        {
        }
    }
}