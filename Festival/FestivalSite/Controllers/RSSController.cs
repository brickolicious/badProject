using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel.Syndication;
using System.Data.Common;
using ClassLibraryModels;
using System.Data;

namespace FestivalSite.Controllers
{
    public class RSSController : ApiController
    {

        public object Get() {
            var feed = new SyndicationFeed("Festival feed", "The official feed for Howestival", new Uri("http://localhost:14783"));
            feed.Authors.Add(new  SyndicationPerson("bart.vandecandelaere@student.howest.be"));
            feed.Categories.Add(new SyndicationCategory("Festival"));
            feed.Description = new TextSyndicationContent("This is a feed for all the visitors off Howestival");


            List<SyndicationItem> lstSynItems = new List<SyndicationItem>();
            try
            {

                string sql = "SELECT * FROM RSSfeed";
                DbDataReader reader = DataBase.GetData(sql);
                foreach (IDataRecord record in reader)
                {

                    string strTitle = (string)reader["Title"];
                    string strContent = (string)reader["RSScontent"];
                    Uri uriAlternativeURI = new Uri((string)reader["AlternativeURI"]);
                    string strItemID = (string)reader["ItemID"];
                    DateTime dtDate =  (DateTime)reader["ItemDate"];

                    SyndicationItem tempItem = new SyndicationItem(
                        strTitle,
                        strContent,
                        uriAlternativeURI,
                        strItemID,
                        dtDate
                       );


                    lstSynItems.Add(tempItem);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            feed.Items = lstSynItems;


            return new Rss20FeedFormatter(feed);
        }


    }
}
