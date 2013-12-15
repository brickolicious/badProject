using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreAppPortLibrary
{
   public class Genre
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
        #endregion
    }
}
