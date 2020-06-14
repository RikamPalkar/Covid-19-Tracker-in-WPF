using System.Collections.Generic;

namespace Covid19Tracker
{
    public class Country
    {
        public string name { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
    }
    public class Countries
    {
        public List<Country> countries { get; set; }
    }
}
