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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_connection = @"Data Source=DESKTOP-TL169CU\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=dbsl";
            SqlConnection connection = new SqlConnection(str_connection);
            connection.Open();

            try
            {
                string name = textBox1.Text;
                int age = int.Parse(textBox3.Text);
                string city = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string blood_type = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string gender = comboBox3.Items[comboBox3.SelectedIndex].ToString();
                int last_donate = int.Parse(textBox4.Text);
                long contact_number = long.Parse(textBox2.Text);

                string q = "INSERT INTO dbsl.dbo.donners(donner_name,donner_age,donner_gender,donner_city,donner_blood_type,donner_last_donate,donner_contact_number) values "
                        + "('" + name + "'," + age + ",'" + gender + "','" + city + "','" + blood_type + "'," + last_donate + "," + contact_number + ")";

                SqlCommand com1 = new SqlCommand(q, connection);
                com1.ExecuteNonQuery();
                Console.WriteLine(connection.State);

                this.Hide();
                Form7 f7 = new Form7();
                f7.ShowDialog();
                this.Close();

                connection.Close();
            }
            catch (Exception epp)
            {
                
                MessageBox.Show("Please, Enter a valid Value");
                connection.Close();
                this.Hide();
                Form6 f6 = new Form6();
                f6.ShowDialog();
                this.Close();
            }
            
        }
    }
}
