﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;

namespace iot.configure.api.services
{
    public interface IDeviceConfigServices
    {
        DeviceConfigDetails AddDeviceConfigDetails(DeviceConfigDetails deviceconfigdetails);
    }
}
