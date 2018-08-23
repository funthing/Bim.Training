namespace Bimcc.BimEngine.Navisworks.UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.button_settting = new System.Windows.Forms.Button();
            this.checkbox_auto = new System.Windows.Forms.CheckBox();
            this.checkbox_save = new System.Windows.Forms.CheckBox();
            this.button_login = new System.Windows.Forms.Button();
            this.pictureBox_company = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_company)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_settting);
            this.groupBox1.Controls.Add(this.checkbox_auto);
            this.groupBox1.Controls.Add(this.checkbox_save);
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textbox_password);
            this.groupBox3.Controls.Add(this.password);
            this.groupBox3.Location = new System.Drawing.Point(216, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 51);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(67, 17);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(100, 21);
            this.textbox_password.TabIndex = 2;
            this.textbox_password.UseSystemPasswordChar = true;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(20, 20);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(41, 12);
            this.password.TabIndex = 12;
            this.password.Text = "密码：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textbox_name);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Location = new System.Drawing.Point(21, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 51);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // textbox_name
            // 
            this.textbox_name.Location = new System.Drawing.Point(74, 16);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(100, 21);
            this.textbox_name.TabIndex = 1;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(15, 20);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(53, 12);
            this.name.TabIndex = 10;
            this.name.Text = "用户名：";
            // 
            // button_settting
            // 
            this.button_settting.Location = new System.Drawing.Point(216, 131);
            this.button_settting.Name = "button_settting";
            this.button_settting.Size = new System.Drawing.Size(75, 32);
            this.button_settting.TabIndex = 15;
            this.button_settting.Text = "授权";
            this.button_settting.UseVisualStyleBackColor = true;
            this.button_settting.Click += new System.EventHandler(this.button_settting_Click);
            // 
            // checkbox_auto
            // 
            this.checkbox_auto.AutoSize = true;
            this.checkbox_auto.Location = new System.Drawing.Point(216, 88);
            this.checkbox_auto.Name = "checkbox_auto";
            this.checkbox_auto.Size = new System.Drawing.Size(72, 16);
            this.checkbox_auto.TabIndex = 4;
            this.checkbox_auto.Text = "自动登录";
            this.checkbox_auto.UseVisualStyleBackColor = true;
            this.checkbox_auto.CheckedChanged += new System.EventHandler(this.checkbox_auto_CheckedChanged);
            // 
            // checkbox_save
            // 
            this.checkbox_save.AutoSize = true;
            this.checkbox_save.Location = new System.Drawing.Point(138, 88);
            this.checkbox_save.Name = "checkbox_save";
            this.checkbox_save.Size = new System.Drawing.Size(72, 16);
            this.checkbox_save.TabIndex = 3;
            this.checkbox_save.Text = "记住密码";
            this.checkbox_save.UseVisualStyleBackColor = true;
            this.checkbox_save.CheckedChanged += new System.EventHandler(this.checkbox_save_CheckedChanged);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(135, 131);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 32);
            this.button_login.TabIndex = 12;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // pictureBox_company
            // 
            this.pictureBox_company.Image = global::Bimcc.BimEngine.Navisworks.Properties.Resources.BIMCC_logo;
            this.pictureBox_company.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_company.Name = "pictureBox_company";
            this.pictureBox_company.Size = new System.Drawing.Size(428, 124);
            this.pictureBox_company.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_company.TabIndex = 1;
            this.pictureBox_company.TabStop = false;
            this.pictureBox_company.Click += new System.EventHandler(this.pictureBox_company_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.button_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 334);
            this.Controls.Add(this.pictureBox_company);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_company)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_settting;
        private System.Windows.Forms.CheckBox checkbox_auto;
        private System.Windows.Forms.CheckBox checkbox_save;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.PictureBox pictureBox_company;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label name;
    }
}