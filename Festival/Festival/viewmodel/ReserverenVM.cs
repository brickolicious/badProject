//using BADProject.model;
using ClassLibraryModels;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace BADProject.viewmodel
{
    class ReserverenVM: ObservableObject,IPage
    {
        public string Name
        {
            get { return "Reserveren"; }
        }


        private ObservableCollection<TicketType> _ticketTypeList;

        public ObservableCollection<TicketType> TicketTypeList
        {
            get {
                _ticketTypeList = TicketType.GetAllTicketTypes();
                return _ticketTypeList; 
            }
            set { _ticketTypeList = value; OnPropertyChanged("TicketTypeList"); }
        }


        private ObservableCollection<Ticket> _filerList;

        public ObservableCollection<Ticket> FilterList
        {
            get { return _filerList; }
            set { _filerList = value; OnPropertyChanged("FilterList"); }
        }
        


        private string _searchtext;
        public string SearchText
        {
            get { return _searchtext; }
            set { _searchtext = value; OnPropertyChanged("SearchText"); }
        }










        public ICommand SearchCommand
        {
            get { return new RelayCommand<KeyEventArgs>(Search); }
        }

        private void Search(KeyEventArgs e)
        {

            FilterList = Ticket.GetVisitorsSearch(SearchText);

            e.Handled = false;
        }

        public ICommand PlaceOrderCommand
        {
            get { return new RelayCommand<Ticket>(Reserveren); }
        }





        public ICommand DeleteTypeCommand
        {
            get { return new RelayCommand<TicketType>(DeleteTicketType); }
        }

        private void DeleteTicketType(TicketType ticketType)
        {

            MessageBoxResult result = MessageBox.Show("This will delete the ticket type along with the orders placed with this type, are you sure?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                TicketType.DeleteTicketTypeAndOrdersPlacedWithThisType(ticketType.ID);
            }
            else { return; }
        }

        

        public ICommand AddTypeCommand {
            get {
                return new RelayCommand(ShowAddType);
            }
        }

        private void ShowAddType()
        {
            AddTicketType ticketTypeView = new AddTicketType();
            ticketTypeView.Show();
        }

        public ICommand AddTypeAction
        {
            get {
                return new RelayCommand<TicketType>(AddTickTypeAction);
            }
        }

        private void AddTickTypeAction(TicketType type)
        {
            MessageBox.Show("add");
            TicketType.AddTicketType(type);
            TicketTypeList = TicketType.GetAllTicketTypes();
        }





        private void Reserveren(Ticket ticket)
        {
            int iPossibleUserID = Ticket.SearchIfUserExistsOrNot(ticket.Name, ticket.Email);

            if (iPossibleUserID != 0)
            {
                ticket.TicketholderID = iPossibleUserID;
                Ticket.PlaceAnOrder(ticket);
            }
            else {
                Ticket.InsertUserAndOrder(ticket);
            }
        }


        

    }
}
