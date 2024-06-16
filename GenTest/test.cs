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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        int nomer_voprosa = 0, ID_question = 0, ball = 0, Number_of_questions = 0, kol_vo_otvety = 0, Score = 0, ball_test = 0;
        string type_voprosa;
        bool flag = false;
        //список номеров вопросов по выбранной теме для последющей выборки из них
        List<int> spisok_nomerov_voprosov = new List<int>();
        List<string> Texts_answer = new List<string>();
        List<string> Correctly = new List<string>();
        List<int> razmer = new List<int>();

        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;

        private void test_SizeChanged(object sender, EventArgs e)
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

        private void button_dalee_Click(object sender, EventArgs e)
        {
            if (button_dalee.Text == "Далее")
            {
                //проверка еще прошлого вопроса
                proverka();
                random_nomer_voprosa();
                text_voprosa();
                otvety();
            }

            if (button_dalee.Text == "Завершить")
            {
                string ball_str = "";
                if (flag == false)
                {
                    proverka();
                    flag = true;
                }
                else
                {
                    proverka();
                    ball = (ball * 100 / ball_test) * Peremennye.Kol_balls / 100;
                    //завершаем прохождение теста
                    myConnection.Open();
                    command = new MySqlCommand("UPDATE `tests` SET `Аssessment`=@Аssessment,`Date`=@Date WHERE `ID_test` = @ID_test", myConnection);
                    command.Parameters.AddWithValue("@Аssessment", ball);
                    command.Parameters.AddWithValue("@Date", DateTime.Today.Date.ToString("yyyy/MM/dd"));
                    command.Parameters.AddWithValue("@ID_test", Peremennye.ID_test);
                    command.ExecuteNonQuery();
                    myConnection.Close();

                    if (ball % 10 == 1 && ball != 11)
                    {
                        ball_str = "балл";
                    }
                    else
                    {
                        if (ball % 10 == 2 && ball != 12 || ball % 10 == 3 && ball != 13 || ball % 10 == 4 && ball != 14)
                        {
                            ball_str = "балла";
                        }
                        else
                        {
                            ball_str = "баллов";
                        }
                    }

                    MessageBox.Show("Тест завершен! Вы набрали "+ ball.ToString() + " " + ball_str.ToString() + " из " + Peremennye.Kol_balls, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    menu_student menu_student = new menu_student();
                    menu_student.Show();
                    this.Close();
                }
            }
        }
        private void test_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            //Узнаем кол-во вопросов данной темы
            myConnection.Open();
            command = new MySqlCommand("SELECT `Number_of_questions` FROM `test_topics` WHERE `ID_topic`=@ID_topic", myConnection);
            command.Parameters.AddWithValue("@ID_topic", Peremennye.ID_topic);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    Number_of_questions = sqlReader.GetInt32(0);
                }
            }
            myConnection.Close();

            //Формируем список номеров вопросов по данной теме
            myConnection.Open();
            command = new MySqlCommand("SELECT `ID_question` FROM `questions` WHERE `ID_topic`=@ID_topic", myConnection);
            command.Parameters.AddWithValue("@ID_topic", Peremennye.ID_topic);
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    spisok_nomerov_voprosov.Add(sqlReader.GetInt32(0));
                }
            }
            myConnection.Close();
            foreach (var person in spisok_nomerov_voprosov)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine(" ");
            //Формируем номер вопроса из диапазона списка номеров вопросов по данной теме + начальные "настройки окна"
            random_nomer_voprosa();
            //Формируем текст вопроса
            text_voprosa();
            //Формируем ответы
            otvety();
        }

        private void random_nomer_voprosa()
        {
            //Очистим панель и массивы данных
            panel_okno.RowStyles.Clear();
            panel_okno.Controls.Clear();
            panel_okno.RowCount = 1;/*
            panel_okno.Size = new Size(this.ClientSize.Width-35, this.ClientSize.Height-200);*/
            nomer_voprosa += 1;

            //текст кнопки "завершить"
            if (nomer_voprosa == Number_of_questions)
            {
                button_dalee.Text = "Завершить";
            }
            //формируем в заголовке номер вопроса
            label_nomer_voprosa.Text = "Вопрос № " + nomer_voprosa;
            //формируем рандомный номер
            var random = new Random();
            int random_index = random.Next(spisok_nomerov_voprosov.Count);

            try
            {
                ID_question = spisok_nomerov_voprosov[random_index];
            }
            catch
            {
                MessageBox.Show("В базе не хватает вопросов. ВАЖНО! Ошибка не исправится сама по себе. Обращайтесь к преподавателю!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            for (int i = 0; i < spisok_nomerov_voprosov.Count; i++)
            {
                if (spisok_nomerov_voprosov[i] == spisok_nomerov_voprosov[random_index])
                {
                    spisok_nomerov_voprosov.Remove(spisok_nomerov_voprosov[i]);
                }
            }
        }
        private void text_voprosa()
        {
            try
            {
                Label label_vopros = new Label();

                myConnection.Open();
                command = new MySqlCommand("SELECT `Text_question`, `Type`, `Score` FROM `questions` WHERE `ID_question`=@ID_question", myConnection);
                command.Parameters.AddWithValue("@ID_question", ID_question);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        label_vopros.Text = sqlReader.GetString(0);
                        type_voprosa = sqlReader.GetString(1);
                        Score = sqlReader.GetInt32(2);
                        ball_test += Score;
                    }
                }
                myConnection.Close();

                label_vopros.AutoSize = true;
                label_vopros.Location = new Point(0, 0);
                label_vopros.Font = new Font("Microsoft Sans Serif", 18);

                panel_okno.Controls.Add(label_vopros);

                panel_okno.RowStyles.Insert(0, new RowStyle(SizeType.Absolute, label_vopros.Height + 25));

                label_vopros.Dock = DockStyle.Fill;
            }
            catch
            {
                MessageBox.Show("Ошибка с вопросом!", "Обращайтесь к разработчику:)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }
        private void otvety()
        {
            try
            {
                Texts_answer.Clear();
                Correctly.Clear();

                kol_vo_otvety = 0;

                //тексты ответов
                myConnection.Open();
                command = new MySqlCommand("SELECT `ID_answer`,`Text_answer` FROM `answers` WHERE `ID_question`=@ID_question", myConnection);
                command.Parameters.AddWithValue("@ID_question", ID_question);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        Texts_answer.Add(Convert.ToString(sqlReader["Text_answer"]));
                        kol_vo_otvety++;
                    }
                }
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка 1!", "Обращайтесь к разработчику:)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
            try
            {
                //правильные ответы
                myConnection.Open();
                command = new MySqlCommand("SELECT `Text_answer` FROM `answers` WHERE `Correctly`='1' AND `ID_question`=@ID_question", myConnection);
                command.Parameters.AddWithValue("@ID_question", ID_question);
                sqlReader = command.ExecuteReader();
                {
                    while (sqlReader.Read())
                    {
                        Correctly.Add(sqlReader.GetString(0));
                    }
                }
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка 2!", "Обращайтесь к разработчику:)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
            try
            {
                razmer.Clear();
                //узнаем длину текста ответа
                for (int i = 0; i < kol_vo_otvety; i++)
                {
                    Label razmer_text = new Label();
                    razmer_text.Location = new Point(0, 0);
                    razmer_text.AutoSize = true;
                    razmer_text.Font = new Font("Microsoft Sans Serif", 14);
                    razmer_text.ForeColor = Color.White;
                    razmer_text.Text = Texts_answer[i];
                    this.Controls.Add(razmer_text);
                    razmer_text.MaximumSize = new Size(this.ClientSize.Width - 55, 10000);
                    razmer.Add(razmer_text.Size.Height);
                    razmer_text.Text = null;
                }

                //Тип - один из многих
                if (type_voprosa == "Один из многих")
                {
                    for (int i = 0; i < kol_vo_otvety; i++)
                    {
                        //добавим "виртуально" ответ
                        RadioButton rb = new RadioButton();
                        rb.Name = "radiobutton" + i;
                        rb.Text = Texts_answer[i];
                        rb.Font = new Font("Microsoft Sans Serif", 14);
                        rb.AutoSize = true;
                        rb.Dock = DockStyle.Fill;

                        //добавим "реально" строку с ответом
                        panel_okno.RowCount++;
                        panel_okno.Controls.Add(rb);

                        //Поменяем высоту строки на нужную
                        panel_okno.RowStyles.Insert(panel_okno.RowCount - 1, new RowStyle(SizeType.Absolute, razmer[i] + 10));
                    }

                    //Подчистим все костыли (лейблы, с помощью которых узнавали размер)
                    foreach (Control ctrl in panel_okno.Controls)
                        if (ctrl is Label) this.Controls.Remove(ctrl);
                }
                //Тип - многие из многих
                if (type_voprosa == "Многие из многих")
                {
                    for (int i = 0; i < kol_vo_otvety; i++)
                    {
                        //добавим "виртуально" ответ
                        CheckBox ChB = new CheckBox();
                        ChB.Name = "checkbox" + i;
                        ChB.Text = Texts_answer[i];
                        ChB.Font = new Font("Microsoft Sans Serif", 14);
                        ChB.AutoSize = true;
                        ChB.Dock = DockStyle.Fill;

                        //добавим "реально" строку с ответом
                        panel_okno.RowCount++;
                        panel_okno.Controls.Add(ChB);

                        //Поменяем высоту строки на нужную
                        panel_okno.RowStyles.Insert(panel_okno.RowCount - 1, new RowStyle(SizeType.Absolute, razmer[i] + 10));
                    }
                }
                //Тип - развернутый
                if (type_voprosa == "Развернутый")
                {
                    TextBox tb = new TextBox();
                    tb.Name = "textBox1";
                    tb.AutoSize = true;
                    tb.Font = new Font("Microsoft Sans Serif", 14);
                    tb.Size = new Size(400, 35);
                    panel_okno.RowCount++;
                    panel_okno.Controls.Add(tb);
                    panel_okno.RowStyles.Insert(panel_okno.RowCount - 1, new RowStyle(SizeType.Absolute, tb.Height + 10));
                }

                //Создадим доп. пустую строку, чтобы последняя строка с ответом не растягивалась
                panel_okno.RowCount++;
                Label l = new Label();
                l.Size = new Size(0, 0);
                l.Dock = DockStyle.Fill;
                panel_okno.RowStyles.Insert(panel_okno.RowCount - 1, new RowStyle(SizeType.Absolute, 0));
                panel_okno.Controls.Add(l);
            }

            catch
            {
                MessageBox.Show("Ошибка 3!", "Обращайтесь к разработчику:)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }
        //проверка ответов
        private void proverka()
        {
            if (type_voprosa == "Один из многих")
            {
                foreach (RadioButton rb in panel_okno.Controls.OfType<RadioButton>())
                    if (rb.Checked == true)
                    {
                        for (int i = 0; i < Correctly.Count; i++)
                        {
                            if (rb.Text == Correctly[i])
                            {
                                ball += Score;
                                break;
                            }
                        }

                    }
            }
            int m = 0, n = 0;
            if (type_voprosa == "Многие из многих")
            {
                //узнаем, сколько выбрано чекбоксов
                foreach (CheckBox ChB in panel_okno.Controls.OfType<CheckBox>())
                {
                    if (ChB.Checked)
                    {
                        m++;
                    }
                }
                //сравним кол-во выбранных чекбоксов с кол-вом верных ответов
                if (m == Correctly.Count)
                {
                    //пройдемся по всем верным ответам
                    for (int i = 0; i < Correctly.Count; i++)
                    {
                        bool F = false;
                        //пройдемся по всем чекбоксам
                        foreach (CheckBox ChB in panel_okno.Controls.OfType<CheckBox>())
                        {
                            //если верный ответ и выбранный ответ совпадают, то флаг=true и выход из цикла фореч на следующий верный ответ
                            if ((Correctly[i] == ChB.Text) && ChB.Checked)
                            {
                                F = true;
                            }
                            if (F == true)
                            {
                                n++;
                                break;
                            }
                        }
                    }
                    if (m == n)
                    {
                        ball += Score;
                    }
                }
            }
            if (type_voprosa == "Развернутый")
            {
                foreach (TextBox TB in panel_okno.Controls.OfType<TextBox>())
                {
                    if (TB.Text == Correctly[0])
                    {
                        ball += Score;
                    }
                }
            }    
        }
    }
}