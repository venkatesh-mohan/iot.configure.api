using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using iot.configure.api.Models;

namespace iot.configure.api.Repository
{
    public class DeviceConfigRepository:IDeviceConfigRepository
    {
        private readonly ILogger _logger;
        private static string _connectionString;
        public DeviceConfigRepository(ILogger<DeviceConfigRepository> logger,IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnectionString");
            _logger = logger;
        }



        public DeviceConfigDetails AddDeviceConfigDetails(DeviceConfigDetails deviceconfigdetails)
        {
            try
            {
                _logger.LogInformation($"DeviceRepository.AddDevice: Start - Adding New device with {deviceconfigdetails}");
                using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand("add_deviceconfig", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("DeviceId", deviceconfigdetails.DeviceId);
                        command.Parameters.AddWithValue("InputId", deviceconfigdetails.InputId);
                        command.Parameters.AddWithValue("InputName", deviceconfigdetails.InputId);
                        command.Parameters.AddWithValue("Coefficientvalue", deviceconfigdetails.CoefficientValue);
                        command.Parameters.AddWithValue("IsConnected", deviceconfigdetails.IsInputConnected);
                        deviceconfigdetails.DeviceId = Convert.ToInt32(command.ExecuteNonQuery());
                        conn.Close();
                    }

                }
                _logger.LogInformation($"DeviceRepository.AddDeviceconfig:{deviceconfigdetails}");
            }
            catch (Exception ex)
            {
                deviceconfigdetails = null;
                string innerEx = "";
                if (ex.InnerException != null)
                {
                    innerEx += ",InnerException: " + ex.InnerException.Message;
                }
                _logger.LogError($"DeviceRepository.AddDevice : Exception - Add New Device {ex.Message},{innerEx}");
            }
            return deviceconfigdetails;
        }
    }
}
