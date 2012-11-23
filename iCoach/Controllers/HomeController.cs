using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCoach.Core;
using iCoach.Data.EF;
using iCoach.Models;

namespace iCoach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoachSettings _settings;
        private ICoachDb _coachDb;

        public HomeController(ICoachSettings settings, ICoachDb db)
        {
            _settings = settings;
            _coachDb = db;
        }

        public ActionResult Index()
        {
            var mes = _coachDb.Users.First().UserName;

            var model = new DemoModel {Message = mes};

            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
