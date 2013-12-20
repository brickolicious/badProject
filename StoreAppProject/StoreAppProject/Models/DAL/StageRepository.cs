using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreAppPortLibrary;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using System.Windows;

namespace StoreAppProject.Models.DAL
{
    public class StageRepository
    {

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
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return stageCollectie;
        }

        /*public static ObservableCollection<Stage> GetAllStages(DateTime day) {
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
                    tempStage.LineUpByStage = LineUpRepository.GetLineupByStageAndDate(tempStage.ID, day);
                    stageCollectie.Add(tempStage);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return stageCollectie;
        }
        */

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
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return tempStage;
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
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            
            }

            return tempStage;
        }

        
    }
}