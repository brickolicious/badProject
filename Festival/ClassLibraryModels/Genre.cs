using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return genreList;
        }


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


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


            return bandsCol;
        }


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
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

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
        #endregion
    }
}
