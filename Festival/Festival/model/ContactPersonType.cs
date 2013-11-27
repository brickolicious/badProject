using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.model
{
    class ContactPersonType
    {
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


        public static ObservableCollection<ContactPersonType> GetAllContactPersonType()
        {
            ObservableCollection<ContactPersonType> contactPersonTypeCol = new ObservableCollection<ContactPersonType>();

            try
            {
                DbDataReader reader = DataBase.GetData("SELECT * FROM ContactPersonType");
                foreach (IDataRecord record in reader)
                {
                    ContactPersonType tempConType = new ContactPersonType();

                    tempConType.ID = (int)reader["ID"];
                    tempConType.Name = (string)reader["Name"];

                    contactPersonTypeCol.Add(tempConType);
                }
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
            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            return tempConTyp;
        }
        
        
    }
}
