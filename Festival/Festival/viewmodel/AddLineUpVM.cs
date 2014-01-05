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

        #region props
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

        #endregion

    public ICommand AddToLineup {

        get { return new RelayCommand(AddLineup,LineUpToAdd.IsValid); }

    }

    //adds line up to database
    //because the prop for the times is string the time needs to be cut up to fit
    private void AddLineup()
    {

        #region tijd
        string[] splitArr = LineUpToAdd.From.Split(' ');
        string[] subSplitArr = splitArr[1].Split(':');
        if (subSplitArr[0].Length == 1) {
            subSplitArr[0] = 0 + subSplitArr[0];
        }
        if (subSplitArr[0].Length == 1)
        {
            subSplitArr[1] = 0 + subSplitArr[1];
        }



        LineUpToAdd.From = subSplitArr[0]+":"+subSplitArr[1]+" "+splitArr[2];

        splitArr = LineUpToAdd.Until.Split(' ');
        subSplitArr = splitArr[1].Split(':');
        if (subSplitArr[0].Length == 1)
        {
            subSplitArr[0] = 0 + subSplitArr[0];
        }
        if (subSplitArr[0].Length == 1)
        {
            subSplitArr[1] = 0 + subSplitArr[1];
        }
        LineUpToAdd.Until = subSplitArr[0] + ":" + subSplitArr[1] + " " + splitArr[2];
        #endregion


        LineUp.AddLineUp(LineUpToAdd);

        UpdateProps();
    }

    //updates lists in other VM
    public static event Update OnComplete;
    private void UpdateProps()
    {
        OnComplete(this);
    }
        
    }
}
