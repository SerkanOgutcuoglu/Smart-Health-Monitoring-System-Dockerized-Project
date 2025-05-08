using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SmartHealthMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthDataController : ControllerBase
    {
        private static readonly Random _random = new Random();

        [HttpGet]
        public IActionResult GetAllPatientsHealthData()
        {
            var allHealthData = new List<HealthDataModel>();

            for (int i = 1; i <= 100; i++) // 100 hasta
            {
                int heartRate = _random.Next(60, 100);
                string bloodPressure = $"{_random.Next(110, 130)}/{_random.Next(70, 85)}";
                int oxygenLevel = _random.Next(90, 100);

                var data = new HealthDataModel
                {
                    Id = i,
                    HeartRate = heartRate,
                    BloodPressure = bloodPressure,
                    OxygenLevel = oxygenLevel,
                    Timestamp = DateTime.Now
                };

                allHealthData.Add(data);
            }
            SaveToMySQL saveToMySQL = new SaveToMySQL();
            saveToMySQL.Save2MySQL(allHealthData);

            return Ok(allHealthData);
        }
    }
}
