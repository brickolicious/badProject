using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreAppPortLibrary;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;

namespace StoreAppProject.Models.DAL
{
    public class FestivalRepository
    {

        #region functions


        public static List<DateTime> GetFestivalDays()
        {

            var dates = new List<DateTime>();
            Festival fest = FestivalDatumsOphalen()[0];
            for (var dt = fest.StartDate; dt <= fest.EndDate; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }



        private static ObservableCollection<Festival> FestivalDatumsOphalen()
        {
            ObservableCollection<Festival> festivalCollectie = new ObservableCollection<Festival>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM FestivalDatums");

                foreach (IDataRecord record in reader)
                {

                    Festival tempFestival = new Festival();
                    tempFestival.StartDate = (DateTime)record["StartDatum"];
                    tempFestival.EndDate = (DateTime)record["EindDatum"];
                    festivalCollectie.Add(tempFestival);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }

            return festivalCollectie;

        }



        #endregion
    }
}