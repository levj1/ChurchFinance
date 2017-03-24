using AutoMapper;
using ChurchFinanceSite.Models;
using ChurchFinanceSite.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChurchFinanceSite.Controllers.Api
{
    [Authorize]
    public class GiversController : ApiController
    {
        private ApplicationDbContext _context;
        public GiversController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // Get api/givers/
        public IEnumerable<GiverDto> GetGivers()
        {
            var givers = _context.Givers.ToList().Select(Mapper.Map<Giver, GiverDto>);
            return givers;
        }


        // Get api/giver/id
        public IHttpActionResult GetGiver(int? id)
        {
            var giver = _context.Givers.Where(x => x.ID == id).SingleOrDefault();

            if (giver == null)
                return NotFound();

            return Ok(Mapper.Map<Giver, GiverDto>(giver));
        }

        // Post 
        [HttpPost]
        public IHttpActionResult CreateGiver(GiverDto giverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var giver = Mapper.Map<GiverDto, Giver>(giverDto);
            _context.Givers.Add(giver);
            _context.SaveChanges();

            giverDto.ID = giver.ID;
            return Created(new Uri(Request.RequestUri + "/" + giver.ID), giverDto);
        }

        public void UpdateGiver(int id, GiverDto giverDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var dbGiver = _context.Givers.FirstOrDefault(x => x.ID == id);
            if (dbGiver == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(giverDto, dbGiver);
            
            _context.SaveChanges();
        }

        public void DeleteGiver(int id)
        {
            var deleteGiver = _context.Givers.FirstOrDefault(x => x.ID == id);
            if (deleteGiver == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Givers.Remove(deleteGiver);
            _context.SaveChanges();
        }
    }
}
