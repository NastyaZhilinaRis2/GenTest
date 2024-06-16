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
    public partial class menu_prepod : Form
    {
        public menu_prepod()
        {
            InitializeComponent();
        }
        MySqlConnection myConnection = new MySqlConnection(Peremennye.conn);
        MySqlDataReader sqlReader;
        MySqlCommand command;

        private void button_test_Click_1(object sender, EventArgs e)
        {
            this.Close();
            tests_prepod tests_prepod = new tests_prepod();
            tests_prepod.Show();
        }

        private void button_student_Click(object sender, EventArgs e)
        {
            this.Close();
            students_prepod students_prepod = new students_prepod();
            students_prepod.Show();
        }

        private void menu_prepod_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void menu_prepod_SizeChanged(object sender, EventArgs e)
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
        string FIO;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            tabel_uspevaemosti tabel_uspevaemosti = new tabel_uspevaemosti();
            tabel_uspevaemosti.Show();

            myConnection.Open();
            command = new MySqlCommand("SELECT CONCAT(`Surname`,' ', `Name`, ' ', `Middle_name`) FROM `teachers` WHERE `ID_teacher` = @ID_teacher", myConnection);
            command.Parameters.AddWithValue("ID_teacher", Peremennye.ID_teacher.ToString());
            sqlReader = command.ExecuteReader();
            {
                while (sqlReader.Read())
                {
                    FIO = sqlReader.GetString(0);
                }
            }
            myConnection.Close();

            tabel_uspevaemosti.comboBox_prepod.Text = FIO;
            tabel_uspevaemosti.comboBox_prepod.Enabled = false;



        }
    }
}
