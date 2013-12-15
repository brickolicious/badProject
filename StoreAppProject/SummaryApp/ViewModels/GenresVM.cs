using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppPortLibrary;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.Data.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Input;

namespace SummaryApp.ViewModels
{
    class GenresVM:ObservableObject
    {

        public GenresVM()
        {
            GetDataFromAPI();
        }

        private  ObservableCollection<Genre> _lstGenres;

        public  ObservableCollection<Genre> GenreList
        {
            get { return _lstGenres; }
            set { _lstGenres = value; OnPropertyChanged("GenreList"); }
        }

        private Genre _selecGen;

        public Genre SelectedGenre
        {
            get { return _selecGen; }
            set { _selecGen = value; }
        }
        


        public async void GetDataFromAPI() {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Genre");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Genre>));
                GenreList = djs.ReadObject(stream) as ObservableCollection<Genre>;
            }

            

        }


        public ICommand ShowTheBands {

            get { return new RelayCommand(GetBands); }
        
        }

        private void GetBands()
        {


            
        }



    }
}
