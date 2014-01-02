//using BADProject.model;
using ClassLibraryModels;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Timers;

namespace BADProject.viewmodel
{
    class LineupVM : ObservableObject, IPage
    {
        public LineupVM()
        {
            this.StageList = Stage.GetAllStages();


        }


      





        #region props

        public string Name
        {
            get { return "Line-up"; }
        }


     
        

        private ObservableCollection<DateTime> _lstDates;

        public ObservableCollection<DateTime> DatesList
        {
            get
            {
                _lstDates = Festival.GetFestivalDays();
                return _lstDates;
            }
            set { _lstDates = value; OnPropertyChanged("DatesList"); }
        }
        


        private ObservableCollection<StackPanel> _colPodia;

        public ObservableCollection<StackPanel> PodiumCollectie
        {
            get { return _colPodia; }
            set { _colPodia = value; OnPropertyChanged("PodiumCollectie"); }
        }

        private Band _selecBand;

        public Band SelectedBand
        {
            get { return _selecBand; }
            set { _selecBand = value; OnPropertyChanged("SelectedBand"); }
        }


        private DateTime _selectedDay;

        public DateTime SelectedDay
        {
            get { return _selectedDay; }
            set { _selectedDay = value; OnPropertyChanged("SelectedDay"); }
        }

        private ObservableCollection<Stage> _stageList;

        public ObservableCollection<Stage> StageList
        {
            get
            {
               // _stageList = Stage.GetAllStages();
                return _stageList;
            }
            set { _stageList = value; OnPropertyChanged("StageList"); }
        }

        private Stage _stageForTheLineup;

        public Stage StageForTheLineup
        {
            get { return _stageForTheLineup; }
            set { _stageForTheLineup = value; OnPropertyChanged("StageForTheLineup"); }
        }

       
        private ObservableCollection<ObservableCollection<LineUp>> _perstagePerdag;

        public ObservableCollection<ObservableCollection<LineUp>> LineUpPerStage
        {
            get { return _perstagePerdag; }
            set { _perstagePerdag = value; OnPropertyChanged("LineUpPerStage"); }
        }

        private LineUp _selectedLineup;

        public LineUp SelectedLineup
        {
            get { return _selectedLineup; }
            set { _selectedLineup = value; OnPropertyChanged("SelectedLineup"); }
        }

        #endregion


        #region commands

        public ICommand ShowLineUpCommand
        {
            get { return new RelayCommand<DateTime>(ToonLineUp); }
        }

        public ICommand DeleteDayCommand
        {
            get { return new RelayCommand(DeleteDay); }
        }

        

        public ICommand AddDayCommand
        {
            get { return new RelayCommand(AddDay); }
        }

        public ICommand AddStageCommand
        {
            get { return new RelayCommand(AddStages); }
        }


        public ICommand AddStageActionCom
        {
            get { return new RelayCommand<string>(AddStageAction); }
        }

        
        public ICommand ShowAddLineUp {
            get { return new RelayCommand(ShowAddLineUpAction); }
        }

        public ICommand AddLineUpAction {
            get { return new RelayCommand<LineUp>(AddAction); }
        }


        public ICommand RemoveLineUp
        {
            get { return new RelayCommand<LineUp>(RemoveLineUpAction); }
        }

        
        public ICommand DeleteStageCommand
        {
            get { return new RelayCommand(ShowRemoveStage); }
        }

        public ICommand RemoveStageAction
        {
            get { return new RelayCommand<Stage>(RemoveAction); }
        }

        public ICommand SetStartCommand {
            get { return new RelayCommand<DateTime>(SetStartDay); }
        }

      
        #endregion


        #region commandFunctions
        private void SetStartDay(DateTime startDay)
        {
            Festival.SetStartDay(startDay);
            this.DatesList = Festival.GetFestivalDays();
        }

        private void RemoveAction(Stage stage)
        {
            if (stage != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete this stage?\nDeleting this stage will also delete all of the line-up elements coupled with it for each day.", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Stage.RemoveStageAndItsLineup(stage.ID);
                }
                else { return; }
            }
            else { return; }
        }

        public void ToonLineUp(DateTime day)
        {

            SelectedDay = day;
            StageList = Stage.GetAllStages(day);

        }

        public void DeleteDay()
        {
            Festival.RemoveDay(DatesList.Count);
            DatesList = Festival.GetFestivalDays();
        }


        public void AddDay()
        {
            Festival.AddDay();
            DatesList = Festival.GetFestivalDays();
        }

        public void AddStages()
        {

            AddStage addStage = new AddStage();
            AddStageVM.OnComplete += AddStageVM_OnComplete;
            addStage.ShowDialog();

        }

      

        public void AddStageAction(string strStageName)
        {

            Stage.AddStageAction(strStageName);
            StageList = Stage.GetAllStages();

        }

        private void RemoveLineUpAction(LineUp lineup)
        {

            //MessageBox.Show("test "+lineup.ID);
            if (lineup != null)
            {
                LineUp.DeleteLineUpElement(lineup.ID);
                StageList = Stage.GetAllStages();
            }
        }

        private void ShowRemoveStage()
        {
            RemoveStage removeView = new RemoveStage();
            removeView.ShowDialog();
        }


        private void AddAction(LineUp lineup)
        {
            LineUp.AddLineUp(lineup);
        }

        private void ShowAddLineUpAction()
        {
            AddLineUp addLineUpView = new AddLineUp();
            AddLineUpVM.OnComplete += AddLineUpVM_OnComplete;
            addLineUpView.ShowDialog();
        }

        void AddLineUpVM_OnComplete(object sender)
        {
            ToonLineUp(SelectedDay);
        }

        #endregion


        void AddStageVM_OnComplete(object sender)
        {
            ToonLineUp(SelectedDay);
        }
    }
}
