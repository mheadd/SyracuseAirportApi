using System;
using System.Xml;

namespace SyracuseAirportApi.Repositories
{
    public interface IFlightRepository
    {
        XmlDocument GetFlights();
        XmlDocument GetFlightsByNumber(int number);
        XmlDocument GetFlightsByGate(int gate);
        XmlDocument GetFlightsByCity(string city);
        XmlDocument GetFlightsByDirection(string direction);
    }
    public class FlightRepository : IFlightRepository
    {
        private XmlDocument _xmldoc = new XmlDocument();
        private readonly FlightContext _context;
        public FlightRepository(FlightContext context)
        {
            _context = context;
        }

        public XmlDocument GetFlights() {
            string xpath = "//*";
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc;
        }

        public XmlDocument GetFlightsByNumber(int number)
        {
            string xpath = String.Format("//flight[@flightnumber='{0}']", number);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc;
        }
        
        public XmlDocument GetFlightsByGate(int gate)
        {
            string xpath = String.Format("//flight[@gate='{0}']", gate);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc;
        }

        public XmlDocument GetFlightsByCity(string city)
        {
            string xpath = String.Format("//flight[@city='{0}']", city);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc;
        }

        public XmlDocument GetFlightsByDirection(string direction)
        {
            string xpath = String.Format("//flight[@type='{0}']", direction);
            _xmldoc.LoadXml(_context.GetXmlData(xpath));
            return _xmldoc;
        }
    }
}