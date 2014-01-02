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
    public class ContactPersonType: IDataErrorInfo
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
        #endregion


        #region functions
        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null),
            null, true);
        }

        public static ObservableCollection<ContactPersonType> GetAllContactPersonType()
        {
            ObservableCollection<ContactPersonType> contactPersonTypeCol = new ObservableCollection<ContactPersonType>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM ContactPersonType ORDER BY Name ASC");
                foreach (IDataRecord record in reader)
                {
                    ContactPersonType tempConType = new ContactPersonType();

                    tempConType.ID = (int)reader["ID"];
                    tempConType.Name = (string)reader["Name"];

                    contactPersonTypeCol.Add(tempConType);
                }



                reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            return contactPersonTypeCol;
        }

        public static ContactPersonType GetContactPersonTypeByID(int id) {
            ContactPersonType tempConTyp = new ContactPersonType();

            try{
            DbParameter idPar = DataBase.AddParameter("@id", id);
            DbDataReader reader = DataBase.GetData("SELECT * FROM ContactPersonType WHERE id = @id",idPar);

            foreach (IDataRecord record in reader) {

                tempConTyp.ID = (int)reader["ID"];
                tempConTyp.Name = (string)reader["Name"];
            
            }


            reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            return tempConTyp;
        }

        public static void AddContactType(string strName) {

            try
            {
                DbParameter catName = DataBase.AddParameter("@catName", strName);
                string sql = "INSERT INTO ContactPersonType(Name) VALUES (@catName)";
                int iModifiedData = DataBase.ModifyData(sql, catName);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteContactType(int id) {
            try
            {
                DbParameter idPar = DataBase.AddParameter("@typeID", id);


                string sql = "SELECT COUNT(JobRole) AS FrequencyOfType FROM ContactPerson WHERE ContactPerson.JobRole = @typeID";
                DbDataReader reader = DataBase.GetData(sql, idPar);
                int iPresentContactsInCategory =0;

                foreach (IDataRecord record in reader) {

                    iPresentContactsInCategory = (int)reader["FrequencyOfType"];

                }


                if (iPresentContactsInCategory > 0)
                {
                    MessageBox.Show("Category can not be deleted, there are still contacts present.", "Delete notification", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else {
                    DbParameter idPar_2 = DataBase.AddParameter("@typeID_2", id);
                    string sql_delete = "DELETE FROM ContactPersonType WHERE ID = @typeID_2";
                    int iModifiedData = DataBase.ModifyData(sql_delete, idPar_2);
                    
                }


            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
