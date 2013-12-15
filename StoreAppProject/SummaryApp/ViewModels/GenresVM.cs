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
            GetGenresFromAPI();
            GetBandsFromAPI();
        }

        private  ObservableCollection<Genre> _lstGenres;

        public  ObservableCollection<Genre> GenreList
        {
            get { return _lstGenres; }
            set { _lstGenres = value; OnPropertyChanged("GenreList"); }
        }


        private ObservableCollection<Band> _bandList;

        public ObservableCollection<Band> BandList
        {
            get { return _bandList; }
            set { _bandList = value; }
        }
        



        private Genre _selecGen;

        public Genre SelectedGenre
        {
            get { return _selecGen; }
            set { _selecGen = value; GetBandIDsForGenre(_selecGen.ID); OnPropertyChanged("SelectedGenre"); }
        }

        private ObservableCollection<Band> _filterBands;

        public ObservableCollection<Band> FilteredBands
        {
            get { return _filterBands; }
            set { _filterBands = value; }
        }

        private ObservableCollection<BandGenre> _bandForGenre;

        public ObservableCollection<BandGenre> BandIDsForGenreList
        {
            get { return _bandForGenre; }
            set { _bandForGenre = value; }
        }
        
        


        public async void GetGenresFromAPI() {

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

        public async void GetBandsFromAPI() {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Band");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Band>));
                BandList = djs.ReadObject(stream) as ObservableCollection<Band>;
            }

        
        }

        public async void GetBandIDsForGenre(int genreID) {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/BandGenre/"+genreID);
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Genre>));
                BandIDsForGenreList = djs.ReadObject(stream) as ObservableCollection<BandGenre>;

                FilteredBands = null;
                foreach (BandGenre item in BandIDsForGenreList)
                {
                    foreach (Band band in BandList)
                    {
                        if (item.ID == band.ID) {
                            FilteredBands.Add(band);
                        }
                    }
                }

            }
        
        }


    }
}
