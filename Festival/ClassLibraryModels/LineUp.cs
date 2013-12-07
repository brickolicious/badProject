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

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private string _until;

        public string Until
        {
            get { return _until; }
            set { _until = value; }
        }

        private Stage _stage;

        public Stage Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private Band _band;

        public Band Band
        {
            get { return _band; }
            set { _band = value; }
        }
        #endregion


        #region functions
        public static ObservableCollection<LineUp> GetLineupByStageAndDate(int stageID,DateTime day) {
            ObservableCollection<LineUp> lineUpCollectie = new ObservableCollection<LineUp>();
            try
            {
                DbParameter stageIdPar = DataBase.AddParameter("@StageID", stageID);
                day = day.Date;
                string sDateTime = day.ToString("yyyy/MM/dd HH:mm:ss");

                DbParameter datePar = DataBase.AddParameter("@Day", sDateTime);
                DbDataReader reader = DataBase.GetData("SELECT * FROM LineUp WHERE Stage = @StageID AND Datum = @Day ORDER BY LineUp.Until ASC", stageIdPar, datePar);
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
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return lineUpCollectie;
             
        }


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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return linCol;
        }
            

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tempCol;
        }

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

        #endregion
    }
}
