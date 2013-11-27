using BADProject.model;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class BandsVM : ObservableObject, IPage
    {
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

        private static Band _selectedBand;

        public static Band SelectedBand
        {
            get { return _selectedBand; }
            set { _selectedBand = value; /*OnPropertyChanged("SelectedBand");*/ }
        }
        






        public ICommand AddBandCommand
        {
            get { return new RelayCommand(ToonAddBand); }
        }

        public void ToonAddBand() {

            AddBand addBandWindow = new AddBand();
            addBandWindow.Show();

        }

        public ICommand AddBandActionCommand
        {
            get { return new RelayCommand<Band>(AddBandAction); }
        }

        private void AddBandAction(Band band)
        {
            Genre.InsertBandAndOrAttachGenres(band);
        }
        


        public ICommand DeleteBandCommand
        {
            get { return new RelayCommand<Band>(DeleteBand); }
        }

        private void DeleteBand(Band band)
        {
            Band.DeleteBand(band.ID);
        }

        public ICommand EditBandCommand
        {
            get { return new RelayCommand<Band>(EditSelectedBand); }
        }

        private void EditSelectedBand(Band band)
        {
            SelectedBand = band;
            EditBand viewEditBand = new EditBand();
            viewEditBand.Show();
        }

        public ICommand EditBandActionCommand {
            get { return new RelayCommand<Band>(EditAction); }
        }

        private void EditAction(Band band)
        {
            
            Genre.InsertBandAndOrAttachGenres(band);
        }






        public ICommand PictureCommand
        {
            get { return new RelayCommand(AddPictureToDB); }
        }

        private void AddPictureToDB()
        {
            
        }




        


    }
}
