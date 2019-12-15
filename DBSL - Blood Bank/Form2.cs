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
    public partial class Form2 : Form
    {
        public static string name, city, blood_type, gender, q;
        int age, needed_bags;
        long contact_number;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_connection = @"Data Source=DESKTOP-TL169CU\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=dbsl";
            SqlConnection connection = new SqlConnection(str_connection);
            connection.Open();
            try
            {
                name = textBox1.Text;
                age = int.Parse(textBox3.Text);
                city = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                blood_type = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                gender = comboBox3.Items[comboBox3.SelectedIndex].ToString();
                needed_bags = int.Parse(textBox4.Text);
                contact_number = long.Parse(textBox2.Text);

                q = "INSERT INTO dbsl.dbo.patients(patient_name,patient_age,patient_gender,patient_city,patient_blood_type,patient_needed_bags,patient_contact_number) values "
                        + "('" + name + "'," + age + ",'" + gender + "','" + city + "','" + blood_type + "'," + needed_bags + "," + contact_number + ")";

                SqlCommand com1 = new SqlCommand(q, connection);
                com1.ExecuteNonQuery();

                connection.Close();
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Close();
            }
            catch(Exception e1)
            {
                MessageBox.Show("Please Enter a valid Values");
                connection.Close();

                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
