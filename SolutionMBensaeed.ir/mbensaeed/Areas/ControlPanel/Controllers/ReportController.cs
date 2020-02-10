using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class ReportController : Controller
    {
        // GET: ControlPanel/Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WebSiteVisit()
        {
            using (var _Conetxt = new ApplicationDbContext())
            {
                var objectVisitWebSite = new RepositoryPattern<WebsiteVisit>(_Conetxt);
                var allVisit = objectVisitWebSite.GetAll();

                return View(allVisit);
            }
        }

    }
}