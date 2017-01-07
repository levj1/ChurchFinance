using ChurchFinanceSite.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace ChurchFinanceSite.Controllers
{
    public class DonationController : Controller
    {
        private ApplicationDbContext _context;
        public DonationController()
        {
            _context = new ApplicationDbContext();
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
    }
}