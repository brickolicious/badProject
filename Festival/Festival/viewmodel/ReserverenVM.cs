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
        public ReserverenVM()
        {
            TicketOrder = new Ticket();
        }

        #region props
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


        private Ticket _ticketOrder;

        public Ticket TicketOrder
        {
            get { return _ticketOrder; }
            set { _ticketOrder = value; OnPropertyChanged("TicketOrder"); }
        }
        

        #endregion


        #region commands
        public ICommand SearchCommand
        {
            get { return new RelayCommand<KeyEventArgs>(Search); }
        }

        
        public ICommand PlaceOrderCommand
        {
            get { return new RelayCommand(Reserveren); }
        }


        public ICommand DeleteTypeCommand
        {
            get { return new RelayCommand<TicketType>(DeleteTicketType); }
        }


        public ICommand AddTypeCommand {
            get {
                return new RelayCommand(ShowAddType);
            }
        }


        public ICommand AddTypeAction
        {
            get {
                return new RelayCommand<TicketType>(AddTickTypeAction);
            }
        }

        #endregion

        #region functions
        private void AddTickTypeAction(TicketType type)
        {
            MessageBox.Show("add");
            TicketType.AddTicketType(type);
            TicketTypeList = TicketType.GetAllTicketTypes();
        }





        private void Reserveren()
        {
            int iPossibleUserID = Ticket.SearchIfUserExistsOrNot(this.TicketOrder.Name, this.TicketOrder.Email);

            if (iPossibleUserID != 0)
            {
                TicketOrder.TicketholderID = iPossibleUserID;
                Ticket.PlaceAnOrder(TicketOrder);
            }
            else {
                Ticket.InsertUserAndOrder(TicketOrder);
            }
            MessageBox.Show("A ticket has been orderd for: " + TicketOrder.Name);
        }

        private void Search(KeyEventArgs e)
        {

            FilterList = Ticket.GetVisitorsSearch(SearchText);

            e.Handled = false;
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


        private void ShowAddType()
        {
            AddTicketType ticketTypeView = new AddTicketType();
            ticketTypeView.Show();
        }
        #endregion
    }
}
