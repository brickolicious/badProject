using StoreAppPortLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FestivalWinStoreApp.ViewModels
{
    class GenresVM:ObservableObject
    {
        public GenresVM()
        {
           // GetGenresFromAPI();
          //  GetBandIDsForGenre();
           
          //  GetBandsFromAPI();
            
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

        private ObservableCollection<LineUp> _filterLine;

        public ObservableCollection<LineUp> FilteredLineUps
        {
            get { return _filterLine; }
            set { _filterLine = value; OnPropertyChanged("FilteredLineUps"); }
        }


        public static async Task<List<LineUp>> GetLineUpsFromAPI(int bandID)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));


            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/Api/LineUp");

            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(List<LineUp>));
                List<LineUp> tempLineList = dxml.ReadObject(stream) as List<LineUp>;
                List<LineUp> filterList = new List<LineUp>();
                foreach (LineUp item in tempLineList)
                {
                    if (item.Band.ID == bandID) {
                        filterList.Add(item);
                    }
                }


                return filterList;
            }

            return null;
        }

        public static async Task<ObservableCollection<Genre>> GetGenresFromAPI() {

            ObservableCollection<Genre> tempList = new ObservableCollection<Genre>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Genre");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Genre>));
                tempList = djs.ReadObject(stream) as ObservableCollection<Genre>;
            }


            return  tempList;

        }

        public static async Task<ObservableCollection<Band>> GetBandsFromAPI() {
            /*
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            */

            ObservableCollection<Band> bandList = new ObservableCollection<Band>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Band");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(ObservableCollection<Band>));
                bandList = dxml.ReadObject(stream) as ObservableCollection<Band>;
                /*DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<Band>));
                BandList = djs.ReadObject(stream) as ObservableCollection<Band>;*/
            }

            return bandList;
        }

        public static async Task<ObservableCollection<BandGenre>> GetBandGenresFromAPI() {

            ObservableCollection<BandGenre> bandGenreList = new ObservableCollection<BandGenre>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/BandGenre/");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer djs = new
                DataContractJsonSerializer(typeof(ObservableCollection<BandGenre>));
                bandGenreList = djs.ReadObject(stream) as ObservableCollection<BandGenre>;

               

            }

            return bandGenreList;
        
        }



        
    
    }
}
