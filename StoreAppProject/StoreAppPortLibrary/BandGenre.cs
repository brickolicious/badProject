using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreAppPortLibrary
{
    public class BandGenre
    {
        //bandgenre model added to be able to store the data from my rest service in 1 list
        public int ID { get; set; }
        public int Genre { get; set; }
        public int Band { get; set; }
    
    }
}
