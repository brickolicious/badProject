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
using System.Runtime.Serialization;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Data;

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
            set { _bandList = value; OnPropertyChanged("BandList"); }
        }
        



        private Genre _selecGen;

        public Genre SelectedGenre
        {
            get { return _selecGen; }
            set { _selecGen = value; GetBandIDsForGenre(_selecGen.ID); OnPropertyChanged("SelectedGenre"); }
        }

        

        private Band _SelectedBand;

        public Band SelectedBand
        {
            get { return _SelectedBand; }
            set { _SelectedBand = value; OnPropertyChanged("SelectedBand"); }
        }

        private Windows.UI.Xaml.Controls.Image _selectedPhoto;

        public Windows.UI.Xaml.Controls.Image SelectedPhoto
        {
            get { return _selectedPhoto; }
            set { _selectedPhoto = value; OnPropertyChanged("SelectedPhoto"); }
        }
        


        private ObservableCollection<Band> _filterBands;

        public ObservableCollection<Band> FilteredBands
        {
            get { return _filterBands; }
            set { _filterBands = value; OnPropertyChanged("FilteredBands"); }
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
            /*
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            */
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Band");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(ObservableCollection<Band>));
                BandList = dxml.ReadObject(stream) as ObservableCollection<Band>;
                /*DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Band>));
                BandList = djs.ReadObject(stream) as ObservableCollection<Band>;*/
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
                DataContractJsonSerializer(typeof(ObservableCollection<BandGenre>));
                BandIDsForGenreList = djs.ReadObject(stream) as ObservableCollection<BandGenre>;

                FilteredBands = new ObservableCollection<Band>();
                foreach (BandGenre item in BandIDsForGenreList)
                {
                    foreach (Band band in BandList)
                    {
                        if (item.Band == band.ID) {
                            FilteredBands.Add(band);
                        }
                    }
                }

            }
        
        }

        
        
    }


    


}
