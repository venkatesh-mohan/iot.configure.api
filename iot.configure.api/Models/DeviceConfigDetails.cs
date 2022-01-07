using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot.configure.api.Models
{
    public class DeviceConfigDetails
    {   
        public int InputId { get; set; }

        public string InputName { get; set; }

        public int InputTypeId { get; set; }

        public decimal CoefficientValue { get; set; }

        public bool IsInputConnected { get; set; }

    }
}
