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
using System.Windows;

namespace ClassLibraryModels
{
    public class ContactPerson : IDataErrorInfo
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
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _company;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        private ContactPersonType _jobRole;
        [Required]
        public ContactPersonType JobRole
        {
            get { return _jobRole; }
            set { _jobRole = value; }
        }

        private string _city;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tussen de 3 en 50 karakters bevatten ")]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        private string _cellphone;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        #endregion

        #region functions

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        //gets a list of all the contacts
        public static ObservableCollection<ContactPerson> GetAllContacts() {
            ObservableCollection<ContactPerson> contactCollection = new ObservableCollection<ContactPerson>();

            try
            {

                DbDataReader reader = DataBase.GetData("SELECT * FROM ContactPerson");
                foreach (IDataRecord record in reader)
                {
                    ContactPerson tempContact = new ContactPerson();
                    tempContact.ID = (int)reader["ID"];
                    tempContact.Name = (string)reader["Name"];
                    tempContact.Company = (string)reader["Company"];
                    tempContact.JobRole = ContactPersonType.GetContactPersonTypeByID((int)reader["ID"]);
                    tempContact.City = (string)reader["city"];
                    tempContact.Email = (string)reader["email"];
                    tempContact.Phone = (string)reader["Phone"];
                    tempContact.CellPhone = (string)reader["CellPhone"];

                    contactCollection.Add(tempContact);
                }


                reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            return contactCollection;
        }

        //gets a list of contactpersons whom have a specific jobrole (jobrole being the contacttype)
        public static ObservableCollection<ContactPerson> GetContactPersonsByJobrole(int jobroleID) {
            ObservableCollection<ContactPerson> colContPer = new ObservableCollection<ContactPerson>();


            try
            {

                DbParameter idPar = DataBase.AddParameter("@ID", jobroleID);
                DbDataReader reader = DataBase.GetData("SELECT * FROM ContactPerson WHERE JobRole = @ID",idPar);


                foreach (IDataRecord record in reader)
                {
                    ContactPerson tempContact = new ContactPerson();
                    tempContact.ID = (int)reader["ID"];
                    tempContact.Name = (string)reader["Name"];
                    tempContact.Company = (string)reader["Company"];
                    tempContact.JobRole = ContactPersonType.GetContactPersonTypeByID((int)reader["ID"]);
                    tempContact.City = (string)reader["city"];
                    tempContact.Email = (string)reader["email"];
                    tempContact.Phone = (string)reader["Phone"];
                    tempContact.CellPhone = (string)reader["CellPhone"];

                    colContPer.Add(tempContact);
                }



                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }


            return colContPer;
        }

        //returns a contactperson object according to the name that was given
        public static ObservableCollection<ContactPerson> GetContactByName(string strName) {
            ObservableCollection<ContactPerson> contColl = new ObservableCollection<ContactPerson>();

            try
            {
                string sql = "SELECT * FROM ContactPerson WHERE name LIKE @Name";
                DbParameter namePar = DataBase.AddParameter("@Name",strName+"%");

                DbDataReader reader = DataBase.GetData(sql, namePar);

                foreach (IDataRecord record in reader) {
                    ContactPerson tempContact = new ContactPerson();
                    tempContact.ID = (int)reader["ID"];
                    tempContact.Name = (string)reader["Name"];
                    tempContact.Company = (string)reader["Company"];
                    tempContact.JobRole = ContactPersonType.GetContactPersonTypeByID((int)reader["ID"]);
                    tempContact.City = (string)reader["city"];
                    tempContact.Email = (string)reader["email"];
                    tempContact.Phone = (string)reader["Phone"];
                    tempContact.CellPhone = (string)reader["CellPhone"];

                    contColl.Add(tempContact);
                }



                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return contColl;
        }

        //adds contact to the database
        public static void AddTheContact(ContactPerson contact)
        {
            try
            {
                DbParameter par1 = DataBase.AddParameter("@Name", contact.Name);
                DbParameter par2 = DataBase.AddParameter("@Company", contact.Company);
                DbParameter par3 = DataBase.AddParameter("@ContactPersonType", contact.JobRole.ID);
                DbParameter par4 = DataBase.AddParameter("@City", contact.City);
                DbParameter par5 = DataBase.AddParameter("@Email", contact.Email);
                DbParameter par6 = DataBase.AddParameter("@Phone", contact.Phone);
                DbParameter par7 = DataBase.AddParameter("@CellPhone", contact.CellPhone);
                string sql = "INSERT INTO ContactPerson (Name,Company,JobRole,City,Email,Phone,CellPhone) VALUES (@Name,@Company,@ContactPersonType,@City,@Email,@Phone,@Cellphone)";
                int modifiedRows = DataBase.ModifyData(sql, par1, par2, par3, par4, par5, par6, par7);



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }

        }

        //updates a contact
        public static void UpdateContact(ContactPerson person) {

            try
            {

                DbParameter idPar = DataBase.AddParameter("@id", person.ID);
                DbParameter namePar = DataBase.AddParameter("@name", person.Name);
                DbParameter companyPar = DataBase.AddParameter("@company", person.Company);
                DbParameter cityPar = DataBase.AddParameter("@city", person.City);
                DbParameter jobPar = DataBase.AddParameter("@jobID", person.JobRole.ID);
                DbParameter emailPar = DataBase.AddParameter("@email", person.Email);
                DbParameter phonePar = DataBase.AddParameter("@phone", person.Phone);
                DbParameter cellPar = DataBase.AddParameter("@cell", person.CellPhone);

                string sql = "UPDATE ContactPerson SET name=@name, company=@company, JobRole=@jobID,City=@city,Email=@email,Phone=@phone,CellPhone=@cell WHERE ID=@id";
                int modifiedData = DataBase.ModifyData(sql, namePar, companyPar, cityPar, jobPar, emailPar, phonePar, cellPar,idPar);
                //MessageBox.Show(modifiedData + "");
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            
            }

        }

        //removes a contact from the database based on his id
        public static void DeleteContact(int contactID) {
            try
            {
                DbParameter idPar = DataBase.AddParameter("@idPar", contactID);
                string sql = "DELETE FROM ContactPerson WHERE ID = @idPar";

                int iModifiedData = DataBase.ModifyData(sql, idPar);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
