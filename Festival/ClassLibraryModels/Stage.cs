using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class Stage
    {


        #region props
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

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

        public static ObservableCollection<Stage> GetAllStages()
        {
            ObservableCollection<Stage> stageCollectie = new ObservableCollection<Stage>();

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

            return stageCollectie;
        }

        public static ObservableCollection<Stage> GetAllStages(DateTime day) {
            ObservableCollection<Stage> stageCollectie = new ObservableCollection<Stage>();

            DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
            foreach (IDataRecord record in reader) {
                Stage tempStage = new Stage();
                tempStage.ID = (int)reader["ID"];
                tempStage.Name = (string)reader["Name"];
               // tempStage.LineUpByStage = LineUp.GetLineUpForStage(tempStage.ID);
                tempStage.LineUpByStage = LineUp.GetLineupByStageAndDate(tempStage.ID, day);
                stageCollectie.Add(tempStage);
            }

            return stageCollectie;
        }


        public static Stage GetStageByID(int stageID)
        {
            Stage tempStage = new Stage();
            DbParameter idPar = DataBase.AddParameter("@StageID", stageID);
            DbDataReader reader = DataBase.GetData("SELECT * FROM Stage WHERE ID = @StageID",idPar);
            foreach (IDataRecord record in reader)
            {

                tempStage.ID = (int)reader["ID"];
                tempStage.Name = (string)reader["Name"];

            }

            return tempStage;
        }

        private static Stage CreateStageWithDate(DbDataReader reader, DateTime time) {

            Stage stage = new Stage();
            stage.ID = (int)reader["ID"];
            stage.Name = (string)reader["Name"];
            stage.LineUpByStage = LineUp.GetBandsByLineUpIDAndDate((int)reader["ID"], time);
            return stage;
        }

        public static Stage GetStageByDay(DateTime day)
        {
            Stage tempStage = new Stage();
            DbParameter dayPar = DataBase.AddParameter("@day", day);
            DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
            foreach (IDataRecord record in reader)
            {

                tempStage.ID = (int)reader["ID"];
                tempStage.Name = (string)reader["Name"];

            }

            return tempStage;
        }

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

    }
}
