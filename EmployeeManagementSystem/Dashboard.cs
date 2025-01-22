using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmployeeManagementSystem
{
    public partial class Dashboard : UserControl
    {
        private SqlConnection _connection = new SqlConnection("Server=DESKTOP-FM0I2MB\\SQLEXPRESS;Database=EmployeeManagementSystem;Trusted_Connection=True;");
        public Dashboard()
        {
            InitializeComponent();
            displayTotalEmployees();
            displayActiveEmployees();
            displayInactiveEmployees();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayTotalEmployees();
            displayActiveEmployees();
            displayInactiveEmployees();
        }
        public void displayTotalEmployees()
        {
            if (_connection.State != ConnectionState.Open)
            {
                try
                {
                    _connection.Open();

                    string selectData = "SELECT COUNT(id) FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, _connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_TE.Text = count.ToString();
                        }
                        reader.Close();
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
        }

        public void displayActiveEmployees()
        {
            if (_connection.State != ConnectionState.Open)
            {
                try
                {
                    _connection.Open();

                    string selectData = "SELECT COUNT(id) FROM employees WHERE status = @status AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, _connection))
                    {
                        cmd.Parameters.AddWithValue("@status", "Active");

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_AE.Text = count.ToString();
                        }
                        reader.Close();
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
        }

        public void displayInactiveEmployees()
        {
            if (_connection.State != ConnectionState.Open)
            {
                try
                {
                    _connection.Open();

                    string selectData = "SELECT COUNT(id) FROM employees WHERE status = @status AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, _connection))
                    {
                        cmd.Parameters.AddWithValue("@status", "Inactive");

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_IE.Text = count.ToString();
                        }
                        reader.Close();
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
        }
    }
}
