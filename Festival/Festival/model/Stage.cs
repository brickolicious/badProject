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
    class Stage
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


        private ObservableCollection<LineUp> _lineUp;

        public ObservableCollection<LineUp> LineUpByStage
        {
            get { return _lineUp; }
            set { _lineUp = value; }
        }
        
        #endregion



        public static ObservableCollection<Stage> GetAllStages() {
            ObservableCollection<Stage> stageCollectie = new ObservableCollection<Stage>();

            DbDataReader reader = DataBase.GetData("SELECT * FROM Stage");
            foreach (IDataRecord record in reader) {
                Stage tempStage = new Stage();
                tempStage.ID = (int)reader["ID"];
                tempStage.Name = (string)reader["Name"];
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
        

    }
}
