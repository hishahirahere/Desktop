
namespace Shahira_12RPLD
{
    partial class FKonfirmasi
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
            this.btnLanjut = new Guna.UI2.WinForms.Guna2Button();
            this.dgvKonfirmasi = new System.Windows.Forms.DataGridView();
            this.colKursi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpenumpang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKonfirmasi = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.lblJumKursi = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKelas = new System.Windows.Forms.Label();
            this.lblJam = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblRute = new System.Windows.Forms.Label();
            this.lblKereta = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblJudul = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonfirmasi)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLanjut
            // 
            this.btnLanjut.BorderRadius = 15;
            this.btnLanjut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLanjut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLanjut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLanjut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLanjut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnLanjut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLanjut.ForeColor = System.Drawing.Color.White;
            this.btnLanjut.Location = new System.Drawing.Point(1588, 695);
            this.btnLanjut.Name = "btnLanjut";
            this.btnLanjut.Size = new System.Drawing.Size(286, 50);
            this.btnLanjut.TabIndex = 32;
            this.btnLanjut.Text = "Selanjutnya";
            // 
            // dgvKonfirmasi
            // 
            this.dgvKonfirmasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKonfirmasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKursi,
            this.colpenumpang,
            this.colNIK});
            this.dgvKonfirmasi.Location = new System.Drawing.Point(-3, 0);
            this.dgvKonfirmasi.Name = "dgvKonfirmasi";
            this.dgvKonfirmasi.RowHeadersWidth = 62;
            this.dgvKonfirmasi.RowTemplate.Height = 28;
            this.dgvKonfirmasi.Size = new System.Drawing.Size(1924, 283);
            this.dgvKonfirmasi.TabIndex = 0;
            // 
            // colKursi
            // 
            this.colKursi.HeaderText = "Kursi";
            this.colKursi.MinimumWidth = 8;
            this.colKursi.Name = "colKursi";
            this.colKursi.Width = 150;
            // 
            // colpenumpang
            // 
            this.colpenumpang.HeaderText = "Nama Penumpang";
            this.colpenumpang.MinimumWidth = 8;
            this.colpenumpang.Name = "colpenumpang";
            this.colpenumpang.Width = 150;
            // 
            // colNIK
            // 
            this.colNIK.HeaderText = "NIK";
            this.colNIK.MinimumWidth = 8;
            this.colNIK.Name = "colNIK";
            this.colNIK.Width = 150;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(522, 102);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(550, 46);
            this.label.TabIndex = 20;
            this.label.Text = "KONFIRMASI PEMESANAN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnKonfirmasi);
            this.panel2.Controls.Add(this.lblTotalHarga);
            this.panel2.Controls.Add(this.lblJumKursi);
            this.panel2.Controls.Add(this.btnLanjut);
            this.panel2.Controls.Add(this.dgvKonfirmasi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 517);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 653);
            this.panel2.TabIndex = 9;
            // 
            // btnKonfirmasi
            // 
            this.btnKonfirmasi.BorderRadius = 15;
            this.btnKonfirmasi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKonfirmasi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKonfirmasi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKonfirmasi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKonfirmasi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnKonfirmasi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKonfirmasi.ForeColor = System.Drawing.Color.White;
            this.btnKonfirmasi.Location = new System.Drawing.Point(38, 434);
            this.btnKonfirmasi.Name = "btnKonfirmasi";
            this.btnKonfirmasi.Size = new System.Drawing.Size(286, 50);
            this.btnKonfirmasi.TabIndex = 35;
            this.btnKonfirmasi.Text = "Konfirmasi dan Pesan";
            this.btnKonfirmasi.Click += new System.EventHandler(this.btnKonfirmasi_Click);
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.Location = new System.Drawing.Point(32, 373);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(192, 32);
            this.lblTotalHarga.TabIndex = 34;
            this.lblTotalHarga.Text = "Total Harga   :";
            // 
            // lblJumKursi
            // 
            this.lblJumKursi.AutoSize = true;
            this.lblJumKursi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumKursi.Location = new System.Drawing.Point(32, 317);
            this.lblJumKursi.Name = "lblJumKursi";
            this.lblJumKursi.Size = new System.Drawing.Size(194, 32);
            this.lblJumKursi.TabIndex = 33;
            this.lblJumKursi.Text = "Jumlah Kursi :";
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.lblKelas);
            this.panelInfo.Controls.Add(this.lblJam);
            this.panelInfo.Controls.Add(this.lblTanggal);
            this.panelInfo.Controls.Add(this.lblRute);
            this.panelInfo.Controls.Add(this.lblKereta);
            this.panelInfo.Controls.Add(this.label);
            this.panelInfo.Controls.Add(this.panelHeader);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1924, 517);
            this.panelInfo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(608, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 46);
            this.label2.TabIndex = 32;
            this.label2.Text = "DATA PENUMPANG";
            // 
            // lblKelas
            // 
            this.lblKelas.AutoSize = true;
            this.lblKelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKelas.Location = new System.Drawing.Point(32, 388);
            this.lblKelas.Name = "lblKelas";
            this.lblKelas.Size = new System.Drawing.Size(144, 32);
            this.lblKelas.TabIndex = 31;
            this.lblKelas.Text = " Kelas      :";
            // 
            // lblJam
            // 
            this.lblJam.AutoSize = true;
            this.lblJam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJam.Location = new System.Drawing.Point(40, 336);
            this.lblJam.Name = "lblJam";
            this.lblJam.Size = new System.Drawing.Size(139, 32);
            this.lblJam.TabIndex = 30;
            this.lblJam.Text = "Jam         :";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggal.Location = new System.Drawing.Point(38, 278);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(141, 32);
            this.lblTanggal.TabIndex = 29;
            this.lblTanggal.Text = "Tanggal  :";
            // 
            // lblRute
            // 
            this.lblRute.AutoSize = true;
            this.lblRute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRute.Location = new System.Drawing.Point(40, 218);
            this.lblRute.Name = "lblRute";
            this.lblRute.Size = new System.Drawing.Size(139, 32);
            this.lblRute.TabIndex = 28;
            this.lblRute.Text = "Rute        :";
            // 
            // lblKereta
            // 
            this.lblKereta.AutoSize = true;
            this.lblKereta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKereta.Location = new System.Drawing.Point(40, 157);
            this.lblKereta.Name = "lblKereta";
            this.lblKereta.Size = new System.Drawing.Size(142, 32);
            this.lblKereta.TabIndex = 27;
            this.lblKereta.Text = "Kereta     :";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.panelHeader.Controls.Add(this.lblJudul);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1924, 88);
            this.panelHeader.TabIndex = 18;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.White;
            this.lblJudul.Location = new System.Drawing.Point(65, 22);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(241, 46);
            this.lblJudul.TabIndex = 19;
            this.lblJudul.Text = "Pesan Tiket";
            // 
            // FKonfirmasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelInfo);
            this.Name = "FKonfirmasi";
            this.Text = "FKonfirmasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FKonfirmasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonfirmasi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLanjut;
        private System.Windows.Forms.DataGridView dgvKonfirmasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKursi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpenumpang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNIK;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblJumKursi;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKelas;
        private System.Windows.Forms.Label lblJam;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblRute;
        private System.Windows.Forms.Label lblKereta;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblJudul;
        private Guna.UI2.WinForms.Guna2Button btnKonfirmasi;
    }
}