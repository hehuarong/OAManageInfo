namespace OAManageSys
{
    partial class frm_login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lb_vession = new DevComponents.DotNetBar.LabelX();
            this.btn_cancel = new DevComponents.DotNetBar.ButtonX();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.tb_pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_uid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(326, 268);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(191, 23);
            this.labelX3.TabIndex = 64;
            this.labelX3.Text = "登录地址：";
            // 
            // lb_vession
            // 
            this.lb_vession.BackColor = System.Drawing.Color.White;
            this.lb_vession.Location = new System.Drawing.Point(523, 268);
            this.lb_vession.Name = "lb_vession";
            this.lb_vession.Size = new System.Drawing.Size(145, 23);
            this.lb_vession.TabIndex = 63;
            this.lb_vession.Text = "版本：";
            // 
            // btn_cancel
            // 
            this.btn_cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancel.Location = new System.Drawing.Point(502, 207);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 62;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ok.Location = new System.Drawing.Point(386, 207);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 61;
            this.btn_ok.Text = "登录";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_pwd
            // 
            // 
            // 
            // 
            this.tb_pwd.Border.Class = "TextBoxBorder";
            this.tb_pwd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_pwd.Location = new System.Drawing.Point(402, 147);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PasswordChar = '*';
            this.tb_pwd.Size = new System.Drawing.Size(193, 33);
            this.tb_pwd.TabIndex = 60;
            this.tb_pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_pwd_KeyDown);
            // 
            // tb_uid
            // 
            // 
            // 
            // 
            this.tb_uid.Border.Class = "TextBoxBorder";
            this.tb_uid.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_uid.Location = new System.Drawing.Point(402, 102);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Size = new System.Drawing.Size(193, 29);
            this.tb_uid.TabIndex = 59;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(306, 157);
            this.labelX2.Name = "labelX2";
            this.labelX2.SingleLineColor = System.Drawing.Color.Empty;
            this.labelX2.Size = new System.Drawing.Size(104, 23);
            this.labelX2.TabIndex = 58;
            this.labelX2.Text = "密  码：";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(306, 107);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 23);
            this.labelX1.TabIndex = 57;
            this.labelX1.Text = "用户名：";
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OAManageSys.Properties.Resources.logininfo;
            this.ClientSize = new System.Drawing.Size(690, 322);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.lb_vession);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_uid);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OA信息化管理中心-登录";
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lb_vession;
        private DevComponents.DotNetBar.ButtonX btn_cancel;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_pwd;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_uid;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}

