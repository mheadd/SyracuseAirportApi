using System;
using Xunit;
using AirportAPI.Controllers;
using AirportAPI.Repositories;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace AirportAPI.Tests
{
    public class FlightsControllerTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            var testFlightRepository = new TestFlightRepository();
            FlightsController controller = new FlightsController(testFlightRepository);
            var expected = typeof(OkObjectResult);

            // Act
            var actual = controller.GetAll();

            // Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void GetByNumberTest()
        {
            // Arrange
            var testFlightRepository = new TestFlightRepository();
            FlightsController controller = new FlightsController(testFlightRepository);
            var expected = typeof(OkObjectResult);

            // Act
            var actual = controller.GetByNumber(4650);

            // Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void GetByGateTest()
        {
            // Arrange
            var testFlightRepository = new TestFlightRepository();
            FlightsController controller = new FlightsController(testFlightRepository);
            var expected = typeof(OkObjectResult);

            // Act
            var actual = controller.GetByGate(24);

            // Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void GetByCityTest()
        {
            // Arrange
            var testFlightRepository = new TestFlightRepository();
            FlightsController controller = new FlightsController(testFlightRepository);
            var expected = typeof(OkObjectResult);

            // Act
            var actual = controller.GetByCity("DETROIT");

            // Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void GetByDirectionTest()
        {
            // Arrange
            var testFlightRepository = new TestFlightRepository();
            FlightsController controller = new FlightsController(testFlightRepository);
            var expected = typeof(OkObjectResult);

            // Act
            var actual = controller.GetByDirection("A");

            // Assert
            Assert.IsType(expected, actual);
        }
    }

    public class TestFlightRepository : IFlightRepository
    {
        private XmlDocument doc = new XmlDocument();
        public XmlNodeList GetFlights()
        {
            doc.LoadXml(_rawXMLString);
            return doc.GetElementsByTagName("flight");

        }
        public XmlNodeList GetFlightsByNumber(int number)
        {
            doc.LoadXml(_rawXMLString);
            return doc.GetElementsByTagName("flight");
        }
        public XmlNodeList GetFlightsByGate(int gate)
        {
            doc.LoadXml(_rawXMLString);
            return doc.GetElementsByTagName("flight");
        }
        public XmlNodeList GetFlightsByCity(string city)
        {
            doc.LoadXml(_rawXMLString);
            return doc.GetElementsByTagName("flight");
        }
        public XmlNodeList GetFlightsByDirection(string direction)
        {
            doc.LoadXml(_rawXMLString);
            return doc.GetElementsByTagName("flight");
        }

        private readonly string _rawXMLString = @"
        <results>
        <flight date=""06/06/17"" claim="" "" remarks=""ON TIME"" gate="""" actualtime=""1650"" scheduletime=""1650"" city=""CHICAGO-O`HARE"" flightnumber=""4650"" airlinecode=""UA"" indicator=""D"" type=""A"" />
        <flight date=""06/06/17"" claim="" "" remarks=""ON TIME"" gate=""25"" actualtime=""1656"" scheduletime=""1656"" city=""DETROIT"" flightnumber=""6241"" airlinecode=""DL"" indicator=""D"" type=""A"" />
        <flight date=""06/06/17"" claim="" "" remarks=""  5:19P"" gate=""24"" actualtime=""1719"" scheduletime=""1708"" city=""ATLANTA"" flightnumber=""2006"" airlinecode=""DL"" indicator=""D"" type=""A"" />
        <flight date=""06/06/17"" claim="" "" remarks=""ON TIME"" gate=""6"" actualtime=""1729"" scheduletime=""1729"" city=""PHILADELPHIA"" flightnumber=""4190"" airlinecode=""AA"" indicator=""D"" type=""A"" />
        <flight date=""06/06/17"" claim="" "" remarks=""  5:47P"" gate=""10"" actualtime=""1747"" scheduletime=""1742"" city=""CHICAGO-O`HARE"" flightnumber=""3542"" airlinecode=""AA"" indicator=""D"" type=""A"" />
        </results>";
    }
}
