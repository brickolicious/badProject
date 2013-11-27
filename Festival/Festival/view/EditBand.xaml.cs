using BADProject.model;
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

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            Band tempBand = new Band();
            tempBand.ID = (int)lblID.Content;
            tempBand.Name = lblID.Content.ToString();
            tempBand.Description = txtDescription.Text;
            tempBand.Twitter = txtTwitter.Text;
            tempBand.Facebook = txtFacebook.Text;
            tempBand.GenresInText = txtGenres.Text;
            tempBand.Genres = Genre.GetCollectionOfGenresForBandFromGenresString(tempBand.GenresInText);
            tempBand.Picture = null; //ng toevoegen

            sendBtn.CommandParameter = tempBand;

            this.Close();
        }
    }
}
