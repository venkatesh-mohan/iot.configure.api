using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;

namespace iot.configure.api.Repository
{
    public interface IDeviceConfigRepository
    {
        void AddDeviceConfigDetails(Deviceconfig deviceconfig);
    }
}
