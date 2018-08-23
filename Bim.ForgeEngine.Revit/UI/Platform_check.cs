using Bimcc.BimEngine.Revit.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.UI
{
    public partial class Platform_check : Form
    {
        public Platform_check()
        {
            InitializeComponent();
        }

        private void Platform_save_Load(object sender, EventArgs e)
        {
            var platform_check = Tools.GetSetting("platform_check");

            if (platform_check != null)
            {
                if (platform_check == "true")
                {
                    textBox_key.UseSystemPasswordChar = true;
                    textBox_access.UseSystemPasswordChar = true;
                }
            }

            var key = Tools.GetSetting("key");

            var access = Tools.GetSetting("access");

            if (key != null && access != null)
            {
                textBox_key.Text = key;
                textBox_access.Text = access;
            }


        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                var access = textBox_access.Text;
                var key = textBox_key.Text;
                var ts = Tools.GetTimeStamp().ToString();
                var rcode = Tools.GetRandomString();
                var signature = Tools.SHA1(rcode + "_" + ts + "_" + key);

                var client = new RestClient("http://cc.bimcc.com/api/app/interface");
                var request = new RestRequest(Method.GET);
                request.AddHeader("signature", signature);
                request.AddHeader("rcode", rcode);
                request.AddHeader("ts", ts);
                request.AddHeader("access", access);
                IRestResponse response = client.Execute(request);

                var obj = JsonConvert.DeserializeObject(response.Content) as JObject;
                if ((int)obj["code"] == 200)
                {
                    var array = obj["content"] as JArray;
                    foreach (var item in array)
                    {
                        Tools.UpdateSetting(item["name"].ToString(), item["api"].ToString());
                    }
                    Tools.UpdateSetting("platform_check", "true");
                    Tools.UpdateSetting("access", access);
                    Tools.UpdateSetting("key", key);
                    Tools.ShowMessageBox("验证成功");
                    Close();
                }
                else
                {
                    Tools.UpdateSetting("platform_check", "false");
                    Tools.ShowMessageBox("验证失败");
                }
            }
            catch (Exception ex)
            {
                Tools.ShowMessageBox(ex.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Platform_check_FormClosing(object sender, FormClosingEventArgs e)
        {
            var platform_check = Tools.GetSetting("platform_check");

            if (platform_check != null)
            {
                if (platform_check == "true")
                {
                    Setting.platform.Text = "已授权";
                }
                else
                {
                    Setting.platform.Text = "未授权";
                }
            }
        }
    }
}
