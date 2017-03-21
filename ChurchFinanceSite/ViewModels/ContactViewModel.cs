using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.ViewModels
{
    public class ContactViewModel
    {
        public ContactEmail ContactEmail { get; set; }


        public string FullName
        {
            get
            {
                return ContactEmail.FirstName + " " + ContactEmail.LastName;
            }
        }
        public bool IsValidEmail(string email)
        {
            bool valid = false;
            if (email.IndexOf('.') > 0 && email.IndexOf('@') > 0)
            {
                valid = true;
            }
            return valid;
        }
    }

}