using StoreAppPortLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SummaryApp.ViewModels
{
    class LineupVM : ObservableObject
    {
        public LineupVM()
        {
            this.GetStagesFromAPI();
            //this.GetLineUpsFromAPI();
            this.GetDaysFromAPI();
            
        }

        private ObservableCollection<Stage> _stages;

        public ObservableCollection<Stage> StageList
        {
            get { return _stages; }
            set { _stages = value; OnPropertyChanged("StageList"); }
        }

        private ObservableCollection<LineUp> _lineup;

        public ObservableCollection<LineUp> LineUpList
        {
            get { return _lineup; }
            set { _lineup = value; OnPropertyChanged("LineUpList"); }
        }

        private ObservableCollection<DateTime> _days;

        public ObservableCollection<DateTime> DateList
        {
            get { return _days; }
            set { _days = value; OnPropertyChanged("DateList"); }
        }


        private DateTime _selecDay;

        public DateTime SelectedDay
        {
            get { return _selecDay; }
            set { _selecDay = value; GetLineUpsFromAPI(_selecDay);/*SetLineupBasedOnDay(_selecDay);*/ OnPropertyChanged("SelectedDay"); }
        }




        public async void GetDaysFromAPI()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Festival");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(ObservableCollection<DateTime>));
                this.DateList = dxml.ReadObject(stream) as ObservableCollection<DateTime>;
            }


        }
        public async void GetStagesFromAPI()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/api/Stage");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();



                DataContractSerializer dxml = new DataContractSerializer(typeof(ObservableCollection<Stage>));
                StageList = dxml.ReadObject(stream) as ObservableCollection<Stage>;
            }


        }
        public async void GetLineUpsFromAPI(DateTime date)
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
                SetLineupBasedOnDay(date);
            }


        }
        public void SetLineupBasedOnDay(DateTime datum) {
            
            //hier lijst aanmaken om op het einde gelijk te zetten => 1x propchanged ipv x-aantal keer
            ObservableCollection<Stage> tempStageList = this.StageList;
            ObservableCollection<LineUp> tempList = new ObservableCollection<LineUp>();

            foreach (LineUp item in LineUpList)
            {
                if (item.Date.Date == datum.Date) {

                    tempList.Add(item);

                }
                
            }

            foreach (Stage stage in tempStageList)
            {
                ObservableCollection<LineUp> lineForStage = new ObservableCollection<LineUp>();
                foreach (LineUp line in tempList)
                {
                    if (stage.ID == line.Stage.ID) {

                        lineForStage.Add(line);
                    
                    }
                }
                stage.StageLineup = lineForStage;
            }

            this.StageList = tempStageList;
        
        }


    }
}
