using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using iot.configure.api.Repository;

namespace iot.configure.api.services
{
    public class DeviceCapabilityServices : IDeviceCapabilityServices
    {
        private readonly IDeviceCapabilityRepository _deviceCapabilityRepository;

        public DeviceCapabilityServices(IDeviceCapabilityRepository deviceCapabilityRepository)
        {
            _deviceCapabilityRepository = deviceCapabilityRepository;
        }
        public String GetDeviceCapabilites(long id)
        {
            
            return _deviceCapabilityRepository.GetDeviceCapabilities(id);
        }
    }
}
