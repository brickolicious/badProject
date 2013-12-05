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
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        public EditContact()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactPerson tempCon = new ContactPerson();
            tempCon.ID = Convert.ToInt16(lblID.Content);
            tempCon.Name = txtName.Text;
            tempCon.Company = txtCompany.Text;
            tempCon.City = txtPlace.Text;
            tempCon.Email = txtEmail.Text;
            tempCon.Phone = txtPhone.Text;
            tempCon.CellPhone = txtCellPhone.Text;
            ContactPersonType tempType = (ContactPersonType)cboJobRole.SelectionBoxItem;
            tempCon.JobRole = tempType;

            sendBtn.CommandParameter = tempCon;

            this.Close();
        }
    }
}
