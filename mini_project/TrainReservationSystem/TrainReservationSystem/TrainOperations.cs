using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    public class TrainOperations
    {
        private DBConnection db = new DBConnection();
        public void AddTrain()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Train No : ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Train Name : ");
                string trainName = Console.ReadLine();

                Console.Write("Source : ");
                string source = Console.ReadLine();

                Console.Write("Destination : ");
                string destination = Console.ReadLine();

                string trainQuery =@"INSERT INTO TrainDetails(TrainNo,TrainName,SourceStation,DestinationStation,ClassType,AvailableSeats,Charges,IsActive)
                                     VALUES(@TrainNo,@TrainName,@Source,@Destination,'NA',0,0,1)";

                SqlCommand trainCmd =
                    new SqlCommand(trainQuery, con);

                trainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                trainCmd.Parameters.AddWithValue("@TrainName", trainName);
                trainCmd.Parameters.AddWithValue("@Source", source);
                trainCmd.Parameters.AddWithValue("@Destination", destination);

                con.Open();
                trainCmd.ExecuteNonQuery();

                Console.Write("How many classes for this train? : ");
                int classCount =
                    Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= classCount; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Class " + i);

                    Console.Write("Class Name (2AC/3AC/Sleeper): ");
                    string classType = Console.ReadLine();

                    Console.Write("Available Seats : ");
                    int seats =Convert.ToInt32(Console.ReadLine());

                    Console.Write("Charges : ");
                    decimal charges =Convert.ToDecimal(Console.ReadLine());

                    string classQuery =@"INSERT INTO TrainClassDetails
                        (TrainNo,ClassType,AvailableSeats,Charges)
                        VALUES(@TrainNo,@ClassType,@Seats,@Charges)";

                    SqlCommand classCmd =new SqlCommand(classQuery, con);

                    classCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    classCmd.Parameters.AddWithValue("@ClassType", classType);
                    classCmd.Parameters.AddWithValue("@Seats", seats);
                    classCmd.Parameters.AddWithValue("@Charges", charges);

                    classCmd.ExecuteNonQuery();
                }

                con.Close();

                Console.WriteLine();
                Console.WriteLine("Train Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void UpdateTrain()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Train No : ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Class (2AC/3AC/Sleeper) : ");
                string classType = Console.ReadLine();

                Console.Write("New Available Seats : ");
                int seats = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Charges : ");
                decimal charges = Convert.ToDecimal(Console.ReadLine());

                string query = @"UPDATE TrainClassDetails
                 SET AvailableSeats=@Seats,
                 Charges=@Charges
                 WHERE TrainNo=@TrainNo AND ClassType=@ClassType";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@ClassType", classType);
                cmd.Parameters.AddWithValue("@Seats", seats);
                cmd.Parameters.AddWithValue("@Charges", charges);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                if (rows > 0)
                    Console.WriteLine("Train Updated Successfully");
                else
                    Console.WriteLine("Train/Class Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void ViewTrain()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT T.TrainNo,T.TrainName,T.SourceStation,T.DestinationStation,C.ClassType,C.AvailableSeats,C.Charges
                 FROM TrainDetails T
                 INNER JOIN TrainClassDetails C
                 ON T.TrainNo = C.TrainNo WHERE T.IsActive = 1 ORDER BY T.TrainNo";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("TrainNo | TrainName | Source | Destination | Class | Seats | Charges");
                Console.WriteLine("---------------------------------------------------------------------");

                while (dr.Read())
                {
                    Console.WriteLine(
                        dr["TrainNo"] + " | " +
                        dr["TrainName"] + " | " +
                        dr["SourceStation"] + " | " +
                        dr["DestinationStation"] + " | " +
                        dr["ClassType"] + " | " +
                        dr["AvailableSeats"] + " | " +
                        dr["Charges"]);
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        public void DeleteTrain()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Train No : ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                string query =@"UPDATE TrainDetails
                      SET IsActive = 0
                      WHERE TrainNo = @TrainNo";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                if (rows > 0)
                    Console.WriteLine("Train Deleted Successfully");
                else
                    Console.WriteLine("Train Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}