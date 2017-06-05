﻿using System;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SyracuseAirportApi.Repositories;

namespace SyracuseAirportApi.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _flightRepository;

        public FlightsController(IFlightRepository FlightRepository)
        {
            _flightRepository = FlightRepository;
        }

        // Get all flights.
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                XmlDocument doc = _flightRepository.GetFlights();
                return Ok(JsonConvert.SerializeXmlNode(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get flghts by number.
        [HttpGet("findByNumber")]
        public ActionResult GetByNumber(int number)
        {
            try
            {
                XmlDocument doc = _flightRepository.GetFlightsByNumber(number);
                return Ok(JsonConvert.SerializeXmlNode(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get flights by gate.
        [HttpGet("findByGate")]
        public ActionResult GetByGate(int gate)
        {
            try
            {
                XmlDocument doc = _flightRepository.GetFlightsByGate(gate);
                return Ok(JsonConvert.SerializeXmlNode(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get flights by city.
        [HttpGet("findByCity")]
        public ActionResult GetByCity(string city)
        {
            try
            {
                XmlDocument doc = _flightRepository.GetFlightsByCity(city);
                return Ok(JsonConvert.SerializeXmlNode(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get flights by direction.
        [HttpGet("findByDirection")]
        public ActionResult GetByDirection(string direction)
        {
            try
            {
                XmlDocument doc = _flightRepository.GetFlightsByDirection(direction);
                return Ok(JsonConvert.SerializeXmlNode(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
