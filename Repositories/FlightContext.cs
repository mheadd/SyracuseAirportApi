using System.Net.Http;
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
                XPathNavigator node = navigator.SelectSingleNode(xpath);
                return node.OuterXml;
            }
        }
    }
}