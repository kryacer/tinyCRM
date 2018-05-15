using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tinyCRM.Models;

namespace tinyCRM.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report
        public ActionResult Index()
        {
            var items = db.TaskItems.Where(t => t.DeadLine < DateTime.Now && t.Progress < 100).ToList();
            return View(items);
        }
    }
}