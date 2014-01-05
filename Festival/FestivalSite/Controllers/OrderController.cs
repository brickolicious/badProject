﻿using ClassLibraryModels;
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

                ordervm.Message = "Tickets off type " + TicketType.GetTicketTypeByID(typeID).Name + " are sold out or not available in this amount.";

            }
            

            ordervm.OrdersPlacedByUser = Ticket.GetAllReservationsForUser(Ticket.GetUserIDFromUsername(HttpContext.User.Identity.Name));
            ordervm.SelectListTypes = new SelectList(TicketType.GetAllTicketTypes().ToList(), "ID", "Name");
            


            return View("OrderIndex",ordervm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PlaceOrder(OrderVM orderVM)
        {

            if (orderVM.SelectedType == 0 || orderVM.Amount == 0 || orderVM.Amount == null)
            {

                return (RedirectToAction("Index"));

            }

            if (orderVM.Amount > TicketType.AvailableTicketsForType(orderVM.SelectedType))
            {
                
                int typeID = orderVM.SelectedType;
                return (RedirectToAction("Index", new { typeID=typeID }));
            }
            else {

                Ticket tempTick = new Ticket();
                tempTick.TicketholderID = Ticket.GetUserIDFromUsername(User.Identity.Name);
                tempTick.TicketTypeProp = TicketType.GetTicketTypeByID(orderVM.SelectedType);
                tempTick.Amount = orderVM.Amount;

                Ticket.PlaceAnOrder(tempTick);


               try
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    string emailTo = Ticket.GetUserEmailFromUsername(HttpContext.User.Identity.Name);
                    mail.To.Add(emailTo);
                    mail.From = new MailAddress("festivalManagerSSA@gmail.com");
                    mail.Subject = "Order confirmation";

                    mail.IsBodyHtml = true;
                    //string Body = "U heeft zonet " + orderVM.Amount + " tickets besteld van het type " + TicketType.GetTicketTypeByID(orderVM.SelectedType).Name + " .";
                    string body = "<html><head><title>Festival order</title></head><body><h3>U plaatste zonet volgend order:</h3><table><tr><td style=padding-left:10px;padding-right:10px;>Ticket</td><td  style=padding-left:10px;padding-right:10px;>Aantal</td><td  style=padding-left:10px;padding-right:10px;>Prijs</td></tr><tr><td>" + TicketType.GetTicketTypeByID(orderVM.SelectedType).Name + "</td><td style=text-align:center;>" + orderVM.Amount + "</td><td>€" + TicketType.GetTicketTypeByID(orderVM.SelectedType).Price * orderVM.Amount + "</td></tr></table></body></html>";
                   
                   
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("festivalManagerSSA@gmail.com", "rootroot123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    

                }
                catch (Exception ex) {

                    Console.WriteLine("Mail not send");
                
                }


                return (RedirectToAction("Index"));
            }



            
            
        }

    
        [Authorize]
        public ActionResult RemoveOrder(int orderID)
        {

            Ticket.DeleteOrder(orderID);




            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                string emailTo = Ticket.GetUserEmailFromUsername(HttpContext.User.Identity.Name);
                mail.To.Add(emailTo);
                mail.From = new MailAddress("festivalManagerSSA@gmail.com");
                mail.Subject = "Order confirmation";
                string Body = "U heeft zonet uw ticket order met ordernummer: " + orderID + " geannuleerd.";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("festivalManagerSSA@gmail.com", "rootroot123");
                smtp.EnableSsl = true;
                smtp.Send(mail);


            }
            catch (Exception ex)
            {

                Console.WriteLine("Mail not send");

            }





            return (RedirectToAction("Index"));
        }

    }
}
