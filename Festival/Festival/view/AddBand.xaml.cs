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
    /// Interaction logic for AddBand.xaml
    /// </summary>
    public partial class AddBand : Window
    {
        public AddBand()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            Band tempBand = new Band();
            tempBand.Name = txtName.Text;
            tempBand.Description = txtDescription.Text;
            tempBand.Twitter = txtTwitter.Text;
            tempBand.Facebook = txtFacebook.Text;
            tempBand.GenresInText = txtGenres.Text;
            tempBand.Picture = null; //vaste waard in insert
            sendBtn.CommandParameter = tempBand;

            this.Close();
        
        }
    }
}
