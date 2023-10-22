using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryAutomation
{
    public partial class BookDetails : Form
    {

        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        public BookDetails()
        { 
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string barcode = BarkodNo.Text;

            if (BookExists(barcode))
            {
                MessageBox.Show("Kitap Eklenirken Bir Hata Oluştu!" + Environment.NewLine + "Zaten Bu Barkod'a Sahip Bir Kitap Var.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddBook(Name.Text, Writer.Text, PageNumber.Text, Year.Text, Genre.Text, ShelfCode.Text, barcode, Count.Text);
            }
            ClearTextBoxes();
            connection.Close();
        }
        private bool BookExists(string barcode)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM books WHERE barcodeNo = @barcode", connection);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            int bookCount = Convert.ToInt32(cmd.ExecuteScalar());
            return bookCount > 0;
        }

        private void AddBook(string name, string writer, string pageCount, string year, string genre, string shelfCode, string barcode, string count)
        {
            MySqlCommand bookInsert = new MySqlCommand("INSERT INTO books (name, writer, pageCount, year, genre, shelfCode, barcodeNo, count, availableCount) VALUES (@name, @writer, @pageCount, @year, @genre, @shelfCode, @barcode, @count, @availableCount)", connection);

            bookInsert.Parameters.AddWithValue("@name", name);
            bookInsert.Parameters.AddWithValue("@writer", writer);
            bookInsert.Parameters.AddWithValue("@pageCount", pageCount);
            bookInsert.Parameters.AddWithValue("@year", year);
            bookInsert.Parameters.AddWithValue("@genre", genre);
            bookInsert.Parameters.AddWithValue("@shelfCode", shelfCode);
            bookInsert.Parameters.AddWithValue("@barcode", barcode);
            bookInsert.Parameters.AddWithValue("@count", count);
            bookInsert.Parameters.AddWithValue("@availableCount", count);

            if (bookInsert.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Kitap Başarıyla Eklendi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kitap Eklenirken Bir Hata Oluştu!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void ClearTextBoxes()
        {
            Name.Clear();
            Writer.Clear();
            PageNumber.Clear();
            Year.Clear();
            Genre.Clear();
            ShelfCode.Clear();
            BarkodNo.Clear();
            Count.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            ClearBookDetails();

            if (FindBookByBarcode(textBox8.Text))
            {
                EnableBookDetailsTextBoxes();
                MessageBox.Show("Kitap Bulundu!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kitap Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private bool FindBookByBarcode(string barcode)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM books WHERE barcodeNo = @barcode", connection);
            cmd.Parameters.AddWithValue("@barcode", barcode);

            
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    textBox10.Text = reader["name"].ToString();
                    textBox11.Text = reader["writer"].ToString();
                    textBox12.Text = reader["pageCount"].ToString();
                    textBox13.Text = reader["year"].ToString();
                    textBox14.Text = reader["genre"].ToString();
                    textBox15.Text = reader["shelfCode"].ToString();
                    textBox16.Text = reader["count"].ToString();
                    textBox17.Text = reader["barcodeNo"].ToString();
                    textBox18.Text = reader["availableCount"].ToString();
                    label18.Text = "Adet Verilebilir.";
                    return true;
                }
            }

            return false;
        }

        private void EnableBookDetailsTextBoxes()
        {
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = false;
            textBox18.Enabled = true;
            button4.Enabled = true;
            deleteBookButton.Enabled = true;    
        }

        private void ClearBookDetails()
        {
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            label18.Text = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu Kitabı Silmek İstiyor Musunuz?", "Uyarı Penceresi!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (DeleteBookByBarcode(textBox8.Text))
                {
                    MessageBox.Show("Kitap Başarıyla Silindi…", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBookDetails();
                }
                else
                {
                    MessageBox.Show("Kitap Silinirken Bir Hata Oluştu!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            textBox8.Clear();
            deleteBookButton.Enabled = false;


        }

        private bool DeleteBookByBarcode(string barcode)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM books WHERE barcodeNo = @barcode", connection);
            cmd.Parameters.AddWithValue("@barcode", barcode);

            connection.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            connection.Close();

            return affectedRows == 1;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Books frm = new Books();
            frm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (UpdateBookDetails())
            {
                MessageBox.Show("Kitap Bilgileri Güncellendi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kitap Bilgileri Güncellenemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearBookDetails();
        }

        private bool UpdateBookDetails()
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE books SET name = @name, writer = @writer, pageCount = @pageCount, year = @year, genre = @genre, shelfCode = @shelfCode, barcodeNo = @barcodeNo, count = @count, availableCount = @availableCount WHERE barcodeNo = @barcode", connection);

            cmd.Parameters.AddWithValue("@name", textBox10.Text);
            cmd.Parameters.AddWithValue("@writer", textBox11.Text);
            cmd.Parameters.AddWithValue("@pageCount", textBox12.Text);
            cmd.Parameters.AddWithValue("@year", textBox13.Text);
            cmd.Parameters.AddWithValue("@genre", textBox14.Text);
            cmd.Parameters.AddWithValue("@shelfCode", textBox15.Text);
            cmd.Parameters.AddWithValue("@barcodeNo", textBox17.Text);
            cmd.Parameters.AddWithValue("@count", textBox16.Text);
            cmd.Parameters.AddWithValue("@availableCount", textBox18.Text);
            cmd.Parameters.AddWithValue("@barcode", textBox8.Text);

            connection.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            connection.Close();

            if (affectedRows == 1)
            {
                return true;
            }

            return false;
        }
    }
}
