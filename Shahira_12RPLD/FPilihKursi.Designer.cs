
namespace Shahira_12RPLD
{
    partial class FPilihKursi
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
            this.btnLanjut = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblRute = new System.Windows.Forms.Label();
            this.lblKereta = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLanjut);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 745);
            this.panel2.TabIndex = 9;
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
            this.btnLanjut.Location = new System.Drawing.Point(34, 508);
            this.btnLanjut.Name = "btnLanjut";
            this.btnLanjut.Size = new System.Drawing.Size(286, 50);
            this.btnLanjut.TabIndex = 33;
            this.btnLanjut.Text = "Pilih Kursi";
            this.btnLanjut.Click += new System.EventHandler(this.btnLanjut_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(31)))), ((int)(((byte)(104)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1924, 479);
            this.flowLayoutPanel1.TabIndex = 0;
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
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblBadge);
            this.panelHeader.Controls.Add(this.lblRute);
            this.panelHeader.Controls.Add(this.lblKereta);
            this.panelHeader.Controls.Add(this.panel3);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1924, 425);
            this.panelHeader.TabIndex = 8;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblRute
            // 
            this.lblRute.AutoSize = true;
            this.lblRute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRute.Location = new System.Drawing.Point(28, 174);
            this.lblRute.Name = "lblRute";
            this.lblRute.Size = new System.Drawing.Size(169, 32);
            this.lblRute.TabIndex = 22;
            this.lblRute.Text = "Info Jadwal";
            // 
            // lblKereta
            // 
            this.lblKereta.AutoSize = true;
            this.lblKereta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKereta.Location = new System.Drawing.Point(28, 108);
            this.lblKereta.Name = "lblKereta";
            this.lblKereta.Size = new System.Drawing.Size(169, 32);
            this.lblKereta.TabIndex = 21;
            this.lblKereta.Text = "Info Jadwal";
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadge.Location = new System.Drawing.Point(28, 238);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(169, 32);
            this.lblBadge.TabIndex = 23;
            this.lblBadge.Text = "Info Jadwal";
            // 
            // FPilihKursi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.Name = "FPilihKursi";
            this.Text = "FPilihKursi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPilihKursi_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblKereta;
        private Guna.UI2.WinForms.Guna2Button btnLanjut;
        private System.Windows.Forms.Label lblRute;
        private System.Windows.Forms.Label lblBadge;
    }
}