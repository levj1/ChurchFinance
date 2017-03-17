using AutoMapper;
using ChurchFinanceSite.Models;
using ChurchFinanceSite.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceSite.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Giver, GiverDto>();
            Mapper.CreateMap<GiverDto, Giver>();
        }
    }
}