using ChurchFinanceSite.Models;
using ChurchFinanceSite.Models.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
namespace ChurchFinanceSite.Controllers.Api
{
    public class TestRepositoryController : ApiController
    {
        private IGiverRepository giverRepository;
        public TestRepositoryController()
        {
            this.giverRepository = new GiverRepository(new ApplicationDbContext());
        }
        // GET: api/TestRepository
        public IEnumerable<Giver> Get()
        {
            return giverRepository.GetGivers();
        }

        // GET: api/TestRepository/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestRepository
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestRepository/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestRepository/5
        public void Delete(int id)
        {
        }
    }
}
