using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.ViewModels
{
    public class OrderVM
    {
        public List<Ticket> OrdersPlacedByUser { get; set; }
        public Ticket Order { get; set; }
        public SelectList SelectListTypes { get; set; }
        public int SelectedType { get; set; }
        public int Amount { get; set; }
        public Reservation ReservationByUser { get; set; }
        public string Message { get; set; }
    
    }
}