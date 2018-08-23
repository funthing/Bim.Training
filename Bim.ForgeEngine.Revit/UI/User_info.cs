using Bimcc.BimEngine.Revit.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.UI
{
    public partial class User_info : Form
    {


        public User_info()
        {
            InitializeComponent();
        }

        private void User_info_Load(object sender, EventArgs e)
        {
            pictureBox_uesr.Image = Image.FromFile(Tools.DownloadImage(Login.avatar));
            label_nickname.Text = Login.we_nickname;
            label_company.Text = Login.cname;
            label_email.Text = Login.email;
            label_name.Text = Login.user_name;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var uri = Tools.GetSetting("登陆");

            if (uri == null)
            {
                return;
            }

            uri = uri.Substring(0, uri.IndexOf("/", 7));

            Process.Start(uri);
        }
    }
}
