
namespace Shahira_12RPLD
{
    partial class FDetailPesanan
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetailPesanan = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKursi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTutup = new Guna.UI2.WinForms.Guna2Button();
            this.lblPemesan = new System.Windows.Forms.Label();
            this.lblRute = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblJumlahPenumpang = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.lblTanggal);
            this.panelHeader.Controls.Add(this.lblRute);
            this.panelHeader.Controls.Add(this.lblPemesan);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1011, 266);
            this.panelHeader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalHarga);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblJumlahPenumpang);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Controls.Add(this.dgvDetailPesanan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 526);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetailPesanan
            // 
            this.dgvDetailPesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailPesanan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colKursi,
            this.colNama,
            this.colNIK});
            this.dgvDetailPesanan.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetailPesanan.Location = new System.Drawing.Point(0, 0);
            this.dgvDetailPesanan.Name = "dgvDetailPesanan";
            this.dgvDetailPesanan.RowHeadersWidth = 62;
            this.dgvDetailPesanan.RowTemplate.Height = 28;
            this.dgvDetailPesanan.Size = new System.Drawing.Size(1011, 317);
            this.dgvDetailPesanan.TabIndex = 0;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No";
            this.colNo.MinimumWidth = 8;
            this.colNo.Name = "colNo";
            this.colNo.Width = 150;
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
            this.colNama.HeaderText = "Nama";
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
            // btnTutup
            // 
            this.btnTutup.BorderRadius = 15;
            this.btnTutup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTutup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTutup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTutup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTutup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(813, 451);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(165, 58);
            this.btnTutup.TabIndex = 39;
            this.btnTutup.Text = "TUTUP";
            // 
            // lblPemesan
            // 
            this.lblPemesan.AutoSize = true;
            this.lblPemesan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPemesan.ForeColor = System.Drawing.Color.White;
            this.lblPemesan.Location = new System.Drawing.Point(26, 91);
            this.lblPemesan.Name = "lblPemesan";
            this.lblPemesan.Size = new System.Drawing.Size(142, 32);
            this.lblPemesan.TabIndex = 6;
            this.lblPemesan.Text = "Pemesan";
            // 
            // lblRute
            // 
            this.lblRute.AutoSize = true;
            this.lblRute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRute.ForeColor = System.Drawing.Color.White;
            this.lblRute.Location = new System.Drawing.Point(26, 141);
            this.lblRute.Name = "lblRute";
            this.lblRute.Size = new System.Drawing.Size(79, 32);
            this.lblRute.TabIndex = 7;
            this.lblRute.Text = "Rute";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggal.ForeColor = System.Drawing.Color.White;
            this.lblTanggal.Location = new System.Drawing.Point(26, 194);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(79, 32);
            this.lblTanggal.TabIndex = 8;
            this.lblTanggal.Text = "Rute";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "DETAIL PESANAN";
            // 
            // lblJumlahPenumpang
            // 
            this.lblJumlahPenumpang.AutoSize = true;
            this.lblJumlahPenumpang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahPenumpang.ForeColor = System.Drawing.Color.Black;
            this.lblJumlahPenumpang.Location = new System.Drawing.Point(49, 340);
            this.lblJumlahPenumpang.Name = "lblJumlahPenumpang";
            this.lblJumlahPenumpang.Size = new System.Drawing.Size(113, 32);
            this.lblJumlahPenumpang.TabIndex = 40;
            this.lblJumlahPenumpang.Text = "Jumlah";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(49, 397);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 32);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.Text = "Status";
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.ForeColor = System.Drawing.Color.Black;
            this.lblTotalHarga.Location = new System.Drawing.Point(49, 451);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(84, 32);
            this.lblTotalHarga.TabIndex = 42;
            this.lblTotalHarga.Text = "Total";
            // 
            // FDetailPesanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 792);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "FDetailPesanan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FDetailPesanan";
            this.Load += new System.EventHandler(this.FDetailPesanan_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPesanan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetailPesanan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKursi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNIK;
        private Guna.UI2.WinForms.Guna2Button btnTutup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblRute;
        private System.Windows.Forms.Label lblPemesan;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblJumlahPenumpang;
    }
}