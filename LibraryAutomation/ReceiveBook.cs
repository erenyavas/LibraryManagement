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
    public partial class ReceiveBook : Form
    {
        private DatabaseHelper dbHelper;
        private MySqlConnection connection;

        public ReceiveBook()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }
        private void ReceiveBook_Load(object sender, EventArgs e)
        {
            LoadLendBooks();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Barkod No";
            dataGridView1.Columns[2].HeaderText = "Numara";
            dataGridView1.Columns[3].HeaderText = "Veriliş Tarihi";
            dataGridView1.Columns[4].HeaderText = "Son Tarih";
            dataGridView1.Columns[5].HeaderText = "Nöbetçi";
            dataGridView1.Columns[6].HeaderText = "Kitap Geri Alındı Mı?";
        }


        private void LoadLendBooks()
        {
            connection.Open();
            string query = "SELECT * FROM lendbooks WHERE isReturned = 0";
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void UpdateBookStatus(string studentID, string barcodeNo)
        {
            connection.Open();

            MySqlCommand updateCommand = new MySqlCommand("UPDATE lendbooks SET isReturned = 1 WHERE studentID = @studentID AND barcodeNo = @barcodeNo", connection);
            updateCommand.Parameters.AddWithValue("@studentID", studentID);
            updateCommand.Parameters.AddWithValue("@barcodeNo", barcodeNo);

            if (updateCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Kitap Başarıyla Teslim Alındı!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update student and book information
                UpdateStudentCheckOutBooksCount(studentID);
                UpdateBookAvailableCount(barcodeNo);
                UpdateStudentReadBooksCount(studentID);
            }
            else
            {
                MessageBox.Show("Kitap Teslim Alınamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }

        private void UpdateStudentCheckOutBooksCount(string studentID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT checkOutBooksCount FROM students WHERE studentID = @studentID", connection);
            cmd.Parameters.AddWithValue("@studentID", studentID);

            int checkOutBooksCount = 0;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    checkOutBooksCount = Convert.ToInt32(reader["checkOutBooksCount"]);
                }
            }

            checkOutBooksCount--;

            MySqlCommand updateCmd = new MySqlCommand("UPDATE students SET checkOutBooksCount = @count WHERE studentID = @studentID", connection);
            updateCmd.Parameters.AddWithValue("@studentID", studentID);
            updateCmd.Parameters.AddWithValue("@count", checkOutBooksCount);
            updateCmd.ExecuteNonQuery();
        }

        private void UpdateBookAvailableCount(string barcodeNo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT availableCount FROM books WHERE barcodeNo = @barcodeNo", connection);
            cmd.Parameters.AddWithValue("@barcodeNo", barcodeNo);

            int availableCount = 0;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    availableCount = Convert.ToInt32(reader["availableCount"]);
                }
            }

            availableCount++;

            MySqlCommand updateCmd = new MySqlCommand("UPDATE books SET availableCount = @count WHERE barcodeNo = @barcodeNo", connection);
            updateCmd.Parameters.AddWithValue("@barcodeNo", barcodeNo);
            updateCmd.Parameters.AddWithValue("@count", availableCount);
            updateCmd.ExecuteNonQuery();
        }

        private void UpdateStudentReadBooksCount(string studentID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT readBooksCount FROM students WHERE studentID = @studentID", connection);
            cmd.Parameters.AddWithValue("@studentID", studentID);

            int readBooksCount = 0;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    readBooksCount = Convert.ToInt32(reader["readBooksCount"]);
                }
            }

            readBooksCount++;

            MySqlCommand updateCmd = new MySqlCommand("UPDATE students SET readBooksCount = @count WHERE studentID = @studentID", connection);
            updateCmd.Parameters.AddWithValue("@studentID", studentID);
            updateCmd.Parameters.AddWithValue("@count", readBooksCount);
            updateCmd.ExecuteNonQuery();
        }

        private void ReturnBook()
        {
            string studentID = textBox1.Text;
            string barcodeNo = textBox2.Text;
            UpdateBookStatus(studentID, barcodeNo);
            LoadLendBooks();
        }

        private void SearchByBarcode(string barcode)
        {
            connection.Open();
            string query = "SELECT * FROM lendbooks WHERE barcodeNo LIKE @barcode AND isReturned = 0";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@barcode", "%" + barcode + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnBook();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string barcode = textBox3.Text;
            SearchByBarcode(barcode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barcode = textBox3.Text;
            SearchByBarcode(barcode);
        }

    
    }
}
