using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class Reservation
    {

        public int ID { get; set; }
        public int TicketHolderID { get; set; }
        public int TicketTypeID { get; set; }
        public int Amount { get; set; }
    }
}
