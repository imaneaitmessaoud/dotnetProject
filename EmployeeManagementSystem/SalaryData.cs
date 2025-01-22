using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace EmployeeManagementSystem
{
    public class SalaryData
    {
        public string EmployeeID { get; set; } // 0 
        public string Name { get; set; } // 1
        public string Gender {get; set; } // 2
        public string Contact {get; set; } // 3
        public string Position { get; set; } // 4
        public int Salary { get; set; } // 5


        private SqlConnection _connection = new SqlConnection("Server=DESKTOP-FM0I2MB\\SQLEXPRESS;Database=EmployeeManagementSystem;Trusted_Connection=True;");


        public List<SalaryData> salaryEmployeeListData()
        {
            List<SalaryData> listData = new List<SalaryData>();

            if (_connection.State != ConnectionState.Open)
            {
                try
                {
                    _connection.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL AND status = 'Active'";

                    using(SqlCommand cmd = new SqlCommand(selectData, _connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            SalaryData salaryData = new SalaryData();
                            salaryData.EmployeeID = reader["employee_id"].ToString();
                            salaryData.Name = reader["full_name"].ToString();
                            salaryData.Gender = reader["gender"].ToString();
                            salaryData.Contact = reader["contact_number"].ToString();
                            salaryData.Position = reader["position"].ToString();
                            salaryData.Salary = (int)reader["salary"];

                            listData.Add(salaryData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:{ex}", "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _connection.Close();
                }
            }
            return listData;
        }
    }
}
