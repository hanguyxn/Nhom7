namespace QuanLyRapPhim
{
    partial class MainForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.userBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.phimBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleTop = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.DarkBlue;
            this.topPanel.Controls.Add(this.userBtn);
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.phimBtn);
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.titleTop);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1307, 67);
            this.topPanel.TabIndex = 0;
            // 
            // userBtn
            // 
            this.userBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.userBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userBtn.FlatAppearance.BorderSize = 0;
            this.userBtn.Image = global::QuanLyRapPhim.Properties.Resources.icons8_user_20__1_;
            this.userBtn.Location = new System.Drawing.Point(882, 0);
            this.userBtn.Margin = new System.Windows.Forms.Padding(0);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(200, 67);
            this.userBtn.TabIndex = 3;
            this.userBtn.Text = "   User";
            this.userBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.userBtn.UseVisualStyleBackColor = false;
            this.userBtn.Click += new System.EventHandler(this.userBtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Image = global::QuanLyRapPhim.Properties.Resources.icons8_ticket_20;
            this.button2.Location = new System.Drawing.Point(282, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 67);
            this.button2.TabIndex = 5;
            this.button2.Text = "   Bán vé";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = global::QuanLyRapPhim.Properties.Resources.icons8_film_20;
            this.button1.Location = new System.Drawing.Point(482, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 67);
            this.button1.TabIndex = 4;
            this.button1.Text = "   Phim";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // phimBtn
            // 
            this.phimBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.phimBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.phimBtn.FlatAppearance.BorderSize = 0;
            this.phimBtn.Image = global::QuanLyRapPhim.Properties.Resources.icons8_setting_20__1_;
            this.phimBtn.Location = new System.Drawing.Point(682, 0);
            this.phimBtn.Margin = new System.Windows.Forms.Padding(0);
            this.phimBtn.Name = "phimBtn";
            this.phimBtn.Size = new System.Drawing.Size(200, 67);
            this.phimBtn.TabIndex = 2;
            this.phimBtn.Text = "   Quản lý";
            this.phimBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.phimBtn.UseVisualStyleBackColor = false;
            this.phimBtn.Click += new System.EventHandler(this.phimBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyRapPhim.Properties.Resources.icons8_film_48;
            this.pictureBox1.Location = new System.Drawing.Point(26, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // titleTop
            // 
            this.titleTop.AutoSize = true;
            this.titleTop.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTop.ForeColor = System.Drawing.Color.White;
            this.titleTop.Location = new System.Drawing.Point(76, 27);
            this.titleTop.Name = "titleTop";
            this.titleTop.Size = new System.Drawing.Size(124, 18);
            this.titleTop.TabIndex = 0;
            this.titleTop.Text = "Quản lý rạp phim";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 67);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1307, 544);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1307, 611);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý rạp phim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseMainForm);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button phimBtn;
        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}