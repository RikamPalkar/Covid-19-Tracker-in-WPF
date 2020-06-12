using System;

namespace Covid19Tracker
{
    public class StatusDetails
    {
        #region Properties
        public ConfirmedCases confirmed { get; set; }
        public RecoveredCases recovered { get; set; }
        public Deaths deaths { get; set; }
        public DateTime lastUpdate { get; set; }
        #endregion

        #region Constructor
        public StatusDetails()
        {
        }
        #endregion

        #region Internal classes
        public class ConfirmedCases
        {
            public long value { get; set; }
        }
        public class RecoveredCases
        {
            public long value { get; set; }
        }
        public class Deaths
        {
            public long value { get; set; }
        }

        public class DailySummary
        {
            public long value { get; set; }
        }
        #endregion

    }
}