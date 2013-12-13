using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class AddLineUpVM : ObservableObject
    {
        public AddLineUpVM()
        {
            this.BandList = Band.GetBands();
            this.StageList = Stage.GetAllStages();
            LineUpToAdd = new LineUp();
            LineUpToAdd.Date = Festival.GetFestivalDays()[0];
    }


        private LineUp _lineup;
	public LineUp LineUpToAdd
	{
		get { return _lineup;}
        set { _lineup = value; OnPropertyChanged("LineUpToAdd"); }
	}

    private ObservableCollection<Band> _bands;

    public ObservableCollection<Band> BandList
    {
        get { return _bands; }
        set { _bands = value; }
    }


    private ObservableCollection<Stage> _stages;

    public ObservableCollection<Stage> StageList
    {
        get { return _stages; }
        set { _stages = value; }
    }




    public ICommand AddToLineup {

        get { return new RelayCommand(AddLineup); }

    }

    private void AddLineup()
    {
        

        DateTime tempTime = Convert.ToDateTime(LineUpToAdd.From);
        LineUpToAdd.From = tempTime.Hour + ":" + tempTime.Minute;
        tempTime = Convert.ToDateTime(LineUpToAdd.Until);
        LineUpToAdd.Until = tempTime.Hour+":"+tempTime.Minute;
        LineUp.AddLineUp(LineUpToAdd);
    }
        
    }
}
