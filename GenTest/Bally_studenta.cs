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
    public partial class Bally_studenta : Form
    {
        public Bally_studenta()
        {
            InitializeComponent();
        }
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;

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

        private void comboBox_teacher_TextChanged(object sender, EventArgs e)
        {
            Peremennye.ID_teacher = 0;
            dataGridView_balls.Rows.Clear();

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
            balls();
        }
        private void balls()
        {
            int i = 0;
            //заполняем баллы для этого студента
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_topic`, `Аssessment` FROM `tests_students_assessment` WHERE `ID_discipline`=@ID_discipline AND `ID_teacher`=@ID_teacher AND `ID_student` = @ID_student", myConnection);
            command.Parameters.AddWithValue("@ID_discipline", Peremennye.ID_Discipline);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            command.Parameters.AddWithValue("@ID_student", Peremennye.ID_student);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    dataGridView_balls.Rows.Add();
                    dataGridView_balls.Rows[i].Cells[0].Value = Convert.ToString(sqlReader["Name_topic"]);
                    dataGridView_balls.Rows[i].Cells[1].Value = Convert.ToString(sqlReader["Аssessment"]);
                    i++;
                }
            }
            myConnection.Close();
        }

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
        private void comboBox_predmet_TextChanged(object sender, EventArgs e)
        {
            Peremennye.ID_Discipline = 0;
            dataGridView_balls.Rows.Clear();

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

            balls();
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

        private void Bally_studenta_Load(object sender, EventArgs e)
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

        private void Bally_studenta_SizeChanged(object sender, EventArgs e)
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
