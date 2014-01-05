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
using System.Windows.Media;


namespace ClassLibraryModels 
{
    public class Band : IDataErrorInfo
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

        //foto als binairy opslaan om te binden
        private Byte[] _picture;
        [Required]
        public Byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _description;
        
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 350 karakters bevatten ")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _twitter;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private string _facebook;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private ObservableCollection<Genre> _genres;
        
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }

        private string _genresText;

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string GenresInText
        {
            get { return _genresText; }
            set { _genresText = value; }
        }

      
        

        #endregion


        #region functions
        
        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        //returns a collection with all the bands as objects
        public static ObservableCollection<Band> GetBands() {

            ObservableCollection<Band> bandsCol = new ObservableCollection<Band>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM Band ORDER BY Name ASC");

                foreach (IDataRecord record in reader)
                {
                    Band tempBand = new Band();
                    tempBand.ID = (int)reader["ID"];
                    tempBand.Name = (string)reader["Name"];
                    tempBand.Picture = reader["Picture"] as Byte[];
                    tempBand.Description = (string)reader["Description"];
                    tempBand.Twitter = (string)reader["Twitter"];
                    tempBand.Facebook = (string)reader["Facebook"];
                    tempBand.Genres = Genre.GetListOfGenresByBand((string)reader["Name"]);

                    string tempstring = "";
                    foreach (Genre genre in tempBand.Genres)
                    {
                        tempstring = tempstring + "," + genre.Name;
                    }
                    tempstring = tempstring.TrimStart(',');
                    tempBand.GenresInText = tempstring;

                    bandsCol.Add(tempBand);

                }


                reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }

            return bandsCol;
        }

        //returns a band based on the id that was given
        public static Band GetBandByID(int bandID)
        {
            Band tempBand = new Band();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@bandID", bandID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM Band WHERE ID = @bandID", idPar);
                foreach (IDataRecord record in reader)
                {


                    tempBand.ID = (int)reader["ID"];
                    tempBand.Name = (string)reader["Name"];
                    tempBand.Picture = reader["Picture"] as Byte[];
                    tempBand.Description = (string)reader["Description"];
                    tempBand.Twitter = (string)reader["Twitter"];
                    tempBand.Facebook = (string)reader["Facebook"];
                    tempBand.Genres = Genre.GetListOfGenresByBand((string)reader["Name"]);

                    string tempstring = "";
                    foreach (Genre genre in tempBand.Genres)
                    {
                        tempstring = tempstring + "," + genre.Name;
                    }
                    tempstring = tempstring.TrimStart(',');
                    tempBand.GenresInText = tempstring;


                }
                reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }
            return tempBand;

        }

        //returns a byte array for an image in a certain path
        //experimental methode
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //removes a band based on its id
        public static void DeleteBand(int id) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", id);
                string sql = "DELETE FROM LineUp WHERE Band = @id;DELETE FROM Band_Genre WHERE Band = @id;DELETE FROM Band WHERE ID =@id;";
                int iModifiedData = DataBase.ModifyData(sql, idPar);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }

        //given a path to a file this function wil return an its contents as a byte array
        //used to convert images to a byte array for storage in the database
        public static byte[] GetPhoto(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            fs.Close();
            return data;
        }


        #endregion
    }
}
