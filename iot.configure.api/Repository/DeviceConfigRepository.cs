using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using iot.configure.api.Models;
using iot.configure.api.Helpers;

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



        public void AddDeviceConfigDetails(Deviceconfig deviceconfig)
        {
            try
            {
                foreach (DeviceConfigDetails configDetails in deviceconfig.Inputlist)
                {
                    _logger.LogInformation($"DeviceConfigRepository.AddDeviceConfigDetails: Start - Adding configuraation against device {deviceconfig.Mac}");
                    using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (NpgsqlCommand command = new NpgsqlCommand("usp_insert_deviceconfig", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("p_deviceid", Utility.HexToLong(deviceconfig.Mac));
                            command.Parameters.AddWithValue("p_inputid", configDetails.InputId);
                            command.Parameters.AddWithValue("p_inputypeid", configDetails.InputTypeId);
                            command.Parameters.AddWithValue("p_inputname", configDetails.InputName);
                            command.Parameters.AddWithValue("p_coeffcientvalue", configDetails.CoefficientValue);
                            command.Parameters.AddWithValue("p_isinputconnected", configDetails.IsInputConnected);
                            deviceconfig.DeviceId = Convert.ToInt64(command.ExecuteNonQuery());
                            conn.Close();
                        }

                    }
                    _logger.LogInformation($"DeviceConfigRepository.AddDeviceConfigDetails:{deviceconfig.Mac}");
                }
            }
            catch (Exception ex)
            {
                deviceconfig = null;
                string innerEx = "";
                if (ex.InnerException != null)
                {
                    innerEx += ",InnerException: " + ex.InnerException.Message;
                }
                _logger.LogError($"DeviceConfigRepository.AddDeviceConfigDetails : Exception -  {ex.Message},{innerEx}");
            }
            //return deviceconfig;
        }
    }
}
