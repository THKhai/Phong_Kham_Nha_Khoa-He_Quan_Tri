namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    partial class UpdateCuocHenNhaSi
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
            this.button3 = new System.Windows.Forms.Button();
            this.dangky = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(213, 385);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 35);
            this.button3.TabIndex = 30;
            this.button3.Text = "Hủy";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dangky
            // 
            this.dangky.Location = new System.Drawing.Point(521, 385);
            this.dangky.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dangky.Name = "dangky";
            this.dangky.Size = new System.Drawing.Size(133, 35);
            this.dangky.TabIndex = 28;
            this.dangky.Text = "Cập Nhật";
            this.dangky.UseVisualStyleBackColor = true;
            this.dangky.Click += new System.EventHandler(this.dangky_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Mã Nha sĩ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Thời Gian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mã Bệnh Nhân";
            // 
            // ThoiGian
            // 
            this.ThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ThoiGian.Location = new System.Drawing.Point(272, 212);
            this.ThoiGian.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ThoiGian.Size = new System.Drawing.Size(159, 26);
            this.ThoiGian.TabIndex = 24;
            this.ThoiGian.Value = new System.DateTime(2023, 12, 22, 0, 0, 0, 0);
            this.ThoiGian.ValueChanged += new System.EventHandler(this.ThoiGian_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 59);
            this.label1.TabIndex = 23;
            this.label1.Text = "CuocHenNhaSi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = ".........";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = ".........";
            // 
            // UpdateCuocHenNhaSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dangky);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ThoiGian);
            this.Controls.Add(this.label1);
            this.Name = "UpdateCuocHenNhaSi";
            this.Text = "UpdateCuocHenNhaSi";
            this.Load += new System.EventHandler(this.UpdateCuocHenNhaSi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button dangky;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ThoiGian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}