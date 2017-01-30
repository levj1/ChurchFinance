using ChurchFinanceSite.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using ChurchFinanceSite.ViewModels;

namespace ChurchFinanceSite.Controllers
{
    public class DonationController : Controller
    {
        private ApplicationDbContext _context;
        public DonationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Donation
        public ActionResult Index()
        {
            var donations = _context.Donations.Include(x => x.Giver).Include(x => x.DonationType);
            return View(donations);
        }

        public ActionResult Detail(int id)
        {
            var donation = _context.Donations.Include(x => x.DonationType).Include(x => x.Giver).SingleOrDefault(c => c.ID == id);
            if (donation == null)
                return HttpNotFound();
            return View(donation);
        }

        public ActionResult DonationForm()
        {
            var donationType = _context.DonationType.ToList();
            var giver = _context.Givers.ToList();
            var viewModel = new DonationFormViewModel
            {
                Giver = giver,                
                DonationType = donationType
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
            return RedirectToAction("Index", "Donation");
        }

        public ActionResult Edit(int id)
        {
            _context.Donations.SingleOrDefault(x => x.ID == id);

            return View();
        }

    }
}