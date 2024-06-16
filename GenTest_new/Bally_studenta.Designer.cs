
namespace GenTest
{
    partial class Bally_studenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bally_studenta));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_teacher = new System.Windows.Forms.ComboBox();
            this.comboBox_predmet = new System.Windows.Forms.ComboBox();
            this.dataGridView_balls = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_balls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 141);
            this.label1.TabIndex = 27;
            this.label1.Text = "Баллы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_teacher
            // 
            this.comboBox_teacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_teacher.Font = new System.Drawing.Font("Montserrat", 20F);
            this.comboBox_teacher.ForeColor = System.Drawing.Color.DarkGray;
            this.comboBox_teacher.FormattingEnabled = true;
            this.comboBox_teacher.Location = new System.Drawing.Point(15, 150);
            this.comboBox_teacher.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_teacher.Name = "comboBox_teacher";
            this.comboBox_teacher.Size = new System.Drawing.Size(860, 45);
            this.comboBox_teacher.TabIndex = 28;
            this.comboBox_teacher.Text = "Преподаватель";
            this.comboBox_teacher.TextChanged += new System.EventHandler(this.comboBox_teacher_TextChanged);
            this.comboBox_teacher.Enter += new System.EventHandler(this.comboBox_teacher_Enter);
            this.comboBox_teacher.Leave += new System.EventHandler(this.comboBox_teacher_Leave);
            // 
            // comboBox_predmet
            // 
            this.comboBox_predmet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_predmet.Font = new System.Drawing.Font("Montserrat", 20F);
            this.comboBox_predmet.ForeColor = System.Drawing.Color.DarkGray;
            this.comboBox_predmet.FormattingEnabled = true;
            this.comboBox_predmet.Location = new System.Drawing.Point(15, 203);
            this.comboBox_predmet.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_predmet.Name = "comboBox_predmet";
            this.comboBox_predmet.Size = new System.Drawing.Size(860, 45);
            this.comboBox_predmet.TabIndex = 29;
            this.comboBox_predmet.Text = "Предмет";
            this.comboBox_predmet.TextChanged += new System.EventHandler(this.comboBox_predmet_TextChanged);
            this.comboBox_predmet.Enter += new System.EventHandler(this.comboBox_predmet_Enter);
            this.comboBox_predmet.Leave += new System.EventHandler(this.comboBox_predmet_Leave);
            // 
            // dataGridView_balls
            // 
            this.dataGridView_balls.AllowUserToAddRows = false;
            this.dataGridView_balls.AllowUserToDeleteRows = false;
            this.dataGridView_balls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_balls.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_balls.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView_balls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_balls.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_balls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_balls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_balls.ColumnHeadersHeight = 50;
            this.dataGridView_balls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_balls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_balls.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_balls.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_balls.EnableHeadersVisualStyles = false;
            this.dataGridView_balls.GridColor = System.Drawing.Color.MistyRose;
            this.dataGridView_balls.Location = new System.Drawing.Point(60, 267);
            this.dataGridView_balls.Margin = new System.Windows.Forms.Padding(60, 15, 60, 3);
            this.dataGridView_balls.Name = "dataGridView_balls";
            this.dataGridView_balls.ReadOnly = true;
            this.dataGridView_balls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_balls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_balls.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_balls.RowHeadersVisible = false;
            this.dataGridView_balls.RowHeadersWidth = 30;
            this.dataGridView_balls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_balls.Size = new System.Drawing.Size(770, 237);
            this.dataGridView_balls.TabIndex = 30;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Тема";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Баллы";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = global::GenTest.Properties.Resources.стрелка;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_balls, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_teacher, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_predmet, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 507);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 141);
            this.panel1.TabIndex = 0;
            // 
            // Bally_studenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(890, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(906, 546);
            this.Name = "Bally_studenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Баллы за пройденные тесты";
            this.Load += new System.EventHandler(this.Bally_studenta_Load);
            this.SizeChanged += new System.EventHandler(this.Bally_studenta_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_balls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_teacher;
        private System.Windows.Forms.ComboBox comboBox_predmet;
        private System.Windows.Forms.DataGridView dataGridView_balls;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}