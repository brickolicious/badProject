using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibraryModels;
using FestivalSite.ViewModels;
using System.Collections.ObjectModel;

namespace FestivalSite.Controllers
{
    public class LineUpController : Controller
    {
        //
        // GET: /Lineup/

        public ActionResult Index()
        {
            List<DateTime> lstDays = Festival.GetFestivalDays();

            LineUpVM lineVM = new LineUpVM();

            lineVM.Days = lstDays;
            lineVM.BandList = Band.GetBands();

            return View("LineUpIndex",lineVM);
        }


        public ActionResult LineUpForDay(DateTime date,LineUpVM lineVM) {

            // parameter lineVM word al meegegeven indien men terug wil keren naar het overzicht dan heeft men al alle waarden die de gebruiker eerder koos
            //indien het de eerste keer is wordt er een instantie gemaakt ervoor
            if (lineVM == null) {

                lineVM = new LineUpVM();

            }

            if (date != null)
            {
                lineVM.SelectedDay = date;
            }
            lineVM.stagesWithLineup = Stage.GetAllStages(date);

            return View("LineUpForDay",lineVM);
        }


        public ActionResult DetailBand(int bandID,LineUpVM lineVM) {

            if (lineVM == null) {
                lineVM = new LineUpVM();
            }

            //vragen waarom er geen modelbinding is tussen lineVM en Model, in de view zit er nochtans een annonieme variable om aan modelbindingte kunnen doen
            lineVM.SelectedBand = Band.GetBandByID(bandID);

            return View("DetailBand",lineVM);
        }

        public ActionResult DetailLineup(int bandID,LineUpVM lineVM) {



            return View("DetailLineup", lineVM);
        }



        public ActionResult GetPhoto(byte[] photo)
        {
            
            return File(photo, "image/jpeg");
        }

    }
}
