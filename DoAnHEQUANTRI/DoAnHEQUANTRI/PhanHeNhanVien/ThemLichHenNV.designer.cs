namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    partial class ThemLichHenNV
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ThoiGian = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.dangky = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Bệnh Nhân";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(160, 228);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Mã Nha sĩ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Thời Gian";
            // 
            // ThoiGian
            // 
            this.ThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ThoiGian.Location = new System.Drawing.Point(160, 176);
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ThoiGian.Size = new System.Drawing.Size(142, 22);
            this.ThoiGian.TabIndex = 23;
            this.ThoiGian.Value = new System.DateTime(2023, 12, 22, 0, 0, 0, 0);
            this.ThoiGian.ValueChanged += new System.EventHandler(this.ThoiGian_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(58, 324);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 28);
            this.button3.TabIndex = 28;
            this.button3.Text = "Hủy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dangky
            // 
            this.dangky.Location = new System.Drawing.Point(332, 324);
            this.dangky.Name = "dangky";
            this.dangky.Size = new System.Drawing.Size(118, 28);
            this.dangky.TabIndex = 27;
            this.dangky.Text = "Đăng ký";
            this.dangky.UseVisualStyleBackColor = true;
            this.dangky.Click += new System.EventHandler(this.dangky_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ThemLichHenNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dangky);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ThoiGian);
            this.Controls.Add(this.label1);
            this.Name = "ThemLichHenNV";
            this.Text = "ThemLichHenNV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ThoiGian;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button dangky;
        private System.Windows.Forms.TextBox textBox1;
    }
}