﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        private SqlConnection _connection = new SqlConnection("Server=DESKTOP-FM0I2MB\\SQLEXPRESS;Database=EmployeeManagementSystem;Trusted_Connection=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _connection.Open();

                        string selectData = "SELECT * FROM users WHERE username = @username AND password = @password";

                        using (SqlCommand cmd = new SqlCommand(selectData, _connection))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                               MessageBox.Show("Incorrect Username or Password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }
    }
}
