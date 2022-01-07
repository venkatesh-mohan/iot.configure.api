using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using iot.configure.api.Repository;

namespace iot.configure.api.services
{
    public class DeviceCapabilityService : IDeviceCapabilityService
    {
        private readonly IDeviceCapabilityRepository _deviceCapabilityRepository;

        public DeviceCapabilityService(IDeviceCapabilityRepository deviceCapabilityRepository)
        {
            _deviceCapabilityRepository = deviceCapabilityRepository;
        }
        public DeviceCapability GetDeviceCapabilites(string mac)
        {
            
            return _deviceCapabilityRepository.GetDeviceCapabilities(mac);
        }
    }
}
