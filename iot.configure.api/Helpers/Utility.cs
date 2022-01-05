using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot.configure.api.Helpers
{
    public static class Utility
    {
        public static long HexToLong(string macAddress)
        {
            return long.Parse(macAddress, System.Globalization.NumberStyles.HexNumber, null);

        }
    }
}
