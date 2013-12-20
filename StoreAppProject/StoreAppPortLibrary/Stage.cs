using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace StoreAppPortLibrary
{
    public class Stage : ObservableObject
    {
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

        private ObservableCollection<LineUp> _stageLineup;

        public ObservableCollection<LineUp> StageLineup
        {
            get { return _stageLineup; }
            set { _stageLineup = value; OnPropertyChanged("StageLineup"); }
        }



        #endregion
    }
}
