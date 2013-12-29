using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class SearchContactVM : ObservableObject
    {
        public SearchContactVM()
        {
            SearchList = ContactPerson.GetAllContacts();
        }


        private ObservableCollection<ContactPerson> _searchList;

        public ObservableCollection<ContactPerson> SearchList
        {
            get { return _searchList; }
            set { _searchList = value;OnPropertyChanged("SearchList"); }
        }


        private string _namePartial;

        public string Name
        {
            get { return _namePartial; }
            set { _namePartial = value; searchContact(); OnPropertyChanged("Name"); }
        }
        
        

        public ICommand SearchContactActionCommand {

            get { return new RelayCommand(searchContact); }
        
        }

        private void searchContact()
        {
            SearchList = ContactPerson.GetContactByName(Name);
        }
    }
}
