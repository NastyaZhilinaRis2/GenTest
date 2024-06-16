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
    public partial class tests_prepod : Form
    {
        public tests_prepod()
        {
            InitializeComponent();
            this.KeyPreview = true;/*
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tests_prepod_KeyUp);
            this.label_dobavit_otvet.Click += new System.EventHandler(this.label_dobavit_otvet_Click);*/
        }
        MySqlCommand command;
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlDataAdapter adapter1;
        MySqlCommandBuilder mySqlBuilder1;
        MySqlDataAdapter adapter2;
        MySqlCommandBuilder mySqlBuilder2;
        MySqlDataAdapter adapter3;
        MySqlCommandBuilder mySqlBuilder3;

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable studentsDT = new DataTable();
        

        int ID_discipline = 0, ID_topic = 0, a = 1, Score = 0, ID_question = 0, ID_group = 0;
        bool flag = false, zapomnen_li_vopros = false;


        private void tests_prepod_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            //Формирование выборки предмета
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (MessageBox.Show("Отменить создание теста?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    myConnection.Open();
                    command = new MySqlCommand("DELETE FROM `test_topics` WHERE `ID_topic=@ID_topic", myConnection);
                    command.Parameters.AddWithValue("@ID_topic", ID_topic);
                    command.ExecuteNonQuery();
                    myConnection.Close();

                    this.Close();
                    menu_prepod menu_Prepod = new menu_prepod();
                    menu_Prepod.Show();
                }
            }
            else
            {
                this.Close();
                menu_prepod menu_Prepod = new menu_prepod();
                menu_Prepod.Show();
            }

        }

        //при изменении типа вопроса (СОЗДАНИЕ ТЕСТА) меняются ответы
        private void comboBox_sosd_vopr_TextChanged(object sender, EventArgs e)
        {
            sosd_vopr_TextChanged();
        }
        private void sosd_vopr_TextChanged()
        {
            panel__sosd_vopr.Controls.Clear();
            if (comboBox_sosd_vopr.Text == "Один из многих")
            {
                Score = 1;
            }
            if (comboBox_sosd_vopr.Text == "Многие из многих")
            {
                Score = 2;
            }
            if (comboBox_sosd_vopr.Text == "Развернутый")
            {
                Score = 3;
            }
        }
        private void redactir_vopr_TextChanged()
        {
            panel_otvety_добавитьНовыеВопросы.Controls.Clear();
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Один из многих")
            {
                Score = 1;
            }
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Многие из многих")
            {
                Score = 2;
            }
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Развернутый")
            {
                Score = 3;
            }
        }
        int Y;
        private void otvety()
        {
            Y = 0;
            foreach (Control control in panel__sosd_vopr.Controls)
            {
                Y = control.Location.Y;
                Y += 30;
            }
            if (comboBox_sosd_vopr.Text == "Один из многих")
            {
                RadioButton rb = new RadioButton();
                rb.Text = textBox_otvet.Text;
                rb.Font = new Font("Microsoft Sans Serif", 12);
                rb.AutoSize = true;
                rb.Location = new Point(3, Y);
                panel__sosd_vopr.Controls.Add(rb);

            }
            if (comboBox_sosd_vopr.Text == "Многие из многих")
            {
                CheckBox ChB = new CheckBox();
                ChB.Text = textBox_otvet.Text;
                ChB.Font = new Font("Microsoft Sans Serif", 12);
                ChB.AutoSize = true;
                ChB.Location = new Point(3, Y);
                panel__sosd_vopr.Controls.Add(ChB);
            }
            if (comboBox_sosd_vopr.Text == "Развернутый")
            {
                Label L = new Label();
                L.Text = textBox_otvet.Text;
                L.Font = new Font("Microsoft Sans Serif", 12);
                L.AutoSize = true;
                L.Location = new Point(3, Y);
                panel__sosd_vopr.Controls.Add(L);
            }
        }
        private void label_dobavit_otvet_Click(object sender, EventArgs e)
        {
            //добавить ответ
            if (comboBox_sosd_vopr.Text != "")
            {
                otvety();
                textBox_otvet.Text = "";
            }
            else MessageBox.Show("Введите вид вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label_delete_otvet_Click(object sender, EventArgs e)
        {
            //удаление ответа
            foreach (Control Control in panel__sosd_vopr.Controls)
            {
                if (Control.Text == textBox_otvet.Text)
                {
                    Control.Dispose();
                }
            }
            textBox_otvet.Text = "";
        }

        private void comboBox_predmet_TextChanged(object sender, EventArgs e)
        {
            ID_discipline = 0;
            //при изменении предмета меняется его ай ди
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_discipline` FROM `disciplines` WHERE `Name_discipline`=@Name_discipline", myConnection);
            command.Parameters.AddWithValue("@Name_discipline", comboBox_predmet.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_discipline = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();

            //при изменении предмета меняются имеющиеся темы тестов
            table_temy_test();
            refresh_redactor_testa();
            table_temy_test1();
            add_predmet_comboBox();
            add_temy_comboBox();
            open_test_tablStudents();
        }
        private void add_temy_comboBox()
        {
            comboBox_temy_открытьТест.Items.Clear();
            //меняется набор имеющихся тем тестов
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_topic` FROM `test_topics` WHERE `ID_discipline`=@ID_discipline AND `ID_teacher` = @ID_teacher", myConnection);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            command.Parameters.AddWithValue("@ID_discipline", ID_discipline);

            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_temy_открытьТест.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }
        private void add_predmet_comboBox()
        {
            comboBox_temy_добавитьНовыеВопросы.Items.Clear();
            //Формирование выборки темы
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_topic` FROM `test_topics` WHERE `ID_teacher`=@ID_teacher AND `ID_discipline`=@ID_discipline", myConnection);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            command.Parameters.AddWithValue("@ID_discipline", ID_discipline);

            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_temy_добавитьНовыеВопросы.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }
        private void button_refresh_Click(object sender, EventArgs e)
        {
            refresh_redactor_testa();
            table_temy_test1();

        }
        private void refresh_redactor_testa()
        {
            dt1.Rows.Clear();
            dt2.Rows.Clear();
            dt3.Rows.Clear();
        }
        private void table_temy_test()
        {
            dataGridView_temy.Rows.Clear();
            int i = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_topic`,`Name_topic`, `Number_of_questions`, `Kol_balls` FROM `test_topics` WHERE `ID_discipline`=@ID_discipline AND `ID_teacher`=@ID_teacher", myConnection);
            command.Parameters.AddWithValue("@ID_discipline", ID_discipline);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    dataGridView_temy.Rows.Add();
                    dataGridView_temy.Rows[i].Cells[0].Value = Convert.ToString(sqlReader["ID_topic"]);
                    dataGridView_temy.Rows[i].Cells[1].Value = Convert.ToString(sqlReader["Name_topic"]);
                    dataGridView_temy.Rows[i].Cells[2].Value = Convert.ToString(sqlReader["Number_of_questions"]);
                    dataGridView_temy.Rows[i].Cells[3].Value = Convert.ToString(sqlReader["Kol_balls"]);
                    i++;
                }
            }
            myConnection.Close();
        }

        private void table_temy_test1()
        {
            dt1.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_topic` as 'Код темы',`Name_topic` as Тема, `Number_of_questions` as 'Количество вопросов', `Kol_balls` as 'Количество баллов' FROM `test_topics` WHERE `ID_discipline`=@ID_discipline AND `ID_teacher`=@ID_teacher", myConnection);
            command.Parameters.AddWithValue("@ID_discipline", ID_discipline);
            command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);

            adapter1 = new MySqlDataAdapter(command);
            mySqlBuilder1 = new MySqlCommandBuilder(adapter1);

            adapter1.Fill(dt1);

            mySqlBuilder1.GetUpdateCommand();
            myConnection.Close();

            dataGridView_temy_redactor.DataSource = dt1;

            dataGridView_temy_redactor.Columns[0].Visible = false;
            dataGridView_temy_redactor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_temy_redactor.Columns[2].Width = 110;
            dataGridView_temy_redactor.Columns[3].Width = 110;

            dataGridView_temy_redactor.ClearSelection();
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            bank_otvetov_add();
            if (zapomnen_li_vopros == true)
            {
                MessageBox.Show("Тест находится в базе данных. Для обеспечения к нему доступа откройте тест группе или отдельному студенту!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh_sosdanie_testa();
            }
        }

        private void tests_prepod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_dalee_cosdaniye.PerformClick();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //удалим выбранную строку
            myConnection.Open();
            command = new MySqlCommand("DELETE FROM `test_topics` WHERE `ID_topic`=@ID_topic", myConnection);
            command.Parameters.AddWithValue("@ID_topic", dataGridView_temy.CurrentRow.Cells[0].Value.ToString());
            command.ExecuteNonQuery();
            myConnection.Close();
            table_temy_test();
            string predmet;
            predmet = comboBox_predmet.Text;
            comboBox_predmet.Text = "";
            comboBox_predmet.Text = predmet;
        }


        private void dataGridView_temy_redactor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dt2.Clear();
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_question`,`Text_question` as 'Текст вопроса' FROM `questions` WHERE `ID_topic`=@ID_topic", myConnection);
                command.Parameters.AddWithValue("@ID_topic", dataGridView_temy_redactor.CurrentRow.Cells[0].Value.ToString());

                adapter2 = new MySqlDataAdapter(command);
                mySqlBuilder2 = new MySqlCommandBuilder(adapter2);

                adapter2.Fill(dt2);

                mySqlBuilder2.GetUpdateCommand();
                myConnection.Close();
                dataGridView_voprosy_redactor.DataSource = dt2;

                dataGridView_voprosy_redactor.Columns[0].Visible = false;
                dataGridView_voprosy_redactor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView_voprosy_redactor.ClearSelection();
            }
            catch
            {
                myConnection.Close();
            }
        }

        private void dataGridView_voprosy_redactor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dt3.Clear();
                
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_answer`, `Text_answer` as 'Текст ответа', `Correctly` as Корректность FROM `answers` WHERE `ID_question` = @ID_question", myConnection);
                command.Parameters.AddWithValue("@ID_question", dataGridView_voprosy_redactor.CurrentRow.Cells[0].Value.ToString());
                adapter3 = new MySqlDataAdapter(command);
                mySqlBuilder3 = new MySqlCommandBuilder(adapter3);

                adapter3.Fill(dt3);

                mySqlBuilder2.GetUpdateCommand();
                myConnection.Close();
                dataGridView_otvety.DataSource = dt3;

                dataGridView_otvety.Columns[0].Visible = false;
                dataGridView_otvety.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView_otvety.Columns[2].Width = 150;

                dataGridView_otvety.ClearSelection();
            }
            catch
            {
                myConnection.Close();
            }
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    adapter1.Update(dt1);
                    adapter2.Update(dt2);
                    adapter3.Update(dt3);
                    string predmet;
                    predmet = comboBox_predmet.Text;
                    comboBox_predmet.Text = "";
                    comboBox_predmet.Text = predmet;
                }
                catch
                {
                    string predmet;
                    predmet = comboBox_predmet.Text;
                    comboBox_predmet.Text = "";
                    comboBox_predmet.Text = predmet;
                }
            }
        }
        int nomerV;
        private void comboBox_temy_добавитьНовыеВопросы_TextChanged(object sender, EventArgs e)
        {
            nomerV = 0;
            //перемена изначального номера вопроса
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_topic` FROM `test_topics` WHERE `Name_topic`=@Name_topic", myConnection);
            command.Parameters.AddWithValue("@Name_topic", comboBox_temy_добавитьНовыеВопросы.Text);

            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_topic = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();

            myConnection.Open();
            command = new MySqlCommand("SELECT * FROM `questions` WHERE `ID_topic` = @ID_topic", myConnection);
            command.Parameters.AddWithValue("@ID_topic", ID_topic);

            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    nomerV++;
                }
            }
            myConnection.Close();
            nomerV++;
            groupBox_bank_voprosov.Text = "Вопрос " + nomerV;
        }
        //при изменении типа вопроса (РЕДАКТИРОВАНИЕ ТЕСТА) меняются ответы
        private void comboBox_vidVoprosa_добавитьНовыеВопросы_TextChanged(object sender, EventArgs e)
        {
            redactir_vopr_TextChanged();
        }

        private void label_add_добавитьНовыеВопросы_Click(object sender, EventArgs e)
        {
            //добавить ответ
            if (textBox_textVoprosa_добавитьНовыеВопросы.Text != "")
            {
                otvety2();
                textBox_otvety_добавитьНовыеВопросы.Text = "";
            }
            else MessageBox.Show("Введите вид вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void otvety2()
        {
            Y = 0;
            foreach (Control control in panel_otvety_добавитьНовыеВопросы.Controls)
            {
                Y = control.Location.Y;
                Y += 30;
            }
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Один из многих")
            {
                RadioButton rb = new RadioButton();
                rb.Text = textBox_otvety_добавитьНовыеВопросы.Text;
                rb.Font = new Font("Microsoft Sans Serif", 12);
                rb.AutoSize = true;
                rb.Location = new Point(3, Y);
                panel_otvety_добавитьНовыеВопросы.Controls.Add(rb);

            }
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Многие из многих")
            {
                CheckBox ChB = new CheckBox();
                ChB.Text = textBox_otvety_добавитьНовыеВопросы.Text;
                ChB.Font = new Font("Microsoft Sans Serif", 12);
                ChB.AutoSize = true;
                ChB.Location = new Point(3, Y);
                panel_otvety_добавитьНовыеВопросы.Controls.Add(ChB);
            }
            if (comboBox_vidVoprosa_добавитьНовыеВопросы.Text == "Развернутый")
            {
                Label L = new Label();
                L.Text = textBox_otvety_добавитьНовыеВопросы.Text;
                L.Font = new Font("Microsoft Sans Serif", 12);
                L.AutoSize = true;
                L.Location = new Point(3, Y);
                panel_otvety_добавитьНовыеВопросы.Controls.Add(L);
            }
        }

        private void label_del_добавитьНовыеВопросы_Click(object sender, EventArgs e)
        {
            //удаление ответа
            foreach (Control Control in panel_otvety_добавитьНовыеВопросы.Controls)
            {
                if (Control.Text == textBox_textVoprosa_добавитьНовыеВопросы.Text)
                {
                    Control.Dispose();
                }
            }
            textBox_textVoprosa_добавитьНовыеВопросы.Text = "";
        }

        private void button_addVopros_добавитьНовыеВопросы_Click(object sender, EventArgs e)
        {
            zapomnen_li_vopros = false;
            //проверка на существование ответов
            bool f = false;
            foreach (Control Control in panel_otvety_добавитьНовыеВопросы.Controls)
            {
                f = true;
            }

            //проверка правильных ответов
            bool f1 = false;
            foreach (RadioButton rb in panel_otvety_добавитьНовыеВопросы.Controls.OfType<RadioButton>())
            {
                if (rb.Checked == true)
                {
                    f1 = true;
                }
            }
            foreach (CheckBox ChB in panel_otvety_добавитьНовыеВопросы.Controls.OfType<CheckBox>())
            {
                if (ChB.Checked == true)
                {
                    f1 = true;
                }
            }
            foreach (Label L in panel_otvety_добавитьНовыеВопросы.Controls.OfType<Label>())
            {
                f1 = true;
            }
            if (textBox_textVoprosa_добавитьНовыеВопросы.Text != "" && f == true && f1 == true)
            {
                //запоминаем вопрос
                myConnection.Open();
                command = new MySqlCommand("INSERT INTO `questions`(`ID_topic`, `Text_question`, `Type`, `Score`) VALUES (@ID_topic, @Text_question, @Type, @Score)", myConnection);
                command.Parameters.AddWithValue("@ID_topic", ID_topic);
                command.Parameters.AddWithValue("@Text_question", textBox_textVoprosa_добавитьНовыеВопросы.Text);
                command.Parameters.AddWithValue("@Type", comboBox_vidVoprosa_добавитьНовыеВопросы.Text);
                command.Parameters.AddWithValue("@Score", Score);
                command.ExecuteNonQuery();
                command = new MySqlCommand("SELECT MAX(`ID_question`) FROM `questions`", myConnection);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        ID_question = sqlReader.GetInt32(0);
                    }
                }
                myConnection.Close();

                //запоминаем ответы и правильные ответы
                foreach (RadioButton rb in panel_otvety_добавитьНовыеВопросы.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked == true)
                    {
                        korrectn_otvet(rb.Text);
                    }
                    else
                    {
                        nekorrectn_otvet(rb.Text);
                    }
                }
                foreach (CheckBox ChB in panel_otvety_добавитьНовыеВопросы.Controls.OfType<CheckBox>())
                {
                    if (ChB.Checked == true)
                    {
                        korrectn_otvet(ChB.Text);
                    }
                    else
                    {
                        nekorrectn_otvet(ChB.Text);
                    }
                }
                foreach (Label L in panel_otvety_добавитьНовыеВопросы.Controls.OfType<Label>())
                {
                    korrectn_otvet(L.Text);
                }
                //подчищаем контролы для след.вопроса
                panel_otvety_добавитьНовыеВопросы.Controls.Clear();
                nomerV++;
                groupBox_bank_voprosov.Text = "Вопрос " + nomerV;
                comboBox_vidVoprosa_добавитьНовыеВопросы.Text = "";
                textBox_textVoprosa_добавитьНовыеВопросы.Text = "";
            }
            else
            {
                if (textBox_textVoprosa_добавитьНовыеВопросы.Text == "" && f == false)
                {
                    MessageBox.Show("Заполните все пустые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox_textVoprosa_добавитьНовыеВопросы.Text == "")
                {
                    MessageBox.Show("Заполните текст вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (f == false)
                {
                    MessageBox.Show("Введите ответы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (f1 == false)
                {
                    MessageBox.Show("Отметьте правильные ответы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

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

        private void comboBox_temy_открытьТест_TextChanged(object sender, EventArgs e)
        {
            ID_topic = 0;
            //узнаем ай ди выбранной темы
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_topic` FROM `test_topics` WHERE `Name_topic`=@Name_topic", myConnection);
            command.Parameters.AddWithValue("@Name_topic", comboBox_temy_открытьТест.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_topic = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();
            open_test_tablStudents();
        }
        private void open_test_tablStudents()
        {
            dataGridView_students.Rows.Clear();

            if (comboBox_predmet.Text != "" && comboBox_temy_открытьТест.Text != "" && comboBox_group.Text != "")
            {
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

                int i = 0;
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_student`, `Surname`, `Name`, `Middle_name` FROM `students` WHERE `ID_group` = @ID_group", myConnection);
                command.Parameters.AddWithValue("@ID_group", ID_group);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        dataGridView_students.Rows.Add();
                        dataGridView_students.Rows[i].Cells[0].Value = Convert.ToString(sqlReader.GetInt32(0));
                        dataGridView_students.Rows[i].Cells[2].Value = Convert.ToString(sqlReader.GetString(1) + " " + sqlReader.GetString(2) + " " + sqlReader.GetString(3));
                        i++;
                    }
                }
                myConnection.Close();
                try
                {
                    myConnection.Open();
                    command = new MySqlCommand("SELECT `Try` FROM `open_tests` WHERE `ID_topic` = @ID_topic AND `ID_teacher` = @ID_teacher AND `ID_student` = @ID_student", myConnection);
                    command.Parameters.AddWithValue("@ID_topic", ID_topic);
                    command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
                    command.Parameters.AddWithValue("@ID_student", dataGridView_students.CurrentRow.Cells[0].Value.ToString());
                    sqlReader = command.ExecuteReader();
                    {
                        while (sqlReader.Read())
                        {
                            dataGridView_students.CurrentRow.Cells[3].Value = Convert.ToString(sqlReader.GetInt32(0));
                        }
                    }
                    myConnection.Close();
                }
                catch
                {
                    myConnection.Close();
                }
                dataGridView_students.ClearSelection();
            }
        }

        private void checkBox_vibratVse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vibratVse.Checked == true)
                foreach (DataGridViewRow row in dataGridView_students.Rows)
                {
                    row.Cells[1].Value = true;
                }
            else
            {
                foreach (DataGridViewRow row in dataGridView_students.Rows)
                {
                    row.Cells[1].Value = false;
                }
            }
        }

        private void button_primenitKVibrannym_Click(object sender, EventArgs e)
        {
            if (textBox_kolvoPopitok_открытьТест.Text != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView_students.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[1].Value) == true)
                        {
                            if (row.Cells[3].Value != null)
                            {
                                int Try = 0;
                                Try = int.Parse(row.Cells[3].Value.ToString()) + int.Parse(textBox_kolvoPopitok_открытьТест.Text);
                                myConnection.Open();
                                command = new MySqlCommand("UPDATE `open_tests` SET `Try`= @Try WHERE `ID_student` = @ID_student AND `ID_topic` = @ID_topic", myConnection);
                                command.Parameters.AddWithValue("Try", Try);
                                command.Parameters.AddWithValue("ID_student", row.Cells[0].Value.ToString());
                                command.Parameters.AddWithValue("ID_topic", ID_topic);
                                command.ExecuteNonQuery();
                                myConnection.Close();
                            }
                            else
                            {
                                myConnection.Open();
                                command = new MySqlCommand("INSERT INTO `open_tests`(`ID_topic`, `ID_discipline`, `ID_teacher`, `ID_student`, `Try`) VALUES (@ID_topic, @ID_discipline, @ID_teacher, @ID_student, @Try)", myConnection);
                                command.Parameters.AddWithValue("ID_topic", ID_topic);
                                command.Parameters.AddWithValue("ID_discipline", ID_discipline);
                                command.Parameters.AddWithValue("ID_teacher", Peremennye.ID_teacher);
                                command.Parameters.AddWithValue("ID_student", row.Cells[0].Value.ToString());
                                command.Parameters.AddWithValue("Try", textBox_kolvoPopitok_открытьТест.Text);
                                command.ExecuteNonQuery();
                                myConnection.Close();
                            }
                            checkBox_vibratVse.Checked = false;
                            open_test_tablStudents();
                        }
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Введите все необходимые данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите количество попыток", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tests_prepod_SizeChanged(object sender, EventArgs e)
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

        private void comboBox_group_TextChanged(object sender, EventArgs e)
        {
            open_test_tablStudents();
        }

        private void refresh_sosdanie_testa()
        {
            ID_discipline = 0; ID_topic = 0; a = 1; Score = 0; ID_question = 0;
            flag = false; zapomnen_li_vopros = false;

            groupBox_sosd_vopr.Text = "Вопрос " + a;

            comboBox_predmet.Text = "";
            textBox_tema.Text = "";
            textBox_ball.Text = "";
            textBox_vopr_kol.Text = "";

            comboBox_predmet.Enabled = true;
            textBox_tema.Enabled = true;
            textBox_ball.Enabled = true;
            textBox_vopr_kol.Enabled = true;


            button_finish.Enabled = false;
        }
        bool flag_test;
        private void button1_dalee_cosdaniye_Click(object sender, EventArgs e)
        {
            flag_test = false;
            if (flag == false)
            {
                if (ID_discipline != 0 && textBox_tema.Text != "" && textBox_vopr_kol.Text != "" && textBox_ball.Text != "")
                {
                    if (int.TryParse(textBox_ball.Text, out var ball) && int.TryParse(textBox_vopr_kol.Text, out var vopr_kol))
                    {
                        flag = true;
                        if (MessageBox.Show("Создать тест?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //проверка, есть ли такой тест уже в БД
                            myConnection.Open();
                            command = new MySqlCommand("SELECT `ID_topic` FROM `test_topics` WHERE `ID_discipline` = @ID_discipline and `Name_topic` = @Name_topic and `ID_teacher` = @ID_teacher", myConnection);
                            command.Parameters.AddWithValue("ID_discipline", ID_discipline);
                            command.Parameters.AddWithValue("Name_topic", textBox_tema.Text);
                            command.Parameters.AddWithValue("ID_teacher", Peremennye.ID_teacher);
                            sqlReader = command.ExecuteReader();
                            {
                                while(sqlReader.Read())
                                {
                                    flag_test = true;
                                }
                            }
                            myConnection.Close();
                            //если нет, то
                            //создаем запись в БД о новой теме
                            if (flag_test == false)
                            {
                                myConnection.Open();
                                command = new MySqlCommand("INSERT INTO `test_topics`(`ID_discipline`, `Name_topic`, `Number_of_questions`, `ID_teacher`, `Kol_balls`) VALUES (@ID_discipline, @Name_topic, @Number_of_questions, @ID_teacher, @Kol_balls)", myConnection);
                                command.Parameters.AddWithValue("@ID_discipline", ID_discipline);
                                command.Parameters.AddWithValue("@Name_topic", textBox_tema.Text);
                                command.Parameters.AddWithValue("@Number_of_questions", vopr_kol);
                                command.Parameters.AddWithValue("@ID_teacher", Peremennye.ID_teacher);
                                command.Parameters.AddWithValue("@Kol_balls", ball);
                                command.ExecuteNonQuery();
                                command = new MySqlCommand("SELECT MAX(`ID_topic`) FROM `test_topics`", myConnection);
                                sqlReader = command.ExecuteReader();
                                {
                                    while (sqlReader.Read())
                                    {
                                        ID_topic = sqlReader.GetInt32(0);
                                    }
                                }
                                myConnection.Close();

                                comboBox_predmet.Enabled = false;
                                textBox_tema.Enabled = false;
                                textBox_ball.Enabled = false;
                                textBox_vopr_kol.Enabled = false;

                                bank_otvetov_add();
                            }
                            else
                            {
                                MessageBox.Show("Тест уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                goto end;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все пустые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                bank_otvetov_add();
            }
        end:
            ;
        }
        private void bank_otvetov_add()
        {
            zapomnen_li_vopros = false;
            //проверка на существование ответов
            bool f = false;
            foreach (Control Control in panel__sosd_vopr.Controls)
            {
                f = true;
            }

            //проверка правильных ответов
            bool f1 = false;
            foreach (RadioButton rb in panel__sosd_vopr.Controls.OfType<RadioButton>())
            {
                if (rb.Checked == true)
                {
                    f1 = true;
                }   
            }
            foreach (CheckBox ChB in panel__sosd_vopr.Controls.OfType<CheckBox>())
            {
                if (ChB.Checked == true)
                {
                    f1 = true;
                }
            }
            foreach (Label L in panel__sosd_vopr.Controls.OfType<Label>())
            {
                f1 = true;
            }
            if (textBox_sosd_vopr.Text != "" && f == true && f1 == true)
            {
                zapomnen_li_vopros = true;
                //запоминаем вопрос
                myConnection.Open();
                command = new MySqlCommand("INSERT INTO `questions`(`ID_topic`, `Text_question`, `Type`, `Score`) VALUES (@ID_topic, @Text_question, @Type, @Score)", myConnection);
                command.Parameters.AddWithValue("@ID_topic", ID_topic);
                command.Parameters.AddWithValue("@Text_question", textBox_sosd_vopr.Text);
                command.Parameters.AddWithValue("@Type", comboBox_sosd_vopr.Text);
                command.Parameters.AddWithValue("@Score", Score);
                command.ExecuteNonQuery();
                command = new MySqlCommand("SELECT MAX(`ID_question`) FROM `questions`", myConnection);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        ID_question = sqlReader.GetInt32(0);
                    }
                }
                myConnection.Close();

                //запоминаем ответы и правильные ответы
                foreach (RadioButton rb in panel__sosd_vopr.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked == true)
                    {
                        korrectn_otvet(rb.Text);
                    }
                    else
                    {
                        nekorrectn_otvet(rb.Text);
                    }
                }
                foreach (CheckBox ChB in panel__sosd_vopr.Controls.OfType<CheckBox>())
                {
                    if (ChB.Checked == true)
                    {
                        korrectn_otvet(ChB.Text);
                    }
                    else
                    {
                        nekorrectn_otvet(ChB.Text);
                    }
                }
                foreach (Label L in panel__sosd_vopr.Controls.OfType<Label>())
                {
                    korrectn_otvet(L.Text);
                }
                //подчищаем контролы для след.вопроса
                panel__sosd_vopr.Controls.Clear();
                a++;
                groupBox_sosd_vopr.Text = "Вопрос " + a;
                comboBox_sosd_vopr.Text = "";
                textBox_sosd_vopr.Text = "";
                if (a >= int.Parse(textBox_vopr_kol.Text))
                {
                    button_finish.Enabled = true;
                }
            }
            else
            {
                if (textBox_sosd_vopr.Text == "" && f == false)
                {
                    MessageBox.Show("Заполните все пустые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox_sosd_vopr.Text == "")
                {
                    MessageBox.Show("Заполните текст вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (f == false)
                {
                    MessageBox.Show("Введите ответы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (f1 == false)
                {
                    MessageBox.Show("Отметьте правильные ответы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void korrectn_otvet(string text)
        {
            myConnection.Open();
            command = new MySqlCommand("INSERT INTO `answers`(`ID_question`, `Text_answer`, `Correctly`) VALUES (@ID_question, @Text_answer, @Correctly)", myConnection);
            command.Parameters.AddWithValue("@ID_question", ID_question);
            command.Parameters.AddWithValue("@Text_answer", text);
            command.Parameters.AddWithValue("@Correctly", "1");
            command.ExecuteNonQuery();
            myConnection.Close();
        }
        private void nekorrectn_otvet(string text)
        {
            myConnection.Open();
            command = new MySqlCommand("INSERT INTO `answers`(`ID_question`, `Text_answer`, `Correctly`) VALUES (@ID_question, @Text_answer, @Correctly)", myConnection);
            command.Parameters.AddWithValue("@ID_question", ID_question);
            command.Parameters.AddWithValue("@Text_answer", text);
            command.Parameters.AddWithValue("@Correctly", "0");
            command.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
