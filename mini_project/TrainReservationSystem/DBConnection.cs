using System.Data.SqlClient;

namespace TrainReservationSystem
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con =
                new SqlConnection(
                @"Data Source=ICS-LT-1LN9J84\SQLEXPRESS;
                  Initial Catalog=TrainReservationDB;
                  Integrated Security=True");

            return con;
        }
    }
}
