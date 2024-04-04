namespace QuanLyRapPhim.Control
{
    partial class QuanLyPhimControl
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
            this.themPhimControl = new System.Windows.Forms.TabControl();
            this.themPhimTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.themPhimControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // themPhimControl
            // 
            this.themPhimControl.Controls.Add(this.themPhimTab);
            this.themPhimControl.Controls.Add(this.tabPage2);
            this.themPhimControl.Location = new System.Drawing.Point(3, 3);
            this.themPhimControl.Name = "themPhimControl";
            this.themPhimControl.SelectedIndex = 0;
            this.themPhimControl.Size = new System.Drawing.Size(1301, 538);
            this.themPhimControl.TabIndex = 0;
            // 
            // themPhimTab
            // 
            this.themPhimTab.Location = new System.Drawing.Point(4, 29);
            this.themPhimTab.Name = "themPhimTab";
            this.themPhimTab.Padding = new System.Windows.Forms.Padding(3);
            this.themPhimTab.Size = new System.Drawing.Size(1293, 505);
            this.themPhimTab.TabIndex = 0;
            this.themPhimTab.Text = "Thêm phim";
            this.themPhimTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 67);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // QuanLyPhimControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.themPhimControl);
            this.Name = "QuanLyPhimControl";
            this.Size = new System.Drawing.Size(1307, 544);
            this.themPhimControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl themPhimControl;
        private System.Windows.Forms.TabPage themPhimTab;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
