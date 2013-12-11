//using BADProject.model;
using ClassLibraryModels;
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


        #region prop
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
            set { _conType = value; OnPropertyChanged("ContactTypeLijst"); }
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
            set { _selectedContactType = value; opVullenMetGeselecteerdeType();OnPropertyChanged("SelectedContactType"); }
        }

        private ObservableCollection<ContactPersonType> _lstContact;

        //gebruikt voor contact type list in addcontact
        public ObservableCollection<ContactPersonType> ContactList
        {
            get {
                _lstContact = ContactPersonType.GetAllContactPersonType();
                return _lstContact; }
            set { _lstContact = value; OnPropertyChanged("ContactList"); }
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

        #endregion



        #region Commands
        public ICommand AddContactCom
        {
            get { return new RelayCommand(ToonAddContact); }
        }

        public ICommand AddContactComBtn
        {
            get { return new RelayCommand<ContactPerson>(AddTheContact); }
        }

        public ICommand SearchContactCommand
        {
            get { return new RelayCommand(SearchContact); }
        }


        public ICommand SearchContactActionCommand {
            get
            {
                return new RelayCommand<string>(SearchAction);
            }
        }

        public ICommand EditContactCommand
        {
            get {
                return new RelayCommand(ShowEditContact);
            }
        }

        public ICommand EditContactComBtn {
            get {
                return new RelayCommand<ContactPerson>(EditContactAction);
            }
        }


        public ICommand AddContactTypeCommand {
            get { return new RelayCommand(OpenAddContactType); }
        }

        
        public ICommand AddCategory
        {
            get { return new RelayCommand<string>(AddCategoryAction); }
        }

        public ICommand DeleteContactTypeCommand
        {
            get { return new RelayCommand<ContactPersonType>(DeleteTypeAction); }
        }


        public ICommand DeleteContact
        {
            get { return new RelayCommand<ContactPerson>(DeleteContactAction); }
        }

#endregion


        #region commandFunctions

        public void ToonAddContact()
        {

            AddContact openNewContact = new AddContact();
            openNewContact.Show();
        }

        private void AddTheContact(ContactPerson person)
        {
            ContactPerson.AddTheContact(person);
        }

        private void DeleteTypeAction(ContactPersonType ConType)
        {
            ContactPersonType.DeleteContactType(ConType.ID);
        }

        private void DeleteContactAction(ContactPerson contact)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete this contact?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ContactPerson.DeleteContact(contact.ID);
            }
            else { return; }
        }

        private void AddCategoryAction(string strName)
        {

            if (!String.IsNullOrEmpty(strName))
            {
                ContactPersonType.AddContactType(strName);
            }

        }

        private void OpenAddContactType()
        {
            AddContactType viewAddType = new AddContactType();
            viewAddType.Show();
        }


        public void EditContactAction(ContactPerson conPer)
        {

            ContactPerson.UpdateContact(conPer);

        }

        private void ShowEditContact()
        {
            //EditContact = conPers;

            EditContact editWindow = new EditContact();
            editWindow.Show();
        }

        private void SearchAction(string strName)
        {
            SearchList = ContactPerson.GetContactByName(strName);
        }


        private void SearchContact()
        {
            SearchContact search = new SearchContact();
            search.Show();
        }

        public void opVullenMetGeselecteerdeType()
        {

            SelectedContactTypeLijst = ContactPerson.GetContactPersonsByJobrole(SelectedContactType.ID);

        }
        #endregion
    }
}
