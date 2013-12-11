using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class AddContactVM :ObservableObject
    {
        public AddContactVM()
        {
            ContactToAdd = new ContactPerson();
        }

        private ObservableCollection<ContactPersonType> _types;

        public  ObservableCollection<ContactPersonType> TypeList
        {
            get {
                _types = ContactPersonType.GetAllContactPersonType();
                return _types; }
            set { _types = value; }
        }

        private ContactPerson _contact;

        public ContactPerson ContactToAdd
        {
            get { return _contact; }
            set { _contact = value; }
        }



        public ICommand AddContactAction
        {
            get { return new RelayCommand(AddContact); }
        }

        private void AddContact()
        {
            ContactPerson.AddTheContact(ContactToAdd);
        }


    }
}
