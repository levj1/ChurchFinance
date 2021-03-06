﻿using System;
using System.ComponentModel.DataAnnotations;
namespace ChurchFinanceSite.Models
{
    public class Donation
    {
        public int ID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime DonationUpdatedDate { get; set; }

        public DonationType DonationType { get; set; }

        [Display(Name = "Donation Type")]
        public int DonationTypeID { get; set; }

        public Giver Giver { get; set; }

        [Display(Name = "Giver Name")]
        public int GiverID { get; set; }
        
    }
}