using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using ClassLibraryModels;

namespace FestivalSite.ViewModels
{
    public class LineUpVM
    {

        public List<DateTime> Days { get; set; }
        public DateTime? SelectedDay { get; set; }
        public ObservableCollection<Stage> stagesWithLineup { get; set; }
        public Band SelectedBand { get; set; }
        public ObservableCollection<Band> BandList { get; set; }
        public ObservableCollection<LineUp> LineupForBand { get; set; }
    }
}