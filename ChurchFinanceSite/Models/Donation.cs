using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models
{
    public enum DonationType
    {
        Tithe,
        Offering,
        Donation,
        Pledge,
        Mission,
        Other
    }
    public class Donation
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public DonationType DonationType { get; set; }
        //public Giver Giver { get; set; }
        public int GiverID { get; set; }
    }
}