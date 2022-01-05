using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using iot.configure.api.Helpers;
using Newtonsoft.Json;

namespace iot.configure.api.Repository
{
    public class DeviceCapabilityRepository: IDeviceCapabilityRepository
    {
        private readonly ILogger _logger;
        private static string _connectionString;
        public DeviceCapabilityRepository(ILogger<DeviceCapabilityRepository> logger, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnectionString");
            _logger = logger;
        }
        

        public DeviceCapability GetDeviceCapabilities(string mac)
        {
            
            DeviceCapability devicecapability = null;

            try
            {
                _logger.LogInformation($"DeviceRepository.GetDeviceCapability: Start - Getting Device Mac For Given Device Id = {mac}");
                using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand("public.usp_getdevicecapabilities", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_deviceid", Utility.HexToLong(mac));
                        using (NpgsqlDataReader dr = command.ExecuteReader())// command.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                devicecapability = new DeviceCapability()
                                {
                                    DeviceId = Convert.ToInt64(dr["deviceid"]),
                                    Mac = Convert.ToString(dr["serialnumber"]),
                                    Inputlist = JsonConvert.DeserializeObject<List<DeviceInput>>(dr["capabilities"].ToString())

                                };

                            }
                        }
                    }

                }
                _logger.LogInformation($"DeviceRepository.GetDevice: End - Getting Device Mac For Given Device Id = {mac}");
            }
            catch (Exception ex)
            {
                devicecapability = null;
                string innerEx = "";
                if (ex.InnerException != null)
                {
                    innerEx += ",InnerException: " + ex.InnerException.Message;
                }
                _logger.LogError($"DeviceRepository.GetDevice : Exception - Device Name For Given id = {ex.Message},{innerEx}");
            }
            return devicecapability;
        }
    }
}
