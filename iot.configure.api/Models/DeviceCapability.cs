using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot.configure.api.Models
{
    public class DeviceCapability
    {
        public string Mac { get; set; }

        public long DeviceId { get; set; }

        public List<DeviceInput> Inputlist { get; set; }

    }
}
