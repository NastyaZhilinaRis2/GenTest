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
    public partial class menu_student : Form
    {
        public menu_student()
        {
            InitializeComponent();
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            temy_test temy_test = new temy_test();
            if (this.WindowState == FormWindowState.Maximized)
            {
                temy_test.WindowState = FormWindowState.Maximized;
            }
            temy_test.Show();
            this.Close();
        }

        private void button_balls_Click(object sender, EventArgs e)
        {
            Bally_studenta Bally_studenta = new Bally_studenta();
            if (this.WindowState == FormWindowState.Maximized)
            {/*
                Bally_studenta.StartPosition = FormStartPosition.CenterScreen;*/
                Bally_studenta.WindowState = FormWindowState.Maximized;
            }
            Bally_studenta.Show();
            this.Close();
        }

        private void menu_student_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void menu_student_SizeChanged(object sender, EventArgs e)
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
