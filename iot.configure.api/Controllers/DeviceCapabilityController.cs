using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using iot.configure.api.Models;
using iot.configure.api.services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iot.configure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceCapabilityController : ControllerBase
    {
        private readonly IDeviceCapabilityServices _deviceCapabilityServices;
        private readonly ILogger<DeviceCapabilityController> _logger;

        public DeviceCapabilityController(ILogger<DeviceCapabilityController> logger, IDeviceCapabilityServices deviceCapabilityServices)
        {
            _deviceCapabilityServices = deviceCapabilityServices;
            _logger = logger;

        }


        // GET: api/<DeviceCapabilityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeviceCapabilityController>/5
        [HttpGet("{mac}")]
        public ActionResult Get(string mac)
        {
            return Ok(_deviceCapabilityServices.GetDeviceCapabilites(mac));
            
        }

        // POST api/<DeviceCapabilityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeviceCapabilityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviceCapabilityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
