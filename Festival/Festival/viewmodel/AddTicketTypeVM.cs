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
    class AddTicketTypeVM:ObservableObject
    {

        public AddTicketTypeVM()
        {
            Type = new TicketType();
        }



        private static TicketType typename;

        public static TicketType Type
        {
            get { return typename; }
            set { typename = value; /*OnPropertyChanged("Type");*/ }
        }
        


        public ICommand AddTypeAction {

            get { return new RelayCommand(AddType,Type.IsValid); }
        
        }

        private void AddType()
        {
            TicketType.AddTicketType(Type);
            UpdateProps();
        }

        //update van lists in ander VM
        public static event Update OnComplete;
        private void UpdateProps()
        {
            OnComplete(this);
        }

    }
}
