using System;
using System.ComponentModel.DataAnnotations;
namespace ChurchFinanceSite.Models
{
    public class DonationType
    {
        public int ID { get; set; }
        [StringLength(75)]
        public string Name { get; set; }

        //Tithe,
        //Offering,
        //Donation,
        //Pledge,
        //Mission,
        //Other
    }
    public class Donation
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public DonationType DonationType { get; set; }
        public Giver Giver { get; set; }
        public int GiverID { get; set; }
    }
}