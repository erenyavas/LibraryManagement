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
    public partial class StudentDetails : Form
    {

        private DatabaseHelper dbHelper;
        private MySqlConnection connection;
        public StudentDetails()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            connection = dbHelper.GetDatabaseConnection();
        }


        private bool StudentExists(string studentID)
        {
            connection.Open();
            MySqlCommand checkExistingStudent = new MySqlCommand("Select * from students where studentID = @studentID", connection);
            checkExistingStudent.Parameters.AddWithValue("@studentID", studentID);

            using (MySqlDataReader dr = checkExistingStudent.ExecuteReader())
            {
                if (dr.Read())
                {
                    connection.Close();
                    return true;
                }
            }

            connection.Close();
            return false;
        }

        private void AddStudent(string nameSurname, string studentID, string className)
        {
            connection.Open();
            MySqlCommand addStudent = new MySqlCommand("Insert into students(nameSurname, studentID, className, readBooksCount, checkOutBooksCount) Values (@nameSurname, @studentID, @className, 0, 0)", connection);
            addStudent.Parameters.AddWithValue("@nameSurname", nameSurname);
            addStudent.Parameters.AddWithValue("@studentID", studentID);
            addStudent.Parameters.AddWithValue("@className", className);

            if (addStudent.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Öğrenci Eklendi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Öğrenci Eklenemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }

        private void UpdateStudentInfo(string studentID, string nameSurname, string className)
        {
            connection.Open();
            MySqlCommand updateStudent = new MySqlCommand("Update students set nameSurname = @nameSurname, className = @className where studentID = @studentID", connection);
            updateStudent.Parameters.AddWithValue("@nameSurname", nameSurname);
            updateStudent.Parameters.AddWithValue("@studentID", studentID);
            updateStudent.Parameters.AddWithValue("@className", className);

            if (updateStudent.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Öğrenci Bilgileri Güncellendi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Öğrenci Bilgileri Güncellenemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }

        private void DeleteStudent(string studentID)
        {
            DialogResult result = MessageBox.Show("Bu Öğrenciyi Silmek İstiyor Musunuz?", "Uyarı Penceresi!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                connection.Open();
                MySqlCommand deleteStudent = new MySqlCommand("delete from students where studentID = @studentID", connection);
                deleteStudent.Parameters.AddWithValue("@studentID", studentID);

                if (deleteStudent.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Öğrenci Silindi!", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Öğrenci Silinemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameSurname = textBox1.Text;
            string studentID = textBox2.Text;
            string className = comboBox1.Text;

            if (!StudentExists(studentID))
            {
                AddStudent(nameSurname, studentID, className);
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Öğrenci Eklenemedi!" + Environment.NewLine + "Zaten Bu Numaraya Sahip Bir Öğrenci Var.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Students frm3 = new Students();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox11.Clear();
            comboBox2.Text = "";
            connection.Open();
            MySqlCommand getStudentDetails = new MySqlCommand("Select * from students where studentID = @studentID", connection);
            getStudentDetails.Parameters.AddWithValue("@studentID", textBox8.Text);

            using (MySqlDataReader dr = getStudentDetails.ExecuteReader())
            {
                if (dr.Read())
                {
                    textBox10.Text = dr["nameSurname"].ToString();
                    textBox11.Text = dr["studentID"].ToString();
                    comboBox2.Text = dr["className"].ToString();
                    label1.Text = dr["readBooksCount"].ToString();
                    label5.Text = dr["checkOutBooksCount"].ToString();
                }
            }

            if (textBox10.Text == "")
            {
                MessageBox.Show("Öğrenci Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Öğrenci Bulundu!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Enabled = true;
                textBox11.Enabled = false;
                comboBox2.Enabled = true;
                button4.Enabled = true;
            }

            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string studentID = textBox8.Text;
            string nameSurname = textBox10.Text;
            string className = comboBox2.Text;
            UpdateStudentInfo(studentID, nameSurname, className);
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            comboBox2.Enabled = false;
            label1.Text = "";
            label5.Text = "";
            button4.Enabled = false;
            textBox10.Clear();
            textBox11.Clear();
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentID = textBox8.Text;
            DeleteStudent(studentID);
            textBox8.Clear();
        }


    }
}
