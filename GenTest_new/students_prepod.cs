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
    public partial class students_prepod : Form
    {
        public students_prepod()
        {
            InitializeComponent();
        }
        MySqlCommand command;
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder mySqlBuilder;
        DataTable dtStusentsBezGroup = new DataTable();

        MySqlDataAdapter adapter1;
        MySqlCommandBuilder mySqlBuilder1;
        DataTable dtStusentsBezGroup1 = new DataTable();

        int ID_group = 0;
        //загрузка формы
        private void students_prepod_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            tableStudents();
        }
        //кнопка назад
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu_prepod menu_Prepod = new menu_prepod();
            menu_Prepod.Show();
        }
        //загрузка таблицы со студентами для добавления
        private void tableStudents()
        {
            string FIO;
            FIO = "%" + textBox_poisk.Text + "%";
            dtStusentsBezGroup.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_student`,  CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) as ФИО FROM `students` WHERE CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) LIKE @FIO AND `ID_group` is NULL", myConnection);
            command.Parameters.AddWithValue("FIO", FIO);

            adapter = new MySqlDataAdapter(command);
            mySqlBuilder = new MySqlCommandBuilder(adapter);

            adapter.Fill(dtStusentsBezGroup);

            mySqlBuilder.GetUpdateCommand();
            myConnection.Close();

            dataGridView_students.DataSource = dtStusentsBezGroup;

            dataGridView_students.Columns[1].Visible = false;
            dataGridView_students.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_students.Columns[1].ReadOnly = true;
            dataGridView_students.ClearSelection();
        }
        //осуществление поиска
        private void textBox_poisk_TextChanged(object sender, EventArgs e)
        {
            tableStudents();
        }
        //добавление студента в группу
        private void button_addStudent_Click(object sender, EventArgs e)
        {
            if (ID_group != 0)
            {
                foreach (DataGridViewRow row in dataGridView_students.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        myConnection.Open();
                        command = new MySqlCommand("UPDATE `students` SET `ID_group`= @ID_group WHERE `ID_student` = @ID_student", myConnection);
                        command.Parameters.AddWithValue("@ID_group", ID_group);
                        command.Parameters.AddWithValue("@ID_student", row.Cells[1].Value.ToString());
                        command.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }
                tableStudents();
                tableStudents1();
            }
            else
            {
                MessageBox.Show("Введите название группы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //меняется группа - меняется ай ди
        private void comboBox_group_TextChanged(object sender, EventArgs e)
        {
            ID_group = 0;
            //узнаем ай ди выбранной группы
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_group` FROM `groups` WHERE  `Name_group` = @Name_group", myConnection);
            command.Parameters.AddWithValue("@Name_group", comboBox_group.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_group = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
            if (ID_group != 0)
            {
                tableStudents1();
            }
        }
        //меняется курс - меняется выборка групп
        private void textBox_kurs_TextChanged(object sender, EventArgs e)
        {
            comboBox_group.Items.Clear();
            //Формирование выборки группы при изменении курса
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_group` FROM `groups` WHERE `Kurs`=@Kurs", myConnection);
            command.Parameters.AddWithValue("@Kurs", textBox_kurs.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_group.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }

        private void checkBox_vibratVse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vibratVse.Checked == true)
                foreach (DataGridViewRow row in dataGridView_students.Rows)
                {
                    row.Cells[0].Value = true;
                }
            else
            {
                foreach (DataGridViewRow row in dataGridView_students.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }
        //загрузка таблицы со студентами для удаления
        private void tableStudents1()
        {
            string FIO;
            FIO = "%" + textBox_poisk1.Text + "%";
            dtStusentsBezGroup1.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_student`,  CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) as ФИО FROM `students` WHERE CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) LIKE @FIO AND `ID_group` = @ID_group", myConnection);
            command.Parameters.AddWithValue("FIO", FIO);
            command.Parameters.AddWithValue("ID_group", ID_group);

            adapter1 = new MySqlDataAdapter(command);
            mySqlBuilder1 = new MySqlCommandBuilder(adapter1);

            adapter1.Fill(dtStusentsBezGroup1);

            mySqlBuilder1.GetUpdateCommand();
            myConnection.Close();

            dataGridView_students1.DataSource = dtStusentsBezGroup1;

            dataGridView_students1.Columns[1].Visible = false;
            dataGridView_students1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_students1.Columns[1].ReadOnly = true;
            dataGridView_students1.ClearSelection();
        }
        private void textBox_poisk1_TextChanged(object sender, EventArgs e)
        {
            tableStudents1();
        }

        private void checkBox_vibratVse1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vibratVse1.Checked == true)
                foreach (DataGridViewRow row in dataGridView_students1.Rows)
                {
                    row.Cells[0].Value = true;
                }
            else
            {
                foreach (DataGridViewRow row in dataGridView_students1.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }
        
        private void button_deleteStudent_Click(object sender, EventArgs e)
        {
            if (ID_group != 0)
            {
                foreach (DataGridViewRow row in dataGridView_students1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        myConnection.Open();
                        command = new MySqlCommand("UPDATE `students` SET `ID_group`= NULL WHERE `ID_student` = @ID_student", myConnection);
                        command.Parameters.AddWithValue("@ID_student", row.Cells[1].Value.ToString());
                        command.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }
                tableStudents();
                tableStudents1();
            }
            else
            {
                MessageBox.Show("Введите название группы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox_reset_Click(object sender, EventArgs e)
        {
            tableStudents();
            tableStudents1();
        }

        private void students_prepod_SizeChanged(object sender, EventArgs e)
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
