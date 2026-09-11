
namespace Shahira_12RPLD
{
    partial class FDataPemesanan
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDPemesanan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStatus = new Guna.UI2.WinForms.Guna2Button();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.colPemesan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKereta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDPemesanan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDPemesanan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 899);
            this.panel2.TabIndex = 9;
            // 
            // dgvDPemesanan
            // 
            this.dgvDPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDPemesanan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPemesan,
            this.colKereta,
            this.colJumlah,
            this.colTotal,
            this.colStatus,
            this.colAksi});
            this.dgvDPemesanan.Location = new System.Drawing.Point(0, 0);
            this.dgvDPemesanan.Name = "dgvDPemesanan";
            this.dgvDPemesanan.RowHeadersWidth = 62;
            this.dgvDPemesanan.RowTemplate.Height = 28;
            this.dgvDPemesanan.Size = new System.Drawing.Size(1924, 469);
            this.dgvDPemesanan.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStatus);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 271);
            this.panel1.TabIndex = 8;
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
            this.label8.Size = new System.Drawing.Size(341, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "Data Pemesanan";
            // 
            // btnStatus
            // 
            this.btnStatus.BorderRadius = 15;
            this.btnStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.btnStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.Location = new System.Drawing.Point(409, 147);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(286, 50);
            this.btnStatus.TabIndex = 38;
            this.btnStatus.Text = "Simpan Status";
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
            this.cmbStatus.Location = new System.Drawing.Point(36, 157);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(286, 36);
            this.cmbStatus.TabIndex = 37;
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
            // colJumlah
            // 
            this.colJumlah.HeaderText = "Jumlah";
            this.colJumlah.MinimumWidth = 8;
            this.colJumlah.Name = "colJumlah";
            this.colJumlah.Width = 150;
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
            // colAksi
            // 
            this.colAksi.HeaderText = "Aksi";
            this.colAksi.MinimumWidth = 8;
            this.colAksi.Name = "colAksi";
            this.colAksi.Width = 150;
            // 
            // FDataPemesanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FDataPemesanan";
            this.Text = "FDataPemesanan";
            this.Load += new System.EventHandler(this.FDataPemesanan_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDPemesanan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDPemesanan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPemesan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKereta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAksi;
    }
}