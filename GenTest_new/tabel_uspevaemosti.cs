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
    public partial class tabel_uspevaemosti : Form
    {
        public tabel_uspevaemosti()
        {
            InitializeComponent();
        }
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlCommand command;
        MySqlDataReader sqlReader;
        MySqlDataAdapter adapter;
        DataTable dtTabel = new DataTable();


        int ID_teacher, ID_group, ID_discipline, ID_topic;

        //кнопка назад
        private void pictureBox_back_Click(object sender, EventArgs e)
        {
            if (Peremennye.ID_teacher == 0)
            {
                menu_administraciya menu_administraciya = new menu_administraciya();
                menu_administraciya.Show();
                this.Close();
            }
            else
            {
                menu_prepod menu_prepod = new menu_prepod();
                menu_prepod.Show();
                this.Close();
            }
        }

        //загрузка формы (формируется выборка преподов
        private void tabelUspevaemosti_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            ItemsPrepod();
        }
        private void ItemsPrepod()
        {
            //добавляем выборку преподавателей
            myConnection.Open();
            command = new MySqlCommand("SELECT `Surname`, `Name`, `Middle_name` FROM `teachers`", myConnection);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_prepod.Items.Add(sqlReader.GetString(0) + " " + sqlReader.GetString(1) + " " + sqlReader.GetString(2));
                }
            }
            myConnection.Close();
        }
        //при изменении курса меняется выборка групп
        private void textBox_kurs_TextChanged(object sender, EventArgs e)
        {
            ItemsGroup();
        }
        private void ItemsGroup()
        {
            comboBox_group.Items.Clear();
            //добавляем выборку групп
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_group` FROM `groups` WHERE `Kurs`=@Kurs", myConnection);
            command.Parameters.AddWithValue("Kurs", textBox_kurs.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_group.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }
        
        private void comboBox_prepod_TextChanged(object sender, EventArgs e)
        {
            //запоминаем ай ди препода
            id_prepod();
            //при изменении препода меняется выборка дисциплин
            discipliny();
            comboBox_disciplina.Text = "";
        }
        private void id_prepod()
        {
            ID_teacher = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_teacher` FROM `teachers` WHERE CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`, ' ') = @FIO", myConnection);
            command.Parameters.AddWithValue("FIO", comboBox_prepod.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_teacher = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
        }
        private void discipliny()
        {
            comboBox_disciplina.Items.Clear();
            //добавляем выборку групп
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_discipline` FROM `disciplines` WHERE `ID_teacher` = @ID_teacher", myConnection);
            command.Parameters.AddWithValue("ID_teacher", ID_teacher);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_disciplina.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }
        //находим ай ди группы
        private void comboBox_group_TextChanged(object sender, EventArgs e)
        {
            ID_group = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_group` FROM `groups` WHERE `Name_group` = @Name_group", myConnection);
            command.Parameters.AddWithValue("Name_group", comboBox_group.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_group = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
        }
        
        private void comboBox_disciplina_TextChanged(object sender, EventArgs e)
        {
            //находим ай ди дисциплины
            id_discipline();
            //при изменении дисциплины меняется выборка тем
            temy();
            comboBox_tema.Text = "";
        }

        private void id_discipline()
        {
            ID_discipline = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_discipline` FROM `disciplines` WHERE `Name_discipline`=@Name_discipline", myConnection);
            command.Parameters.AddWithValue("Name_discipline", comboBox_disciplina.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_discipline = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
        }
        //кнопка обновить
        private void pictureBox_reset_Click(object sender, EventArgs e)
        {
            //очищаем все
            comboBox_prepod.Text = "";
            textBox_kurs.Text = "";
            comboBox_group.Text = "";
            comboBox_disciplina.Text = "";
            comboBox_tema.Text = "";
        }

        private void tabel_uspevaemosti_SizeChanged(object sender, EventArgs e)
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

        private void temy()
        {
            comboBox_tema.Items.Clear();
            //добавляем выборку групп
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_topic` FROM `test_topics` WHERE `ID_discipline` = @ID_discipline AND `ID_teacher` = @ID_teacher", myConnection);
            command.Parameters.AddWithValue("ID_discipline", ID_discipline);
            command.Parameters.AddWithValue("ID_teacher", ID_teacher);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_tema.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }

        private void comboBox_tema_TextChanged(object sender, EventArgs e)
        {
            //находим ай ди темы
            ID_topic = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_topic` FROM `test_topics` WHERE `Name_topic` = @Name_topic", myConnection);
            command.Parameters.AddWithValue("Name_topic", comboBox_tema.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_topic = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
            //строим таблицу
            tabel();
        }
        private void tabel()
        {
            try
            {
                dtTabel.Rows.Clear();
                myConnection.Open();
                command = new MySqlCommand("SELECT CONCAT(`Surname`,' ', `Name`,' ', `Middle_name`) as 'ФИО',`Аssessment` as 'Оценка', `Date` as 'Дата' FROM `tests_students_assessment` WHERE `ID_teacher` = @ID_teacher AND `ID_discipline` = @ID_discipline AND `ID_group` = @ID_group AND `ID_topic` = @ID_topic", myConnection);
                command.Parameters.AddWithValue("ID_teacher", ID_teacher);
                command.Parameters.AddWithValue("ID_discipline", ID_discipline);
                command.Parameters.AddWithValue("ID_group", ID_group);
                command.Parameters.AddWithValue("ID_topic", ID_topic);

                adapter = new MySqlDataAdapter(command);

                adapter.Fill(dtTabel);

                myConnection.Close();

                dataGridView_students.DataSource = dtTabel;
                dataGridView_students.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView_students.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_students.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch
            {
                myConnection.Close();
            }
        }
    }
}
