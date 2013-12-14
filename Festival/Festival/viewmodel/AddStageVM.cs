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
    class AddStageVM : ObservableObject
    {

        public AddStageVM()
        {
            this.StageToCreate = new Stage();
        }


        private Stage _stage;

        public Stage StageToCreate
        {
            get { return _stage; }
            set { _stage = value; OnPropertyChanged("StageToCreate"); }
        }


        public ICommand CreateStage
        {
            get { return new RelayCommand(Addstage,StageToCreate.IsValid); }
        }


        public void Addstage() {

            Stage.AddStageAction(StageToCreate.Name);
        
        }
    }
}
