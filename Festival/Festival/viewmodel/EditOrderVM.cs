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
    class EditOrderVM:ObservableObject
    {
        public EditOrderVM()
        {
           //SelectedTicket = new Ticket();
        }


        private int _indexOfCBO;

        public int TicketTypePosition
        {
            get { return _indexOfCBO; }
            set { _indexOfCBO = value; }
        }
        


        private static Ticket _selectedTicketStatic;

        public static Ticket SelectedTicketStatic
        {
            get { return _selectedTicketStatic; }
            set { _selectedTicketStatic = value; }
        }
        

        private Ticket _selecTick;

        public Ticket SelectedTicket
        {
            get { return _selecTick; }
            set { _selecTick = value; SelectedTicketStatic = _selecTick; SetIndexForComboBoxType(); OnPropertyChanged("SelectedTicket"); }
        }

        private ObservableCollection<TicketType> _typeList;

        public ObservableCollection<TicketType> TypeList
        {
            get {
                _typeList = TicketType.GetAllTicketTypes();
                return _typeList; }
            set { _typeList = value; }
        }
        


        public ICommand EditActionCommand {
            get { return new RelayCommand(EditOrder, SelectedTicketStatic.IsValid); }
        }

        private void EditOrder()
        {
            Ticket updateTicket = SelectedTicketStatic;
            updateTicket.Amount = 0;
            
            Ticket.UpdateOrder(SelectedTicketStatic);
        }



        public void SetIndexForComboBoxType()
        {
            //lukt niet om via XAML dus int prop binden aan index

            if (SelectedTicket == null || SelectedTicket.TicketTypeProp == null) { return; }
            int iTeller = 1;
            foreach (TicketType type in TicketType.GetAllTicketTypes())
            {
                if (SelectedTicket.TicketTypeProp.ID == type.ID)
                {

                    TicketTypePosition = iTeller;
                    
                }
                iTeller++;
            }

        }

        


    }
}
