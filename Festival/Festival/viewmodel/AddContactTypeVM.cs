using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class AddContactTypeVM
    {
        public string Name { get; set; }



        public ICommand AddTypeCommand {
            get { return new RelayCommand(AddTypeAction); }
        }

        private void AddTypeAction()
        {
            ContactPersonType.AddContactType(Name);
        }
        
    }
}
