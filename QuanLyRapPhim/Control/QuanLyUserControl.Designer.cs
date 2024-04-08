﻿namespace QuanLyRapPhim.Control
{
    partial class QuanLyUserControl
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
            this.userControl = new System.Windows.Forms.TabControl();
            this.userTab = new System.Windows.Forms.TabPage();
            this.editUserBtn = new System.Windows.Forms.Button();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.sdt = new System.Windows.Forms.TextBox();
            this.hoTen = new System.Windows.Forms.TextBox();
            this.diaChi = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.userGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.xoaUserBtn = new System.Windows.Forms.Button();
            this.userControl.SuspendLayout();
            this.userTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // userControl
            // 
            this.userControl.Controls.Add(this.userTab);
            this.userControl.Controls.Add(this.tabPage2);
            this.userControl.Location = new System.Drawing.Point(3, 3);
            this.userControl.Name = "userControl";
            this.userControl.SelectedIndex = 0;
            this.userControl.Size = new System.Drawing.Size(1301, 538);
            this.userControl.TabIndex = 1;
            // 
            // userTab
            // 
            this.userTab.Controls.Add(this.xoaUserBtn);
            this.userTab.Controls.Add(this.editUserBtn);
            this.userTab.Controls.Add(this.addUserBtn);
            this.userTab.Controls.Add(this.label6);
            this.userTab.Controls.Add(this.label5);
            this.userTab.Controls.Add(this.label4);
            this.userTab.Controls.Add(this.label3);
            this.userTab.Controls.Add(this.label2);
            this.userTab.Controls.Add(this.label1);
            this.userTab.Controls.Add(this.roleComboBox);
            this.userTab.Controls.Add(this.sdt);
            this.userTab.Controls.Add(this.hoTen);
            this.userTab.Controls.Add(this.diaChi);
            this.userTab.Controls.Add(this.password);
            this.userTab.Controls.Add(this.username);
            this.userTab.Controls.Add(this.userGrid);
            this.userTab.Location = new System.Drawing.Point(4, 29);
            this.userTab.Name = "userTab";
            this.userTab.Padding = new System.Windows.Forms.Padding(3);
            this.userTab.Size = new System.Drawing.Size(1293, 505);
            this.userTab.TabIndex = 0;
            this.userTab.Text = "Quản lý user";
            this.userTab.UseVisualStyleBackColor = true;
            // 
            // editUserBtn
            // 
            this.editUserBtn.Location = new System.Drawing.Point(432, 339);
            this.editUserBtn.Name = "editUserBtn";
            this.editUserBtn.Size = new System.Drawing.Size(258, 51);
            this.editUserBtn.TabIndex = 14;
            this.editUserBtn.Text = "Sửa";
            this.editUserBtn.UseVisualStyleBackColor = true;
            this.editUserBtn.Click += new System.EventHandler(this.editUserBtn_Click);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(127, 339);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(258, 51);
            this.addUserBtn.TabIndex = 13;
            this.addUserBtn.Text = "Thêm";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vai trò";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sđt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tài khoản";
            // 
            // roleComboBox
            // 
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] {
            "member",
            "admin"});
            this.roleComboBox.Location = new System.Drawing.Point(127, 204);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(165, 28);
            this.roleComboBox.TabIndex = 6;
            this.roleComboBox.Text = "Chọn vai trò";
            // 
            // sdt
            // 
            this.sdt.Location = new System.Drawing.Point(127, 172);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(165, 26);
            this.sdt.TabIndex = 5;
            // 
            // hoTen
            // 
            this.hoTen.Location = new System.Drawing.Point(127, 108);
            this.hoTen.Name = "hoTen";
            this.hoTen.Size = new System.Drawing.Size(165, 26);
            this.hoTen.TabIndex = 4;
            // 
            // diaChi
            // 
            this.diaChi.Location = new System.Drawing.Point(127, 140);
            this.diaChi.Name = "diaChi";
            this.diaChi.Size = new System.Drawing.Size(165, 26);
            this.diaChi.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(127, 76);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(165, 26);
            this.password.TabIndex = 2;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(127, 41);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(165, 26);
            this.username.TabIndex = 1;
            // 
            // userGrid
            // 
            this.userGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGrid.Location = new System.Drawing.Point(496, 33);
            this.userGrid.Name = "userGrid";
            this.userGrid.RowHeadersWidth = 62;
            this.userGrid.RowTemplate.Height = 28;
            this.userGrid.Size = new System.Drawing.Size(725, 236);
            this.userGrid.TabIndex = 0;
            this.userGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userGrid_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1293, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // xoaUserBtn
            // 
            this.xoaUserBtn.Location = new System.Drawing.Point(734, 339);
            this.xoaUserBtn.Name = "xoaUserBtn";
            this.xoaUserBtn.Size = new System.Drawing.Size(258, 51);
            this.xoaUserBtn.TabIndex = 15;
            this.xoaUserBtn.Text = "Xóa";
            this.xoaUserBtn.UseVisualStyleBackColor = true;
            this.xoaUserBtn.Click += new System.EventHandler(this.xoaUserBtn_Click);
            // 
            // QuanLyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControl);
            this.Name = "QuanLyUserControl";
            this.Size = new System.Drawing.Size(1307, 544);
            this.Load += new System.EventHandler(this.QuanLyUserControl_Load);
            this.userControl.ResumeLayout(false);
            this.userTab.ResumeLayout(false);
            this.userTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl userControl;
        private System.Windows.Forms.TabPage userTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView userGrid;
        private System.Windows.Forms.TextBox sdt;
        private System.Windows.Forms.TextBox hoTen;
        private System.Windows.Forms.TextBox diaChi;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.Button editUserBtn;
        private System.Windows.Forms.Button xoaUserBtn;
    }
}
