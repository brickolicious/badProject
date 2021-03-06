﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibraryModels
{
    public class Genre : IDataErrorInfo
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
        #endregion

        #region functions

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        //gets a collection of all the genres
        public static ObservableCollection<Genre> GetGenres() {
            ObservableCollection<Genre> genreList = new ObservableCollection<Genre>();

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

                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return genreList;
        }

        //gets a list of genres based on the bands name
        //does this by inner joining, it goes the the band table and does a where on its name, the gets the genreID from the reservations and looks up the genre
        public static ObservableCollection<Genre> GetListOfGenresByBand(string bandName) {
            ObservableCollection<Genre> bandsCol = new ObservableCollection<Genre>();

            try
            {
                string sql = "SELECT Genre.ID,Genre.Name FROM Band_Genre join genre ON Band_Genre.Genre = Genre.ID JOIN Band ON Band_Genre.Band = Band.ID WHERE Band.Name = @bandnaam";
                DbParameter bandnaamPar = DataBase.AddParameter("@bandnaam", bandName);
                DbDataReader reader = DataBase.GetData(sql,bandnaamPar);
                foreach (IDataRecord record in reader) {
                    Genre tempGenre = new Genre();
                    tempGenre.ID = (int)reader["ID"];
                    tempGenre.Name = (string)reader["Name"];
                    bandsCol.Add(tempGenre);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


            return bandsCol;
        }

        //it gets a string and splits the string based on the ',' charachter it then checks if that genre exists or not if so it adds that genre to the collection
        //if it checks the genre table it doenst exist, it creates the genre and then adds the newly created genre to the collection
        public static ObservableCollection<Genre> GetCollectionOfGenresForBandFromGenresString(string genresString) {

            ObservableCollection<Genre> genreColl = new ObservableCollection<Genre>();

            Genre tempGenre = new Genre();

            string[] genresSplitArr = genresString.Split(',');

            foreach (string tempString in genresSplitArr) {

                tempGenre = CheckIfGenreExistsIfSoReturnGenre(tempString);
                if (tempGenre != null)
                {

                    genreColl.Add(tempGenre);
                }
                else {
                    tempGenre = CreateAndReturnGenre(tempString);
                    if (tempGenre != null)
                    {
                        genreColl.Add(tempGenre);
                    }
                }

            }

            return genreColl;
        }

        //creates a genrebased on a string that should represent its name
        //then it returns the created genre
        private static Genre CreateAndReturnGenre(string tempString)
        {
            Genre gen;
            try
            {
                DbParameter namePar = DataBase.AddParameter("@name", tempString);
                string sql = "INSERT INTO Genre (Name) VALUES (@name)";

                int iModifiedData = DataBase.ModifyData(sql, namePar);
                gen = CheckIfGenreExistsIfSoReturnGenre(tempString);
                return gen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //checks if there exists a genre that has the same name as its parameter string if so it returns that genre
        private static Genre CheckIfGenreExistsIfSoReturnGenre(string tempString)
        {
            try
            {
                DbParameter genName = DataBase.AddParameter("@name", tempString);
                string sql = "SELECT * FROM Genre WHERE Name =@name";
                DbDataReader reader = DataBase.GetData(sql, genName);
                foreach (IDataRecord record in reader)
                {
                    Genre gen = new Genre();
                    gen.ID = (int)record["ID"];
                    gen.Name = (string)record["Name"];
                    return gen;
                }


                reader.Close();
                return null;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //checks if band exists if so it updates the band info
        //if the band doesnt exist it creates the band
        //if the band already existed it removes all the genres associated with it and adds all the genres again in the bandgenre table 
        //this is to make sure there are no old settings left
        //because all genres are directly visbible in the store app
        public static void InsertBandAndOrAttachGenres(Band band) {

            try
            {
                ObservableCollection<Genre> genColl = GetCollectionOfGenresForBandFromGenresString(band.GenresInText);

                //check if band already exists
                bool createNew = true;
                foreach (Band tempband in Band.GetBands()) {

                    if (band.Name == tempband.Name)
                    {
                        createNew = false;
                        DbParameter nameUpdatePar = DataBase.AddParameter("@nameUpdate",tempband.Name);
                        DbParameter descriptionUpdatePar = DataBase.AddParameter("@descriptionUpdate",band.Description);
                        DbParameter twitterUpdatePar = DataBase.AddParameter("@twitterUpdate",band.Twitter);
                        DbParameter facebookUpdatePar = DataBase.AddParameter("@facebookUpdate",band.Facebook);
                        DbParameter picturePar = DataBase.AddParameter("@picture", band.Picture);
                        DbParameter idUpdatePar = DataBase.AddParameter("@idUpdate",tempband.ID);

                        if (band.Picture != null)
                        {
                            string sql_update = "UPDATE Band SET Name = @nameUpdate,Picture = @picture,Description = @descriptionUpdate, Twitter = @twitterUpdate, Facebook = @facebookUpdate WHERE ID = @idUpdate";
                            int iModifiedDataUpdate = DataBase.ModifyData(sql_update, nameUpdatePar, picturePar, descriptionUpdatePar, twitterUpdatePar, facebookUpdatePar, idUpdatePar);
                        }
                        else {

                            string sql_update = "UPDATE Band SET Name = @nameUpdate,Description = @descriptionUpdate, Twitter = @twitterUpdate, Facebook = @facebookUpdate WHERE ID = @idUpdate";
                            int iModifiedDataUpdate = DataBase.ModifyData(sql_update, nameUpdatePar, descriptionUpdatePar, twitterUpdatePar, facebookUpdatePar, idUpdatePar);
                        
                        }

                        string sql = "DELETE FROM Band_Genre WHERE Band = @id";
                        DbParameter idpar = DataBase.AddParameter("@id", tempband.ID);
                        int iModifiedData = DataBase.ModifyData(sql, idpar);

                        foreach (Genre gen in genColl)
                        {
                            //check op genres doen
                            DbParameter bandPar = DataBase.AddParameter("@band", tempband.ID);
                            DbParameter genPar = DataBase.AddParameter("@genre", gen.ID);
                            string sql_q2 = "INSERT INTO Band_Genre (Genre,Band) VALUES (@Genre,@band)";
                            int iModifiedData_2 = DataBase.ModifyData(sql_q2, bandPar, genPar);
                        }
                        return;
                    }
                    

                }
                 
                if(createNew == true){

                        int insertedID = 0;
                        string sql_insert = "INSERT INTO Band(Name,Picture,Description,Twitter,Facebook) OUTPUT Inserted.ID VALUES (@name,@pic,@descr,@twit,@fb)";

                        DbParameter namePar = DataBase.AddParameter("@name",band.Name);
                        DbParameter picPar = DataBase.AddParameter("@pic", band.Picture);
                        DbParameter descripPar = DataBase.AddParameter("@descr", band.Description);
                        DbParameter twitPar = DataBase.AddParameter("@twit", band.Twitter);
                        DbParameter fbPar = DataBase.AddParameter("@fb", band.Facebook);

                        DbDataReader reader = DataBase.GetData(sql_insert,namePar,descripPar,twitPar,fbPar,picPar);

                        foreach (IDataRecord record in reader) {
                            insertedID = (int)reader["ID"];
                        }

                        foreach (Genre gen in genColl)
                        {
                            DbParameter bandPar = DataBase.AddParameter("@band", insertedID);
                            DbParameter genPar = DataBase.AddParameter("@genre", gen.ID);
                            string sql_q2 = "INSERT INTO Band_Genre (Genre,Band) VALUES (@Genre,@band)";
                            int iModifiedData_2 = DataBase.ModifyData(sql_q2, bandPar, genPar);
                        }
                    }
                    
                    }

                

                




            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //removes a genre based on the given id
        public static void RemoveGenre(int genreID) {

            try
            {

                DbParameter idPar1 = DataBase.AddParameter("@id1", genreID);
                DbParameter idPar2 = DataBase.AddParameter("@id2", genreID);
                string sql_tussen = "DELETE from Band_Genre WHERE Band_Genre.Genre = @id1";
                string sql_genre = "DELETE from Genre WHERE Genre.ID = @id2";
                int iModifiedData1 = DataBase.ModifyData(sql_tussen, idPar1);
                int iModifiedData2 = DataBase.ModifyData(sql_genre, idPar2);

                MessageBox.Show("Genre has been removed.","Genre removed");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        #endregion
    }
}
