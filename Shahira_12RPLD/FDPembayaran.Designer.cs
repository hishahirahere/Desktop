
namespace Shahira_12RPLD
{
    partial class FDPembayaran
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
            this.panelDetail = new System.Windows.Forms.Panel();
            this.lblMetodeDetail = new System.Windows.Forms.Label();
            this.lblTotalDetail = new System.Windows.Forms.Label();
            this.lblPemesanDetail = new System.Windows.Forms.Label();
            this.btnTerima = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picBukti = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnTolak = new Guna.UI2.WinForms.Guna2Button();
            this.panelDetail.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.btnTolak);
            this.panelDetail.Controls.Add(this.picBukti);
            this.panelDetail.Controls.Add(this.lblMetodeDetail);
            this.panelDetail.Controls.Add(this.lblTotalDetail);
            this.panelDetail.Controls.Add(this.lblPemesanDetail);
            this.panelDetail.Controls.Add(this.btnTerima);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 126);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1004, 418);
            this.panelDetail.TabIndex = 3;
            // 
            // lblMetodeDetail
            // 
            this.lblMetodeDetail.AutoSize = true;
            this.lblMetodeDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodeDetail.ForeColor = System.Drawing.Color.Black;
            this.lblMetodeDetail.Location = new System.Drawing.Point(368, 161);
            this.lblMetodeDetail.Name = "lblMetodeDetail";
            this.lblMetodeDetail.Size = new System.Drawing.Size(116, 32);
            this.lblMetodeDetail.TabIndex = 42;
            this.lblMetodeDetail.Text = "Metode";
            // 
            // lblTotalDetail
            // 
            this.lblTotalDetail.AutoSize = true;
            this.lblTotalDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDetail.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDetail.Location = new System.Drawing.Point(368, 107);
            this.lblTotalDetail.Name = "lblTotalDetail";
            this.lblTotalDetail.Size = new System.Drawing.Size(84, 32);
            this.lblTotalDetail.TabIndex = 41;
            this.lblTotalDetail.Text = "Total";
            // 
            // lblPemesanDetail
            // 
            this.lblPemesanDetail.AutoSize = true;
            this.lblPemesanDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPemesanDetail.ForeColor = System.Drawing.Color.Black;
            this.lblPemesanDetail.Location = new System.Drawing.Point(368, 50);
            this.lblPemesanDetail.Name = "lblPemesanDetail";
            this.lblPemesanDetail.Size = new System.Drawing.Size(142, 32);
            this.lblPemesanDetail.TabIndex = 40;
            this.lblPemesanDetail.Text = "Pemesan";
            // 
            // btnTerima
            // 
            this.btnTerima.BorderRadius = 15;
            this.btnTerima.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTerima.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTerima.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTerima.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTerima.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTerima.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTerima.ForeColor = System.Drawing.Color.White;
            this.btnTerima.Location = new System.Drawing.Point(374, 242);
            this.btnTerima.Name = "btnTerima";
            this.btnTerima.Size = new System.Drawing.Size(165, 58);
            this.btnTerima.TabIndex = 39;
            this.btnTerima.Text = "TERIMA";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1004, 126);
            this.panelHeader.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "BUKTI PEMBAYARAN";
            // 
            // picBukti
            // 
            this.picBukti.ImageRotate = 0F;
            this.picBukti.Location = new System.Drawing.Point(32, 46);
            this.picBukti.Name = "picBukti";
            this.picBukti.Size = new System.Drawing.Size(300, 267);
            this.picBukti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBukti.TabIndex = 43;
            this.picBukti.TabStop = false;
            // 
            // btnTolak
            // 
            this.btnTolak.BorderRadius = 15;
            this.btnTolak.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTolak.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTolak.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTolak.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTolak.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnTolak.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTolak.ForeColor = System.Drawing.Color.White;
            this.btnTolak.Location = new System.Drawing.Point(557, 242);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(165, 58);
            this.btnTolak.TabIndex = 44;
            this.btnTolak.Text = "TOLAK";
            // 
            // FDPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 544);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Name = "FDPembayaran";
            this.Text = "FDPembayaran";
            this.Load += new System.EventHandler(this.FDPembayaran_Load);
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblMetodeDetail;
        private System.Windows.Forms.Label lblTotalDetail;
        private System.Windows.Forms.Label lblPemesanDetail;
        private Guna.UI2.WinForms.Guna2Button btnTerima;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox picBukti;
        private Guna.UI2.WinForms.Guna2Button btnTolak;
    }
}