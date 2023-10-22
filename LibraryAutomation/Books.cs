using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace LibraryAutomation
{
    public partial class Books : Form
    {

        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        public Books()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            LoadBooksData();
        }

        private void LoadBooksData()
        {
            using (MySqlConnection connection = dbHelper.GetDatabaseConnection())
            {
                connection.Open();
                string command = "SELECT * FROM books";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }

            SetDataGridHeaders();
        }

        private void SetDataGridHeaders()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].HeaderText = "Basım Yılı";
            dataGridView1.Columns[5].HeaderText = "Tür";
            dataGridView1.Columns[6].HeaderText = "Raf";
            dataGridView1.Columns[7].HeaderText = "Barkod";
            dataGridView1.Columns[8].HeaderText = "Stok";
            dataGridView1.Columns[9].HeaderText = "Verilebilirlik";
        }

        private void SearchBooks(string columnName, string query)
        {
            using (MySqlConnection connection = dbHelper.GetDatabaseConnection())
            {
                connection.Open();
                string command = $"SELECT * FROM books WHERE {columnName} LIKE @query";
                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@query", "%" + query + "%");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchBooks("name", textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchBooks("writer", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchBooks("barcodeNo", textBox1.Text);
        }

      
    }
}
