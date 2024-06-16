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
    public partial class menu_administraciya : Form
    {
        public menu_administraciya()
        {
            InitializeComponent();
        }

        private void button_spisokTest_Click(object sender, EventArgs e)
        {
            tabel_uspevaemosti tabelUspevaemosti = new tabel_uspevaemosti();
            tabelUspevaemosti.Show();
            this.Close();
        }

        private void menu_administraciya_Load(object sender, EventArgs e)
        {
            //размер окна (большой или маленький)
            if (Peremennye.min_razmer_okna == false)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void menu_administraciya_SizeChanged(object sender, EventArgs e)
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
