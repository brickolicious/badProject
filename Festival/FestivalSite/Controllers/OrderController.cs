using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalSite.ViewModels;

namespace FestivalSite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        
        public ActionResult Index(int? typeID)
        {
            OrderVM ordervm = new OrderVM();

            if (typeID != null)
            {

                ordervm.Message = "Tickets off type " + TicketType.GetTicketTypeByID(typeID).Name + " are sold out.";

            }


            ordervm.OrdersPlacedByUser = Ticket.GetAllReservationsForUser(Ticket.GetUserIDFromUsername(HttpContext.User.Identity.Name));
            ordervm.SelectListTypes = new SelectList(TicketType.GetAllTicketTypes().ToList(), "ID", "Name");
            


            return View("OrderIndex",ordervm);
        }

        
        public ActionResult PlaceOrder(OrderVM order)
        {
            if (order.Amount > TicketType.AvailableTicketsForType(order.SelectedType))
            {
                //bij doorgeven van niet meer te bestellen type wordt de int niet doorgegeven
                int typeID = order.SelectedType;
                return (RedirectToAction("Index", typeID));
            }
            else {

                Ticket tempTick = new Ticket();
                tempTick.TicketholderID = Ticket.GetUserIDFromUsername(User.Identity.Name);
                tempTick.TicketTypeProp = TicketType.GetTicketTypeByID(order.SelectedType);
                tempTick.Amount = order.Amount;

                Ticket.PlaceAnOrder(tempTick);

                return (RedirectToAction("Index"));
            }



            
            
        }

    

        public ActionResult RemoveOrder(int orderID)
        {

            Ticket.DeleteOrder(orderID);

            return (RedirectToAction("Index"));
        }

    }
}
