using System.Net.Http;
using System.Xml;
using System.Xml.XPath;

namespace SyracuseAirportApi.Repositories
{
    public class FlightContext
    {
        private static string _endpoint;

        public FlightContext(string endpoint)
        {
            _endpoint = endpoint;
        }

        public string GetXmlData(string xpath)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStreamAsync(_endpoint);
                XPathDocument document = new XPathDocument(response.Result);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator node = navigator.Select(xpath);

               string flights = "<results>";
                while (node.MoveNext())
                {
                    flights += node.Current.OuterXml;
                }
                flights += "</results>";
                return flights;
            }
        }
    }
}