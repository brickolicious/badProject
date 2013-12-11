﻿using ClassLibraryModels;
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

            get { return new RelayCommand(AddType); }
        
        }

        private void AddType()
        {
            TicketType.AddTicketType(Type);
        }

    }
}