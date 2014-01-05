using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BADProject.viewmodel
{
    class EditBandVM:ObservableObject
    {
        public EditBandVM()
        {
            //SelectedBandNonStatic = new Band();
            Photo = new Image();
            //SelectedBandNonStatic = new Band();
        }

        #region props
        private static Band _selected ;

        public static Band SelectedBand
        {
            get { return _selected; }
            set { _selected = value; }
        }


        private Band _selecBandNonStat;

        public Band SelectedBandNonStatic
        {
            get { return _selecBandNonStat; }
            set { _selecBandNonStat = value; SelectedBand = _selecBandNonStat; OnPropertyChanged("SelectedBandNonStatic"); }
        }
        

        private Image _photo;

        public Image Photo
        {
            get { return _photo; }
            set { _photo = value; OnPropertyChanged("Photo"); }
        }


        private byte[] _pic;

        public byte[] Pic
        {
            get { return _pic; }
            set { _pic = value; OnPropertyChanged("Pic"); }
        }
        #endregion

        #region commands
        public ICommand ChoosePictureCommand {

            get { return new RelayCommand(GetPicture); }
        
        }

        public ICommand FacebookCommand
        {

            get { return new RelayCommand(ShowFacebook); }

        }

        public ICommand TwitterCommand
        {

            get { return new RelayCommand(ShowTwitter); }

        }

        public ICommand EditBandAction {
            get { return new RelayCommand(SaveChanges,SelectedBand.IsValid); }
        }

        public ICommand RemoveBand
        {

            get { return new RelayCommand(RemoveBandAction); }

        }

        #endregion

        //save changes made to a band
        private void SaveChanges()
        {
            //MessageBox.Show("bla");
           // SelectedBand.Picture = Pic;
            Genre.InsertBandAndOrAttachGenres(SelectedBand);

            UpdateProps();
        }

        public static event Update OnComplete;
        private void UpdateProps()
        {
            OnComplete(this);
        }

        //calls functions to remove the band
        private void RemoveBandAction()
        {
            MessageBoxResult result = MessageBox.Show("Removing this band will also remove all the line-up elements coupled to this band.\nAre you sure?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                Band.DeleteBand(this.SelectedBandNonStatic.ID);
            }
            else { return; }
        }

        //open filedialog to get image path
        private void GetPicture()
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            oFD.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            oFD.Title = "Please select an image for your band.";
            string fileName;
            if (oFD.ShowDialog() == true)
            {

                fileName = oFD.FileName;
                this.SelectedBandNonStatic = SelectedBand;
                Pic = Band.GetPhoto(fileName);
                this.SelectedBandNonStatic.Picture = Band.GetPhoto(fileName);
                //Photo.Source = new ImageSourceConverter().ConvertFromString(fileName) as ImageSource;

            }


        }

        //open link to socialmedia of band called when clicked on the icons
        private void ShowFacebook()
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://www.facebook.com/" + SelectedBandNonStatic.Facebook);
                Process.Start(sInfo);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        private void ShowTwitter()
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://www.twitter.com/" + SelectedBandNonStatic.Twitter);
                Process.Start(sInfo);
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
