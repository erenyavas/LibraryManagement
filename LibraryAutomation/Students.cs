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
    public partial class Students : Form
    {

        private DatabaseHelper dbHelper;
        private MySqlConnection connection;


        public Students()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }

  

        private void Students_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            connection.Open();
            string query = "SELECT * FROM students";

            using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Ad Soyad";
                dataGridView1.Columns[2].HeaderText = "Sınıf";
                dataGridView1.Columns[3].HeaderText = "Numara";
                dataGridView1.Columns[4].HeaderText = "Okuduğu Kitap Sayısı";
                dataGridView1.Columns[5].HeaderText = "Elindeki Kitap Sayısı";
            }

            connection.Close();
        }

        private void SearchStudents(string searchTerm, string columnName)
        {
            connection.Open();
            string query = "SELECT * FROM students WHERE " + columnName + " LIKE @searchTerm";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentID = textBox1.Text;
            SearchStudents(studentID, "studentID");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nameSurname = textBox1.Text;
            SearchStudents(nameSurname, "nameSurname");
        }
    }
}
