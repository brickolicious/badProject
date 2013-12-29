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


        //enable disable via codebehind validatie via annotations IsValid flipt op het feit dat een andere lijst ook mijn controls gaan updaten
        #region enable/disable button
        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void Check() {
        if (txtName.Text != string.Empty && txtEmail.Text != string.Empty && txtAmount.Text != string.Empty && cboType.SelectedItem != null)
        {
              btnSend.IsEnabled = true;
        }
       }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
        }
        #endregion
    }
}
