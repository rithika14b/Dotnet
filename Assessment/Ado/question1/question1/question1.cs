using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement
{
    class question1
    {
        static void Main(string[] args)
        {

            string conStr = "Data Source=ICS-LT-1LN9J84\\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True";

            SqlConnection Connection = new SqlConnection(conStr);

            Console.Write("Enter Employee Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Employee Type (F/P) : ");
            char type = Convert.ToChar(Console.ReadLine());


            SqlCommand cmd = new SqlCommand("sp_InsertEmployee", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpName", name);
            cmd.Parameters.AddWithValue("@Empsal", salary);
            cmd.Parameters.AddWithValue("@Emptype", type);


            Connection.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Employee Inserted Successfully");

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Employee_Details", Connection);
            SqlDataReader display = cmd2.ExecuteReader();
            Console.WriteLine("\nEmployee Details");

            while (display.Read())
            {
                Console.WriteLine(
                    display["Empno"] + "  " +
                    display["EmpName"] + "  " +
                    display["Empsal"] + "  " +
                    display["Emptype"]);
            }

            display.Close();
            Connection.Close();
            Console.ReadLine();
        }
    }
}
