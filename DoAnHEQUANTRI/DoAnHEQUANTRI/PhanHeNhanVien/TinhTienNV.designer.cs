namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    partial class TinhTienNV
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.quanLyPhongKhamNhaKhoa_HQTDataSet = new DoAnHEQUANTRI.QuanLyPhongKhamNhaKhoa_HQTDataSet();
            this.quanLyPhongKhamNhaKhoaHQTDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamNhaKhoa_HQTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamNhaKhoaHQTDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số điện thoại";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thành tiền";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quanLyPhongKhamNhaKhoa_HQTDataSet
            // 
            this.quanLyPhongKhamNhaKhoa_HQTDataSet.DataSetName = "QuanLyPhongKhamNhaKhoa_HQTDataSet";
            this.quanLyPhongKhamNhaKhoa_HQTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyPhongKhamNhaKhoaHQTDataSetBindingSource
            // 
            this.quanLyPhongKhamNhaKhoaHQTDataSetBindingSource.DataSource = this.quanLyPhongKhamNhaKhoa_HQTDataSet;
            this.quanLyPhongKhamNhaKhoaHQTDataSetBindingSource.Position = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng tiền ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 247);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 22);
            this.textBox2.TabIndex = 4;
            // 
            // TinhTienNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "TinhTienNV";
            this.Text = "TinhTienNV";
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamNhaKhoa_HQTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamNhaKhoaHQTDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource quanLyPhongKhamNhaKhoaHQTDataSetBindingSource;
        private QuanLyPhongKhamNhaKhoa_HQTDataSet quanLyPhongKhamNhaKhoa_HQTDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}