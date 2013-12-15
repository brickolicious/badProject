using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreAppPortLibrary;
using System.Data.Common;
using System.Data;
using DBHelper;

namespace StoreAppProject.Models.DAL
{
    public class BandsRepository
    {

        public static List<Band> GetBands()
        {

            List<Band> bandsCol = new List<Band>();

            try
            {
                DbDataReader reader = DBHelper.Database.GetData("SELECT * FROM Band ORDER BY Name ASC");

                foreach (IDataRecord record in reader)
                {
                    Band tempBand = new Band();
                    tempBand.ID = (int)reader["ID"];
                    tempBand.Name = (string)reader["Name"];
                    tempBand.Picture = reader["Picture"] as Byte[];
                    tempBand.Description = (string)reader["Description"];
                    tempBand.Twitter = (string)reader["Twitter"];
                    tempBand.Facebook = (string)reader["Facebook"];
                    tempBand.Genres = GenreRepository.GetListOfGenresByBand((string)reader["Name"]);

                    string tempstring = "";
                    foreach (Genre genre in tempBand.Genres)
                    {
                        tempstring = tempstring + "," + genre.Name;
                    }
                    tempstring = tempstring.TrimStart(',');
                    tempBand.GenresInText = tempstring;

                    bandsCol.Add(tempBand);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }

            return bandsCol;
        }

        public static Band GetBand(int bandID)
        {

             Band tempBand = new Band();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", bandID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM Band WHERE ID = @id",idPar);

                foreach (IDataRecord record in reader)
                {
                   
                    tempBand.ID = (int)reader["ID"];
                    tempBand.Name = (string)reader["Name"];
                    tempBand.Picture = reader["Picture"] as Byte[];
                    tempBand.Description = (string)reader["Description"];
                    tempBand.Twitter = (string)reader["Twitter"];
                    tempBand.Facebook = (string)reader["Facebook"];
                    tempBand.Genres = GenreRepository.GetListOfGenresByBand((string)reader["Name"]);

                    string tempstring = "";
                    foreach (Genre genre in tempBand.Genres)
                    {
                        tempstring = tempstring + "," + genre.Name;
                    }
                    tempstring = tempstring.TrimStart(',');
                    tempBand.GenresInText = tempstring;


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }

            return tempBand;
        }

    }
}