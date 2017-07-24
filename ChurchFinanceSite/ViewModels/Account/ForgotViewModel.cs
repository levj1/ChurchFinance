using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchFinanceSite.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}