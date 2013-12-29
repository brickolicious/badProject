//using BADProject.model;
using ClassLibraryModels;
using BADProject.view;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace BADProject.viewmodel
{
    class BezoekersVM: ObservableObject,IPage
    {


        #region props
        public string Name
        {
            get { return "Visitors"; }
        }

    

        private ObservableCollection<Ticket> _tickList;

        public ObservableCollection<Ticket> TicketList
        {
            get {
                _tickList = Ticket.GetAllVisitors();
                return _tickList; }
            set { _tickList = value;OnPropertyChanged("TicketList"); }
        }

        private static Ticket _selectedTicket;

        public static Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set { _selectedTicket = value;}
        }

        private ObservableCollection<TicketType> _tickTypList;

        public ObservableCollection<TicketType> TicketTypeList
        {
            get {
                _tickTypList = TicketType.GetAllTicketTypes();
                return _tickTypList; }
            set { _tickTypList = value; OnPropertyChanged("TicketTypeList"); }
        }


        private ObservableCollection<Ticket> _SearchList;

        public ObservableCollection<Ticket> SearchList
        {
            get { return _SearchList; }
            set { _SearchList = value; OnPropertyChanged("SearchList"); }
        }


        #endregion

        #region commands
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchOrders);
            }
        }

        public ICommand SearchOrderActionCommand
        {
            get {
                return new RelayCommand<string>(SearchAction);
            }
        }


        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand<Ticket>(DeleteOrder);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand<Ticket>(EditAnOrder);
            }
        }

        public ICommand EditActionCommand
        {
            get {
                return new RelayCommand<Ticket>(EditOrderAction);
            }
        }

        public ICommand PrintOrderCommand
        {
            get { return new RelayCommand<Ticket>(PrintOrder); }
        }

        
        #endregion

        #region commandFunctions
        private void PrintOrder(Ticket order)
        {
            Ticket.PrintOrder(order);
        }

        private void SearchOrders()
        {

            SearchOrder searchView = new SearchOrder();
            searchView.Show();

        }

        private void DeleteOrder(Ticket ticket)
        {
            Ticket.DeleteOrder(ticket.ID);
            TicketList = Ticket.GetAllVisitors();

        }

        private void EditAnOrder(Ticket ticket)
        {
            //SelectedTicket = ticket;
            EditOrder editOrderView = new EditOrder();
            editOrderView.Show();
        }

        private void EditOrderAction(Ticket ticket)
        {
            Ticket.UpdateOrder(ticket);
            ObservableCollection<Ticket> lstTemp = new ObservableCollection<Ticket>();
            TicketList = lstTemp;
            TicketList = Ticket.GetAllVisitors();
            
        }

        public void SearchAction(string namePartial) {

            SearchList = Ticket.GetVisitorsSearch(namePartial);

        }
        #endregion




    }
}
