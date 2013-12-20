using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppPortLibrary;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization;

namespace SummaryApp.ViewModels
{
    class AgendaVM : ObservableObject
    {

        public AgendaVM()
        {
            this.GetLineUpsFromAPI();
        }


        private ObservableCollection<LineUp> _lineList;

        public ObservableCollection<LineUp> LineUpList
        {
            get { return _lineList; }
            set { _lineList = value; OnPropertyChanged("LineUpList"); }
        }

        private LineUp _selecLine;

        public LineUp SelectedLineUp
        {
            get { return _selecLine; }
            set { _selecLine = value; OnPropertyChanged("SelectedLineUp"); }
        }
        



        public async void GetLineUpsFromAPI()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));


            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/Api/LineUp");

            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(ObservableCollection<LineUp>));
                LineUpList = dxml.ReadObject(stream) as ObservableCollection<LineUp>;
               
            }


        }
    }
}
