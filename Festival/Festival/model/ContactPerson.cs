using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BADProject.model
{
    class ContactPerson
    {
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

        private string _company;

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        private ContactPersonType _jobRole;

        public ContactPersonType JobRole
        {
            get { return _jobRole; }
            set { _jobRole = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        private string _cellphone;

        public string CellPhone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        #endregion

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
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            return contactCollection;
        }


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
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }


            return colContPer;
        }


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
            
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return contColl;
        }

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



    }
}
