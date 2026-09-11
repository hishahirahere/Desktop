
namespace Shahira_12RPLD
{
    partial class FCariJadwal
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
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAsal = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTujuan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTanggal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnCari = new Guna.UI2.WinForms.Guna2Button();
            this.btnPilihJadwal = new Guna.UI2.WinForms.Guna2Button();
            this.colIdJadwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // dgvJadwal
            // 
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdJadwal,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column9});
            this.dgvJadwal.Location = new System.Drawing.Point(0, 0);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 28;
            this.dgvJadwal.Size = new System.Drawing.Size(1924, 294);
            this.dgvJadwal.TabIndex = 0;
            this.dgvJadwal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwal_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPilihJadwal);
            this.panel2.Controls.Add(this.dgvJadwal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 731);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCari);
            this.panel1.Controls.Add(this.dtTanggal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbTujuan);
            this.panel1.Controls.Add(this.cmbAsal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 439);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Stasiun Awal";
            // 
            // cmbAsal
            // 
            this.cmbAsal.BackColor = System.Drawing.Color.Transparent;
            this.cmbAsal.BorderRadius = 15;
            this.cmbAsal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAsal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAsal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAsal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAsal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAsal.ItemHeight = 30;
            this.cmbAsal.Location = new System.Drawing.Point(73, 172);
            this.cmbAsal.Name = "cmbAsal";
            this.cmbAsal.Size = new System.Drawing.Size(286, 36);
            this.cmbAsal.TabIndex = 21;
            // 
            // cmbTujuan
            // 
            this.cmbTujuan.BackColor = System.Drawing.Color.Transparent;
            this.cmbTujuan.BorderRadius = 15;
            this.cmbTujuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTujuan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTujuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTujuan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTujuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTujuan.ItemHeight = 30;
            this.cmbTujuan.Location = new System.Drawing.Point(502, 172);
            this.cmbTujuan.Name = "cmbTujuan";
            this.cmbTujuan.Size = new System.Drawing.Size(286, 36);
            this.cmbTujuan.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Stasiun Tujuan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(929, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tanggal";
            // 
            // dtTanggal
            // 
            this.dtTanggal.BorderColor = System.Drawing.Color.White;
            this.dtTanggal.BorderRadius = 15;
            this.dtTanggal.Checked = true;
            this.dtTanggal.FillColor = System.Drawing.Color.White;
            this.dtTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTanggal.ForeColor = System.Drawing.Color.Black;
            this.dtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtTanggal.Location = new System.Drawing.Point(935, 172);
            this.dtTanggal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTanggal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTanggal.Name = "dtTanggal";
            this.dtTanggal.Size = new System.Drawing.Size(286, 36);
            this.dtTanggal.TabIndex = 30;
            this.dtTanggal.Value = new System.DateTime(2026, 8, 28, 9, 10, 27, 337);
            // 
            // btnCari
            // 
            this.btnCari.BorderRadius = 15;
            this.btnCari.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCari.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCari.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCari.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCari.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCari.ForeColor = System.Drawing.Color.White;
            this.btnCari.Location = new System.Drawing.Point(20, 363);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(286, 50);
            this.btnCari.TabIndex = 31;
            this.btnCari.Text = "Cari Jadwal";
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnPilihJadwal
            // 
            this.btnPilihJadwal.BorderRadius = 15;
            this.btnPilihJadwal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPilihJadwal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPilihJadwal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPilihJadwal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPilihJadwal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnPilihJadwal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPilihJadwal.ForeColor = System.Drawing.Color.White;
            this.btnPilihJadwal.Location = new System.Drawing.Point(20, 320);
            this.btnPilihJadwal.Name = "btnPilihJadwal";
            this.btnPilihJadwal.Size = new System.Drawing.Size(286, 50);
            this.btnPilihJadwal.TabIndex = 32;
            this.btnPilihJadwal.Text = "Pilih Jadwal";
            this.btnPilihJadwal.Click += new System.EventHandler(this.btnPilihJadwal_Click);
            // 
            // colIdJadwal
            // 
            this.colIdJadwal.HeaderText = "No";
            this.colIdJadwal.MinimumWidth = 8;
            this.colIdJadwal.Name = "colIdJadwal";
            this.colIdJadwal.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nama Kereta";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Kelas";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Jam Berangkat";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Jam Tiba";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Harga";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Sisa Kursi";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.Width = 150;
            // 
            // FCariJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FCariJadwal";
            this.Text = "FCariJadwal";
            this.Load += new System.EventHandler(this.FCariJadwal_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTujuan;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAsal;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTanggal;
        private Guna.UI2.WinForms.Guna2Button btnCari;
        private Guna.UI2.WinForms.Guna2Button btnPilihJadwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdJadwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}