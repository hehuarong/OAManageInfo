using DevComponents.DotNetBar;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace OAManageSys
{
    public partial class frm_login : Office2007Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        public frm_login(string id):this()
        { 

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string uid = tb_uid.Text.Trim();
            string pwd = tb_pwd.Text.Trim();
            if (uid == "" || pwd == "")
            {
                MessageBox.Show("用户名密码不能为空");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void tb_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(null, null);
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            lb_vession.Text = "版本:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            labelX3.Text = "登录IP地址:" + Common2.DNSInfo.GetIPAdress();
        }
    }
}
