using System.ComponentModel.DataAnnotations;

namespace ChurchFinanceSite.Models
{
    public class Giver
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [MaxLength(30)]
        public string Middle { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public int AddressId { get; set; }
        public string AppUserId { get; set; }

        public string FullName {
            get
            {
                return FirstName + " " + Middle + " " + LastName;
            }
        }
    }
}