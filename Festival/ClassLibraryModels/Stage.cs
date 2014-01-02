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
    public class Stage : IDataErrorInfo
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

        private string _name;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ObservableCollection<LineUp> _stageLineup;
        
        public ObservableCollection<LineUp> StageLineup
        {
            get { return _stageLineup; }
            set { _stageLineup = value; }
        }
        


        private ObservableCollection<LineUp> _lineUp;
        
        public ObservableCollection<LineUp> LineUpByStage
        {
            get { return _lineUp; }
            set { _lineUp = value; }
        }
        
        #endregion

        #region functions

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        public static ObservableCollection<Stage> GetAllStages()
        {
            ObservableCollection<Stage> stageCollectie = new ObservableCollection<Stage>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
                foreach (IDataRecord record in reader)
                {
                    Stage tempStage = new Stage();
                    tempStage.ID = (int)reader["ID"];
                    tempStage.Name = (string)reader["Name"];
                    // tempStage.LineUpByStage = LineUp.GetLineUpForStage(tempStage.ID);
                    //tempStage.LineUpByStage = LineUp.GetLineupByStageAndDate(tempStage.ID, day);
                    stageCollectie.Add(tempStage);
                }


                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return stageCollectie;
        }

        public static ObservableCollection<Stage> GetAllStages(DateTime day) {
            ObservableCollection<Stage> stageCollectie = new ObservableCollection<Stage>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
                foreach (IDataRecord record in reader)
                {
                    Stage tempStage = new Stage();
                    tempStage.ID = (int)reader["ID"];
                    tempStage.Name = (string)reader["Name"];
                    // tempStage.LineUpByStage = LineUp.GetLineUpForStage(tempStage.ID);
                    tempStage.LineUpByStage = LineUp.GetLineupByStageAndDate(tempStage.ID, day);
                    stageCollectie.Add(tempStage);
                }

                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return stageCollectie;
        }


        public static Stage GetStageByID(int stageID)
        {
            Stage tempStage = new Stage();
            try
            {
                
                DbParameter idPar = DataBase.AddParameter("@StageID", stageID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM Stage WHERE ID = @StageID", idPar);
                foreach (IDataRecord record in reader)
                {

                    tempStage.ID = (int)reader["ID"];
                    tempStage.Name = (string)reader["Name"];

                }


                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return tempStage;
        }

       /* private static Stage CreateStageWithDate(DbDataReader reader, DateTime time)
        {

            Stage stage = new Stage();
            try
            {
                stage.ID = (int)reader["ID"];
                stage.Name = (string)reader["Name"];
                stage.LineUpByStage = LineUp.GetBandsByLineUpIDAndDate((int)reader["ID"], time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stage;
        }
        
        public static Stage GetStageByDay(DateTime day)
        {
            Stage tempStage = new Stage();
            try
            {
                DbParameter dayPar = DataBase.AddParameter("@day", day);
                DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
                foreach (IDataRecord record in reader)
                {

                    tempStage.ID = (int)reader["ID"];
                    tempStage.Name = (string)reader["Name"];

                }


                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            return tempStage;
        }*/

        public static void RemoveStageAndItsLineup(int stageID) {

            try
            {
                string sql = "DELETE FROM LineUp WHERE Stage = @id;Delete FROM Stage WHERE ID = @id";
                DbParameter idPar = DataBase.AddParameter("@id", stageID);
                int iModifiedData = DataBase.ModifyData(sql, idPar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddStageAction(string strStageName)
        {

            try
            {
                string sql = "INSERT INTO Stage VALUES (@StageName)";
                DbParameter namePar = DataBase.AddParameter("@StageName", strStageName);
                int modifiedData = DataBase.ModifyData(sql, namePar);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        #endregion
    }
}
