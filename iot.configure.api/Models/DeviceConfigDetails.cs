using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot.configure.api.Models
{
    public class DeviceConfigDetails
    {
        public long DeviceId { get; set; }
        public int InputId { get; set; }

        public int InputName { get; set; }

        public int InputTypeId { get; set; }

        public decimal CoefficientValue { get; set; }

        public bool IsInputConnected { get; set; }

    }
}
