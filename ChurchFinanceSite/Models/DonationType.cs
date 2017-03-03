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
}