using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ChurchFinanceSite.Models;

namespace ChurchFinanceSite.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Donations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportPDF()
        {
            var donations = db.Donations.Include(d => d.DonationType).Include(d => d.Giver).OrderBy(d => d.Giver.FirstName);
            return View(donations.ToList());
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
