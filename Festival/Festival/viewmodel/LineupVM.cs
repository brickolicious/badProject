using BADProject.model;
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

namespace BADProject.viewmodel
{
    class LineupVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Line-up"; }
        }

       
        private List<DateTime> _lstDates;

        public List<DateTime> DatesList
        {
            get {
                _lstDates = Festival.GetFestivalDays();
                return _lstDates; }
            set { _lstDates = value; OnPropertyChanged("DatesList"); }
        }


        private ObservableCollection<Stage> _stageList;

        public ObservableCollection<Stage> StageList
        {
            get {
                _stageList = Stage.GetAllStages();
                return _stageList; }
            set { _stageList = value; OnPropertyChanged("StageList"); }
        }


        private ObservableCollection<StackPanel> _colPodia;

        public ObservableCollection<StackPanel> PodiumCollectie
        {
            get { return _colPodia; }
            set { _colPodia = value; OnPropertyChanged("PodiumCollectie"); }
        }

        private DateTime _selectedDay;

        public DateTime SelectedDay
        {
            get { return _selectedDay; }
            set { _selectedDay = value; OnPropertyChanged("SelectedDay"); }
        }


        private Band _selecBand;

        public Band SelectedBand
        {
            get { return _selecBand; }
            set { _selecBand = value; OnPropertyChanged("SelectedBand"); }
        }
        
        

        







        public ICommand ShowLineUpCommand
        {
            get { return new RelayCommand<DateTime>(ToonLineUp); }
        }

        public void ToonLineUp(DateTime day) {

            SelectedDay = day;
            ObservableCollection<StackPanel> stpnlColLineUpPerDay = new ObservableCollection<StackPanel>();

            

            foreach (Stage stage in StageList) {

                StackPanel stpnlContainer = new StackPanel();

                stpnlContainer.Width = 507;

                TextBlock txbKop = new TextBlock();
                txbKop.Text = stage.Name+"\n"+day.Day+"-"+day.Month+"-"+day.Year;
                txbKop.FontSize = 18;
                txbKop.FontWeight = FontWeights.Bold;
                txbKop.HorizontalAlignment = HorizontalAlignment.Center;
                txbKop.VerticalAlignment = VerticalAlignment.Center;
                Thickness thick = new Thickness();
                thick.Bottom = 15;
                txbKop.Margin = thick;


                ObservableCollection<LineUp> tempLineUp = LineUp.GetLineupByStageAndDate(stage.ID, day);

                
                DataGrid tempDG = new DataGrid();
                tempDG.ItemsSource = tempLineUp;
                tempDG.AutoGenerateColumns = false;


                DataGridTextColumn BandCol = new DataGridTextColumn();
                BandCol.Header = "Band";
               /* BandCol.Binding = {Binding Band.Name} //?*/





                tempDG.RowHeaderWidth = 0;
                tempDG.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                tempDG.Height = 500;
                

                
                stpnlContainer.Children.Add(tempDG);

                stpnlContainer.Children.Add(txbKop);
                stpnlColLineUpPerDay.Add(stpnlContainer);
            }
            
            this.PodiumCollectie = stpnlColLineUpPerDay;
        
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

        public void DeleteDay() {
            try
            {
                int tempID = 1;
                if (DatesList.Count == 1) { MessageBox.Show("Festival needs to have a length of atleast 1 day."); return; }
                DbParameter idPar = DataBase.AddParameter("@id", tempID);
                string sql = "UPDATE FestivalDatums SET EindDatum = EindDatum-1 WHERE id = @id";

                int iModifiedData = DataBase.ModifyData(sql, idPar);
                DatesList = Festival.GetFestivalDays();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void AddDay() {
            try
            {
                int tempID = 1;

                DbParameter idPar = DataBase.AddParameter("@id", tempID);
                string sql = "UPDATE FestivalDatums SET EindDatum = EindDatum+1 WHERE id = @id";

                DataBase.ModifyData(sql, idPar);
                DatesList = Festival.GetFestivalDays();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddStages() {

            AddStage addStage = new AddStage();
            addStage.Show();

        }

        public void AddStageAction(string strStageName) {

            try
            {
                string sql = "INSERT INTO Stage VALUES (@StageName)";
                DbParameter namePar = DataBase.AddParameter("@StageName", strStageName);
                int modifiedData = DataBase.ModifyData(sql, namePar);
                StageList = Stage.GetAllStages();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        
        }

    }
}
