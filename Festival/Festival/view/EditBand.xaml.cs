//using BADProject.model;
using ClassLibraryModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BADProject.view
{
    /// <summary>
    /// Interaction logic for EditBand.xaml
    /// </summary>
    public partial class EditBand : Window
    {
        public EditBand()
        {
            InitializeComponent();
        }

        public Byte[] Photo { get; set; }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            Band tempBand = new Band();
            tempBand.ID = (int)lblID.Content;
            tempBand.Name = lblName.Content.ToString();
            tempBand.Description = txtDescription.Text;
            tempBand.Twitter = txtTwitter.Text;
            tempBand.Facebook = txtFacebook.Text;
            tempBand.GenresInText = txtGenres.Text;
            tempBand.Genres = Genre.GetCollectionOfGenresForBandFromGenresString(tempBand.GenresInText);

            if (this.Photo != null)
            {
                tempBand.Picture = Photo;
            }
            else
            {
                tempBand.Picture = null;
            }

            sendBtn.CommandParameter = tempBand;

            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            oFD.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            oFD.Title = "Please select an image for your band.";
            string fileName;
            if (oFD.ShowDialog() == true)
            {

                fileName = oFD.FileName;
                this.Photo = Band.GetPhoto(fileName);
                imgBand.Source = new ImageSourceConverter().ConvertFromString(fileName) as ImageSource;
            }



        }
    }
}
