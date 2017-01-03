using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models
{
    public class Giver
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}