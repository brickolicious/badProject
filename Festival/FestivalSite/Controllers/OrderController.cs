using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalSite.ViewModels;
using System.Web.Mail;
using System.Net.Mail;

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

        
        public ActionResult PlaceOrder(int type,int Amount)
        {
            if (Amount > TicketType.AvailableTicketsForType(type))
            {
                
                int typeID = type;
                return (RedirectToAction("Index", new { typeID=typeID }));
            }
            else {

                Ticket tempTick = new Ticket();
                tempTick.TicketholderID = Ticket.GetUserIDFromUsername(User.Identity.Name);
                tempTick.TicketTypeProp = TicketType.GetTicketTypeByID(type);
                tempTick.Amount = Amount;

                Ticket.PlaceAnOrder(tempTick);
                /*
                
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("festival@noreply.com");
                mail.To.Add("bart.vandecandelaere@student.howest.be");
                mail.Subject = "Password recovery";
                mail.Body = "Recovering the password";

                SmtpServer.Send(mail);*/


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
