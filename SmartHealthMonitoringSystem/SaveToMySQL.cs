using MySql.Data.MySqlClient;

namespace SmartHealthMonitoringSystem
{
    public class SaveToMySQL
    {

        public void Save2MySQL(List<HealthDataModel> dataList)
        {
            string connectionString = "server=localhost;port=3306;user=root;password=test123;database=healthdb";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                foreach (var data in dataList)
                {
                    string query = @"INSERT INTO health_data 
                        (user_id, heart_rate, blood_pressure, temperature, recorded_at) 
                        VALUES (@user_id, @heart_rate, @blood_pressure, @temperature, @recorded_at)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", data.Id);
                        cmd.Parameters.AddWithValue("@heart_rate", data.HeartRate);
                        cmd.Parameters.AddWithValue("@blood_pressure", data.BloodPressure);
                        cmd.Parameters.AddWithValue("@temperature", data.OxygenLevel);
                        cmd.Parameters.AddWithValue("@recorded_at", data.Timestamp);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }





    }
}
