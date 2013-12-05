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
using System.Windows.Shapes;

namespace BADProject.view
{
    /// <summary>
    /// Interaction logic for AddTicketType.xaml
    /// </summary>
    public partial class AddTicketType : Window
    {
        public AddTicketType()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            TicketType tempType = new TicketType();
            tempType.Name = txtName.Text;
            tempType.Price = Convert.ToDouble(txtPrice.Text);
            tempType.TotalTickets = Convert.ToInt16(txtTotal.Text);
            sendBtn.CommandParameter = tempType;


            this.Close();
        }
    }
}
