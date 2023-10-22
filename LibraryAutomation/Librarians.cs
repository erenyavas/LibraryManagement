using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class Librarians : Form
    {
        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Librarians()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
            dataAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
        }

        private void Librarians_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            connection.Open();
            RefreshData();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO librarians (dutyDate, nameSurname, studentID, className) VALUES (@dutyDate, @nameSurname, @studentID, @className)";

            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@dutyDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@nameSurname", textBox1.Text);
                cmd.Parameters.AddWithValue("@studentID", textBox3.Text);
                cmd.Parameters.AddWithValue("@className", textBox2.Text);

                cmd.ExecuteNonQuery();
            }

            RefreshData();
            ClearTextBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM librarians WHERE dutyDate = @dutyDate";

            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@dutyDate", dateTimePicker2.Text);
                cmd.ExecuteNonQuery();
            }

            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm Kayıtları Silmek İstiyor Musunuz?", "Uyarı Penceresi!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                string deleteAllQuery = "DELETE FROM librarians";

                using (MySqlCommand cmd = new MySqlCommand(deleteAllQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                RefreshData();
            }
        }

        private void RefreshData()
        {
            string selectQuery = "SELECT * FROM librarians";
            dataAdapter.SelectCommand = new MySqlCommand(selectQuery, connection);
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad Soyad";
            dataGridView1.Columns[2].HeaderText = "Numara";
            dataGridView1.Columns[3].HeaderText = "Sınıf";
            dataGridView1.Columns[4].HeaderText = "Tarih";
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
