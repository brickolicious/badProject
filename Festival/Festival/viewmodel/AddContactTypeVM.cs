using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class AddContactTypeVM:ObservableObject
    {
        public AddContactTypeVM()
        {
            Name = new ContactPersonType();
        }

        private ContactPersonType _name;

        public ContactPersonType Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        


        public ICommand AddTypeCommand {
            get { return new RelayCommand(AddTypeAction,Name.IsValid); }
        }

        private void AddTypeAction()
        {
            ContactPersonType.AddContactType(Name.Name);
            UpdateProps();
        }

        //updates lists in other VM
        public static event Update OnComplete;
        private void UpdateProps()
        {
            OnComplete(this);
        }
        
    }
}
