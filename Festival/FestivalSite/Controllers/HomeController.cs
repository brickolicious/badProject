using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Controllers
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            Festival festival = Festival.FestivalDatumsOphalen()[0];
            String intro = festival.StartDate.ToShortDateString() + " - " + festival.EndDate.ToShortDateString();
            ViewData["festival"] = intro;
            return View("HomeIndex");
        }

    }
}
