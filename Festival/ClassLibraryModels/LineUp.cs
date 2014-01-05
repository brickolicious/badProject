using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class LineUp : IDataErrorInfo
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
        #region props
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _date;
        [Required]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

  

        private string _from;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private string _until;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Until
        {
            get { return _until; }
            set { _until = value; }
        }

        private Stage _stage;
        [Required]
        public Stage Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private Band _band;
        [Required]
        public Band Band
        {
            get { return _band; }
            set { _band = value; }
        }
        #endregion


        #region functions

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        //returns a collection of lineups by stage and date
        //used to fillup the stages in getAllStages
        public static ObservableCollection<LineUp> GetLineupByStageAndDate(int stageID,DateTime day) {
            ObservableCollection<LineUp> lineUpCollectie = new ObservableCollection<LineUp>();
            try
            {
                //opgesplit in 2 queries --> anders PM tijdens de AMs <3 sorting



                DbParameter stageIdPar = DataBase.AddParameter("@StageID", stageID);
                day = day.Date;
                string sDateTime = day.ToString("yyyy/MM/dd HH:mm:ss");

                DbParameter datePar = DataBase.AddParameter("@Day", sDateTime);
                DbDataReader reader = DataBase.GetData("SELECT * FROM LineUp WHERE Stage = @StageID AND Datum = @Day AND Start like '%AM' ORDER BY LineUp.Start ASC", stageIdPar, datePar);
                foreach (IDataRecord record in reader)
                {
                    LineUp tempLineup = new LineUp();
                    tempLineup.ID = (int)reader["ID"];
                    tempLineup.Date = (DateTime)reader["Datum"];
                    tempLineup.From = (string)reader["Start"];
                    tempLineup.Until = (string)reader["Until"];
                    tempLineup.Stage = Stage.GetStageByID((int)reader["Stage"]);
                    tempLineup.Band = Band.GetBandByID((int)reader["Band"]);
                    lineUpCollectie.Add(tempLineup);
                }


                reader.Close();




                DbParameter stageIdPar2 = DataBase.AddParameter("@StageID2", stageID);
                day = day.Date;
                string sDateTime2 = day.ToString("yyyy/MM/dd HH:mm:ss");

                DbParameter datePar2 = DataBase.AddParameter("@Day2", sDateTime2);
                DbDataReader reader2 = DataBase.GetData("SELECT * FROM LineUp WHERE Stage = @StageID2 AND Datum = @Day2 AND Start like '%PM' ORDER BY LineUp.Start ASC", stageIdPar2, datePar2);
                foreach (IDataRecord record2 in reader2)
                {
                    LineUp tempLineup = new LineUp();
                    tempLineup.ID = (int)reader2["ID"];
                    tempLineup.Date = (DateTime)reader2["Datum"];
                    tempLineup.From = (string)reader2["Start"];
                    tempLineup.Until = (string)reader2["Until"];
                    tempLineup.Stage = Stage.GetStageByID((int)reader2["Stage"]);
                    tempLineup.Band = Band.GetBandByID((int)reader2["Band"]);
                    lineUpCollectie.Add(tempLineup);
                }


                reader2.Close();






            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return lineUpCollectie;
             
        }

        //gets all lineup elements for a stage not taking the day into account.
        //usefull for rest services -> copied to the portable library
        public static ObservableCollection<LineUp> GetLineUpForStage(int stageID) {
            ObservableCollection<LineUp> linCol = new ObservableCollection<LineUp>();

            try
            {
                string sql = "SELECT * FROM LineUp WHERE Band = @id";
                DbParameter idPar = DataBase.AddParameter("@id", stageID);
                DbDataReader reader = DataBase.GetData(sql, idPar);
                foreach (IDataRecord  record in reader)
                {
                LineUp tempLineup = new LineUp();
                tempLineup.ID = (int)reader["ID"];
                tempLineup.Date = (DateTime)reader["Datum"];
                tempLineup.From = (string)reader["Start"];
                tempLineup.Until = (string)reader["Until"];
                tempLineup.Stage = Stage.GetStageByID((int)reader["Stage"]);
                tempLineup.Band = Band.GetBandByID((int)reader["Band"]);
                linCol.Add(tempLineup);
                }


                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return linCol;
        }
            
        //adds a lineup element to the database
        public static void AddLineUp(LineUp lineup) {

            try
            {
                DbParameter datePar = DataBase.AddParameter("@date", lineup.Date);
                DbParameter fromPar = DataBase.AddParameter("@from", lineup.From);
                DbParameter untilPar = DataBase.AddParameter("@until", lineup.Until);
                DbParameter stagePar = DataBase.AddParameter("@stage", lineup.Stage.ID);
                DbParameter bandPar = DataBase.AddParameter("@band", lineup.Band.ID);
                string sql = "INSERT INTO LineUp (Datum,Start,Until,Stage,Band) VALUES (@date,@from,@until,@stage,@band)";
                int iModifiedData = DataBase.ModifyData(sql, datePar, fromPar, untilPar, stagePar, bandPar);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //returns a collection of lineups 
        //old code
        public static ObservableCollection<LineUp> GetBandsByLineUpIDAndDate(int id, DateTime time)
        {
            ObservableCollection<LineUp> tempCol = new ObservableCollection<LineUp>();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id",id);
                DbParameter datePar = DataBase.AddParameter("@date",time);  //co,vertren naar ander formaat type yyyy/mm/dd
                DbDataReader reader = DataBase.GetData("SELECT * FROM LineUp WHERE Stage = @id AND Datum = @date",idPar,datePar);

                while (reader.Read())
                {
                   // tempCol.Add(createLineUp(reader));
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tempCol;
        }

        //removes a lineup element from the database
        public static void DeleteLineUpElement(int lineupID) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id",lineupID);
                string sql = "DELETE FROM LineUp WHERE ID = @id";
                int iModifiedData = DataBase.ModifyData(sql, idPar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        //gets all the lineup elements that have a certain band
        public static ObservableCollection<LineUp> GetLineUpForBand(int bandID) {
            ObservableCollection<LineUp> lstLineup = new ObservableCollection<LineUp>();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", bandID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM LineUp WHERE Band = @id",idPar);
                foreach (IDataRecord record in reader)
                {
                    LineUp tempLine = new LineUp();
                    tempLine.ID = (int)reader["ID"];
                    tempLine.Date = (DateTime)reader["Datum"];
                    tempLine.From = (string)reader["Start"];
                    tempLine.Until = (string)reader["Until"];
                    tempLine.Stage = Stage.GetStageByID((int)reader["Stage"]);
                    tempLine.Band = Band.GetBandByID((int)reader["Band"]);
                    lstLineup.Add(tempLine);


                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lstLineup;
        }

        #endregion
    }
}
