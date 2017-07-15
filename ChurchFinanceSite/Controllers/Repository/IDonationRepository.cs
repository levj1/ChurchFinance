using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Controllers.Repository
{
    public interface IDonationRepository: IDisposable
    {
        IEnumerable<Donation> GetDonations();
        Donation GetDonationByID(int id);
        void InsertDonation(Donation donation);
        void DeleteDonation(int donationID);
        void UpdateDonation(Donation donation);
        void Save();
    }
}