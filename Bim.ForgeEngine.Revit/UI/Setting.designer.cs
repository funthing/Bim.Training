namespace Bimcc.BimEngine.Revit.UI
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_platform = new System.Windows.Forms.LinkLabel();
            this.label_plugin = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_platform);
            this.groupBox1.Controls.Add(this.label_plugin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(18, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Note：必须先授权轻量化插件后才可授权BIM平台";
            // 
            // label_platform
            // 
            this.label_platform.AutoSize = true;
            this.label_platform.Location = new System.Drawing.Point(200, 99);
            this.label_platform.Name = "label_platform";
            this.label_platform.Size = new System.Drawing.Size(41, 12);
            this.label_platform.TabIndex = 20;
            this.label_platform.TabStop = true;
            this.label_platform.Text = "未授权";
            this.label_platform.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label_platform_LinkClicked);
            // 
            // label_plugin
            // 
            this.label_plugin.AutoSize = true;
            this.label_plugin.Location = new System.Drawing.Point(200, 47);
            this.label_plugin.Name = "label_plugin";
            this.label_plugin.Size = new System.Drawing.Size(41, 12);
            this.label_plugin.TabIndex = 19;
            this.label_plugin.TabStop = true;
            this.label_plugin.Text = "未授权";
            this.label_plugin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label_plugin_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "BIM平台授权状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "轻量化插件授权状态：";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 223);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "授权信息";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel label_platform;
        private System.Windows.Forms.LinkLabel label_plugin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}