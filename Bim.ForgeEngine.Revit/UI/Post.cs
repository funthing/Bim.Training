using Bimcc.BimEngine.Revit.Utility;
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
    public partial class Post : Form
    {
        public Post()
        {
            InitializeComponent();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (textBox_company.Text.Length == 0 || textBox_email.Text.Length == 0 
                || textBox_name.Text.Length == 0 || textBox_phone.Text.Length == 0)
            {
                Tools.ShowMessageBox("请将信息输入完整");
            }
            else
            {
                Tools.ShowMessageBox("提交成功");
                Close();
            }
        }

        private void Plugin_submit_Load(object sender, EventArgs e)
        {

        }
    }
}
