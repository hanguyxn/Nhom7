namespace QuanLyRapPhim.Control
{
    partial class BanVeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ghePanel = new System.Windows.Forms.Panel();
            this.lichChieuComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.testLabel = new System.Windows.Forms.Label();
            this.giaVeLabel = new System.Windows.Forms.Label();
            this.phimChieuLabel = new System.Windows.Forms.Label();
            this.phongChieuLabel = new System.Windows.Forms.Label();
            this.thanhToanBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(585, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 27);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Màn hình chiếu";
            // 
            // ghePanel
            // 
            this.ghePanel.BackColor = System.Drawing.SystemColors.Control;
            this.ghePanel.Location = new System.Drawing.Point(432, 42);
            this.ghePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ghePanel.Name = "ghePanel";
            this.ghePanel.Size = new System.Drawing.Size(825, 434);
            this.ghePanel.TabIndex = 1;
            // 
            // lichChieuComboBox
            // 
            this.lichChieuComboBox.FormattingEnabled = true;
            this.lichChieuComboBox.Location = new System.Drawing.Point(40, 42);
            this.lichChieuComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.lichChieuComboBox.Name = "lichChieuComboBox";
            this.lichChieuComboBox.Size = new System.Drawing.Size(275, 21);
            this.lichChieuComboBox.TabIndex = 2;
            this.lichChieuComboBox.SelectedIndexChanged += new System.EventHandler(this.lichChieuComboBox_CellCLick);
            this.lichChieuComboBox.Enter += new System.EventHandler(this.BanVeControl_Load);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.testLabel);
            this.panel2.Controls.Add(this.giaVeLabel);
            this.panel2.Controls.Add(this.phimChieuLabel);
            this.panel2.Controls.Add(this.phongChieuLabel);
            this.panel2.Location = new System.Drawing.Point(40, 88);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 252);
            this.panel2.TabIndex = 5;
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(19, 115);
            this.testLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(0, 13);
            this.testLabel.TabIndex = 3;
            // 
            // giaVeLabel
            // 
            this.giaVeLabel.AutoSize = true;
            this.giaVeLabel.Location = new System.Drawing.Point(19, 81);
            this.giaVeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.giaVeLabel.Name = "giaVeLabel";
            this.giaVeLabel.Size = new System.Drawing.Size(41, 13);
            this.giaVeLabel.TabIndex = 2;
            this.giaVeLabel.Text = "Giá vé:";
            // 
            // phimChieuLabel
            // 
            this.phimChieuLabel.AutoSize = true;
            this.phimChieuLabel.Location = new System.Drawing.Point(19, 54);
            this.phimChieuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phimChieuLabel.Name = "phimChieuLabel";
            this.phimChieuLabel.Size = new System.Drawing.Size(33, 13);
            this.phimChieuLabel.TabIndex = 1;
            this.phimChieuLabel.Text = "Phim:";
            // 
            // phongChieuLabel
            // 
            this.phongChieuLabel.AutoSize = true;
            this.phongChieuLabel.Location = new System.Drawing.Point(19, 25);
            this.phongChieuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phongChieuLabel.Name = "phongChieuLabel";
            this.phongChieuLabel.Size = new System.Drawing.Size(41, 13);
            this.phongChieuLabel.TabIndex = 0;
            this.phongChieuLabel.Text = "Phòng:";
            // 
            // thanhToanBtn
            // 
            this.thanhToanBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.thanhToanBtn.Image = global::QuanLyRapPhim.Properties.Resources.icons8_cash_20;
            this.thanhToanBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thanhToanBtn.Location = new System.Drawing.Point(193, 375);
            this.thanhToanBtn.Margin = new System.Windows.Forms.Padding(2);
            this.thanhToanBtn.Name = "thanhToanBtn";
            this.thanhToanBtn.Padding = new System.Windows.Forms.Padding(3);
            this.thanhToanBtn.Size = new System.Drawing.Size(122, 39);
            this.thanhToanBtn.TabIndex = 0;
            this.thanhToanBtn.Text = "Thanh toán";
            this.thanhToanBtn.UseVisualStyleBackColor = false;
            this.thanhToanBtn.Click += new System.EventHandler(this.thanhToanBtn_Click);
            // 
            // BanVeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.thanhToanBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lichChieuComboBox);
            this.Controls.Add(this.ghePanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BanVeControl";
            this.Size = new System.Drawing.Size(1285, 538);
            this.Load += new System.EventHandler(this.BanVeControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ghePanel;
        private System.Windows.Forms.ComboBox lichChieuComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label phongChieuLabel;
        private System.Windows.Forms.Label phimChieuLabel;
        private System.Windows.Forms.Label giaVeLabel;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.Button thanhToanBtn;
    }
}
