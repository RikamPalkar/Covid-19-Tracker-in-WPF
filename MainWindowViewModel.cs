using Covid19Tracker.DTOClasses;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Net.Http;

namespace Covid19Tracker
{
    public class MainWindowViewModel : BindableBase
    {
        private List<ChartData> _chartdetailsList;

        public List<ChartData> ChartdetailsList
        {
            get { return _chartdetailsList; }
            set { SetProperty(ref _chartdetailsList , value); }
        }

        private StatusDetails _covidDetails;

        public StatusDetails CovidDetails
        {
            get { return _covidDetails; }
            set { SetProperty(ref _covidDetails , value); }
        }


        public MainWindowViewModel()
        {
        var response = WebAPI.GetCall();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CovidDetails = response.Result.Content.ReadAsAsync<StatusDetails>().Result;
                ChartdetailsList = new List<ChartData>()
                {
                   new ChartData("Recovery Rate",CovidDetails.recovered.value, CovidDetails.confirmed.value),
                   new ChartData("Fatality  Rate",CovidDetails.deaths.value, CovidDetails.confirmed.value)
                };
            }
        }
    }
}
