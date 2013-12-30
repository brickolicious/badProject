using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibraryModels;

namespace FestivalSite.ViewModels
{
    public class AdminPanelVM
    {
        public AdminPanelVM()
        {
            
            TicketTypes = TicketType.GetAllTicketTypes().ToList();
        }

        public List<TicketType> TicketTypes { get; set; }
        public RSSmodel Rss { get; set; }
        public string Message { get; set; }

    }
}