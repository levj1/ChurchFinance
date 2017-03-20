using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models.DTOs
{
    public class DonationDto
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        
        public DateTime DonationDate { get; set; }

        public DateTime DonationUpdatedDate { get; set; }

        public int DonationTypeID { get; set; }
        
        public int GiverID { get; set; }
    }
}