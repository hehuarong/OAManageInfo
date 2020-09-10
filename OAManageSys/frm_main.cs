using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OAManageSys
{
    public partial class frm_main : Office2007Form
    {
        public frm_main()
        {
            InitializeComponent();
        }
        public frm_main(string uid)
            : this()
        {
            _Uid = uid;
        }
        private string _Uid = "";

        private void frm_main_Load(object sender, EventArgs e)
        {
            GetImageRrl();
        }

        public void GetImageRrl()
        {
            pictureBox1.ImageLocation = Common2.HttpMethods.HttpGet("http://localhost:3176/Login/GetAuthCode");
        }

    }
}
