using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibraryModels
{
    public class Ticket
    {


        #region props
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _ticketHolder;

        public int TicketholderID
        {
            get { return _ticketHolder; }
            set { _ticketHolder = value; }
        }

        public string Name { get; set; }
        public string Email { get; set; }

        private TicketType _ticketType;

        public TicketType TicketTypeProp
        {
            get { return _ticketType; }
            set { _ticketType = value;}
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        #endregion

        public static ObservableCollection<Ticket> GetAllVisitors() {
            ObservableCollection<Ticket> visitorsCollection = new ObservableCollection<Ticket>();

            DbDataReader reader = DataBase.GetData("SELECT Reservatie.ID AS reservationID, TicketHolderID,Reservatie.TicketType,Amount,UserId,UserName,UserEmail,TicketType.ID AS typeID,TicketType.Name AS TypeName,Price,TotalTickets FROM Reservatie JOIN UserProfile ON Reservatie.TicketHolderID =  UserProfile.UserId JOIN TicketType ON Reservatie.TicketType = TicketType.ID ORDER BY UserName");
            foreach (IDataRecord record in reader) {
                Ticket tempTicket = new Ticket();
                tempTicket.ID = (int)reader["reservationID"];
                tempTicket.TicketholderID = (int)reader["UserID"];
                tempTicket.Amount = (int)reader["Amount"];
                tempTicket.TicketTypeProp = TicketType.GetTicketTypeByID((int)reader["TicketType"]);
                tempTicket.Name = (string)reader["UserName"];
                tempTicket.Email = (string)reader["UserEmail"];

                visitorsCollection.Add(tempTicket);
            }

            return visitorsCollection;
        }

        public static ObservableCollection<Ticket> GetVisitorsSearch(string partialName)
        {
            ObservableCollection<Ticket> searchColl = new ObservableCollection<Ticket>();

            DbParameter partialPar = DataBase.AddParameter("@partial", partialName+"%");
            DbDataReader reader = DataBase.GetData("SELECT * FROM UserProfile JOIN Reservatie ON UserProfile.UserId = Reservatie.TicketHolderID WHERE UserProfile.UserName LIKE @partial OR UserProfile.UserEmail LIKE @partial",partialPar);
            foreach (IDataRecord record in reader)
            {
                Ticket tempTicket = new Ticket();
                tempTicket.ID = (int)reader["ID"];
                tempTicket.TicketholderID = (int)reader["UserID"];
                tempTicket.Amount = (int)reader["Amount"];
                tempTicket.TicketTypeProp = TicketType.GetTicketTypeByID(tempTicket.ID);

                tempTicket.Name = (string)reader["UserName"];
                tempTicket.Email = (string)reader["UserEmail"];

                searchColl.Add(tempTicket);
            }

            return searchColl;
        }

        public static int SearchIfUserExistsOrNot(string strName,string strEmail){
            int userID = 0;

            try
            {
                DbParameter namePar = DataBase.AddParameter("@name", strName);
                DbParameter emailPar = DataBase.AddParameter("@email", strEmail);
                string sql = "SELECT * FROM UserProfile WHERE UserName = @name AND UserEmail = @email";
                DbDataReader reader = DataBase.GetData(sql, namePar, emailPar);
                if (reader.HasRows != false)
                {

                    foreach (IDataRecord record in reader)
                    {

                        userID = (int)reader["UserID"];

                    }

                }
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }

                return userID;
        }

        public static void PlaceAnOrder(Ticket ticket){

            try
            {

                DbParameter userPar = DataBase.AddParameter("@userID", ticket.TicketholderID);
                DbParameter typePar = DataBase.AddParameter("@ticketType", ticket.TicketTypeProp.ID);
                DbParameter amountPar = DataBase.AddParameter("@amount", ticket.Amount);
                string sql = "INSERT INTO Reservatie (TicketHolderID,TicketType,Amount) VALUES (@userID,@ticketType,@amount)";

                int modifiedData = DataBase.ModifyData(sql, userPar, typePar, amountPar);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        public static void InsertUserAndOrder(Ticket ticket){

            DbTransaction trans = DataBase.BeginTransaction();
            try
            {
                DbParameter parName = DataBase.AddParameter("@name", ticket.Name);
                DbParameter parEmail = DataBase.AddParameter("@email", ticket.Email);
                string sql_q1 = "INSERT INTO UserProfile (UserName,UserEmail)  VALUES (@name,@email)";
                int modifiedData_1 = DataBase.ModifyData(/*trans,*/sql_q1, parName, parEmail);

                int userID = SearchIfUserExistsOrNot(ticket.Name, ticket.Email);

                ticket.TicketholderID = userID;
                PlaceAnOrder(ticket);
                /*DbParameter userPar = DataBase.AddParameter("@userID", userID);
                DbParameter typePar = DataBase.AddParameter("@ticketType", ticket.TicketType.ID);
                DbParameter amountPar = DataBase.AddParameter("@amount", ticket.Amount);
                string sql_q2 = "INSERT INTO Reservatie (TicketHolderID,TicketType,Amount) VALUES (@userID,@ticketType,@amount)";
                int modifiedData_2 = DataBase.ModifyData(trans,sql_q2, userPar, typePar, amountPar);*/

                DbParameter userPar_q3 = DataBase.AddParameter("@userID2", userID);
                DbParameter datePar = DataBase.AddParameter("@date", DateTime.Now);
                DbParameter confirmedPar = DataBase.AddParameter("@confirm", 1);
                DbParameter failuresPar = DataBase.AddParameter("@fail", 0);
                DbParameter hashPar = DataBase.AddParameter("@hash",HashPassword("root123"));
                DbParameter passwChangedPar = DataBase.AddParameter("@passChange", DateTime.Now);
                DbParameter saltPar = DataBase.AddParameter("@salt", "");
                string sql_q3 = "INSERT INTO webpages_Membership (UserId,CreateDate,IsConfirmed,PasswordFailuresSinceLastSuccess,Password,PasswordChangedDate,PasswordSalt) VALUES (@userID2,@date,@confirm,@fail,@hash,@passChange,@salt)";
                int modifiedData_3 = DataBase.ModifyData(/*trans,*/sql_q3, userPar_q3, datePar, confirmedPar, failuresPar, hashPar, passwChangedPar, saltPar);

                trans.Commit();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }

        }


        //crypto voor zodat users die aangemaakt zijn in de desktopapp ook online kunnen inloggen(pasw hash berekenen)
         #region Crypto
        private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
        private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
        private const int SaltSize = 128 / 8; // 128 bits

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            // Produce a version 0 (see comment above) password hash.
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }

            byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }
        #endregion

        public static void UpdateOrder(Ticket ticket) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", ticket.ID);
                DbParameter typePar = DataBase.AddParameter("@type", ticket.TicketTypeProp.ID);
                DbParameter amountPar = DataBase.AddParameter("@amount", ticket.Amount);
                string sql = "UPDATE Reservatie SET TicketType = @type,Amount = @amount WHERE ID = @id";
                int iModifiedData = DataBase.ModifyData(sql, idPar, typePar, amountPar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }

        public static void DeleteOrder(int id) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", id);
                string sql = "DELETE FROM Reservatie WHERE ID=@id";
                int iModifiedData = DataBase.ModifyData(sql, idPar);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
