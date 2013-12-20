using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StoreAppPortLibrary
{
    public class LineUp
    {
        #region props
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _date;
        [Required]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }



        private string _from;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private string _until;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Until
        {
            get { return _until; }
            set { _until = value; }
        }

        private Stage _stage;
        [Required]
        public Stage Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private Band _band;
        [Required]
        public Band Band
        {
            get { return _band; }
            set { _band = value; }
        }
        #endregion


        


    }
}
