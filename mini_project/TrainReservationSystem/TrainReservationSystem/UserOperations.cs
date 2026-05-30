using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    public class UserOperations
    {
        DBConnection db =new DBConnection();
        public void SearchTrain()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Source : ");
                string source = Console.ReadLine();

                Console.Write("Enter Destination : ");
                string destination = Console.ReadLine();

                string query =
                @"SELECT T.TrainNo,T.TrainName,C.ClassType,C.AvailableSeats,C.Charges
                  FROM TrainDetails T
                  INNER JOIN TrainClassDetails C
                  ON T.TrainNo = C.TrainNo
                  WHERE T.SourceStation=@Source
                  AND T.DestinationStation=@Destination
                  AND T.IsActive=1";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("Available Trains");
                Console.WriteLine("--------------------------------------------------");

                while (dr.Read())
                {
                    Console.WriteLine(
                        "Train No : " + dr["TrainNo"]);
                    Console.WriteLine(
                        "Train Name : " + dr["TrainName"]);
                    Console.WriteLine(
                        "Class : " + dr["ClassType"]);
                    Console.WriteLine(
                        "Seats : " + dr["AvailableSeats"]);
                    Console.WriteLine(
                        "Charges : " + dr["Charges"]);

                    Console.WriteLine("--------------------------------");
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
        private void ShowAvailableSeats(SqlConnection con,int trainNo,string classType)

          {
            int totalSeats = 0;

            string seatCountQuery =@"SELECT AvailableSeats FROM TrainClassDetails WHERE TrainNo=@TrainNo AND ClassType=@ClassType";

            SqlCommand seatCmd =new SqlCommand(seatCountQuery, con);

            seatCmd.Parameters.AddWithValue("@TrainNo", trainNo);
            seatCmd.Parameters.AddWithValue("@ClassType", classType);

            totalSeats =
                Convert.ToInt32(seatCmd.ExecuteScalar());

            string prefix = "";

            if (classType == "2AC")
                prefix = "A";
            else if (classType == "3AC")
                prefix = "B";
            else
                prefix = "S";

            Console.WriteLine();
            Console.WriteLine("Available Seats");

            for (int i = 1; i <= totalSeats; i++)
            {
                string seatNo = prefix + i;

                string checkQuery =
                @"SELECT COUNT(*)
          FROM PassengerDetails P
          INNER JOIN BookingDetails B
          ON P.BookingId = B.BookingId
          WHERE B.TrainNo=@TrainNo
          AND B.ClassType=@ClassType
          AND P.SeatNo=@SeatNo";

                SqlCommand checkCmd =new SqlCommand(checkQuery, con);

                checkCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                checkCmd.Parameters.AddWithValue("@ClassType", classType);
                checkCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                int booked =Convert.ToInt32(checkCmd.ExecuteScalar());

                if (booked == 0)
                {
                    Console.Write(seatNo + " ");
                }
            }

            Console.WriteLine();
        }
        public void BookTicket()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Train No : ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Class (2AC/3AC/Sleeper) : ");
                string classType = Console.ReadLine();

                DateTime travelDate;

                while (true)
                {
                    Console.Write("Enter Travel Date (yyyy-mm-dd) : ");
                    travelDate = Convert.ToDateTime(Console.ReadLine());

                    if (travelDate.Date < DateTime.Now.Date)
                    {
                        Console.WriteLine("Something wrong  in your entered date ");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Passenger Count (Max 3) : ");
                int count =
                    Convert.ToInt32(Console.ReadLine());

                if (count > 3)
                {
                    Console.WriteLine("Maximum 3 Passengers Allowed");
                    Console.ReadKey();
                    return;
                }

                string chargeQuery =
                    @"SELECT Charges FROM TrainClassDetails
              WHERE TrainNo=@TrainNo AND ClassType=@ClassType";

                SqlCommand chargeCmd =new SqlCommand(chargeQuery, con);

                chargeCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                chargeCmd.Parameters.AddWithValue("@ClassType", classType);

                con.Open();

                ShowAvailableSeats(con, trainNo, classType);

                decimal charge = Convert.ToDecimal(chargeCmd.ExecuteScalar());

                decimal amount = charge * count;

                string bookingQuery = @"INSERT INTO BookingDetails
                 VALUES(@BookingDate,@TravelDate,@TrainNo,@ClassType,@PassengerCount,@Amount)";

                SqlCommand bookingCmd = new SqlCommand(bookingQuery, con);

                bookingCmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                bookingCmd.Parameters.AddWithValue("@TravelDate", travelDate);
                bookingCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                bookingCmd.Parameters.AddWithValue("@ClassType", classType);
                bookingCmd.Parameters.AddWithValue("@PassengerCount", count);
                bookingCmd.Parameters.AddWithValue("@Amount", amount);

                bookingCmd.ExecuteNonQuery();

                SqlCommand idCmd =new SqlCommand("SELECT MAX(BookingId) FROM BookingDetails", con);

                int bookingId = Convert.ToInt32(idCmd.ExecuteScalar());

                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Passenger " + i);

                    Console.Write("Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Age : ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gender : ");
                    string gender = Console.ReadLine();

                    string seatNo;

                    while (true)
                    {
                        Console.Write("Choose Seat : ");
                        seatNo = Console.ReadLine();

                        string checkSeatQuery =
                        @"SELECT COUNT(*)
                  FROM PassengerDetails P
                  INNER JOIN BookingDetails B
                  ON P.BookingId = B.BookingId
                  WHERE B.TrainNo=@TrainNo
                  AND B.ClassType=@ClassType
                  AND P.SeatNo=@SeatNo";

                        SqlCommand seatCheckCmd = new SqlCommand(checkSeatQuery, con);

                        seatCheckCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        seatCheckCmd.Parameters.AddWithValue("@ClassType", classType);
                        seatCheckCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                        int seatBooked =Convert.ToInt32(seatCheckCmd.ExecuteScalar());

                        if (seatBooked > 0)
                        {
                            Console.WriteLine("Seat Already Booked. Choose another seat.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    string passengerQuery =@"INSERT INTO PassengerDetails
                         VALUES(@BookingId,@Name,@Age,@Gender,@SeatNo)";

                    SqlCommand passengerCmd =new SqlCommand(passengerQuery, con);

                    passengerCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    passengerCmd.Parameters.AddWithValue("@Name", name);
                    passengerCmd.Parameters.AddWithValue("@Age", age);
                    passengerCmd.Parameters.AddWithValue("@Gender", gender);
                    passengerCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                    passengerCmd.ExecuteNonQuery();
                }

                string updateSeat =@"UPDATE TrainClassDetails
          SET AvailableSeats = AvailableSeats - @Count
          WHERE TrainNo=@TrainNo AND ClassType=@ClassType";

                SqlCommand updateCmd =new SqlCommand(updateSeat, con);

                updateCmd.Parameters.AddWithValue("@Count", count);
                updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                updateCmd.Parameters.AddWithValue("@ClassType", classType);

                updateCmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine();
                Console.WriteLine("Booking Successful");
                Console.WriteLine("Booking Id : " + bookingId);
                Console.WriteLine("Amount : " + amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        public void ViewTicket()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Booking Id : ");
                int bookingId =Convert.ToInt32(Console.ReadLine());

                string bookingQuery =@"SELECT * FROM BookingDetails WHERE BookingId=@BookingId";

                SqlCommand cmd =new SqlCommand(bookingQuery, con);

                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                con.Open();

                SqlDataReader dr =cmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("Booking Id : " + dr["BookingId"]);
                    Console.WriteLine("Train No : " + dr["TrainNo"]);
                    Console.WriteLine("Class : " + dr["ClassType"]);
                    Console.WriteLine("Travel Date : " + dr["TravelDate"]);
                    Console.WriteLine("Amount : ₹" + dr["Amount"]);
                }

                dr.Close();

                string passengerQuery =@"SELECT * FROM PassengerDetails WHERE BookingId=@BookingId";

                SqlCommand passengerCmd =new SqlCommand(passengerQuery, con);

                passengerCmd.Parameters.AddWithValue("@BookingId", bookingId);

                SqlDataReader pdr =passengerCmd.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("Passengers");

                while (pdr.Read())
                {
                    Console.WriteLine( pdr["PassengerName"] + " | " +pdr["Age"] + " | " +pdr["Gender"] + " | " + pdr["SeatNo"]);
                }

                pdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        public void CancelTicket()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                Console.Write("Enter Booking Id : ");
                int bookingId =Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Seat No To Cancel : ");
                string seatNo =Console.ReadLine();

                con.Open();

                string refundQuery =@"INSERT INTO CancellationDetails
                 (BookingId,SeatNo,RefundAmount) VALUES(@BookingId,@SeatNo,900)";

                SqlCommand refundCmd =new SqlCommand(refundQuery, con);

                refundCmd.Parameters.AddWithValue("@BookingId", bookingId);
                refundCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                refundCmd.ExecuteNonQuery();

                string deletePassenger = @"DELETE FROM PassengerDetails
                 WHERE BookingId=@BookingId AND SeatNo=@SeatNo";

                SqlCommand deleteCmd =new SqlCommand(deletePassenger, con);

                deleteCmd.Parameters.AddWithValue("@BookingId", bookingId);
                deleteCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                deleteCmd.ExecuteNonQuery();

                Console.WriteLine("Ticket Cancelled");
                Console.WriteLine("Refund Amount : ₹900");

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
