//using BADProject.model;
using ClassLibraryModels;
using BADProject.viewmodel;
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
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public EditOrder()
        {
            InitializeComponent();
        }




        //window wil enkel binden aan static prop, static prop heeft geen porpchanged
        //bij instantie maken worden velden gewist dus validatie in codebehind
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool result = Int32.TryParse(txtAmount.Text, out number);
            if (txtAmount.Text == string.Empty || result == false || cboTicketType.SelectedItem== null)
            {

                sendBtn.IsEnabled = false;
                    
            }
            else
            {
                sendBtn.IsEnabled = true;
            }
        }


        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
           
            
            this.Close();
        }


        
    }
}
