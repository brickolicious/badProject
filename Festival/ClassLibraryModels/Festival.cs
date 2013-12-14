using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class Festival : IDataErrorInfo
    {
        #region IDataErrorInfo
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {

                    return ex.Message;
                }
                return string.Empty;
            }





        }
        #endregion
        #region prop
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

        #endregion


        #region functions
        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
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

        public static void AddDay()
        {
            try
            {
                int tempID = 1;

                DbParameter idPar = DataBase.AddParameter("@id", tempID);
                string sql = "UPDATE FestivalDatums SET EindDatum = EindDatum+1 WHERE id = @id";

                DataBase.ModifyData(sql, idPar);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion


    }
}
