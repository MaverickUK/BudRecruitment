using System.Xml.Serialization;

namespace PeterBridger.BudTest.Web.Models.WorldBank
{
    public class Country
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("iso2Code")]
        public string Iso2Code { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("capitalCity")]
        public string CapitalCity { get; set; }

        [XmlElement("longitude")]
        public double Longitude { get; set; }

        [XmlElement("latitude")]
        public double Latitude { get; set; }

        [XmlElement("adminregion")]
        public string AdminRegion { get; set; }

        [XmlElement("incomelevel")]
        public string IncomeLevel { get; set; }

        [XmlElement("lendingType")]
        public string LendingType { get; set; }
    }
}