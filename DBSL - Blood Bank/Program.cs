



using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string str_connection = @"Data Source=DESKTOP-TL169CU\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=master";
            SqlConnection connection = new SqlConnection(str_connection);
            connection.Open();
            try
            {
                SqlCommand com1 = new SqlCommand("CREATE DATABASE dbsl", connection);
                com1.ExecuteNonQuery();
                com1.Connection.ChangeDatabase("dbsl");
                SqlCommand com2 = new SqlCommand("create table dbsl.dbo.donners([donner_id] int,[donner_name] varchar(255),[donner_gender] varchar(255),[donner_city] varchar(255),[donner_blood_type] varchar(255),[donner_last_donate] int,[donner_contact_number] bigint))", connection);
                SqlCommand com3 = new SqlCommand("create table dbsl.dbo.patients([patient_id] int,[patient_name] varchar(255),[patient_gender] varchar(255),[patient_city] varchar(255),[patient_blood_type] varchar(255),[patient_needed_bags] int,[donner_contact_number] bigint))", connection);
                com2.ExecuteNonQuery();
                com3.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // already created
            }
            connection.Close();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
