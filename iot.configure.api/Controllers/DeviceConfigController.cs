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
    public class DeviceConfigController : ControllerBase
    {
        private readonly IDeviceConfigService _deviceConfigServices;
        private readonly ILogger<DeviceConfigController> _logger;

        public DeviceConfigController(ILogger<DeviceConfigController> logger, IDeviceConfigService deviceConfigServices)
        {
            _deviceConfigServices = deviceConfigServices;
            _logger = logger;

        }


        // GET: api/<DeviceConfigController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeviceConfigController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeviceConfigController>
        [HttpPost]
        public void Post([FromBody] Deviceconfig deviceconfig)
        {
            _deviceConfigServices.AddDeviceConfigDetails(deviceconfig);
        }

        // PUT api/<DeviceConfigController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviceConfigController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
