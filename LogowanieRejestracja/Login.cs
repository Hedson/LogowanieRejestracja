using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace LogowanieRejestracja
{
    public partial class Login : Form
    {

        public static string AlreadyUserName;

        SqlConnection connection;
        string connectionString;
        public Login()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["LogowanieRejestracja.Properties.Settings.LoginConnectionString"].ConnectionString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "SELECT * FROM Login where Username = @user and Password = @pass";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // get string from textBox1 and textBox2
                command.Parameters.AddWithValue("@user", textBox1.Text);
                command.Parameters.AddWithValue("@pass", textBox2.Text);

                // create new DataTable instance
                DataTable recipeTable = new DataTable();
                adapter.Fill(recipeTable);

                int count = recipeTable.Rows.Count;
                if (count == 1)
                {
                    AlreadyUserName = textBox1.Text;
                    MessageBox.Show(AlreadyUserName);
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Biodata bio = new Biodata();
                    bio.Show();
                }
                else
                {
                    MessageBox.Show("Login failed!");
                }

               

                listBox1.DisplayMember = "Username";
                listBox1.ValueMember = "Id";
                listBox1.DataSource = recipeTable;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }   
}

