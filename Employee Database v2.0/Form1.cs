using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Database_v2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=Employeev20DB;Integrated Security=True";

            //2. establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection
            con.Open();

            //4. prepare query
            string label2 = textBox1.Text;
            string label3 = textBox2.Text;
            string label4 = textBox3.Text;
            string label5 = textBox4.Text;

            string Query = "INSERT INTO Names VALUES ('"+ label2 +"', '"+ label3 +"', '"+ label4 +"', '"+ label5 +"')";

            //5. execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //6. close connection
            con.Close();

            MessageBox.Show("Data has been saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=Employeev20DB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string Query = "SELECT * FROM Names";
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["EmployeeID"], reader["FirstName"], reader["LastName"], reader["Position"]);
            }

            //6. close connection (c# sqlcommand close)
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=Employeev20DB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string SearchData = textBox5.Text;
            string Query = "SELECT * FROM Names WHERE FirstName LIKE '%"+ SearchData +"%' OR LastName LIKE '%"+ SearchData +"%'";
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteReader();

            

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["EmployeeID"], reader["FirstName"], reader["LastName"], reader["Position"]);
            }

            //6. close connection (c# sqlcommand close)
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
