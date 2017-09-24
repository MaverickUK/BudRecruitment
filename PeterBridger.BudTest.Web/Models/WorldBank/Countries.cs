using System.Xml;
using System.Xml.Serialization;

namespace PeterBridger.BudTest.Web.Models.WorldBank
{
    [XmlRoot("countries", Namespace = "http://www.worldbank.org")]
    public class Countries
    {
        [XmlElement("country")]
        public Country Country { get; set; }
    }
}
