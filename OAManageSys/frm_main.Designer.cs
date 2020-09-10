namespace OAManageSys
{
    partial class frm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.p_top = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.p_left1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // p_top
            // 
            this.p_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_top.Location = new System.Drawing.Point(0, 0);
            this.p_top.Name = "p_top";
            this.p_top.Size = new System.Drawing.Size(939, 88);
            this.p_top.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // p_left1
            // 
            this.p_left1.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_left1.Location = new System.Drawing.Point(0, 88);
            this.p_left1.Name = "p_left1";
            this.p_left1.Size = new System.Drawing.Size(160, 367);
            this.p_left1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(160, 88);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(16, 367);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(328, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 160);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 477);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.p_left1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.p_top);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OA信息化管理中心";
            this.Load += new System.EventHandler(this.frm_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_top;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel p_left1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}