using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class Admin : Form
    {

        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        private string adminPassword;

        public Admin()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
            adminPassword = GetAdminPassword();
        }

        private string GetAdminPassword()
        {
            string password = null;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT password FROM admin WHERE id = 1", connection))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    password = reader["password"].ToString();
                }
            }
            connection.Close(); 
            return password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox2.Text;

            if (textBox1.Text == adminPassword)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (UpdateAdminPassword(newPassword))
                {
                    MessageBox.Show("Şifre Güncellendi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Şifre Güncellenemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girdiğiniz Şifre Hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close(); 
        }

        private bool UpdateAdminPassword(string newPassword)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE admin SET password = @newPass WHERE id = 1", connection))
                {
                    cmd.Parameters.AddWithValue("@newPass", newPassword);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close(); 
                    return rowsAffected == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close(); 
                return false;
            }
        }

    }
}
