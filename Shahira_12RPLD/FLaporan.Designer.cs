
namespace Shahira_12RPLD
{
    partial class FLaporan
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
            this.btnTampilkan = new Guna.UI2.WinForms.Guna2Button();
            this.dtSampai = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalPendapatan = new System.Windows.Forms.Label();
            this.lblTotalTransaksi = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPemesan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKereta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglBerangkat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKursi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnCetak = new Guna.UI2.WinForms.Guna2Button();
            this.dtDari = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.BorderRadius = 15;
            this.btnTampilkan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTampilkan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTampilkan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTampilkan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTampilkan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnTampilkan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTampilkan.ForeColor = System.Drawing.Color.White;
            this.btnTampilkan.Location = new System.Drawing.Point(823, 295);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(178, 50);
            this.btnTampilkan.TabIndex = 31;
            this.btnTampilkan.Text = "Tampilkan";
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // dtSampai
            // 
            this.dtSampai.BorderColor = System.Drawing.Color.White;
            this.dtSampai.BorderRadius = 15;
            this.dtSampai.Checked = true;
            this.dtSampai.FillColor = System.Drawing.Color.White;
            this.dtSampai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtSampai.ForeColor = System.Drawing.Color.Black;
            this.dtSampai.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtSampai.Location = new System.Drawing.Point(502, 172);
            this.dtSampai.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtSampai.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtSampai.Name = "dtSampai";
            this.dtSampai.Size = new System.Drawing.Size(286, 36);
            this.dtSampai.TabIndex = 30;
            this.dtSampai.Value = new System.DateTime(2026, 8, 28, 9, 10, 27, 337);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(929, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Sampai";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 15;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Location = new System.Drawing.Point(935, 172);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(286, 36);
            this.cmbStatus.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Dari";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotalPendapatan);
            this.panel2.Controls.Add(this.lblTotalTransaksi);
            this.panel2.Controls.Add(this.dgvLaporan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 384);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 786);
            this.panel2.TabIndex = 7;
            // 
            // lblTotalPendapatan
            // 
            this.lblTotalPendapatan.AutoSize = true;
            this.lblTotalPendapatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendapatan.Location = new System.Drawing.Point(1084, 326);
            this.lblTotalPendapatan.Name = "lblTotalPendapatan";
            this.lblTotalPendapatan.Size = new System.Drawing.Size(241, 32);
            this.lblTotalPendapatan.TabIndex = 22;
            this.lblTotalPendapatan.Text = "Total Pendapatan";
            // 
            // lblTotalTransaksi
            // 
            this.lblTotalTransaksi.AutoSize = true;
            this.lblTotalTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransaksi.Location = new System.Drawing.Point(56, 326);
            this.lblTotalTransaksi.Name = "lblTotalTransaksi";
            this.lblTotalTransaksi.Size = new System.Drawing.Size(209, 32);
            this.lblTotalTransaksi.TabIndex = 21;
            this.lblTotalTransaksi.Text = "Total Transaksi";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colTanggal,
            this.colPemesan,
            this.colKereta,
            this.colRute,
            this.colTglBerangkat,
            this.colKursi,
            this.colTotal,
            this.colStatus});
            this.dgvLaporan.Location = new System.Drawing.Point(0, 0);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 62;
            this.dgvLaporan.RowTemplate.Height = 28;
            this.dgvLaporan.Size = new System.Drawing.Size(1924, 294);
            this.dgvLaporan.TabIndex = 0;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No";
            this.colNo.MinimumWidth = 8;
            this.colNo.Name = "colNo";
            this.colNo.Width = 150;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal Pesan";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.Width = 150;
            // 
            // colPemesan
            // 
            this.colPemesan.HeaderText = "Pemesan";
            this.colPemesan.MinimumWidth = 8;
            this.colPemesan.Name = "colPemesan";
            this.colPemesan.Width = 150;
            // 
            // colKereta
            // 
            this.colKereta.HeaderText = "Kereta";
            this.colKereta.MinimumWidth = 8;
            this.colKereta.Name = "colKereta";
            this.colKereta.Width = 150;
            // 
            // colRute
            // 
            this.colRute.HeaderText = "Rute";
            this.colRute.MinimumWidth = 8;
            this.colRute.Name = "colRute";
            this.colRute.Width = 150;
            // 
            // colTglBerangkat
            // 
            this.colTglBerangkat.HeaderText = "Tanggal Berangkat";
            this.colTglBerangkat.MinimumWidth = 8;
            this.colTglBerangkat.Name = "colTglBerangkat";
            this.colTglBerangkat.Width = 150;
            // 
            // colKursi
            // 
            this.colKursi.HeaderText = "Kursi";
            this.colKursi.MinimumWidth = 8;
            this.colKursi.Name = "colKursi";
            this.colKursi.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 8;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 150;
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
            this.label8.Size = new System.Drawing.Size(173, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "Laporan";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnCetak);
            this.panelHeader.Controls.Add(this.dtDari);
            this.panelHeader.Controls.Add(this.btnTampilkan);
            this.panelHeader.Controls.Add(this.dtSampai);
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.cmbStatus);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.panel3);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1924, 384);
            this.panelHeader.TabIndex = 6;
            // 
            // btnCetak
            // 
            this.btnCetak.BorderRadius = 15;
            this.btnCetak.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCetak.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCetak.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCetak.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCetak.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(1048, 295);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(178, 50);
            this.btnCetak.TabIndex = 33;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // dtDari
            // 
            this.dtDari.BorderColor = System.Drawing.Color.White;
            this.dtDari.BorderRadius = 15;
            this.dtDari.Checked = true;
            this.dtDari.FillColor = System.Drawing.Color.White;
            this.dtDari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtDari.ForeColor = System.Drawing.Color.Black;
            this.dtDari.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDari.Location = new System.Drawing.Point(73, 172);
            this.dtDari.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDari.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDari.Name = "dtDari";
            this.dtDari.Size = new System.Drawing.Size(286, 36);
            this.dtDari.TabIndex = 32;
            this.dtDari.Value = new System.DateTime(2026, 8, 28, 9, 10, 27, 337);
            // 
            // FLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.Name = "FLaporan";
            this.Text = "FLaporan";
            this.Load += new System.EventHandler(this.FLaporan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTampilkan;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtSampai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalPendapatan;
        private System.Windows.Forms.Label lblTotalTransaksi;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPemesan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKereta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglBerangkat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKursi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Button btnCetak;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDari;
    }
}