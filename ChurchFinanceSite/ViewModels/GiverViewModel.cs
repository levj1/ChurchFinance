using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.ViewModels
{
    public class GiverViewModel
    {
        public Address Addresses { get; set; }
        public List<Giver> Givers { get; set; }

    }
}