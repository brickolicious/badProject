using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreAppPortLibrary
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

        private List<Genre> _genres;

        public List<Genre> Genres
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

    }
}
