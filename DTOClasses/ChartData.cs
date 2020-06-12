namespace Covid19Tracker.DTOClasses
{
    public class ChartData
    {
        #region Properties
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal ConfirmedCases { get; set; }
        public decimal RecorveredOrDeaths { get; set; }
        #endregion

        #region Constructor
        public ChartData(string description, decimal recorveredOrDeaths, decimal confirmedCases)
        {
            this.Description = description;
            this.RecorveredOrDeaths = recorveredOrDeaths;
            this.ConfirmedCases = confirmedCases;
            Value = CalculateFatalityOrRecoveryPercentage();
        }
        #endregion

        #region Methods
        private decimal CalculateFatalityOrRecoveryPercentage()
        {
            return (RecorveredOrDeaths / ConfirmedCases) * 100;
        }
        #endregion
    }
}
