using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using BADProject.view;
using System.Windows;

namespace BADProject.viewmodel
{
    class EditContactVM:ObservableObject
    {
        public EditContactVM()
        {
            
        }

        private static ContactPerson selected;

        public static ContactPerson SelectedContactStatic
        {
            get { return selected; }
            set { selected = value; }
        }
        

        private ContactPerson _contact;

        public ContactPerson SelectedContact
        {
            get { return _contact; }
            set { _contact = value; SelectedContactStatic = _contact; OnPropertyChanged("SelectedContact"); }
        }

        private ObservableCollection<ContactPersonType>  _types;

        public ObservableCollection<ContactPersonType> TypeList
        {
            get {
                _types = ContactPersonType.GetAllContactPersonType();
                return _types; }
            set { _types = value; }
        }


        public ICommand EditContactAction
        {
            get { return new RelayCommand(EditAction,SelectedContactStatic.IsValid); }
        }

        private void EditAction()
        {
            ContactPerson.UpdateContact(SelectedContactStatic);
        }



        public ICommand DeleteContactCommand {

            get { return new RelayCommand(RemoveContact); }
        
        }

        private void RemoveContact()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this contact.", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ContactPerson.DeleteContact(SelectedContactStatic.ID);
            }
            else { return; }
        }


    }
}
