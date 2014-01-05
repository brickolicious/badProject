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

        public ICommand ShowRemoveGenreCommand {
            get { return new RelayCommand(ShowRemoveGenre); }
        }

        #endregion



        #region commandFunctions

        private void ShowRemoveGenre()
        {
            RemoveGenres removeGenreView = new RemoveGenres();
            RemoveGenreVM.OnComplete += RemoveGenreVM_OnComplete;
            removeGenreView.ShowDialog();
        }

        void RemoveGenreVM_OnComplete(object sender)
        {
            Bands = Band.GetBands();
        }

        public void ToonAddBand() {

            AddBand addBandWindow = new AddBand();
            AddBandVM.OnComplete += AddBandVM_OnComplete;
            addBandWindow.ShowDialog();



        }

        private void AddBandVM_OnComplete(object sender)
        {
            UpdatePropsForBands();
        }

        private void AddBandAction(Band band)
        {
            Genre.InsertBandAndOrAttachGenres(band);
            Bands = Band.GetBands();
        }
        
        private void DeleteBand(Band band)
        {
            MessageBoxResult result = MessageBox.Show("Removing this band will also remove all the line-up elements coupled to this band.\nAre you sure?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                Band.DeleteBand(band.ID);
                Bands = Band.GetBands();
            }
            else { return; }
        }

        private void EditSelectedBand(Band band)
        {
            SelectedBand = band;
            EditBand viewEditBand = new EditBand();
            EditBandVM.OnComplete += EditBandVM_OnComplete;
            viewEditBand.ShowDialog();
        }

        void EditBandVM_OnComplete(object sender)
        {
            UpdatePropsForBands();
        }

        private void EditAction(Band band)
        {
            
            Genre.InsertBandAndOrAttachGenres(band);
        }

        private void UpdatePropsForBands() {

            Bands = Band.GetBands();
        
        }
        #endregion


        


    }
}
