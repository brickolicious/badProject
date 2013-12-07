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
    /// Interaction logic for AddLineUp.xaml
    /// </summary>
    public partial class AddLineUp : Window
    {
        public AddLineUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LineUp tempLineUp = new LineUp();
            tempLineUp.Date = Convert.ToDateTime(datePicker.Text);

            string[] formatingTime = fromPicker.Value.ToString().Split(' ')[1].Split(':');
            tempLineUp.From = formatingTime[0]+":"+formatingTime[1];
            formatingTime = untilPicker.Value.ToString().Split(' ')[1].Split(':');
            tempLineUp.Until = formatingTime[0] + ":" + formatingTime[1];

            tempLineUp.Band = (Band)cboBand.SelectedItem;
            tempLineUp.Stage = (Stage)cboStage.SelectedItem;

            btnSend.CommandParameter = tempLineUp;
            this.Close();
        }
    }
}
