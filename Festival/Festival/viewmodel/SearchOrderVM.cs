using BADProject.view;
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
    class SearchOrderVM:ObservableObject
    {
        public SearchOrderVM()
        {
            SearchList = Ticket.GetAllVisitors();
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private ObservableCollection<Ticket> _colTick;

        public ObservableCollection<Ticket> SearchList
        {
            get { return _colTick; }
            set { _colTick = value; OnPropertyChanged("SearchList"); }
        }
        
        

        public ICommand SearchOrderActionCommand {

            get { return new RelayCommand(SearchOrder); }
        
        }

        private void SearchOrder()
        {
            SearchList = Ticket.GetVisitorsSearch(Name);
        }

        public ICommand EditActionCommand {
            get { return new RelayCommand(EditAction); }
        }

        private void EditAction()
        {
            EditOrder editV = new EditOrder();
            editV.Show();
        }
    }
}
