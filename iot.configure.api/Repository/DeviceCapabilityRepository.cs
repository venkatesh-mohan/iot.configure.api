using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot.configure.api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;


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
        

        public string GetDeviceCapabilities(long id)
        {
            
            DeviceCapability devicecapability = null;

            try
            {
                _logger.LogInformation($"DeviceRepository.GetDeviceCapability: Start - Getting Device Mac For Given Device Id = {id}");
                using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand("get_devicecapability", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("DeviceId", id);
                        using (NpgsqlDataReader dr = command.ExecuteReader())// command.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                devicecapability = new DeviceCapability()
                                {
                                    DeviceId = Convert.ToInt32(dr["DeviceId"]),
                                    Mac = Convert.ToString(dr["Mac"]),

                                };

                            }
                        }
                    }

                }
                _logger.LogInformation($"DeviceRepository.GetDevice: End - Getting Device Mac For Given Device Id = {id}");
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
            return devicecapability.Mac;
        }
    }
}
