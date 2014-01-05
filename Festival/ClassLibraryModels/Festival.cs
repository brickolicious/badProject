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
using System.Windows;

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

        //gets a collection of days based on the interval between the start and end property
        public static ObservableCollection<DateTime> GetFestivalDays()
        {

            var dates = new ObservableCollection<DateTime>();
            Festival fest = FestivalDatumsOphalen()[0];
            for (var dt = fest.StartDate; dt <= fest.EndDate; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }

        //gets the days based on the values that were set in the database
        public static ObservableCollection<Festival> FestivalDatumsOphalen()
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
                reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }

            return festivalCollectie;

        }

        //updates the start day to the startday+1
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

        //sets the start day in the database but also sets the end day equal to the startday+1
        //there is a check if you remove day that the end day cant be lower than the start day
        //by setting the end day to start+1 you prevent the user from ever getting a lower end day then start day
        public static void SetStartDay(DateTime date) {


            try
            {

                int tempID = 1;
                DbParameter dagPar = DataBase.AddParameter("@day", date);
                DbParameter idPar = DataBase.AddParameter("@id", tempID);
                string sql = "UPDATE FestivalDatums SET StartDatum = @day WHERE id = @id;UPDATE FestivalDatums SET EindDatum = StartDatum+1 WHERE id = 1";

                int modifiedData = DataBase.ModifyData(sql, idPar,dagPar);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        
        }

        //this function gets the length of the list of days there are and if this list has only 1 day left it warns the user and returns so you cant get an end date lower then start
        //removes a day, by doing endday = endday-1
        public static void RemoveDay(int listLenght)
        {
            try
            {
                int tempID = 1;
                if (listLenght == 1) { MessageBox.Show("Festival needs to have a length of atleast 1 day."); return; }
                DbParameter idPar = DataBase.AddParameter("@id", tempID);
                string sql = "UPDATE FestivalDatums SET EindDatum = EindDatum-1 WHERE id = @id";

                int iModifiedData = DataBase.ModifyData(sql, idPar);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion



        
    }
}
