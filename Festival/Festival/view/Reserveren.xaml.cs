//using BADProject.model;
using ClassLibraryModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BADProject.view
{
    /// <summary>
    /// Interaction logic for Reserveren.xaml
    /// </summary>
    public partial class Reserveren : UserControl
    {
        public Reserveren()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ticket tempTicket = new Ticket();
            tempTicket.Name = txtName.Text;
            tempTicket.Email = txtEmail.Text;
            tempTicket.Amount = Convert.ToInt16(txtAmount.Text);
            tempTicket.TicketTypeProp = (TicketType)cboType.SelectedItem;
            btnSend.CommandParameter = tempTicket;
        }


    }
}
