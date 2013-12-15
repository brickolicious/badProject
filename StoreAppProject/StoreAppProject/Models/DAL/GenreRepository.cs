using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using StoreAppPortLibrary;

namespace StoreAppProject.Models.DAL
{
    public class GenreRepository
    {

        public static List<Genre> GetGenres()
        {
            List<Genre> genreList = new List<Genre>();

            try
            {
                string sql = "SELECT * FROM Genre";
                DbDataReader reader = DataBase.GetData(sql);
                foreach (IDataRecord record in reader)
                {
                    Genre tempGenre = new Genre();
                    tempGenre.ID = (int)reader["ID"];
                    tempGenre.Name = (string)reader["Name"];
                    genreList.Add(tempGenre);
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return genreList;
        }

        public static List<Genre> GetListOfGenresByBand(string bandName)
        {
            List<Genre> bandsCol = new List<Genre>();

            try
            {
                string sql = "SELECT Genre.ID,Genre.Name FROM Band_Genre join genre ON Band_Genre.Genre = Genre.ID JOIN Band ON Band_Genre.Band = Band.ID WHERE Band.Name = @bandnaam";
                DbParameter bandnaamPar = DataBase.AddParameter("@bandnaam", bandName);
                DbDataReader reader = DataBase.GetData(sql, bandnaamPar);
                foreach (IDataRecord record in reader)
                {
                    Genre tempGenre = new Genre();
                    tempGenre.ID = (int)reader["ID"];
                    tempGenre.Name = (string)reader["Name"];
                    bandsCol.Add(tempGenre);
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


            return bandsCol;
        }

    }
}