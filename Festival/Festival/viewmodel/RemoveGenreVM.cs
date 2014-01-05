using ClassLibraryModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class RemoveGenreVM : ObservableObject
    {
        public RemoveGenreVM()
        {
            GenresList = Genre.GetGenres();
        }


        private ObservableCollection<Genre> _genresList;

        public ObservableCollection<Genre> GenresList
        {
            get { return _genresList; }
            set { _genresList = value; OnPropertyChanged("GenresList"); }
        }



        public ICommand RemoveGenreActionCommand
        {
            get { return new RelayCommand<Genre>(RemoveGenre);}
        }

        private void RemoveGenre(Genre selectedGen)
        {
            Genre.RemoveGenre(selectedGen.ID);
            UpdateProps();
        }


        //"refreshes" the lists after completing an insert or update
        public static event Update OnComplete;
        private void UpdateProps()
        {
            OnComplete(this);
        }
    }
}
