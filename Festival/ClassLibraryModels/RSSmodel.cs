using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class RSSmodel
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string RSScontent { get; set; }
        public string AlternativeURI { get; set; }
        public string ItemID { get; set; }
        public DateTime ItemDate { get; set; }
    
    }
}
