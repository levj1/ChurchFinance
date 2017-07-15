using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Controllers.Repository
{
    interface IGiverRepository: IDisposable
    {
        IEnumerable<Giver> GetGivers();
        Giver GetGiverByID(int id);
        void InsertGiver(Giver giver);
        void DeleteGiver(int giverID);
        void UpdateGiver(Giver giver);
        void Save();
    }
}