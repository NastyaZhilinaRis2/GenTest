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
    public partial class sis_admin_menu : Form
    {
        public sis_admin_menu()
        {
            InitializeComponent();
        }
        int ID_user = 0, ID_discipline = 0, ID_teacher = 0, ID_user_sbros = 0, ID_teacher_dlya_redactir;
        List<int> usersDel = new List<int> { };
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;

        MySqlDataAdapter adapter;
        MySqlCommandBuilder mySqlBuilder;
        DataTable dtDiscipline = new DataTable();

        MySqlDataAdapter adapter1;
        MySqlCommandBuilder mySqlBuilder1;
        DataTable dtPrepods = new DataTable();

        //загрузка формы
        private void sis_admin_menu_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            ItemsPrepods();
            Prepod_on_delete();
        }
        //Добавление выборки фамилий преподов
        private void ItemsPrepods()
        {
            comboBox_FIO.Items.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `Surname`, `Name`, `Middle_name` FROM `teachers`", myConnection);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_FIO.Items.Add(sqlReader.GetString(0) + " " + sqlReader.GetString(1) + " " + sqlReader.GetString(2));
                }
            }
            myConnection.Close();
        }
        private void ItemsGroup()
        {
            comboBox_groupRedactor.Items.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_group` FROM `groups` WHERE `Kurs` = @Kurs", myConnection);
            command.Parameters.AddWithValue("Kurs", textBox_kursRedactor.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_groupRedactor.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();

            comboBox_groupDelete.Items.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `Name_group` FROM `groups` WHERE `Kurs` = @Kurs", myConnection);
            command.Parameters.AddWithValue("Kurs", textBox_kursDelete.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_groupDelete.Items.Add(sqlReader.GetString(0));
                }
            }
            myConnection.Close();
        }
        private void Prepod_on_delete()
        {
            //предметы
            dtPrepods.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_teacher`, CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) as 'ФИО', `ID_user` FROM `teachers`", myConnection);

            adapter1 = new MySqlDataAdapter(command);
            mySqlBuilder1 = new MySqlCommandBuilder(adapter1);

            adapter1.Fill(dtPrepods);

            mySqlBuilder1.GetUpdateCommand();
            myConnection.Close();

            dataGridView_PrepodsOnDelete.DataSource = dtPrepods;

            dataGridView_PrepodsOnDelete.Columns[1].Visible = false;
            dataGridView_PrepodsOnDelete.Columns[3].Visible = false;
            dataGridView_PrepodsOnDelete.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_PrepodsOnDelete.ClearSelection();
        }

        //при нажатии на "+" дисциплин
        private void pictureBox_addDiscipline_Click(object sender, EventArgs e)
        {
            tableLayoutPanel_dataAdd.RowCount++;
            TextBox tb = new TextBox();
            tb.Name = "textBox_disciplina" + tableLayoutPanel_dataAdd.RowCount;
            tb.Dock = DockStyle.Fill;
            tb.Font = new Font("Montserrat", 12);
            tableLayoutPanel_dataAdd.Controls.Add(tb, 1, tableLayoutPanel_dataAdd.RowCount - 1);
            tableLayoutPanel_dataAdd.Controls.Add(pictureBox_addDiscipline, 2, tableLayoutPanel_dataAdd.RowCount - 1);
        }
        //"добавить" препода
        bool flag_data, flag_login;

        //при изменении ФИО меняются отдельные строки с ФИО, ай ди и предметы
        private void comboBox_FIO_TextChanged(object sender, EventArgs e)
        {
            //при изменении ФИО меняются отдельные строки с ФИО и ай ди
            textBox_redactorFamiliya.Text = "";
            textBox_redactorName.Text = "";
            textBox_redactorOtchestvo.Text = "";
            ID_teacher_dlya_redactir = 0;
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_teacher`, `Surname`, `Name`, `Middle_name` FROM `teachers` WHERE CONCAT(`Surname`, ' ', `Name`, ' ',`Middle_name`) = @FIO", myConnection);
            command.Parameters.AddWithValue("FIO", comboBox_FIO.Text);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    ID_teacher_dlya_redactir = sqlReader.GetInt32(0);
                    textBox_redactorFamiliya.Text = sqlReader.GetString(1);
                    textBox_redactorName.Text = sqlReader.GetString(2);
                    textBox_redactorOtchestvo.Text = sqlReader.GetString(3);
                }
            }
            myConnection.Close();
            //предметы
            dtDiscipline.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_discipline`, `Name_discipline` as 'Дисциплина' FROM `disciplines` WHERE `ID_teacher` = @ID_teacher", myConnection);
            command.Parameters.AddWithValue("ID_teacher", ID_teacher_dlya_redactir);

            adapter = new MySqlDataAdapter(command);
            mySqlBuilder = new MySqlCommandBuilder(adapter);

            adapter.Fill(dtDiscipline);

            mySqlBuilder.GetUpdateCommand();
            myConnection.Close();

            dataGridView_discipline.DataSource = dtDiscipline;

            dataGridView_discipline.Columns[1].Visible = false;
            dataGridView_discipline.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_discipline.ClearSelection();
        }
        //кнопка редактора фамилии препода
        private void button_familiyaRedactor_Click(object sender, EventArgs e)
        {
            if(textBox_newFamiliya.Text != "")
            {
                myConnection.Open();
                command = new MySqlCommand("UPDATE `teachers` SET `Surname`=@Surname WHERE `ID_teacher` = @ID_teacher", myConnection);
                command.Parameters.AddWithValue("Surname", textBox_newFamiliya.Text);
                command.Parameters.AddWithValue("ID_teacher", ID_teacher_dlya_redactir);
                command.ExecuteNonQuery();
                myConnection.Close();
                textBox_redactorFamiliya.Text = textBox_newFamiliya.Text;
                textBox_newFamiliya.Text = "";
            }
            obnovlenie_textfio();
        }
        private void obnovlenie_textfio()
        {
            comboBox_FIO.Items.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `Surname`, `Name`, `Middle_name` FROM `teachers`", myConnection);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    comboBox_FIO.Items.Add(sqlReader.GetString(0) + " " + sqlReader.GetString(1) + " " + sqlReader.GetString(2));
                }
            }
            myConnection.Close();

            foreach (string cmbitem in comboBox_FIO.Items)
            {
                if (cmbitem == (textBox_redactorFamiliya.Text + " " + textBox_redactorName.Text + " " + textBox_redactorOtchestvo.Text))
                {
                    comboBox_FIO.Text = cmbitem;
                }
            }
        }
        //кнопка редактора имени препода
        private void button_nameRedactor_Click(object sender, EventArgs e)
        {
            if (textBox_newName.Text != "")
            {
                myConnection.Open();
                command = new MySqlCommand("UPDATE `teachers` SET `Name`=@Name WHERE `ID_teacher` = @ID_teacher", myConnection);
                command.Parameters.AddWithValue("Name", textBox_newName.Text);
                command.Parameters.AddWithValue("ID_teacher", ID_teacher_dlya_redactir);
                command.ExecuteNonQuery();
                myConnection.Close();
                textBox_redactorName.Text = textBox_newName.Text;
                textBox_newName.Text = "";
            }
            obnovlenie_textfio();
        }
        //кнопка редактора отчества препода
        private void button_otchestvoRedactor_Click(object sender, EventArgs e)
        {
            if (textBox_newOtchestvo.Text != "")
            {
                myConnection.Open();
                command = new MySqlCommand("UPDATE `teachers` SET `Middle_name`=@Middle_name WHERE `ID_teacher` = @ID_teacher", myConnection);
                command.Parameters.AddWithValue("Middle_name", textBox_newOtchestvo.Text);
                command.Parameters.AddWithValue("ID_teacher", ID_teacher_dlya_redactir);
                command.ExecuteNonQuery();
                myConnection.Close();
                textBox_redactorOtchestvo.Text = textBox_newOtchestvo.Text;
                textBox_newOtchestvo.Text = "";
            }
            obnovlenie_textfio();
        }
        //кнопка вставки нового(ых) предметов, которые ведет препод
        private void button_insert_Click(object sender, EventArgs e)
        {
        metka:
            for (int i = 0; i < dataGridView_discipline.RowCount - 1; i++)
            {
                if (Convert.ToString(dataGridView_discipline.Rows[i].Cells[2].Value) == "")
                {
                    dataGridView_discipline.Rows.RemoveAt(dataGridView_discipline.Rows[i].Index);
                    goto metka;
                }
            }
            adapter.Update(dtDiscipline);
            myConnection.Open();
            command = new MySqlCommand("UPDATE `disciplines` SET `ID_teacher`=@ID_teacher WHERE `ID_teacher` is NULL", myConnection);
            command.Parameters.AddWithValue("ID_teacher", ID_teacher_dlya_redactir);
            command.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBox_FIO.Text = comboBox_FIO.Text;
            ;
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            snachala1:
            foreach (DataGridViewRow row in dataGridView_discipline.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    dataGridView_discipline.Rows.Remove(row);
                    try
                    {
                        adapter.Update(dtDiscipline);
                    }
                    catch
                    {
                        myConnection.Close();
                    }
                    goto snachala1;
                }
            }
        }
        //для изменения высоты таблицы с преподами
        private void ChangeHeight()
        {
            // меняем высоту таблицу по высоте всех строк
            dataGridView_PrepodsOnDelete.Height = dataGridView_PrepodsOnDelete.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dataGridView_PrepodsOnDelete.ColumnHeadersHeight + 10;
        }
        private void dataGridView_PrepodsOnDelete_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ChangeHeight();
        }

        private void dataGridView_PrepodsOnDelete_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ChangeHeight();
        }
        //поиск преподавателей
        private void textBox_poiskPrepod_TextChanged(object sender, EventArgs e)
        {
            string FIO;
            FIO = "%" + textBox_poiskPrepod.Text + "%";
            dtPrepods.Rows.Clear();
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_teacher`, CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) as 'ФИО' FROM `teachers` WHERE CONCAT(`Surname`, ' ', `Name`, ' ', `Middle_name`) LIKE @FIO", myConnection);
            command.Parameters.AddWithValue("FIO", FIO);

            adapter1 = new MySqlDataAdapter(command);
            mySqlBuilder1 = new MySqlCommandBuilder(adapter1);

            adapter1.Fill(dtPrepods);

            mySqlBuilder1.GetUpdateCommand();
            myConnection.Close();

            dataGridView_PrepodsOnDelete.DataSource = dtPrepods;

            dataGridView_PrepodsOnDelete.Columns[1].Visible = false;
            dataGridView_PrepodsOnDelete.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_PrepodsOnDelete.Columns[1].ReadOnly = true;
            dataGridView_PrepodsOnDelete.ClearSelection();
        }

        private void checkBox_viborVse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_viborVse.Checked == true)
                foreach (DataGridViewRow row in dataGridView_PrepodsOnDelete.Rows)
                {
                    row.Cells[0].Value = true;
                }
            else
            {
                foreach (DataGridViewRow row in dataGridView_PrepodsOnDelete.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void button_delPrepod_Click(object sender, EventArgs e)
        {
        Close:
            foreach (DataGridViewRow row in dataGridView_PrepodsOnDelete.Rows)
            {
                if (Convert.ToString(row.Cells[2].Value) == "" && Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    dataGridView_PrepodsOnDelete.Rows.Remove(row);
                    goto Close;
                }
            }
        snachala:
            foreach (DataGridViewRow row in dataGridView_PrepodsOnDelete.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    usersDel.Add(int.Parse(row.Cells[3].Value.ToString()));
                    dataGridView_PrepodsOnDelete.Rows.Remove(row);
                    adapter1.Update(dtPrepods);
                    goto snachala;
                }
            }
            ItemsPrepods();
            foreach (int id_user in usersDel)
            {
                myConnection.Open();
                command = new MySqlCommand("DELETE FROM `users` WHERE `ID_user`=@ID_user", myConnection);
                command.Parameters.AddWithValue("ID_user", id_user);
                command.ExecuteNonQuery();
                myConnection.Close();
                comboBox_FIO.Text = "";
            }
            usersDel.Clear();
        }

        private void button_addGroup_Click(object sender, EventArgs e)
        {
            if(textBox_kursAdd.Text != "" && textBox_groupAdd.Text != "")
            {
                if (int.TryParse(textBox_kursAdd.Text, out var number))
                {
                    myConnection.Open();
                    command = new MySqlCommand("INSERT INTO `groups`(`Name_group`, `Kurs`) VALUES (@Name_group, @Kurs)", myConnection);
                    command.Parameters.AddWithValue("Name_group", textBox_groupAdd.Text);
                    command.Parameters.AddWithValue("Kurs", number);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_groupAdd.Text = "";
                    textBox_kursAdd.Text = "";
                }
                else
                {
                    MessageBox.Show("Неверно введен курс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        //при изменении курса появляется выборка имеющихся групп для редактирования
        private void textBox_kursRedactor_TextChanged(object sender, EventArgs e)
        {
            ItemsGroup();
        }
        //при изменении курса появляется выборка имеющихся групп для удаления
        private void textBox_kursDelete_TextChanged(object sender, EventArgs e)
        {
            ItemsGroup();
        }
        //редактирование текста(курса) группы
        int ID_group;
        private void button_redactorGroup_Click(object sender, EventArgs e)
        {
            if (textBox_kursRedactor.Text != "" && comboBox_groupRedactor.Text != "")
            {
                ID_group = 0;
                //найдем ай ди группы
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_group` FROM `groups` WHERE `Name_group` = @Name_group AND `Kurs` = @Kurs", myConnection);
                command.Parameters.AddWithValue("Name_group", comboBox_groupRedactor.Text);
                command.Parameters.AddWithValue("Kurs", textBox_kursRedactor.Text);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        ID_group = sqlReader.GetInt32(0);
                    }
                }
                myConnection.Close();

                myConnection.Open();
                command = new MySqlCommand("UPDATE `groups` SET `Name_group`= @Name_group,`Kurs`= @Kurs WHERE `ID_group`=@ID_group", myConnection);
                if (textBox_newGroupRedactor.Text != "")
                {
                    command.Parameters.AddWithValue("Name_group", textBox_newGroupRedactor.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("Name_group", comboBox_groupRedactor.Text);
                }

                if (textBox_newKursRedactor.Text != "")
                {
                    command.Parameters.AddWithValue("Kurs", textBox_newKursRedactor.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("Kurs", textBox_kursRedactor.Text);
                }

                command.Parameters.AddWithValue("ID_group", ID_group);
                command.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_newGroupRedactor.Text = "";
                comboBox_groupRedactor.Text = "";
                textBox_newKursRedactor.Text = "";
                textBox_kursRedactor.Text = "";
            }
            else
            {
                MessageBox.Show("Введите курс и группу, которые необходимо изменить!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_deleteGroup_Click(object sender, EventArgs e)
        {
            if (textBox_kursDelete.Text != "" && comboBox_groupDelete.Text != "")
            {
                myConnection.Open();
                command = new MySqlCommand("DELETE FROM `groups` WHERE `Name_group`=@Name_group AND `Kurs`=@Kurs", myConnection);
                command.Parameters.AddWithValue("Name_group", comboBox_groupDelete.Text);
                command.Parameters.AddWithValue("Kurs", textBox_kursDelete.Text);
                command.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Готово!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox_groupDelete.Text = "";
                textBox_kursDelete.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox_polzovatel_TextChanged(object sender, EventArgs e)
        {
            textBox_familiya_sbros.Text = "";
            textBox_name_sbros.Text = "";
            textBox_otchestvo_sbros.Text = "";
            textBox_password_sbros.Text = "";
            textBox_kodWord_sbros.Text = "";
            maskedTextBox_GR.Text = "";

            if (comboBox_polzovatel.Text == "Преподаватель")
            {
                //активируем поля ввода
                textBox_familiya_sbros.Enabled = true;
                textBox_name_sbros.Enabled = true;
                textBox_otchestvo_sbros.Enabled = true;
                maskedTextBox_GR.Enabled = true;
            }
            else if (comboBox_polzovatel.Text == "Студент")
            {
                //активируем поля ввода
                textBox_familiya_sbros.Enabled = true;
                textBox_name_sbros.Enabled = true;
                textBox_otchestvo_sbros.Enabled = true;
                maskedTextBox_GR.Enabled = true;
            }
            else
            {
                //дезактивируем поля ввода
                textBox_familiya_sbros.Enabled = false;
                textBox_name_sbros.Enabled = false;
                textBox_otchestvo_sbros.Enabled = false;
                maskedTextBox_GR.Enabled = false;
            }
        }

        private void sis_admin_menu_SizeChanged(object sender, EventArgs e)
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

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_familiya_sbros.Text != "" && textBox_name_sbros.Text != "" && textBox_otchestvo_sbros.Text != "" && maskedTextBox_GR.Text != "")
            {
                ID_user_sbros = 0;
                DateTime GR = DateTime.Parse(maskedTextBox_GR.Text);
                string GR_formatted = GR.ToString("yyyy-MM-dd");
                //найдем ай ди пользователя СТУДЕНТА для сброса
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_user` FROM `students` WHERE `Surname` = @Surname AND `Name` = @Name AND `Middle_name` = @Middle_name AND `Year_of_birth` = @Year_of_birth", myConnection);
                command.Parameters.AddWithValue("Surname", textBox_familiya_sbros.Text);
                command.Parameters.AddWithValue("Name", textBox_name_sbros.Text);
                command.Parameters.AddWithValue("Middle_name", textBox_otchestvo_sbros.Text);
                command.Parameters.AddWithValue("Year_of_birth", GR_formatted);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        ID_user_sbros = sqlReader.GetInt32(0);
                    }
                }
                myConnection.Close();

                //найдем ай ди пользователя ПРЕПОДАВАТЕЛЯ для сброса
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_user` FROM `teachers` WHERE `Surname` = @Surname AND `Name` = @Name AND `Middle_name` = @Middle_name AND `Year_of_birth` = @Year_of_birth", myConnection);
                command.Parameters.AddWithValue("Surname", textBox_familiya_sbros.Text);
                command.Parameters.AddWithValue("Name", textBox_name_sbros.Text);
                command.Parameters.AddWithValue("Middle_name", textBox_otchestvo_sbros.Text);
                command.Parameters.AddWithValue("Year_of_birth", maskedTextBox_GR.Text);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        ID_user_sbros = sqlReader.GetInt32(0);
                    }
                }
                myConnection.Close();

                //меняем пароль
                if (ID_user_sbros != 0)
                {
                    myConnection.Open();
                    command = new MySqlCommand("UPDATE `users` SET `Password`=@Password,`Code_word`= @Code_word WHERE `ID_user` = @ID_user AND `User`= @User", myConnection);
                    command.Parameters.AddWithValue("Password", Hesh.HashPassword(textBox_password_sbros.Text));
                    command.Parameters.AddWithValue("Code_word", Hesh.HashPassword(textBox_kodWord_sbros.Text));
                    command.Parameters.AddWithValue("ID_user", ID_user_sbros);
                    command.Parameters.AddWithValue("User", comboBox_polzovatel.Text);
                    command.ExecuteNonQuery();
                    myConnection.Close();

                    //проверяем, изменился ли пароль
                    myConnection.Open();
                    command = new MySqlCommand("SELECT `Password` FROM `users` WHERE (`ID_user` = @ID_user) AND `User` = @User", myConnection);
                    command.Parameters.AddWithValue("ID_user", ID_user_sbros);
                    command.Parameters.AddWithValue("User", comboBox_polzovatel.Text);
                    sqlReader = command.ExecuteReader();
                    {
                        while (sqlReader.Read())
                        {
                            //если такой пользователь с таким логином существует + у него изменен пароль
                            if (sqlReader.GetString(0) == Hesh.HashPassword(textBox_password_sbros.Text))
                            {
                                MessageBox.Show("Пароль успешно изменен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comboBox_polzovatel.Text = "";
                                textBox_familiya_sbros.Text = "";
                                textBox_name_sbros.Text = "";
                                textBox_otchestvo_sbros.Text = "";
                                textBox_password_sbros.Text = "";
                                textBox_kodWord_sbros.Text = "";
                                maskedTextBox_GR.Text = "";
                            }
                        }
                    }
                }
                //если нет такого пользователя
                else
                {
                    MessageBox.Show("Пароль не изменен! Неверно введены данные", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox_reset_Click(object sender, EventArgs e)
        {
            upDataAdd();
        }

        private void button_addPrepod_Click(object sender, EventArgs e)
        {
            flag_data = true;
            for (int y = 0; y < 7; y++)
            {
                if (tableLayoutPanel_dataAdd.GetControlFromPosition(1, y).Text == "")
                {
                    flag_data = false;
                }
            }
            if (flag_data == true)
            {
                try
                {
                    ID_user = 0;
                    ID_discipline = 0;
                    ID_teacher = 0;
                    flag_login = true;
                    //проверяем, нет ли индентичного логина
                    myConnection.Open();
                    command = new MySqlCommand("SELECT `ID_user` FROM `users` WHERE `Login` = @Login;", myConnection);
                    command.Parameters.AddWithValue("Login", textBox_login.Text);
                    sqlReader = command.ExecuteReader();
                    {
                        while (sqlReader.Read())
                        {
                            flag_login = false;
                        }
                    }
                    myConnection.Close();

                    if (flag_login != false)
                    {
                        //вставляем запись о новом преподе в "юзерс"
                        myConnection.Open();
                        command = new MySqlCommand("INSERT INTO `users`(`User`, `Login`, `Password`, `Code_word`) VALUES (@User, @Login, @Password, @Code_word)", myConnection);
                        command.Parameters.AddWithValue("User", "преподаватель");
                        command.Parameters.AddWithValue("Login", textBox_login.Text);
                        command.Parameters.AddWithValue("Password", Hesh.HashPassword(textBox_password.Text));
                        command.Parameters.AddWithValue("Code_word", Hesh.HashPassword(textBox_cod_word.Text));
                        command.ExecuteNonQuery();
                        command = new MySqlCommand("SELECT MAX(`ID_user`) FROM `users`", myConnection);
                        sqlReader = command.ExecuteReader();
                        {
                            while (sqlReader.Read())
                            {
                                ID_user = sqlReader.GetInt32(0);
                            }
                        }
                        myConnection.Close();
                        //вставляем запись с ФИО и предметами
                        if (ID_user != 0)
                        {
                            myConnection.Open();
                            command = new MySqlCommand("INSERT INTO `teachers`(`Surname`, `Name`, `Middle_name`, `ID_user`) VALUES (@Surname, @Name, @Middle_name, @ID_user)", myConnection);
                            command.Parameters.AddWithValue("Surname", textBox_familiya.Text);
                            command.Parameters.AddWithValue("Name", textBox_name.Text);
                            command.Parameters.AddWithValue("Middle_name", textBox_otchestvo.Text);
                            command.Parameters.AddWithValue("ID_user", ID_user);
                            command.ExecuteNonQuery();
                            command = new MySqlCommand("SELECT MAX(`ID_teacher`) FROM `teachers`", myConnection);
                            sqlReader = command.ExecuteReader();
                            {
                                while (sqlReader.Read())
                                {
                                    ID_teacher = sqlReader.GetInt32(0);
                                }
                            }
                            myConnection.Close();
                        }
                        //создаем дисциплину
                        for (int y = 6; y < tableLayoutPanel_dataAdd.RowCount; y++)
                        {
                            ID_discipline = 0;
                            myConnection.Open();
                            command = new MySqlCommand("INSERT INTO `disciplines`(`Name_discipline`, `ID_teacher`) VALUES (@Name_discipline, @ID_teacher)", myConnection);
                            command.Parameters.AddWithValue("Name_discipline", tableLayoutPanel_dataAdd.GetControlFromPosition(1, y).Text);
                            command.Parameters.AddWithValue("ID_teacher", ID_teacher);
                            sqlReader = command.ExecuteReader();
                            {
                                while (sqlReader.Read())
                                {
                                    ID_discipline = sqlReader.GetInt32(0);
                                }
                            }
                            myConnection.Close();

                            if (tableLayoutPanel_dataAdd.GetControlFromPosition(1, y).Text == "")
                            {
                                flag_data = false;
                            }
                        }
                        MessageBox.Show("Преподаватель зарегестрирован!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //очищаем(обновляем)
                        upDataAdd();
                        //обновляем выборку преподов
                        ItemsPrepods();
                        Prepod_on_delete();
                    }
                    else
                    {
                        MessageBox.Show("Такой логин уже существует", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        myConnection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный тип данных!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все ячейки!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void upDataAdd()
        {
            for (int y = 0; y < 7; y++)
            {
                tableLayoutPanel_dataAdd.GetControlFromPosition(1, y).Text = "";
            }
            for (int y = tableLayoutPanel_dataAdd.RowCount - 1; y >= 7; y--)
            {
                var control = tableLayoutPanel_dataAdd.GetControlFromPosition(1, y);
                tableLayoutPanel_dataAdd.Controls.Remove(control);
                tableLayoutPanel_dataAdd.RowCount--;
            }
            tableLayoutPanel_dataAdd.Controls.Add(pictureBox_addDiscipline, 2, 6);
        }
    }
}
