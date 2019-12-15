using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string str_connection = @"Data Source=DESKTOP-TL169CU\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=dbsl";
            SqlConnection connection = new SqlConnection(str_connection);
            connection.Open();

            string x = Form2.blood_type;
            string q = "SELECT donner_name AS ' Name ', donner_city AS ' City ', donner_blood_type AS 'Blood Type',donner_gender AS ' Gender ', [donner_contact_number] AS ' Contact Number ' FROM donners WHERE donner_blood_type = '" + x + "' AND donner_age > 18 AND ( (donner_gender = 'Male' and donner_last_donate > 4) OR (donner_gender = 'Female' and donner_last_donate > 6) );";
            SqlCommand com = new SqlCommand(q, connection);

            SqlDataReader data_reader = com.ExecuteReader();
            DataTable data_table = new DataTable();
            data_table.Load(data_reader);
            this.dataGridView1.DataSource = data_table;
        }
    }
}
