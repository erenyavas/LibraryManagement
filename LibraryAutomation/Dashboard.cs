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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryAutomation
{
    public partial class Dashboard : Form
    {
        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        public Dashboard()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }


        private void RetrieveLibrarianData()
        {
            bool demoStudent = false;

            try
            {
                string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

                using (MySqlCommand mysqlcommand = new MySqlCommand("Select * from librarians where dutyDate=@Date", connection))
                {
                    mysqlcommand.Parameters.AddWithValue("@Date", todayDate);
                    connection.Open();

                    using (MySqlDataReader mysqldatareader = mysqlcommand.ExecuteReader())
                    {
                        if (mysqldatareader.Read())
                        {
                            label6.Text = mysqldatareader["nameSurname"].ToString();
                            label8.Text = mysqldatareader["studentID"].ToString();
                            label9.Text = mysqldatareader["className"].ToString();
                        }
                        else
                        {
                            demoStudent = true;
                            MessageBox.Show("Nöbetçi öğrenci bulunamadı. Test için öğrenci ekleniyor. Programı yeniden başlatın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                if (demoStudent)
                {
                    string insertQuery = "INSERT INTO librarians (dutyDate, nameSurname, studentID, className) VALUES (@dutyDate, @nameSurname, @studentID, @className)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@dutyDate", todayDate);
                        cmd.Parameters.AddWithValue("@nameSurname", "Test Öğrenci");
                        cmd.Parameters.AddWithValue("@studentID", 1111);
                        cmd.Parameters.AddWithValue("@className", "10-A");

                        cmd.ExecuteNonQuery();
                    }
                    Application.Exit();
                }
                
            }
            catch (MySqlException ex)
            {
                string errorMessage = "MySQL Error: " + ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            RetrieveLibrarianData();
        }

        private void BookDetails_Click(object sender, EventArgs e)
        {
            BookDetails bookdetails = new BookDetails();
            bookdetails.ShowDialog();
        }

        private void StudentDetails_Click(object sender, EventArgs e)
        {
            StudentDetails studentdetails = new StudentDetails();
            studentdetails.ShowDialog();
        }

        private void UpdateDateTimeLabels(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void ReceiveBook_Click(object sender, EventArgs e)
        {
            ReceiveBook receivebook = new ReceiveBook();
            receivebook.ShowDialog();
        }

        private void LendBook_Click(object sender, EventArgs e)
        {
            LendBook lendbook = new LendBook();
            lendbook.ShowDialog();
        }

        private void Librarians_Click(object sender, EventArgs e)
        {
            Librarians librarians = new Librarians();
            librarians.ShowDialog();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void Books_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.ShowDialog();
        }


        private void Lock_Click(object sender, EventArgs e)
        {

            string pass;
            connection.Open();
            MySqlCommand command = new MySqlCommand("Select * from admin where id=1", connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                pass = dataReader["password"].ToString();
            }
            else
            {
                pass = "";
            }

            if (PasswordTextField.Text == pass)
            {
                BookDetailsButton.Enabled = true;
                StudentDetailsButton.Enabled = true;
                LibrariansButton.Enabled = true;
                MessageBox.Show("Yönetici Girişi Başarılı!" + Environment.NewLine + "Yönetici Modu: Açık", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BookDetailsButton.Enabled = false;
                StudentDetailsButton.Enabled = false;
                LibrariansButton.Enabled = false;
                MessageBox.Show("Girdiğiniz Şifre Hatalı!" + Environment.NewLine + "Yönetici Modu: Kapalı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PasswordTextField.Clear();
            connection.Close();
        }

       
    }
}
