﻿using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.ViewModels
{
    public class GiverFormViewModel
    {
        public Giver Giver { get; set; }
        public Address Address { get; set; }
    }
}