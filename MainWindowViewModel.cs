using Covid19Tracker.DTOClasses;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid19Tracker
{
    public class MainWindowViewModel : BindableBase
    {
        #region Properties
        private List<ChartData> _chartdetailsList;

        public List<ChartData> ChartdetailsList
        {
            get { return _chartdetailsList; }
            set { SetProperty(ref _chartdetailsList, value); }
        }

        private StatusDetails _covidDetails;

        public StatusDetails CovidDetails
        {
            get { return _covidDetails; }
            set { SetProperty(ref _covidDetails, value); }
        }

        private Country _selectedCountry;

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                SetProperty(ref _selectedCountry, value);
                GetRecoveryAndFatalityRateByCountry(SelectedCountry.name);
            }
        }

        private Countries affectedCountries;

        public Countries AffectedCountries
        {
            get { return affectedCountries; }
            set { SetProperty(ref affectedCountries, value); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            GetAfftectedNumbersFromAPI();
            GetRecoveryAndFatalityRate();
        }
        #endregion

        #region Methods
        private void GetAfftectedNumbersFromAPI()
        {
            var covidNumbers = WebAPI.GetCall("");
            UpdateRecoveryAndFatalityRate(covidNumbers);
        }

        private void GetRecoveryAndFatalityRate()
        {
            var covidCountries = WebAPI.GetCall("countries");

            if (covidCountries.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                AffectedCountries = covidCountries.Result.Content.ReadAsAsync<Countries>().Result;
            }
        }

        private void GetRecoveryAndFatalityRateByCountry(string nameOfTheCountry)
        {
            var countriesRate = WebAPI.GetCall("countries/" + nameOfTheCountry);
            UpdateRecoveryAndFatalityRate(countriesRate);
        }

        private void UpdateRecoveryAndFatalityRate(Task<HttpResponseMessage> response)
        {
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CovidDetails = response.Result.Content.ReadAsAsync<StatusDetails>().Result; ChartdetailsList = new List<ChartData>()
                {
                   new ChartData("Recovery Rate",CovidDetails.recovered.value, CovidDetails.confirmed.value),
                   new ChartData("Fatality  Rate",CovidDetails.deaths.value, CovidDetails.confirmed.value)
                };
            }
        }
        #endregion
    }
}
