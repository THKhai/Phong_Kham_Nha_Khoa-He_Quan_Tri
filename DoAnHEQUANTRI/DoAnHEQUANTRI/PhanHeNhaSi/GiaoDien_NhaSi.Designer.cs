namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    partial class GiaoDien_NhaSi
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ChinhSua = new System.Windows.Forms.Button();
            this.Đang_Xuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1083, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm Hồ Sơ Bệnh Nhân";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 342);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1329, 312);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 81);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hồ Sơ Bệnh Nhân";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1083, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Thêm Bệnh Nhân";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 296);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(261, 29);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "MaNV :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "..........";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 661);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 59);
            this.button3.TabIndex = 8;
            this.button3.Text = "Bệnh Nhân";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(168, 660);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 59);
            this.button4.TabIndex = 9;
            this.button4.Text = "Hồ Sơ Bệnh Nhân";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1191, 660);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 59);
            this.button5.TabIndex = 10;
            this.button5.Text = "Cuộc Hẹn Cá Nhân";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1035, 661);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 59);
            this.button6.TabIndex = 11;
            this.button6.Text = "Thêm Cuộc Hẹn";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ChinhSua
            // 
            this.ChinhSua.Location = new System.Drawing.Point(1083, 277);
            this.ChinhSua.Name = "ChinhSua";
            this.ChinhSua.Size = new System.Drawing.Size(258, 59);
            this.ChinhSua.TabIndex = 13;
            this.ChinhSua.Text = "Chỉnh Sửa";
            this.ChinhSua.UseVisualStyleBackColor = true;
            this.ChinhSua.Click += new System.EventHandler(this.ChinhSua_Click);
            // 
            // Đang_Xuat
            // 
            this.Đang_Xuat.Location = new System.Drawing.Point(1200, 9);
            this.Đang_Xuat.Name = "Đang_Xuat";
            this.Đang_Xuat.Size = new System.Drawing.Size(141, 59);
            this.Đang_Xuat.TabIndex = 14;
            this.Đang_Xuat.Text = "Đăng Xuẩt";
            this.Đang_Xuat.UseVisualStyleBackColor = true;
            this.Đang_Xuat.Click += new System.EventHandler(this.Đang_Xuat_Click);
            // 
            // GiaoDien_NhaSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 858);
            this.Controls.Add(this.Đang_Xuat);
            this.Controls.Add(this.ChinhSua);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "GiaoDien_NhaSi";
            this.Text = "Home_NhaSi";
            this.Load += new System.EventHandler(this.GiaoDien_NhaSi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button ChinhSua;
        private System.Windows.Forms.Button Đang_Xuat;
    }
}