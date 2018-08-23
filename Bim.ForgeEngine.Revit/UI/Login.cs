using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Bimcc.BimEngine.Revit.Utility;
using System.Security.Cryptography;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Bimcc.BimEngine.Revit.UI
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

        public static bool LoginSuccess = false;

        public static string token;

        public static string user_name;

        public static string email;

        public static string we_nickname;

        public static string cname;

        public static string avatar;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (LoginSuccess)
            {
                return;
            }
            else
            {
                string save = Tools.GetSetting("save");

                if (save == null || save.Length == 0)
                {
                    return;
                }

                bool Save = Convert.ToBoolean(save);

                if (Save)
                {
                    checkbox_save.Checked = true;

                    Textbox_user.Text = Tools.GetSetting("user");

                    Textbox_password.Text = Tools.GetSetting("pass");

                    bool Auto = Convert.ToBoolean(Tools.GetSetting("auto"));

                    if (Auto)
                    {
                        checkbox_auto.Checked = true;

                        LogIn(Textbox_user.Text, Textbox_password.Text);
                    }
                }
                else
                {
                    checkbox_save.Checked = false;

                    checkbox_auto.Checked = false;
                }
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (checkbox_save.Checked == true)
            {
                Tools.UpdateSetting("user", Textbox_user.Text);
                Tools.UpdateSetting("pass", Textbox_password.Text);
            }

            PlatformCheck();
        }

        void PlatformCheck()
        {
            var key = Tools.GetSetting("platform_check");

            if (key != null)
            {
                if (key == "true")
                {
                    LogIn(Textbox_user.Text, Textbox_password.Text);
                }
                else
                {
                    Tools.ShowMessageBox("请先进行平台授权");
                }
            }
            else
            {
                Tools.ShowMessageBox("请先进行平台授权");
            }
        }

        public void LogIn(string user, string pass)
        {
            var obj = GetLogin(user, pass);
            if (obj == null)
            {
                return;
            }
            if ((int)obj["status"] == 1)
            {
                LoginSuccess = true;
                token = obj["data"]["token"].ToString();                
                user_name = obj["data"]["name"].ToString();
                email = obj["data"]["email"].ToString();
                we_nickname = obj["data"]["we_nickname"].ToString();
                cname = obj["data"]["cname"].ToString();
                avatar = obj["data"]["avatar"].ToString();

                Tools.ShowMessageBox("登陆成功\n请点击插件按钮");

                Close();
            }
            else
            {
                Tools.ShowMessageBox("登陆失败\n" + obj["msg"]);
            }
        }

        public JObject GetLogin(string user, string password)
        {
            var undefined = "username=" + user + "&" + "password=" + password;
            var api = Tools.GetSetting("登陆");
            if (api == null)
            {
                return null;
            }
            try
            {
                var client = new RestClient(api);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Postman-Token", "49e64b59-d51d-456b-a8e9-e05b832cbc67");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", undefined, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject(response.Content) as JObject;
            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message); return null;
            }

        }

        private void checkbox_save_CheckedChanged(object sender, EventArgs e)
        {
            Tools.UpdateSetting("save", checkbox_save.Checked.ToString());

            if (checkbox_save.Checked == false)
            {
                checkbox_auto.Checked = false;
            }
        }

        private void button_settting_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkbox_auto_CheckedChanged(object sender, EventArgs e)
        {
            Tools.UpdateSetting("auto", checkbox_auto.Checked.ToString());

            if (checkbox_auto.Checked)
            {
                checkbox_save.Checked = true;
            }
        }

        private void pictureBox_company_Click(object sender, EventArgs e)
        {

        }


    }
}
