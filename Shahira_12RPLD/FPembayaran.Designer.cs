
namespace Shahira_12RPLD
{
    partial class FPembayaran
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
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.colKereta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatusBayar = new System.Windows.Forms.Label();
            this.lblNamaFile = new System.Windows.Forms.Label();
            this.picBukti = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTotalBayar = new System.Windows.Forms.Label();
            this.btnBayar = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnPilihBukti = new Guna.UI2.WinForms.Guna2Button();
            this.cmbMetode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKereta,
            this.colRute,
            this.colTanggal,
            this.colJam,
            this.colTotal,
            this.colStatusBayar});
            this.dgvPembayaran.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPembayaran.Location = new System.Drawing.Point(0, 0);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.RowHeadersWidth = 62;
            this.dgvPembayaran.RowTemplate.Height = 28;
            this.dgvPembayaran.Size = new System.Drawing.Size(1924, 342);
            this.dgvPembayaran.TabIndex = 0;
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
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.Width = 150;
            // 
            // colJam
            // 
            this.colJam.HeaderText = "Jam";
            this.colJam.MinimumWidth = 8;
            this.colJam.Name = "colJam";
            this.colJam.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 8;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 150;
            // 
            // colStatusBayar
            // 
            this.colStatusBayar.HeaderText = "Status Bayar";
            this.colStatusBayar.MinimumWidth = 8;
            this.colStatusBayar.Name = "colStatusBayar";
            this.colStatusBayar.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblStatusBayar);
            this.panel2.Controls.Add(this.lblNamaFile);
            this.panel2.Controls.Add(this.picBukti);
            this.panel2.Controls.Add(this.lblTotalBayar);
            this.panel2.Controls.Add(this.btnBayar);
            this.panel2.Controls.Add(this.dgvPembayaran);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 925);
            this.panel2.TabIndex = 9;
            // 
            // lblStatusBayar
            // 
            this.lblStatusBayar.AutoSize = true;
            this.lblStatusBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBayar.Location = new System.Drawing.Point(390, 586);
            this.lblStatusBayar.Name = "lblStatusBayar";
            this.lblStatusBayar.Size = new System.Drawing.Size(79, 32);
            this.lblStatusBayar.TabIndex = 36;
            this.lblStatusBayar.Text = "Total";
            // 
            // lblNamaFile
            // 
            this.lblNamaFile.AutoSize = true;
            this.lblNamaFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaFile.Location = new System.Drawing.Point(390, 447);
            this.lblNamaFile.Name = "lblNamaFile";
            this.lblNamaFile.Size = new System.Drawing.Size(79, 32);
            this.lblNamaFile.TabIndex = 35;
            this.lblNamaFile.Text = "Total";
            // 
            // picBukti
            // 
            this.picBukti.ImageRotate = 0F;
            this.picBukti.Location = new System.Drawing.Point(36, 386);
            this.picBukti.Name = "picBukti";
            this.picBukti.Size = new System.Drawing.Size(300, 267);
            this.picBukti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBukti.TabIndex = 34;
            this.picBukti.TabStop = false;
            // 
            // lblTotalBayar
            // 
            this.lblTotalBayar.AutoSize = true;
            this.lblTotalBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBayar.Location = new System.Drawing.Point(390, 515);
            this.lblTotalBayar.Name = "lblTotalBayar";
            this.lblTotalBayar.Size = new System.Drawing.Size(79, 32);
            this.lblTotalBayar.TabIndex = 33;
            this.lblTotalBayar.Text = "Total";
            // 
            // btnBayar
            // 
            this.btnBayar.BorderRadius = 15;
            this.btnBayar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBayar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBayar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBayar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBayar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnBayar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBayar.ForeColor = System.Drawing.Color.White;
            this.btnBayar.Location = new System.Drawing.Point(47, 685);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(286, 50);
            this.btnBayar.TabIndex = 32;
            this.btnBayar.Text = "Bayar Sekarang";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnPilihBukti);
            this.panelHeader.Controls.Add(this.cmbMetode);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.panel3);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1924, 245);
            this.panelHeader.TabIndex = 8;
            // 
            // btnPilihBukti
            // 
            this.btnPilihBukti.BorderRadius = 15;
            this.btnPilihBukti.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPilihBukti.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPilihBukti.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPilihBukti.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPilihBukti.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnPilihBukti.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPilihBukti.ForeColor = System.Drawing.Color.White;
            this.btnPilihBukti.Location = new System.Drawing.Point(724, 142);
            this.btnPilihBukti.Name = "btnPilihBukti";
            this.btnPilihBukti.Size = new System.Drawing.Size(286, 50);
            this.btnPilihBukti.TabIndex = 36;
            this.btnPilihBukti.Text = "Bukti Transfer";
            // 
            // cmbMetode
            // 
            this.cmbMetode.BackColor = System.Drawing.Color.Transparent;
            this.cmbMetode.BorderRadius = 15;
            this.cmbMetode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMetode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMetode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMetode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMetode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMetode.ItemHeight = 30;
            this.cmbMetode.Location = new System.Drawing.Point(351, 152);
            this.cmbMetode.Name = "cmbMetode";
            this.cmbMetode.Size = new System.Drawing.Size(286, 36);
            this.cmbMetode.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 32);
            this.label1.TabIndex = 34;
            this.label1.Text = "Metode Pembayaran";
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
            this.label8.Size = new System.Drawing.Size(255, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pembayaran";
            // 
            // FPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.Name = "FPembayaran";
            this.Text = "FPembayaran";
            this.Load += new System.EventHandler(this.FPembayaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalBayar;
        private Guna.UI2.WinForms.Guna2Button btnBayar;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMetode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKereta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusBayar;
        private Guna.UI2.WinForms.Guna2PictureBox picBukti;
        private Guna.UI2.WinForms.Guna2Button btnPilihBukti;
        private System.Windows.Forms.Label lblStatusBayar;
        private System.Windows.Forms.Label lblNamaFile;
    }
}