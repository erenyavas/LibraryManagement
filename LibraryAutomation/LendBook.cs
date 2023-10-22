using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class LendBook : Form
    {
        private DatabaseHelper dbHelper;
        private MySqlConnection connection;

        public LendBook()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }

        private void LendBook_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(14);

            LoadData();

            connection.Open();

            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");


            MySqlCommand command = new MySqlCommand("SELECT * FROM librarians WHERE dutyDate = @date", connection);
            command.Parameters.AddWithValue("@Date", todayDate);

            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count != 0)
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox3.Text = reader["nameSurname"].ToString();
                }
            }

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Barkod No";
            dataGridView1.Columns[2].HeaderText = "Numara";
            dataGridView1.Columns[3].HeaderText = "Veriliş Tarihi";
            dataGridView1.Columns[4].HeaderText = "Son Tarih";
            dataGridView1.Columns[5].HeaderText = "Nöbetçi";
            dataGridView1.Columns[6].HeaderText = "Kitap Geri Alındı Mı?";

            connection.Close();
        }

        private void LoadData()
        {
            connection.Open();
            string query = "SELECT * FROM lendbooks ORDER BY id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void SearchByNumber(string studentID)
        {
            connection.Open();
            string query = "SELECT * FROM lendbooks WHERE studentID LIKE '%" + studentID + "%' AND isReturned = 0";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void SearchByBarkod(string barcodeNo)
        {
            connection.Open();
            string query = "SELECT * FROM lendbooks WHERE barcodeNo LIKE '%" + barcodeNo + "%' AND isReturned = 0";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string barcodeNo = textBox1.Text;
            string studentID = textBox2.Text;
            string lendingDate = dateTimePicker1.Text;
            string dueDate = dateTimePicker2.Text;
            string librarianName = textBox3.Text;


            if (HasReachedMaxBorrowedBooks(studentID))
            {
                MessageBox.Show("Kitap Verilemedi!" + Environment.NewLine + "Öğrenci en fazla 3 kitap alabilir!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string insertQuery = $"INSERT INTO lendbooks (barcodeNo, studentID, lendingDate, dueDate, librarianName) VALUES ('{barcodeNo}', '{studentID}', '{lendingDate}', '{dueDate}', '{librarianName}')";
            string updateOgrenciQuery = $"UPDATE students SET checkOutBooksCount = checkOutBooksCount + 1 WHERE studentID = '{studentID}'";
            string updateKitapQuery = $"UPDATE books SET availableCount = availableCount - 1 WHERE barcodeNo = '{barcodeNo}'";

            try
            {
                connection.Open();



                MySqlCommand updateOgrenciCmd = new MySqlCommand(updateOgrenciQuery, connection);
                int updateOgrenciResult = updateOgrenciCmd.ExecuteNonQuery();

                MySqlCommand updateKitapCmd = new MySqlCommand(updateKitapQuery, connection);
                int updateKitapResult = updateKitapCmd.ExecuteNonQuery();

                

                if (updateOgrenciResult == 1 && updateKitapResult == 1)
                {
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                    int insertResult = insertCmd.ExecuteNonQuery();
                    if (insertResult == 1)
                    {

                        MessageBox.Show("Kitap Başarıyla Verildi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Kitap Verilemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private bool HasReachedMaxBorrowedBooks(string studentID)
        {
            connection.Open();
            string query = $"SELECT COUNT(*) FROM lendBooks WHERE studentID = '{studentID}' AND isReturned = 0";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int numberOfBorrowedBooks = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            return numberOfBorrowedBooks >= 3;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SearchByNumber(textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchByBarkod(textBox4.Text);
        }
    }
}
