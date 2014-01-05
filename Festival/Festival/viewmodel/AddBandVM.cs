using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BADProject.viewmodel
{
    class AddBandVM : ObservableObject
    {

        


        public AddBandVM()
        {
            BandToAdd = new Band();
        }


        #region props
        private Band _band;

        public Band BandToAdd
        {
            get { return _band; }
            set { _band = value; }
        }

        private Image pic;

        public Image Photo
        {
            get { return pic; }
            set { pic = value; OnPropertyChanged("Photo"); }
        }
        
#endregion


        public ICommand AddToBands {

            get { return new RelayCommand(AddBand,BandToAdd.IsValid); }
        
        }

        public ICommand ChoosePictureCommand {
            get { return new RelayCommand(GetPicture); }
        }



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
                BandToAdd.Picture = Band.GetPhoto(fileName);
                Photo = new Image();
                Photo.Source = new ImageSourceConverter().ConvertFromString(fileName) as ImageSource;
            }
        }

        private void AddBand()
        {
            
            Genre.InsertBandAndOrAttachGenres(BandToAdd);

            UpdateProps();
        }



        //updates lists in other VMs
        public static event Update OnComplete;
        private void UpdateProps() {
            OnComplete(this);
        }
    }
}
