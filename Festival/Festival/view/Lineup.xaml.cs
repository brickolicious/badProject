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
using Microsoft.VisualBasic;

namespace BADProject.view
{
    /// <summary>
    /// Interaction logic for PartOne.xaml
    /// </summary>
    public partial class Lineup : UserControl
    {
        public Lineup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datePick.Visibility = Visibility.Visible;
            btnDate.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Visible;
        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            
            btnSubmit.CommandParameter = datePick.SelectedDate;

            datePick.Visibility = Visibility.Hidden;
            btnDate.Visibility = Visibility.Visible;
            btnSubmit.Visibility = Visibility.Hidden;


        }


        

       

        

    }
}
