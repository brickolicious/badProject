using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

       /* public ActionResult Index()
        {

            return View("ErrorIndex");
        }*/

        public ActionResult NotFound() {

            return View("NotFound");

        }

        public ActionResult ServerError() {

            return View("ServerError");

        }

    }
}
