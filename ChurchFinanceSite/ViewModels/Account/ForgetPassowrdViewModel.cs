using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchFinanceSite.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}