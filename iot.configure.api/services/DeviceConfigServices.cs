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
        IDeviceConfigRepository DeviceConfigRepository;
        

        public DeviceConfigDetails AddDeviceConfigDetails(DeviceConfigDetails deviceconfigdetails)
        {
            return DeviceConfigRepository.AddDeviceConfigDetails(deviceconfigdetails);
        }
    }
}
