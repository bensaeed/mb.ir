using mbensaeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            //var query = _context.Category.Include(x=>x.Posts).Where(x=>x.)
            return View();
        }
    }
}