using System.ComponentModel.DataAnnotations;

namespace ChurchFinanceSite.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string ApplicationUserId { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(30)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(30)]
        public string AddressLine2 { get; set; }

        [StringLength(30)]
        public string City { get; set; }
        
        [StringLength(30)]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10)]
        public string ZipCode { get; set; }
    }
}

