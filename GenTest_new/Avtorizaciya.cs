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
    public partial class Avtorizaciya : Form
    {
        public Avtorizaciya()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        int ID_user = 0;
        string polzovatel;

        private MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        private MySqlDataReader sqlReader;
        private MySqlCommand command;
        
        //!!!НАВОДИТСЯ "КРАСОТА"!!!
        //Проверка после клика на логин, если там текст "логин" - стирается все, текст сменяется на черный
        private void textBox_login_Enter(object sender, EventArgs e)
        {
            if (textBox_login.Text == "Логин")
            {
                textBox_login.Text = "";
                textBox_login.ForeColor = Color.Black;
            }
        }
        //Если логин пустой - вновь пишется текст "логин" серым
        private void textBox_login_Leave(object sender, EventArgs e)
        {
            if (textBox_login.Text == "")
            {
                textBox_login.Text = "Логин";
                textBox_login.ForeColor = Color.DarkGray;
            }
        }
        //Проверка после клика на пароля, если там текст "пароль" - стирается все, текст сменяется на черный + ввод пароля заменяется на "*"
        private void textBox_password_Enter(object sender, EventArgs e)
        {
            if (textBox_password.Text == "Пароль")
            {
                textBox_password.Text = "";
                textBox_password.PasswordChar = '*';
                textBox_password.ForeColor = Color.Black;
            }
        }
        //Если пароль пустой - вновь пишется текст "пароль" серым + снимается "*" на обычные символы
        private void textBox_password_Leave(object sender, EventArgs e)
        {
            if (textBox_password.Text == "")
            {
                textBox_password.PasswordChar = '\0';
                textBox_password.Text = "Пароль";
                textBox_password.ForeColor = Color.DarkGray;
            }
        }
        //!!!КРАСОТА НАВЕЛАСЬ!!!

        private void button_input_Click(object sender, EventArgs e)
        {
            try
            {
                Peremennye.ID_student = 0;
                Peremennye.ID_teacher = 0;
                //проверяем, все ли поля заполнены
                if (textBox_login.ForeColor != Color.DarkGray && textBox_password.ForeColor != Color.DarkGray)
                {
                    //вычисляем хэш пароля
                    string password = Hesh.HashPassword(textBox_password.Text);
                    //Сверим пароль и сохраним id найденного пользователя 
                    myConnection.Open();
                    command = new MySqlCommand("SELECT `ID_user`, `User` FROM `users` WHERE BINARY `Login`=@Login AND `Password`=@Password", myConnection);
                    command.Parameters.AddWithValue("@Login", textBox_login.Text);
                    command.Parameters.AddWithValue("@Password", password);
                    sqlReader = command.ExecuteReader();
                    {
                        while (sqlReader.Read())
                        {
                            ID_user = sqlReader.GetInt32(0);
                            polzovatel = sqlReader.GetString(1).ToString().ToLower();
                        }
                    }
                    myConnection.Close();
                    //если вход удачный
                    if (ID_user != 0)
                    {
                        if (polzovatel == "студент")
                        {
                            //находим ай ди студента
                            myConnection.Open();
                            command = new MySqlCommand("SELECT `ID_student` FROM `students` WHERE `ID_user`=@ID_user", myConnection);
                            command.Parameters.AddWithValue("@ID_user", ID_user);
                            sqlReader = command.ExecuteReader();
                            {
                                while (sqlReader.Read())
                                {
                                    Peremennye.ID_student = sqlReader.GetInt32(0);
                                }
                            }
                            myConnection.Close();

                            menu_student menu_student = new menu_student();
                            menu_student.Show();
                        }
                        if (polzovatel == "преподаватель")
                        {
                            //находим ай ди препода
                            myConnection.Open();
                            command = new MySqlCommand("SELECT `ID_teacher` FROM `teachers` WHERE `ID_user`=@ID_user", myConnection);
                            command.Parameters.AddWithValue("@ID_user", ID_user);
                            sqlReader = command.ExecuteReader();
                            {
                                while (sqlReader.Read())
                                {
                                    Peremennye.ID_teacher = sqlReader.GetInt32(0);
                                }
                            }
                            myConnection.Close();

                            menu_prepod menu_prepod = new menu_prepod();
                            menu_prepod.Show();
                        }
                        if (polzovatel == "администрация")
                        {
                            menu_administraciya menu_administraciya = new menu_administraciya();
                            menu_administraciya.Show();
                        }
                        if (polzovatel == "системный администратор")
                        {
                            sis_admin_menu sis_admin_menu = new sis_admin_menu();
                            sis_admin_menu.Show();
                        }
                        textBox_login.Text = "Логин";
                        textBox_login.ForeColor = Color.DarkGray;

                        textBox_password.PasswordChar = '\0';
                        textBox_password.Text = "Пароль";
                        textBox_password.ForeColor = Color.DarkGray;

                    }
                    //если вход неудачный
                    else
                    {
                        if (ID_user == 0)
                        {
                            if (MessageBox.Show("Вход не выполнен! Проверьте введенные данные!", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                            {
                                Application.Exit();
                            }
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Введите все необходимые данные!", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Вероятно не включен xampp!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //кнопка регистрации
        private void label_registraciya_Click(object sender, EventArgs e)
        {
            registraciya registraciya = new registraciya();
            registraciya.Show();
        }
        //"Глазик"
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox_password.PasswordChar == '*' && textBox_password.ForeColor != Color.DarkGray)
            {
                textBox_password.PasswordChar = '\0';
            }
            else if (textBox_password.PasswordChar == '\0' && textBox_password.ForeColor != Color.DarkGray)
            {
                textBox_password.PasswordChar = '*';
            }
        }
        //кнопка восстановления пароля
        private void label_vosstanovleniye_Click(object sender, EventArgs e)
        {
            sbros_parol sbros_parol = new sbros_parol();
            sbros_parol.Show();
        }
        //при любых изменениях в логине и пароле сбрасывается ай ди
        private void textBox_login_TextChanged(object sender, EventArgs e)
        {
            ID_user = 0;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            ID_user = 0;
        }
        //при нажатии на "энтер" производится нажатии на кнопку "войти"
        private void Avtorizaciya_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button_input.PerformClick();
        }
        //при перемене размера меняется размер последующих форм
        private void Avtorizaciya_SizeChanged(object sender, EventArgs e)
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
