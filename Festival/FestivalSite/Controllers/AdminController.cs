using ClassLibraryModels;
using FestivalSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        [Authorize(Roles = "Admin")]
        public ActionResult Index(bool insertOke = false)
        {
            AdminPanelVM adminVM = new AdminPanelVM();
            
            if (insertOke == true) {
                adminVM.Message = "RSS item werd opgeslaan.";
            }

            
            adminVM.Rss = new RSSmodel();

            return View("AdminIndex",adminVM);
        }

        //[HttpPost]
        public ActionResult OpslaanRSS(RSSmodel rssmodel) {
            
            try
            {
                DbParameter titlePar = DataBase.AddParameter("@title", rssmodel.Title);
                DbParameter contentPar = DataBase.AddParameter("@content", rssmodel.RSScontent);
                DbParameter uriPar = DataBase.AddParameter("@uri", rssmodel.AlternativeURI);
                DbParameter itemIDPar = DataBase.AddParameter("@itemID", rssmodel.ItemID);
                DbParameter datePar = DataBase.AddParameter("@date", DateTime.Now);
                string sql = "INSERT INTO RSSfeed (Title,RSScontent,AlternativeURI,ItemID,ItemDate) VALUES (@title,@content,@uri,@itemID,@date)";
                int iModifiedData = DataBase.ModifyData(sql,titlePar,contentPar,uriPar,itemIDPar,datePar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("Index", "Admin", new {insertOke = true });
        }

    }
}
