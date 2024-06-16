
namespace GenTest
{
    partial class Avtorizaciya
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Avtorizaciya));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.button_input = new System.Windows.Forms.Button();
            this.label_registraciya = new System.Windows.Forms.Label();
            this.label_vosstanovleniye = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 155);
            this.label1.TabIndex = 26;
            this.label1.Text = "Авторизация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_password.Font = new System.Drawing.Font("Montserrat", 20F);
            this.textBox_password.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox_password.Location = new System.Drawing.Point(79, 220);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(650, 40);
            this.textBox_password.TabIndex = 23;
            this.textBox_password.Text = "Пароль";
            this.textBox_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox_password_TextChanged);
            this.textBox_password.Enter += new System.EventHandler(this.textBox_password_Enter);
            this.textBox_password.Leave += new System.EventHandler(this.textBox_password_Leave);
            // 
            // textBox_login
            // 
            this.textBox_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_login.Font = new System.Drawing.Font("Montserrat", 20F);
            this.textBox_login.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox_login.Location = new System.Drawing.Point(79, 174);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(650, 40);
            this.textBox_login.TabIndex = 22;
            this.textBox_login.Text = "Логин";
            this.textBox_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_login.TextChanged += new System.EventHandler(this.textBox_login_TextChanged);
            this.textBox_login.Enter += new System.EventHandler(this.textBox_login_Enter);
            this.textBox_login.Leave += new System.EventHandler(this.textBox_login_Leave);
            // 
            // button_input
            // 
            this.button_input.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_input.BackColor = System.Drawing.Color.RosyBrown;
            this.button_input.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_input.Font = new System.Drawing.Font("Montserrat", 24F);
            this.button_input.Location = new System.Drawing.Point(33, 338);
            this.button_input.MinimumSize = new System.Drawing.Size(737, 53);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(737, 53);
            this.button_input.TabIndex = 21;
            this.button_input.Text = "Войти";
            this.button_input.UseVisualStyleBackColor = false;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // label_registraciya
            // 
            this.label_registraciya.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_registraciya.AutoSize = true;
            this.label_registraciya.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_registraciya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_registraciya.ForeColor = System.Drawing.Color.Red;
            this.label_registraciya.Location = new System.Drawing.Point(76, 270);
            this.label_registraciya.Name = "label_registraciya";
            this.label_registraciya.Size = new System.Drawing.Size(221, 15);
            this.label_registraciya.TabIndex = 27;
            this.label_registraciya.Text = "Регистрация (только для студентов)";
            this.label_registraciya.Click += new System.EventHandler(this.label_registraciya_Click);
            // 
            // label_vosstanovleniye
            // 
            this.label_vosstanovleniye.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_vosstanovleniye.AutoSize = true;
            this.label_vosstanovleniye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_vosstanovleniye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_vosstanovleniye.ForeColor = System.Drawing.Color.Blue;
            this.label_vosstanovleniye.Location = new System.Drawing.Point(625, 270);
            this.label_vosstanovleniye.Name = "label_vosstanovleniye";
            this.label_vosstanovleniye.Size = new System.Drawing.Size(104, 15);
            this.label_vosstanovleniye.TabIndex = 28;
            this.label_vosstanovleniye.Text = "Забыли пароль?";
            this.label_vosstanovleniye.Click += new System.EventHandler(this.label_vosstanovleniye_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = global::GenTest.Properties.Resources.глазик;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(734, 229);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackgroundImage = global::GenTest.Properties.Resources.пароль;
            this.pictureBox2.Location = new System.Drawing.Point(33, 220);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackgroundImage = global::GenTest.Properties.Resources.логин1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(33, 174);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // Avtorizaciya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_vosstanovleniye);
            this.Controls.Add(this.label_registraciya);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.button_input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Avtorizaciya";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.SizeChanged += new System.EventHandler(this.Avtorizaciya_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Avtorizaciya_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Label label_registraciya;
        private System.Windows.Forms.Label label_vosstanovleniye;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

