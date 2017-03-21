using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models
{
    public class ContactEmail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Please leave us a comment")]
        public string Comment { get; set; }
    }
}