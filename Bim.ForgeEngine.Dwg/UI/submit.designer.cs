namespace Bimcc.BimEngine.Dwg.UI
{
    partial class Submit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Submit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_HardwareId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.textBox_data = new System.Windows.Forms.TextBox();
            this.textBox_company = new System.Windows.Forms.TextBox();
            this.label_domain = new System.Windows.Forms.Label();
            this.label_company = new System.Windows.Forms.Label();
            this.label_key = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.textBox_domain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_HardwareId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_mail);
            this.groupBox1.Controls.Add(this.textBox_data);
            this.groupBox1.Controls.Add(this.textBox_company);
            this.groupBox1.Controls.Add(this.label_domain);
            this.groupBox1.Controls.Add(this.label_company);
            this.groupBox1.Controls.Add(this.label_key);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轻量化转换授权";
            // 
            // textbox_HardwareId
            // 
            this.textbox_HardwareId.Location = new System.Drawing.Point(85, 35);
            this.textbox_HardwareId.Name = "textbox_HardwareId";
            this.textbox_HardwareId.ReadOnly = true;
            this.textbox_HardwareId.Size = new System.Drawing.Size(217, 21);
            this.textbox_HardwareId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "机器码：";
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(85, 116);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(217, 21);
            this.textBox_mail.TabIndex = 2;
            // 
            // textBox_data
            // 
            this.textBox_data.Location = new System.Drawing.Point(85, 89);
            this.textBox_data.Name = "textBox_data";
            this.textBox_data.Size = new System.Drawing.Size(217, 21);
            this.textBox_data.TabIndex = 1;
            // 
            // textBox_company
            // 
            this.textBox_company.Location = new System.Drawing.Point(85, 62);
            this.textBox_company.Name = "textBox_company";
            this.textBox_company.Size = new System.Drawing.Size(217, 21);
            this.textBox_company.TabIndex = 0;
            // 
            // label_domain
            // 
            this.label_domain.AutoSize = true;
            this.label_domain.Location = new System.Drawing.Point(38, 119);
            this.label_domain.Name = "label_domain";
            this.label_domain.Size = new System.Drawing.Size(41, 12);
            this.label_domain.TabIndex = 2;
            this.label_domain.Text = "邮箱：";
            // 
            // label_company
            // 
            this.label_company.AutoSize = true;
            this.label_company.Location = new System.Drawing.Point(38, 92);
            this.label_company.Name = "label_company";
            this.label_company.Size = new System.Drawing.Size(41, 12);
            this.label_company.TabIndex = 1;
            this.label_company.Text = "日期：";
            // 
            // label_key
            // 
            this.label_key.AutoSize = true;
            this.label_key.Location = new System.Drawing.Point(38, 65);
            this.label_key.Name = "label_key";
            this.label_key.Size = new System.Drawing.Size(41, 12);
            this.label_key.TabIndex = 0;
            this.label_key.Text = "公司：";
            // 
            // button_submit
            // 
            this.button_submit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_submit.Location = new System.Drawing.Point(152, 295);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(75, 32);
            this.button_submit.TabIndex = 5;
            this.button_submit.Text = "提交";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_key);
            this.groupBox2.Controls.Add(this.textBox_domain);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 101);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "应用授权";
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(85, 62);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(217, 21);
            this.textBox_key.TabIndex = 4;
            // 
            // textBox_domain
            // 
            this.textBox_domain.Location = new System.Drawing.Point(85, 35);
            this.textBox_domain.Name = "textBox_domain";
            this.textBox_domain.Size = new System.Drawing.Size(217, 21);
            this.textBox_domain.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务器key：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "应用域名：";
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(239, 295);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 32);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Submit
            // 
            this.AcceptButton = this.button_submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(356, 348);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Submit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "授权申请";
            this.Load += new System.EventHandler(this.Log_setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_domain;
        private System.Windows.Forms.Label label_company;
        private System.Windows.Forms.Label label_key;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.TextBox textBox_data;
        private System.Windows.Forms.TextBox textBox_company;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.TextBox textbox_HardwareId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.TextBox textBox_domain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_cancel;
    }
}