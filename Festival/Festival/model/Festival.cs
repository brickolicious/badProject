using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.model
{
    class Festival
    {

        private DateTime _startDate;

        public DateTime StartDate
        {

            get {
                
               
                return _startDate; 
            }
            set { _startDate = value; }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get {
                
                return _endDate; 
            }
            set { _endDate = value; }
        }


        


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
            catch (Exception ex) {

                Console.WriteLine(ex);

            }

            return festivalCollectie;

        }



   
    }
}
