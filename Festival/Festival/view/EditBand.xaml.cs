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

        //public Byte[] Photo { get; set; }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       


        
    }
}
