using BADProject.model;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class ContactVM : ObservableObject, IPage
    {

   

        public string Name
        {
            get { return "Contact"; }
        }

   

        private ObservableCollection<ContactPersonType> _conType;

        public ObservableCollection<ContactPersonType> ContactTypeLijst
        {
            get {
                _conType = ContactPersonType.GetAllContactPersonType();
                return _conType; }
            set { _conType = value; }
        }


        private ObservableCollection<ContactPerson> _selectedContactLijst;

        public ObservableCollection<ContactPerson> SelectedContactTypeLijst
        {
            get { return _selectedContactLijst; }
            set { _selectedContactLijst = value; OnPropertyChanged("SelectedContactTypeLijst"); }
        }
        


        private  ContactPersonType _selectedContactType;

        public ContactPersonType SelectedContactType
        {
            get { return _selectedContactType; }
            set { _selectedContactType = value; opVullenMetGeselecteerdeType(); OnPropertyChanged("SelectedContactType"); }
        }

        private ObservableCollection<ContactPersonType> _lstContact;

        //gebruikt voor contact type list in addcontact
        public ObservableCollection<ContactPersonType> ContactList
        {
            get {
                _lstContact = ContactPersonType.GetAllContactPersonType();
                return _lstContact; }
            set { _lstContact = value; }
        }

        private ObservableCollection<ContactPerson> _searchList;

        public ObservableCollection<ContactPerson> SearchList
        {
            get { return _searchList; }
            set { _searchList = value; OnPropertyChanged("SearchList"); }
        }

        private static ContactPerson _editContact;

        public static ContactPerson EditContact
        {
            get { return _editContact; }
            set { _editContact = value; /*OnPropertyChanged("EditContact");*/ }
        }

        
        
        
        

      
        public void opVullenMetGeselecteerdeType(){

            SelectedContactTypeLijst = ContactPerson.GetContactPersonsByJobrole(SelectedContactType.ID);

        }



        public ICommand AddContactCom
        {
            get { return new RelayCommand(ToonAddContact); }
        }

        public void ToonAddContact() {
            
            AddContact openNewContact = new AddContact();
            openNewContact.Show();
        }

        public ICommand AddContactComBtn
        {
            get { return new RelayCommand<ContactPerson>(AddTheContact); }
        }

        public void AddTheContact(ContactPerson contact){
            try
            {
                DbParameter par1 = DataBase.AddParameter("@Name", contact.Name);
                DbParameter par2 = DataBase.AddParameter("@Company", contact.Company);
                DbParameter par3 = DataBase.AddParameter("@ContactPersonType", contact.JobRole.ID);
                DbParameter par4 = DataBase.AddParameter("@City", contact.City);
                DbParameter par5 = DataBase.AddParameter("@Email", contact.Email);
                DbParameter par6 = DataBase.AddParameter("@Phone", contact.Phone);
                DbParameter par7 = DataBase.AddParameter("@CellPhone", contact.CellPhone);
                string sql = "INSERT INTO ContactPerson (Name,Company,JobRole,City,Email,Phone,CellPhone) VALUES (@Name,@Company,@ContactPersonType,@City,@Email,@Phone,@Cellphone)";
                int modifiedRows = DataBase.ModifyData(sql, par1, par2, par3, par4, par5, par6, par7);
                

                
            }catch(Exception ex){
            
                Console.WriteLine(ex);
            
            }

        }

        public ICommand SearchContactCommand
        {
            get { return new RelayCommand(SearchContact); }
        }

        private void SearchContact()
        {
            SearchContact search = new SearchContact();
            search.Show();
        }

        public ICommand SearchContactActionCommand {
            get
            {
                return new RelayCommand<string>(SearchAction);
            }
        }

        private void SearchAction(string strName)
        {
            SearchList = ContactPerson.GetContactByName(strName);
        }


        public ICommand EditContactCommand {
            get {
                return new RelayCommand<ContactPerson>(ShowEditContact);
            }
        }

        private void ShowEditContact(ContactPerson conPers)
        {
            EditContact = conPers;

            EditContact editWindow = new EditContact();
            editWindow.Show();
            ContactTypeLijst = ContactPersonType.GetAllContactPersonType();
        }

        

        public ICommand EditContactComBtn {
            get {
                return new RelayCommand<ContactPerson>(EditContactAction);
            }
        }

        public void EditContactAction(ContactPerson conPer) {

            ContactPerson.UpdateContact(conPer);
        
        }


    }
}
