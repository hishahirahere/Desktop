
namespace Shahira_12RPLD
{
    partial class FPenumpang
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
            this.btnSelanjutnya = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPenumpang = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRingkasan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdKursi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKursi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenumpang)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelanjutnya
            // 
            this.btnSelanjutnya.BorderRadius = 15;
            this.btnSelanjutnya.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelanjutnya.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelanjutnya.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelanjutnya.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelanjutnya.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnSelanjutnya.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelanjutnya.ForeColor = System.Drawing.Color.White;
            this.btnSelanjutnya.Location = new System.Drawing.Point(56, 366);
            this.btnSelanjutnya.Name = "btnSelanjutnya";
            this.btnSelanjutnya.Size = new System.Drawing.Size(286, 50);
            this.btnSelanjutnya.TabIndex = 32;
            this.btnSelanjutnya.Text = "Selanjutnya";
            this.btnSelanjutnya.Click += new System.EventHandler(this.btnSelanjutnya_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 46);
            this.label1.TabIndex = 20;
            this.label1.Text = "DATA PENUMPANG";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelanjutnya);
            this.panel2.Controls.Add(this.dgvPenumpang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 716);
            this.panel2.TabIndex = 7;
            // 
            // dgvPenumpang
            // 
            this.dgvPenumpang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenumpang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colIdKursi,
            this.colKursi,
            this.colNama,
            this.colNIK});
            this.dgvPenumpang.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPenumpang.Location = new System.Drawing.Point(0, 0);
            this.dgvPenumpang.Name = "dgvPenumpang";
            this.dgvPenumpang.RowHeadersWidth = 62;
            this.dgvPenumpang.RowTemplate.Height = 28;
            this.dgvPenumpang.Size = new System.Drawing.Size(1924, 342);
            this.dgvPenumpang.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRingkasan);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 454);
            this.panel1.TabIndex = 6;
            // 
            // lblRingkasan
            // 
            this.lblRingkasan.AutoSize = true;
            this.lblRingkasan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRingkasan.Location = new System.Drawing.Point(50, 245);
            this.lblRingkasan.Name = "lblRingkasan";
            this.lblRingkasan.Size = new System.Drawing.Size(492, 32);
            this.lblRingkasan.TabIndex = 27;
            this.lblRingkasan.Text = "Isi data penumpang untuk setiap kursi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(492, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "Isi data penumpang untuk setiap kursi";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 88);
            this.panel3.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(65, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pesan Tiket";
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No";
            this.colNo.MinimumWidth = 8;
            this.colNo.Name = "colNo";
            this.colNo.Width = 150;
            // 
            // colIdKursi
            // 
            this.colIdKursi.HeaderText = "idkursi";
            this.colIdKursi.MinimumWidth = 8;
            this.colIdKursi.Name = "colIdKursi";
            this.colIdKursi.Visible = false;
            this.colIdKursi.Width = 150;
            // 
            // colKursi
            // 
            this.colKursi.HeaderText = "Kursi";
            this.colKursi.MinimumWidth = 8;
            this.colKursi.Name = "colKursi";
            this.colKursi.Width = 150;
            // 
            // colNama
            // 
            this.colNama.HeaderText = "Nama Penumpang";
            this.colNama.MinimumWidth = 8;
            this.colNama.Name = "colNama";
            this.colNama.Width = 150;
            // 
            // colNIK
            // 
            this.colNIK.HeaderText = "NIK";
            this.colNIK.MinimumWidth = 8;
            this.colNIK.Name = "colNIK";
            this.colNIK.Width = 150;
            // 
            // FPenumpang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FPenumpang";
            this.Text = "FPenumpang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPenumpang_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenumpang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSelanjutnya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPenumpang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRingkasan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdKursi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKursi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNIK;
    }
}