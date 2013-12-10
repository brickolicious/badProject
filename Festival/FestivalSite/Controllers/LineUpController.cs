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

        
        public ActionResult LineUpForDay(DateTime date) {

            LineUpVM lineVM = new LineUpVM();

            if (date != null)
            {
                lineVM.SelectedDay = date;
            }
            lineVM.stagesWithLineup = Stage.GetAllStages(date);

            return View("LineUpForDay",lineVM);
        }


        public ActionResult DetailBand(int bandID, DateTime? date) {

            LineUpVM lineVM = new LineUpVM();

           

            lineVM.SelectedDay = date;
            lineVM.SelectedBand = Band.GetBandByID(bandID);

            return View("DetailBand",lineVM);
        }

        public ActionResult BandLineUp(int bandID) {

            LineUpVM lineVM = new LineUpVM();

            lineVM.SelectedBand = Band.GetBandByID(bandID);
            lineVM.LineupForBand = LineUp.GetLineUpForBand(bandID);


            return View("BandLineUp", lineVM);
        }



        //public ActionResult GetPhoto(int id)
        //{
            
        //    return File(photo, "image/jpeg");
        //}

    }
}
