using ChurchFinanceSite.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using ChurchFinanceSite.ViewModels;

namespace ChurchFinanceSite.Controllers
{
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
            return View(givers.ToList());
        }

        public ActionResult Detail(int id)
        {
            var giver = _context.Givers.Include(c => c.Address).SingleOrDefault(c => c.ID == id);
            if (giver == null)
                return HttpNotFound();
            return View(giver);
        }

        public ActionResult GiverForm()
        {
            var giver = new Giver();
            return View(giver);
        }
        [HttpPost]
        public ActionResult Create(Giver giver)
        {
            _context.Givers.Add(giver);
            _context.SaveChanges();

            return RedirectToAction("Index", "Giver");
        }

        public ActionResult Edit(int id)
        {
            var giver = _context.Givers.SingleOrDefault(c => c.ID == id);
             if (giver == null)
                return HttpNotFound();
            return View("GiverForm", giver);
        }
       
    }
}