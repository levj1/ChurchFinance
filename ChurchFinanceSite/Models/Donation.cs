using System;
using System.ComponentModel.DataAnnotations;
namespace ChurchFinanceSite.Models
{
    public class DonationType
    {
        public int ID { get; set; }

        [StringLength(75)]
        [Display(Name = "Donation Type")]
        public string Name { get; set; }
    }
    public class Donation
    {
        public int ID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        public DonationType DonationType { get; set; }

        [Display(Name = "Donation Type")]
        public int DonationTypeID { get; set; }

        public Giver Giver { get; set; }

        [Display(Name = "Giver Name")]
        public int GiverID { get; set; }
        
    }
}