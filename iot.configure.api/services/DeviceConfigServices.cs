using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using iot.configure.api.Repository;

namespace iot.configure.api.services
{
    public class DeviceConfigServices : IDeviceConfigServices
    {
        IDeviceConfigRepository _deviceConfigRepository;

        public DeviceConfigServices(IDeviceConfigRepository deviceConfigRepository)
        {
            _deviceConfigRepository = deviceConfigRepository;
        }


        public DeviceConfigDetails AddDeviceConfigDetails(DeviceConfigDetails deviceconfigdetails)
        {
            return _deviceConfigRepository.AddDeviceConfigDetails(deviceconfigdetails);
        }
    }
}
