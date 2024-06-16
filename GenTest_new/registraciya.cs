using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenTest
{
    public partial class registraciya : Form
    {
        public registraciya()
        {
            InitializeComponent();
        }
        bool flag = false;
        int ID_user=0;
        //"Глазик"
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;
        private void pictureBox_glazik_Click(object sender, EventArgs e)
        {
            if (textBox_password.PasswordChar == '*')
            {
                textBox_password.PasswordChar = '\0';
            }
            else
            {
                textBox_password.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text != "" && textBox_password.Text != "" && textBox_cod_word.Text != "")
            {
                //проверяем, нет ли совпадений по логину
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_user` FROM `users` WHERE `Login`=@Login", myConnection);
                command.Parameters.AddWithValue("@Login", textBox_login.Text);

                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        flag = true;
                    }
                }
                myConnection.Close();
                //если нет совпадений
                if (flag == false)
                {
                    string password = Hesh.HashPassword(textBox_password.Text);
                    myConnection.Close();
                    //добавляем
                    myConnection.Open();
                    command = new MySqlCommand("INSERT INTO `users`(`User`, `Login`, `Password`, `Code_word`) VALUES (@User,@Login,@Password,@Code_word)", myConnection);
                    command.Parameters.AddWithValue("@User", "студент");
                    command.Parameters.AddWithValue("@Login", textBox_login.Text);
                    command.Parameters.AddWithValue("@Password", Hesh.HashPassword(textBox_password.Text));
                    command.Parameters.AddWithValue("@Code_word", Hesh.HashPassword(textBox_cod_word.Text));
                    command.ExecuteNonQuery(); 
                    command = new MySqlCommand("SELECT MAX(`ID_user`) FROM `users`", myConnection);
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        ID_user = sqlReader.GetInt32(0);

                    }
                    myConnection.Close();

                    DateTime GR = DateTime.Parse(maskedTextBox_GR.Text);
                    string GR_formatted = GR.ToString("yyyy-MM-dd");

                    myConnection.Open();
                    command = new MySqlCommand("INSERT INTO `students`(`Surname`, `Name`, `Middle_name`,`Year_of_birth`, `ID_user`) VALUES (@Surname, @Name, @Middle_name,@Year_of_birth, @ID_user)", myConnection);
                    command.Parameters.AddWithValue("@Surname", textBox_Familiya.Text);
                    command.Parameters.AddWithValue("@Name", textBox_Name.Text);
                    command.Parameters.AddWithValue("@Middle_name", textBox_Otchestvo.Text);
                    command.Parameters.AddWithValue("@Year_of_birth", GR_formatted);
                    command.Parameters.AddWithValue("@ID_user", ID_user);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    if (MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)==DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else { MessageBox.Show("Такой логин уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("Заполните все пустые поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {
            flag = false;
        }

        private void registraciya_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void registraciya_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Peremennye.min_razmer_okna = false;
            }
            else
            {
                Peremennye.min_razmer_okna = true;
            }
        }
    }
}
