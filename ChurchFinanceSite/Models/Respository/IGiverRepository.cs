using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchFinanceSite.Models.Respository
{
    interface IGiverRepository
    {
        IEnumerable<Giver> GetGivers();
        Giver GetGiver();
        void UpdateGiver();
        void DeleteGiver();
        void Save();
    }
}
