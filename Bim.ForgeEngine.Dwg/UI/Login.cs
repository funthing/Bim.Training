using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using Bimcc.BimEngine.Dwg.Config;
using System.Threading;

namespace Bimcc.BimEngine.Dwg.UI
{
    public partial class Login : System.Windows.Forms.Form
    {
        public class WebClientEx : WebClient
        {
            public int Timeout { get; set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                request.Timeout = Timeout;
                return request;
            }
        }

        public class login
        {
            public string msg { get; set; }
            public bool success { get; set; }
            public data data { get; set; }
        }
        public class data
        {
            public int model_id { get; set; }
            public int uid { get; set; }
            public string token { get; set; }
            public string user { get; set; }
        }

        public static bool FormExportSvfzipXpLoad = false;

        public static int uid;

        public static string token;

        public static bool LoginSuccess = false;

        public static string UserName;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                string User = Encoding.UTF8.GetString(Convert.FromBase64String(GetSetting("qwe")));

                string Pass = Encoding.UTF8.GetString(Convert.FromBase64String(GetSetting("ewq")));

                bool Auto = Convert.ToBoolean(GetSetting("auto"));

                if (User.Length == 0 || Pass.Length == 0)
                {
                    checkbox_save.Checked = false; checkbox_auto.Checked = false;
                }

                else
                {
                    checkbox_save.Checked = true;

                    textbox_name.Text = User.Substring(0, User.Length - 5); textbox_password.Text = Pass.Substring(0, Pass.Length - 6);

                    if (Auto)
                    {
                        checkbox_auto.Checked = true; LogIn(textbox_name.Text, textbox_password.Text);
                    }
                }
            }
            catch (Exception) { }
        }

        public static int GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0); return Convert.ToInt32(ts.TotalSeconds);
        }

        public static string GetSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void UpdateSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            try
            {
                if (config.AppSettings.Settings[key] != null)
                {
                    config.AppSettings.Settings.Remove(key);
                }
                config.AppSettings.Settings.Add(key, value); config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception) { }
        }

        public void LogIn(string user, string pass)
        {
            login login = GetLogin(user, pass);

            if (login.success)
            {
                LoginSuccess = true;

                UserName = login.data.user;

                uid = login.data.uid;

                token = login.data.token;

                this.Hide();

                var appConfig = AppConfigManager.Load();

                new FormAppXp(appConfig).ShowDialog();

            }
            else
            {
                MessageBox.Show("登陆失败\n" + login.msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public login GetLogin(string User, string Password)
        {
            string user = Convert.ToBase64String(Encoding.UTF8.GetBytes(User));
            string pass = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
            string cfrom = "thirdParty";
            int device = GetTimeStamp();

            StringBuilder LoginData = new StringBuilder();
            LoginData.AppendFormat("{0}={1}&", "user", user);
            LoginData.AppendFormat("{0}={1}&", "pass", pass);
            LoginData.AppendFormat("{0}={1}&", "cfrom", cfrom);
            LoginData.AppendFormat("{0}={1}&", "device", device);

            WebClientEx LoginWc = new WebClientEx
            {
                Timeout = 5000
            };
            LoginWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            string Url = "http://bim.cme-gc.com/api.php?m=login&a=check";

            return JsonConvert.DeserializeObject<login>(Encoding.UTF8.GetString(LoginWc.UploadData(Url, Encoding.UTF8.GetBytes(LoginData.ToString()))));
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) { Close(); return; }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (checkbox_save.Checked == true)
            {
                string User = Convert.ToBase64String(Encoding.UTF8.GetBytes(textbox_name.Text + "fuzor"));

                string Pass = Convert.ToBase64String(Encoding.UTF8.GetBytes(textbox_password.Text + "123456"));

                UpdateSetting("qwe", User); UpdateSetting("ewq", Pass);
            }

            if (checkbox_auto.Checked)
            {
                UpdateSetting("auto", checkbox_auto.Checked.ToString());
            }

            try
            {
                button_login.Enabled = false;

                LogIn(textbox_name.Text, textbox_password.Text);

                new Thread(delegate ()
                {
                    Thread.Sleep(1000);

                    button_login.Enabled = true;

                }).Start();
            }
            catch (Exception)
            {
                MessageBox.Show("登陆失败\n请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkbox_save_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_save.Checked == false)
            {
                UpdateSetting("qwe", string.Empty); UpdateSetting("ewq", string.Empty);
            }
        }

        private void button_settting_Click(object sender, EventArgs e)
        {
            new Submit().ShowDialog();
        }

        private void checkbox_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_auto.Checked)
            {
                UpdateSetting("auto", "true"); checkbox_save.Checked = true;
            }
            else
            {
                UpdateSetting("auto", "false");
            }
        }

        private void pictureBox_company_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.bimcc.cn/");
        }
    }
}
