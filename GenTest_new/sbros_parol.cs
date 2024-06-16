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
    public partial class sbros_parol : Form
    {
        public sbros_parol()
        {
            InitializeComponent();
        }
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;
        string Code_word;

        private void textBox_new_password2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_new_password1.Text != textBox_new_password2.Text)
            {
                textBox_new_password2.ForeColor = Color.Red;
            }
            else
            {
                textBox_new_password2.ForeColor = Color.Black;
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button_primenit_Click(object sender, EventArgs e)
        {
            if (textBox_new_password2.ForeColor != Color.Red)
            {
                //проверяем, совпадает ли кодовое слово
                myConnection.Open();
                command = new MySqlCommand("SELECT `Code_word` FROM `users` WHERE `Login`=@Login", myConnection);
                command.Parameters.AddWithValue("@Login", textBox_login.Text);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        Code_word = sqlReader.GetString(0);
                    }
                }
                myConnection.Close();
                //совпадает
                if (Code_word.ToUpper() == (Hesh.HashPassword(textBox_cod_word.Text)))
                {
                    myConnection.Open();
                    command = new MySqlCommand("UPDATE `users` SET `Password`=@Password,`Code_word`=@Code_word WHERE `Login`=@Login", myConnection);
                    command.Parameters.AddWithValue("@Password", Hesh.HashPassword(textBox_new_password1.Text));
                    command.Parameters.AddWithValue("@Code_word", Hesh.HashPassword(textBox_new_cod_word.Text));
                    command.Parameters.AddWithValue("@Login", textBox_login.Text);
                    command.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("Неверно введено кодовое слово!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
            else { MessageBox.Show("Неверно введен повторный пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void sbros_parol_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void sbros_parol_SizeChanged(object sender, EventArgs e)
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
