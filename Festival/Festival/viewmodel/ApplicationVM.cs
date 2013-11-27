using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BADProject.viewmodel
{
    class ApplicationVM : ObservableObject
    {
        public ApplicationVM()
        {
            Pages.Add(new LineupVM());
            Pages.Add(new BandsVM());
            Pages.Add(new ContactVM());
            Pages.Add(new ReserverenVM());
            Pages.Add(new BezoekersVM());
            

            CurrentPage = Pages[0];

        }

        private IPage _currentpage;
        public IPage CurrentPage
        {
            get { return _currentpage; }
            set { _currentpage = value; OnPropertyChanged("CurrentPage"); }
        }

        private List<IPage> _pages;
        public List<IPage> Pages
        {
            get
            {
                if (_pages == null)
                    _pages = new List<IPage>();
                return _pages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        
        private void ChangePage(IPage page)
        {
            CurrentPage = page;
        }


    }
}
