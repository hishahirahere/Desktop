
namespace Shahira_12RPLD
{
    partial class FTPembayaran
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
            this.dgvVerifikasi = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colPemesan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKereta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerifikasi)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVerifikasi
            // 
            this.dgvVerifikasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerifikasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPemesan,
            this.colKereta,
            this.colTotal,
            this.colMetode,
            this.colStatus,
            this.colAksi});
            this.dgvVerifikasi.Location = new System.Drawing.Point(0, 0);
            this.dgvVerifikasi.Name = "dgvVerifikasi";
            this.dgvVerifikasi.RowHeadersWidth = 62;
            this.dgvVerifikasi.RowTemplate.Height = 28;
            this.dgvVerifikasi.Size = new System.Drawing.Size(1924, 469);
            this.dgvVerifikasi.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVerifikasi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 1021);
            this.panel2.TabIndex = 11;
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
            this.label8.Size = new System.Drawing.Size(355, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "Data Pembayaran";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 149);
            this.panel1.TabIndex = 10;
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
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 8;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 150;
            // 
            // colMetode
            // 
            this.colMetode.HeaderText = "Metode";
            this.colMetode.MinimumWidth = 8;
            this.colMetode.Name = "colMetode";
            this.colMetode.Width = 150;
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
            // FTPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FTPembayaran";
            this.Text = "FTPembayaran";
            this.Load += new System.EventHandler(this.FTPembayaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerifikasi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVerifikasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPemesan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKereta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAksi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}