
namespace GenTest
{
    partial class menu_student
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu_student));
            this.button_test = new System.Windows.Forms.Button();
            this.button_balls = new System.Windows.Forms.Button();
            this.панель_контент = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.панель_контент.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_test
            // 
            this.button_test.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_test.BackColor = System.Drawing.Color.RosyBrown;
            this.button_test.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_test.Font = new System.Drawing.Font("Montserrat", 24F);
            this.button_test.Location = new System.Drawing.Point(94, 3);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(608, 53);
            this.button_test.TabIndex = 22;
            this.button_test.Text = "Тестирование";
            this.button_test.UseVisualStyleBackColor = false;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_balls
            // 
            this.button_balls.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_balls.BackColor = System.Drawing.Color.RosyBrown;
            this.button_balls.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_balls.Font = new System.Drawing.Font("Montserrat", 24F);
            this.button_balls.Location = new System.Drawing.Point(92, 62);
            this.button_balls.Name = "button_balls";
            this.button_balls.Size = new System.Drawing.Size(610, 53);
            this.button_balls.TabIndex = 24;
            this.button_balls.Text = "Просмотр баллов";
            this.button_balls.UseVisualStyleBackColor = false;
            this.button_balls.Click += new System.EventHandler(this.button_balls_Click);
            // 
            // панель_контент
            // 
            this.панель_контент.ColumnCount = 1;
            this.панель_контент.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.панель_контент.Controls.Add(this.label1, 0, 0);
            this.панель_контент.Controls.Add(this.panel1, 0, 1);
            this.панель_контент.Dock = System.Windows.Forms.DockStyle.Fill;
            this.панель_контент.Location = new System.Drawing.Point(0, 0);
            this.панель_контент.Name = "панель_контент";
            this.панель_контент.RowCount = 2;
            this.панель_контент.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.панель_контент.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.панель_контент.Size = new System.Drawing.Size(800, 450);
            this.панель_контент.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(794, 225);
            this.label1.TabIndex = 23;
            this.label1.Text = "Меню";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_test);
            this.panel1.Controls.Add(this.button_balls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 219);
            this.panel1.TabIndex = 25;
            // 
            // menu_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.панель_контент);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "menu_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.menu_student_Load);
            this.SizeChanged += new System.EventHandler(this.menu_student_SizeChanged);
            this.панель_контент.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button_balls;
        private System.Windows.Forms.TableLayoutPanel панель_контент;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}