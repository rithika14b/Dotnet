
using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            string conStr ="Data Source=ICS-LT-1LN9J84\\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True";

            SqlConnection Connection = new SqlConnection(conStr);

            Console.Write("Enter Employee ID : ");
            int empid = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd =new SqlCommand("sp_UpdateSalary", Connection);

            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empid", empid);

            SqlParameter outSalary =new SqlParameter("@UpdatedSalary",SqlDbType.Decimal);

            outSalary.Direction = ParameterDirection.Output;

            outSalary.Precision = 10;
            outSalary.Scale = 2;

            cmd.Parameters.Add(outSalary);

            Connection.Open();

            cmd.ExecuteNonQuery();

            Console.WriteLine("Updated Salary : " + outSalary.Value);

            SqlCommand cmd2 =new SqlCommand("SELECT * FROM Employee_Details WHERE Empno=@id",Connection);

            cmd2.Parameters.AddWithValue("@id", empid);

            SqlDataReader Update = cmd2.ExecuteReader();

            Console.WriteLine("\nUpdated Employee Record");

            while (Update.Read())
            {
                Console.WriteLine(
                    Update["Empno"] + "  " +
                    Update["EmpName"] + "  " +
                    Update["Empsal"] + "  " +
                    Update["Emptype"]);
            }

            Update.Close();
            Connection.Close();

            Console.ReadLine();
        }
    }
}
