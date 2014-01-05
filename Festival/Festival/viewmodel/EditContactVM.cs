﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using BADProject.view;
using System.Windows;

namespace BADProject.viewmodel
{
    class EditContactVM:ObservableObject
    {
        public EditContactVM()
        {
            
        }


        #region props
        private int _type;

        public int ContactTypePosition
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("ContactTypePosition"); }
        }
        


        private static ContactPerson selected;

        public static ContactPerson SelectedContactStatic
        {
            get { return selected; }
            set { selected = value; }
        }
        

        private ContactPerson _contact;

        public ContactPerson SelectedContact
        {
            get { return _contact; }
            set { _contact = value; SelectedContactStatic = _contact; if (SelectedContactStatic != null) { SelectedContactStatic.JobRole = null; }; OnPropertyChanged("SelectedContact"); }
        }

        private ObservableCollection<ContactPersonType>  _types;

        public ObservableCollection<ContactPersonType> TypeList
        {
            get {
                _types = ContactPersonType.GetAllContactPersonType();
                return _types; }
            set { _types = value; }
        }
        #endregion

        public ICommand EditContactAction
        {
            get { return new RelayCommand(EditAction,SelectedContactStatic.IsValid); }
        }

        private void EditAction()
        {
            ContactPerson.UpdateContact(SelectedContactStatic);
        }


    }
}
