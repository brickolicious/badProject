using ClassLibraryModels;
//using BADProject.model;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace BADProject.viewmodel
{
    class BandsVM : ObservableObject, IPage
    {

        #region props
        public string Name
        {
            get { return "Bands"; }
        }


        private ObservableCollection<Band> _bands;

        public ObservableCollection<Band> Bands
        {
            get {
               
                _bands = Band.GetBands();
                return _bands; 
            }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }

        private Band _selectedBand;
        //geen binding tenzij deze prop static is
        public Band SelectedBand
        {
            get { return _selectedBand; }
            set { _selectedBand = value; SelectedBandStatic = _selectedBand; OnPropertyChanged("SelectedBand"); }
        }

        private static Band _selectedBandStatic;

        public static Band SelectedBandStatic
        {
            get { return _selectedBandStatic; }
            set { _selectedBandStatic = value; }
        }
        #endregion


        #region commands

        public ICommand AddBandShowCommand
        {
            get { return new RelayCommand(ToonAddBand); }
        }

        public ICommand AddBandActionCommand
        {
            get { return new RelayCommand<Band>(AddBandAction); }
        }

        public ICommand DeleteBandCommand
        {
            get { return new RelayCommand<Band>(DeleteBand); }
        }

        public ICommand EditBandCommand
        {
            get { return new RelayCommand<Band>(EditSelectedBand); }
        }

        public ICommand EditBandActionCommand
        {
            get { return new RelayCommand<Band>(EditAction); }
        }
        #endregion



        #region commandFunctions
        public void ToonAddBand() {

            AddBand addBandWindow = new AddBand();
            addBandWindow.Show();

        }

        

        private void AddBandAction(Band band)
        {
            Genre.InsertBandAndOrAttachGenres(band);
        }
        


        

        private void DeleteBand(Band band)
        {
            Band.DeleteBand(band.ID);
        }

        

        private void EditSelectedBand(Band band)
        {
            SelectedBand = band;
            EditBand viewEditBand = new EditBand();
            viewEditBand.Show();
        }

        

        private void EditAction(Band band)
        {
            
            Genre.InsertBandAndOrAttachGenres(band);
        }

        #endregion




    }
}
