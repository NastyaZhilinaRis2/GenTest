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
    public partial class temy_test : Form
    {
        public temy_test()
        {
            InitializeComponent();
            Peremennye.ID_test = 0;
        }
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;

        //!!!НАВОДИМ КРАСОТУ!!!
        //при активном предмете
        private void comboBox_predmet_Enter(object sender, EventArgs e)
        {
            if (comboBox_predmet.Text == "Предмет")
            {
                comboBox_predmet.Text = "";
                comboBox_predmet.ForeColor = Color.Black;
            }
        }
        //при неактивном предмете
        private void comboBox_predmet_Leave(object sender, EventArgs e)
        {
            if (comboBox_predmet.Text == "")
            {
                comboBox_predmet.Text = "Предмет";
                comboBox_predmet.ForeColor = Color.DarkGray;
            }
        }
        //Проверка после клика на преподавателя, если там текст "преподаватель" - стирается все, текст сменяется на черный
        private void comboBox_teacher_Enter(object sender, EventArgs e)
        {
            if (comboBox_teacher.Text == "Преподаватель")
            {
                comboBox_teacher.Text = "";
                comboBox_teacher.ForeColor = Color.Black;
            }
        }
        //Если преподаватель пустая - вновь пишется текст "Преподаватель" серым
        private void comboBox_teacher_Leave(object sender, EventArgs e)
        {
            if (comboBox_teacher.Text == "")
            {
                comboBox_teacher.Text = "Преподаватель";
                comboBox_teacher.ForeColor = Color.DarkGray;
            }
        }
        //!!!КРАСОТУ НАВЕЛИ!!!

        //при загрузке формы
        private void temy_test_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            Peremennye.ID_teacher = 0;
            Peremennye.ID_Discipline = 0;

            //Формирование выборки препода
            myConnection.Open();
            command = new MySqlCommand("SELECT `Surname`, `Name`, `Middle_name` FROM `teachers`", myConnection);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_teacher.Items.Add(sqlReader.GetString(0) + " " + sqlReader.GetString(1) + " " + sqlReader.GetString(2));
                }
            }
            myConnection.Close();
        }

        private void button_start_test_Click(object sender, EventArgs e)
        {
            if (Peremennye.ID_teacher != 0 && Peremennye.ID_Discipline != 0)
            {
                if (MessageBox.Show("Начать тестирование?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        //Найдем ID_topic
                        myConnection.Open();
                        command = new MySqlCommand("SELECT `ID_topic`,`Number_of_questions`, `Kol_balls` FROM `test_topics` WHERE `Name_topic`=@Name_topic", myConnection);
                        command.Parameters.AddWithValue("@Name_topic", dataGridView_temy.CurrentRow.Cells[0].Value.ToString());
                        sqlReader = command.ExecuteReader();
                        {
                            while (sqlReader.Read())
                            {
                                Peremennye.ID_topic = sqlReader.GetInt32(0);
                                Peremennye.Number_of_questions = sqlReader.GetInt32(1);
                                Peremennye.Kol_balls = sqlReader.GetInt32(2);
                            }
                        }
                        myConnection.Close();

                        //Уменьшим кол-во попыток
                        myConnection.Open();
                        command = new MySqlCommand("UPDATE `open_tests` SET `Try`=`Try`-1 WHERE `ID_student`=@ID_student AND `ID_topic`=@ID_topic", myConnection);
                        command.Parameters.AddWithValue("@ID_student", Peremennye.ID_student);
                        command.Parameters.AddWithValue("@ID_topic", Peremennye.ID_topic);
                        command.ExecuteNonQuery();
                        myConnection.Close();

                        //удалим строку, если попытки кончились
                        myConnection.Open();
                        command = new MySqlCommand("DELETE FROM `open_tests` WHERE `Try`=0", myConnection);
                        command.ExecuteNonQuery();
                        myConnection.Close();

                        //создаем строку о прохождении теста
                        myConnection.Open();
                        command = new MySqlCommand("INSERT INTO `tests` (`ID_topic`, `ID_student`) VALUES (@ID_topic, @ID_student)", myConnection);
                        command.Parameters.AddWithValue("@ID_topic", Peremennye.ID_topic);
                        command.Parameters.AddWithValue("@ID_student", Peremennye.ID_student);
                        command.ExecuteNonQuery();
                        command = new MySqlCommand("SELECT MAX(`ID_test`) FROM `tests`", myConnection);
                        sqlReader = command.ExecuteReader();
                        while (sqlReader.Read())
                        {
                            Peremennye.ID_test = sqlReader.GetInt32(0);

                        }
                        myConnection.Close();
                        //Откроем форму с тестом
                        test test = new test();

                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            test.WindowState = FormWindowState.Maximized;
                        }
                        test.Show();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Не выбрана тема теста!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        myConnection.Close();
                    }
                }
            }
            else MessageBox.Show("Не выбраны поля выборки", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //назад
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menu_student menu_student = new menu_student();
            if (this.WindowState == FormWindowState.Maximized)
            {
                menu_student.WindowState = FormWindowState.Maximized;
            }
            menu_student.Show();
            this.Close();
        }

        
        private void comboBox_teacher_TextChanged(object sender, EventArgs e)
        {
            Peremennye.ID_teacher = 0;
            dataGridView_temy.Rows.Clear();

            //запоминаем ай ди препода
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_teacher` FROM `teachers` WHERE Concat(Surname, ' ', Name, ' ', Middle_name) = @FIO", myConnection);
            command.Parameters.AddWithValue("@FIO", comboBox_teacher.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    Peremennye.ID_teacher = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();

            comboBox_predmet.Items.Clear();
            //Формирование выборки предмета при изменении препода
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_discipline` FROM `disciplines` WHERE `ID_teacher`=@ID_teacher", myConnection);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_predmet.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
            temy();
        }
        
        private void comboBox_predmet_TextChanged(object sender, EventArgs e)
        {
            Peremennye.ID_Discipline = 0;
            dataGridView_temy.Rows.Clear();

            //запоминаем ай ди предмета
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_discipline` FROM `disciplines` WHERE `Name_discipline`=@Name_discipline", myConnection);
            command.Parameters.AddWithValue("@Name_discipline", comboBox_predmet.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    Peremennye.ID_Discipline = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();

            temy();
        }
        private void temy()
        {
            int i = 0;
            //заполняем открытые для этого студента тесты
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_topic`, `Try` FROM `open_tests_students` WHERE `ID_student`=@ID_student AND `ID_discipline`=@ID_discipline AND `ID_teacher`=@ID_teacher", myConnection);
            command.Parameters.AddWithValue("@ID_student", Peremennye.ID_student);
            command.Parameters.AddWithValue("@ID_discipline", Peremennye.ID_Discipline);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    dataGridView_temy.Rows.Add();
                    dataGridView_temy.Rows[i].Cells[0].Value = Convert.ToString(sqlReader["Name_topic"]);
                    dataGridView_temy.Rows[i].Cells[1].Value = Convert.ToString(sqlReader["Try"]);
                    i++;
                }
            }
            myConnection.Close();
        }

        private void temy_test_SizeChanged(object sender, EventArgs e)
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
