using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace ClassLibraryModels
{
    public class Band 
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

        //foto als binairy opslaan om te binden
        private Byte[] _picture;

        public Byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _twitter;

        public string Twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private string _facebook;

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

        public string GenresInText
        {
            get { return _genresText; }
            set { _genresText = value; }
        }


        

        #endregion


        #region functions
        public static ObservableCollection<Band> GetBands() {

            ObservableCollection<Band> bandsCol = new ObservableCollection<Band>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM Band");

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

            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }

            return bandsCol;
        }


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
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }
            return tempBand;

        }


        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }



        
        public static void DeleteBand(int id) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", id);
                string sql = "DELETE FROM Band_Genre WHERE Band = @id; DELETE FROM Band WHERE ID =@id";
                int iModifiedData = DataBase.ModifyData(sql, idPar);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }




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
