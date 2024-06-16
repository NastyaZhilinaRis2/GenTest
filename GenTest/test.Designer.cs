
namespace GenTest
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            this.button_dalee = new System.Windows.Forms.Button();
            this.label_nomer_voprosa = new System.Windows.Forms.Label();
            this.panel_okno = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // button_dalee
            // 
            this.button_dalee.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_dalee.BackColor = System.Drawing.Color.RosyBrown;
            this.button_dalee.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_dalee.Font = new System.Drawing.Font("Montserrat", 24F);
            this.button_dalee.Location = new System.Drawing.Point(188, 385);
            this.button_dalee.MaximumSize = new System.Drawing.Size(409, 53);
            this.button_dalee.Name = "button_dalee";
            this.button_dalee.Size = new System.Drawing.Size(409, 53);
            this.button_dalee.TabIndex = 24;
            this.button_dalee.Text = "Далее";
            this.button_dalee.UseVisualStyleBackColor = false;
            this.button_dalee.Click += new System.EventHandler(this.button_dalee_Click);
            // 
            // label_nomer_voprosa
            // 
            this.label_nomer_voprosa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_nomer_voprosa.BackColor = System.Drawing.Color.Transparent;
            this.label_nomer_voprosa.Font = new System.Drawing.Font("Montserrat", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nomer_voprosa.Location = new System.Drawing.Point(0, 0);
            this.label_nomer_voprosa.Name = "label_nomer_voprosa";
            this.label_nomer_voprosa.Size = new System.Drawing.Size(800, 100);
            this.label_nomer_voprosa.TabIndex = 23;
            this.label_nomer_voprosa.Text = "Вопрос №";
            this.label_nomer_voprosa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_okno
            // 
            this.panel_okno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_okno.AutoScroll = true;
            this.panel_okno.ColumnCount = 1;
            this.panel_okno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_okno.Location = new System.Drawing.Point(10, 103);
            this.panel_okno.Name = "panel_okno";
            this.panel_okno.RowCount = 1;
            this.panel_okno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_okno.Size = new System.Drawing.Size(775, 272);
            this.panel_okno.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_okno);
            this.Controls.Add(this.button_dalee);
            this.Controls.Add(this.label_nomer_voprosa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прохождение теста";
            this.Load += new System.EventHandler(this.test_Load);
            this.SizeChanged += new System.EventHandler(this.test_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_dalee;
        private System.Windows.Forms.Label label_nomer_voprosa;
        private System.Windows.Forms.TableLayoutPanel panel_okno;
    }
}