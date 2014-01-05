using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryModels
{
    public class RSSmodel
    {
        
        public int ID { get; set; }
        
        [StringLength(50,MinimumLength=3)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string RSScontent { get; set; }

        [Required]
        public string AlternativeURI { get; set; }

        [Required]
        public string ItemID { get; set; }
        public DateTime ItemDate { get; set; }
    
    }
}
