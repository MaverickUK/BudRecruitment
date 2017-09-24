using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PeterBridger.BudTest.Web.Services
{
    public class DeserializerService
    {
        public T Deserialize<T>(string xml)
        {
            if ( string.IsNullOrEmpty(xml))
                throw new ArgumentNullException(nameof(xml));

            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
