using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.Models.DTOs
{
    public class GiverDto
    {

        public int ID { get; set; }
                
        [StringLength(30)]
        public string FirstName { get; set; }
                
        [MaxLength(30)]
        public string Middle { get; set; }
                
        [StringLength(30)]
        public string LastName { get; set; }
        
        public int AddressId { get; set; }
    }
}