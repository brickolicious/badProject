using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StoreAppPortLibrary
{
   public class Festival
    {
        #region prop
        private DateTime _startDate;

        public DateTime StartDate
        {

            get
            {


                return _startDate;
            }
            set { _startDate = value; }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get
            {

                return _endDate;
            }
            set { _endDate = value; }
        }

        #endregion


     
    }
}
