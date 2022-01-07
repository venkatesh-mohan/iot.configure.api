using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using iot.configure.api.Repository;

namespace iot.configure.api.services
{
    public class DeviceConfigService : IDeviceConfigService
    {
        IDeviceConfigRepository _deviceConfigRepository;

        public DeviceConfigService(IDeviceConfigRepository deviceConfigRepository)
        {
            _deviceConfigRepository = deviceConfigRepository;
        }


        public void AddDeviceConfigDetails(Deviceconfig deviceconfig)
        {
            _deviceConfigRepository.AddDeviceConfigDetails(deviceconfig);
        }
    }
}
