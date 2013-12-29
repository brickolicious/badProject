using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ClassLibraryModels
{
    public class Ticket : IDataErrorInfo
    {

        #region IDataErrorInfo
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {

                    return ex.Message;
                }
                return string.Empty;
            }





        }
        #endregion
        #region props
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _ticketHolder;
        [Required]
        public int TicketholderID
        {
            get { return _ticketHolder; }
            set { _ticketHolder = value; }
        }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        private TicketType _ticketType;
        [Required]
        public TicketType TicketTypeProp
        {
            get { return _ticketType; }
            set { _ticketType = value;}
        }

        private int _amount;
        [Required]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        #endregion

        #region functions

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        public static ObservableCollection<Ticket> GetAllVisitors() {
            ObservableCollection<Ticket> visitorsCollection = new ObservableCollection<Ticket>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT Reservatie.ID AS reservationID, TicketHolderID,Reservatie.TicketType,Amount,UserId,UserName,UserEmail,TicketType.ID AS typeID,TicketType.Name AS TypeName,Price,TotalTickets FROM Reservatie JOIN UserProfile ON Reservatie.TicketHolderID =  UserProfile.UserId JOIN TicketType ON Reservatie.TicketType = TicketType.ID ORDER BY UserName");
                foreach (IDataRecord record in reader)
                {
                    Ticket tempTicket = new Ticket();
                    tempTicket.ID = (int)reader["reservationID"];
                    tempTicket.TicketholderID = (int)reader["UserID"];
                    tempTicket.Amount = (int)reader["Amount"];
                    tempTicket.TicketTypeProp = TicketType.GetTicketTypeByID((int)reader["TicketType"]);
                    tempTicket.Name = (string)reader["UserName"];
                    tempTicket.Email = (string)reader["UserEmail"];

                    visitorsCollection.Add(tempTicket);
                }


                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return visitorsCollection;
        }

        public static ObservableCollection<Ticket> GetVisitorsSearch(string partialName)
        {
            ObservableCollection<Ticket> searchColl = new ObservableCollection<Ticket>();

            try
            {






                DbParameter partialPar = DataBase.AddParameter("@partial", partialName + "%");
                DbDataReader reader = DataBase.GetData("SELECT * FROM UserProfile WHERE UserProfile.UserName LIKE @partial OR UserProfile.UserEmail LIKE @partial", partialPar);
                foreach (IDataRecord record in reader)
                {
                    Ticket tempTicket = new Ticket();
                    
                    tempTicket.Name = (string)reader["UserName"];
                    tempTicket.Email = (string)reader["UserEmail"];

                    searchColl.Add(tempTicket);
                }

                reader.Close();





























               /* DbParameter partialPar = DataBase.AddParameter("@partial", partialName + "%");
                DbDataReader reader = DataBase.GetData("SELECT * FROM UserProfile JOIN Reservatie ON UserProfile.UserId = Reservatie.TicketHolderID WHERE UserProfile.UserName LIKE @partial OR UserProfile.UserEmail LIKE @partial", partialPar);
                foreach (IDataRecord record in reader)
                {
                    Ticket tempTicket = new Ticket();
                    tempTicket.ID = (int)reader["ID"];
                    tempTicket.TicketholderID = (int)reader["UserID"];
                    tempTicket.Amount = (int)reader["Amount"];
                    tempTicket.TicketTypeProp = TicketType.GetTicketTypeByID((int)reader["UserID"]);

                    tempTicket.Name = (string)reader["UserName"];
                    tempTicket.Email = (string)reader["UserEmail"];

                    searchColl.Add(tempTicket);
                }

                reader.Close();*/
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
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
                reader.Close();
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
                System.Windows.MessageBox.Show("A ticket has been orderd for: " + ticket.Name);
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
                //System.Windows.MessageBox.Show("A ticket has been orderd for: " + ticket.Name);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                trans.Rollback();
                System.Windows.MessageBox.Show("Ticket was not orderd for: " + ticket.Name+"\nCheck if user and email are correct.");
            }

        }


        //crypto zodat users die aangemaakt zijn in de desktopapp ook online kunnen inloggen(pasw hash berekenen)
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



        public static void PrintOrder(Ticket ticket)
        {

            try
            {
                FolderBrowserDialog fbrowse = new FolderBrowserDialog();
                fbrowse.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DialogResult result = fbrowse.ShowDialog();
                if (result.ToString() == "OK")
                {
                    //System.Windows.MessageBox.Show(""+fbrowse.SelectedPath);

                    string fileName = ticket.Name + "_" + ticket.ID + ".docx";
                    string filePath = System.IO.Path.Combine(fbrowse.SelectedPath, fileName);
                    File.Copy("template.docx", filePath, true);
                    WordprocessingDocument newdoc = WordprocessingDocument.Open(filePath, true);
                    IDictionary<String, BookmarkStart> bookmarks = new Dictionary<String, BookmarkStart>();
                    foreach (BookmarkStart bms in newdoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
                    {
                        bookmarks[bms.Name] = bms;
                    }
                    bookmarks["Name"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(Ticket.GetUserNameByID(ticket.TicketholderID))), bookmarks["Name"]);
                    bookmarks["Email"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(ticket.Email)), bookmarks["Email"]);
                    bookmarks["Type"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(ticket.TicketTypeProp.Name)), bookmarks["Type"]);
                    bookmarks["Amount"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(ticket.Amount+"")), bookmarks["Amount"]);
                    bookmarks["Total"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text((ticket.Amount * ticket.TicketTypeProp.Price) + "")), bookmarks["Total"]);



                    DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(ticket.TicketholderID+"-"+ticket.TicketTypeProp.ID+"-"+ticket.Amount));
                    RunProperties prop = new RunProperties();
                    RunFonts font = new RunFonts() { Ascii = "Free 3 of 9 Extended", HighAnsi = "Free 3 of 9 Extended" };
                    FontSize size = new FontSize() { Val = "96" };
                    prop.Append(font);
                    prop.Append(size);
                    run.PrependChild<RunProperties>(prop);





                    bookmarks["Code"].Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(run, bookmarks["Code"]);
                    newdoc.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public static string GetUserNameByID(int userID) { 
            string name="";

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", userID);
                string sql = "SELECT * FROM UserProfile WHERE UserId = @id";
                DbDataReader reader = DataBase.GetData(sql, idPar);
                foreach (IDataRecord record in reader)
                {
                    name = (string)reader["UserName"];
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return name;
        }


        public static List<Ticket> GetAllReservationsForUser(int UserID) {
            List<Ticket> tickList = new List<Ticket>();

            try
            {
                string sql = "SELECT * FROM Reservatie JOIN UserProfile ON UserProfile.UserId = Reservatie.TicketHolderID WHERE TicketHolderID = @id";
                DbParameter idPar = DataBase.AddParameter("@id", UserID);

                DbDataReader reader = DataBase.GetData(sql, idPar);
                foreach (IDataRecord record in reader)
                {
                    Ticket tempTicket = new Ticket();
                    tempTicket.ID = (int)reader["ID"];
                    tempTicket.TicketholderID = (int)reader["TicketHolderID"];
                    tempTicket.Name = (string)reader["UserName"];
                    tempTicket.Email = (string)reader["UserEmail"];
                    tempTicket.TicketTypeProp = TicketType.GetTicketTypeByID((int)reader["TicketType"]);
                    tempTicket.Amount = (int)reader["Amount"];
                    tickList.Add(tempTicket);

                }



                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tickList;
        }


        public static int GetUserIDFromUsername(string name) {
            int userID = 0;

            try
            {
                string sql = "SELECT UserId From UserProfile WHERE UserName = @name";
                DbParameter namePar = DataBase.AddParameter("@name", name);
                DbDataReader reader = DataBase.GetData(sql, namePar);

                foreach (IDataRecord record in reader)
                {
                    userID = (int)reader["UserId"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userID;
        }


        public static string GetUserEmailFromUsername(string name)
        {
            string email = "";

            try
            {
                string sql = "SELECT UserEmail From UserProfile WHERE UserName = @name";
                DbParameter namePar = DataBase.AddParameter("@name", name);
                DbDataReader reader = DataBase.GetData(sql, namePar);

                foreach (IDataRecord record in reader)
                {
                    email = (string)reader["UserEmail"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return email;
        }
        #endregion
    }
}
