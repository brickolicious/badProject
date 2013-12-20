using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using StoreAppPortLibrary;
using System.Data.Common;
using System.Data;

namespace StoreAppProject.Models.DAL
{
    public class LineUpRepository
    {

        public static ObservableCollection<LineUp> GetLineupByStageAndDate(int stageID, DateTime day)
        {
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
                    tempLineup.Stage = StageRepository.GetStageByID((int)reader["Stage"]);
                    tempLineup.Band = BandsRepository.GetBand((int)reader["Band"]);
                    lineUpCollectie.Add(tempLineup);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lineUpCollectie;

        }


        public static ObservableCollection<LineUp> GetAllLineUps()
        {
            ObservableCollection<LineUp> linCol = new ObservableCollection<LineUp>();

            try
            {
                string sql = "SELECT * FROM LineUp";
                DbDataReader reader = DataBase.GetData(sql);
                foreach (IDataRecord record in reader)
                {
                    LineUp tempLineup = new LineUp();
                    tempLineup.ID = (int)reader["ID"];
                    tempLineup.Date = (DateTime)reader["Datum"];
                    tempLineup.From = (string)reader["Start"];
                    tempLineup.Until = (string)reader["Until"];
                    tempLineup.Stage = StageRepository.GetStageByID((int)reader["Stage"]);
                    tempLineup.Band = BandsRepository.GetBand((int)reader["Band"]);
                    linCol.Add(tempLineup);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return linCol;
        }


  


     
 


        public static ObservableCollection<LineUp> GetLineUpForBand(int bandID)
        {
            ObservableCollection<LineUp> lstLineup = new ObservableCollection<LineUp>();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", bandID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM LineUp WHERE Band = @id", idPar);
                foreach (IDataRecord record in reader)
                {
                    LineUp tempLine = new LineUp();
                    tempLine.ID = (int)reader["ID"];
                    tempLine.Date = (DateTime)reader["Datum"];
                    tempLine.From = (string)reader["Start"];
                    tempLine.Until = (string)reader["Until"];
                    tempLine.Stage = StageRepository.GetStageByID((int)reader["Stage"]);
                    tempLine.Band = BandsRepository.GetBand((int)reader["Band"]);
                    lstLineup.Add(tempLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lstLineup;
        }


    }
}