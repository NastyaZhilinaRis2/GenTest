
namespace GenTest
{
    partial class menu_administraciya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu_administraciya));
            this.панель_контент = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_spisokTest = new System.Windows.Forms.Button();
            this.панель_контент.SuspendLayout();
            this.SuspendLayout();
            // 
            // панель_контент
            // 
            this.панель_контент.BackColor = System.Drawing.Color.MistyRose;
            this.панель_контент.ColumnCount = 1;
            this.панель_контент.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.панель_контент.Controls.Add(this.label1, 0, 0);
            this.панель_контент.Controls.Add(this.button_spisokTest, 0, 1);
            this.панель_контент.Dock = System.Windows.Forms.DockStyle.Fill;
            this.панель_контент.Location = new System.Drawing.Point(0, 0);
            this.панель_контент.Name = "панель_контент";
            this.панель_контент.RowCount = 2;
            this.панель_контент.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.панель_контент.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.панель_контент.Size = new System.Drawing.Size(800, 450);
            this.панель_контент.TabIndex = 26;
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
            // button_spisokTest
            // 
            this.button_spisokTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_spisokTest.BackColor = System.Drawing.Color.RosyBrown;
            this.button_spisokTest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_spisokTest.Font = new System.Drawing.Font("Montserrat", 24F);
            this.button_spisokTest.Location = new System.Drawing.Point(96, 228);
            this.button_spisokTest.Name = "button_spisokTest";
            this.button_spisokTest.Size = new System.Drawing.Size(608, 53);
            this.button_spisokTest.TabIndex = 22;
            this.button_spisokTest.Text = "Табель успеваемости";
            this.button_spisokTest.UseVisualStyleBackColor = false;
            this.button_spisokTest.Click += new System.EventHandler(this.button_spisokTest_Click);
            // 
            // menu_administraciya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.панель_контент);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "menu_administraciya";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.menu_administraciya_Load);
            this.SizeChanged += new System.EventHandler(this.menu_administraciya_SizeChanged);
            this.панель_контент.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel панель_контент;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_spisokTest;
    }
}