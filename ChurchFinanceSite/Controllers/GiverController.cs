using ChurchFinanceSite.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using ChurchFinanceSite.ViewModels;
using System.Net;
using System;

namespace ChurchFinanceSite.Controllers
{
    [Authorize(Roles = RoleName.CanManageFinance)]
    public class GiverController : Controller
    {
        private ApplicationDbContext _context;

        public GiverController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: Giver
        public ActionResult Index()
        {
            var givers = _context.Givers.Include(c => c.Address).ToList();
            return View("Index", givers.ToList());
        }
               
        public ActionResult Detail(int id)
        {
            var giver = _context.Givers.Include(c => c.Address).SingleOrDefault(c => c.ID == id);
            if (giver == null)
                return HttpNotFound();
            return View(giver);
        }

        public ActionResult New()
        {
            //var giver = new Giver();
            var vm = new GiverFormViewModel();
            return View("GiverForm", vm);
        }

        [HttpPost]
        public ActionResult Save(GiverFormViewModel vm)
        {
            if(vm.Giver.ID == 0)
            {
                _context.Givers.Add(vm.Giver);
            }
            else
            {
                var giverInDb = _context.Givers.SingleOrDefault(c => c.ID == vm.Giver.ID);
                var addressInDb = _context.Addresses.SingleOrDefault(c => c.ID == giverInDb.AddressId);
                giverInDb.FirstName = vm.Giver.FirstName;
                giverInDb.LastName = vm.Giver.LastName;
                giverInDb.Middle = vm.Giver.Middle;
                addressInDb.AddressLine1 = vm.Giver.Address.AddressLine1;
                addressInDb.AddressLine2 = vm.Giver.Address.AddressLine2;
                addressInDb.City = vm.Giver.Address.City;
                addressInDb.State = vm.Giver.Address.State;
                addressInDb.ZipCode = vm.Giver.Address.ZipCode;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Giver");
        }

        public ActionResult Edit(int id)
        {
            var giver = _context.Givers.SingleOrDefault(c => c.ID == id);
            var address = _context.Addresses.SingleOrDefault(c => c.ID == giver.AddressId);
            var vm = new GiverFormViewModel
            {
                Giver = giver
            };
             if (giver == null)
                return HttpNotFound();
            return View("GiverForm", vm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var giverToDelete = _context.Givers.FirstOrDefault(x => x.ID == id);

            if (giverToDelete == null)
                return HttpNotFound();
            try
            {
                _context.Givers.Remove(giverToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return RedirectToAction("Index");
        }

       

    }
}