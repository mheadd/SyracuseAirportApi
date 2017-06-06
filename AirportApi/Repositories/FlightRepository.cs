using System;
using System.Xml;

namespace AirportAPI.Repositories
{
    public interface IFlightRepository
    {
        XmlNodeList GetFlights();
        XmlNodeList GetFlightsByNumber(int number);
        XmlNodeList GetFlightsByGate(int gate);
        XmlNodeList GetFlightsByCity(string city);
        XmlNodeList GetFlightsByDirection(string direction);
    }
    public class FlightRepository : IFlightRepository
    {
        private XmlDocument _xmldoc = new XmlDocument();
        private readonly FlightContext _context;
        public FlightRepository(FlightContext context)
        {
            _context = context;
        }

        public XmlNodeList GetFlights()
        {
            string xpath = "//*";
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc.GetElementsByTagName("flight");
        }

        public XmlNodeList GetFlightsByNumber(int number)
        {
            string xpath = String.Format("//flight[@flightnumber='{0}']", number);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc.GetElementsByTagName("flight");
        }

        public XmlNodeList GetFlightsByGate(int gate)
        {
            string xpath = String.Format("//flight[@gate='{0}']", gate);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc.GetElementsByTagName("flight");
        }

        public XmlNodeList GetFlightsByCity(string city)
        {
            string xpath = String.Format("//flight[@city='{0}']", city);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc.GetElementsByTagName("flight");
        }

        public XmlNodeList GetFlightsByDirection(string direction)
        {
            string xpath = String.Format("//flight[@type='{0}']", direction);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc.GetElementsByTagName("flight");
        }
    }
}