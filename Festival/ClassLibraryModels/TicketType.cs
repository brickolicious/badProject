using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class TicketType : IDataErrorInfo
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

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _availableTickets;

        public int AvailableTickets
        {
            get { return _availableTickets; }
            set { _availableTickets = value; }
        }
        

        private int _totalTickets;

        public int TotalTickets
        {
            get { return _totalTickets; }
            set { _totalTickets = value; }
        }
        #endregion

        #region functions
        public static ObservableCollection<TicketType> GetAllTicketTypes() { 
            ObservableCollection<TicketType> typesColl = new ObservableCollection<TicketType>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM TicketType");
                foreach (IDataRecord record in reader) {
                    TicketType tempType = new TicketType();

                    tempType.ID = (int)reader["ID"];
                    tempType.Name = (string)reader["Name"];
                    tempType.Price = Convert.ToDouble(reader["Price"]);
                    tempType.TotalTickets = (int)reader["TotalTickets"];
                    tempType.AvailableTickets = tempType.TotalTickets-AantalBesteldeTicketsPerType(tempType.ID);

                    typesColl.Add(tempType);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return typesColl;
        }

        public static TicketType GetTicketTypeByID(int typeID) {
            TicketType tempType = new TicketType();

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", typeID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM TicketType WHERE ID = @id",idPar);
                foreach (IDataRecord record in reader)
                {
                    tempType.ID = (int)reader["ID"];
                    tempType.Name = (string)reader["Name"];
                    tempType.Price = Convert.ToDouble(reader["Price"]);
                    tempType.TotalTickets = (int)reader["TotalTickets"];
                    tempType.AvailableTickets = tempType.TotalTickets - AantalBesteldeTicketsPerType(tempType.ID);

                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return tempType;
        }

        public static int AantalBesteldeTicketsPerType(int ticketTypeID){

            int iAantal = 0;

            try
            {
                string sql = "SELECT sum(amount) AS AantalBesteldeTickets FROM Reservatie WHERE TicketType = @id ";

                DbParameter idPar = DataBase.AddParameter("@id", ticketTypeID);

                DbDataReader reader = DataBase.GetData(sql, idPar);

                foreach (IDataRecord record in reader)
                {
                    iAantal = (int)reader[0];
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return iAantal;
        }

        public static void AddTicketType(TicketType ticketType) {

            try
            {
                DbParameter namePar = DataBase.AddParameter("@name", ticketType.Name);
                DbParameter pricePar = DataBase.AddParameter("@price", ticketType.Price);
                DbParameter totalPar = DataBase.AddParameter("@total", ticketType.TotalTickets);
                string sql = "INSERT INTO TicketType (Name,Price,TotalTickets) VALUES (@name,@price,@total)";
                int iModifiedData = DataBase.ModifyData(sql, namePar, pricePar, totalPar);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteTicketTypeAndOrdersPlacedWithThisType(int ticketTypeID) {

            try
            {
                DbParameter idPar = DataBase.AddParameter("@id", ticketTypeID);
                string sql = "DELETE FROM Reservatie WHERE TicketType=@id;DELETE FROM TicketType WHERE ID=@id";

                int iModifiedData = DataBase.ModifyData(sql, idPar);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
