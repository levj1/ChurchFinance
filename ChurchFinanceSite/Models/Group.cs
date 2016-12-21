using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime GroupDateCreated { get; set; }

        public Group()
        {
            GroupDateCreated = DateTime.Now;
        }
    }
}