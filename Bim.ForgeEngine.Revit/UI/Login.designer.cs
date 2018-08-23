namespace Bimcc.BimEngine.Revit.UI
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
            this.Textbox_password = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Textbox_user = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkbox_auto = new System.Windows.Forms.CheckBox();
            this.checkbox_save = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.pictureBox_user = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_cancel);
            this.groupBox1.Controls.Add(this.checkbox_auto);
            this.groupBox1.Controls.Add(this.checkbox_save);
            this.groupBox1.Controls.Add(this.button_ok);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Textbox_password);
            this.groupBox3.Controls.Add(this.password);
            this.groupBox3.Location = new System.Drawing.Point(216, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 51);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // Textbox_password
            // 
            this.Textbox_password.Location = new System.Drawing.Point(67, 17);
            this.Textbox_password.Name = "Textbox_password";
            this.Textbox_password.Size = new System.Drawing.Size(100, 21);
            this.Textbox_password.TabIndex = 1;
            this.Textbox_password.UseSystemPasswordChar = true;
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
            this.groupBox2.Controls.Add(this.Textbox_user);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Location = new System.Drawing.Point(21, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 51);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // Textbox_user
            // 
            this.Textbox_user.Location = new System.Drawing.Point(74, 16);
            this.Textbox_user.Name = "Textbox_user";
            this.Textbox_user.Size = new System.Drawing.Size(100, 21);
            this.Textbox_user.TabIndex = 0;
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
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(216, 131);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 32);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_settting_Click);
            // 
            // checkbox_auto
            // 
            this.checkbox_auto.AutoSize = true;
            this.checkbox_auto.Location = new System.Drawing.Point(216, 88);
            this.checkbox_auto.Name = "checkbox_auto";
            this.checkbox_auto.Size = new System.Drawing.Size(72, 16);
            this.checkbox_auto.TabIndex = 3;
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
            this.checkbox_save.TabIndex = 2;
            this.checkbox_save.Text = "记住密码";
            this.checkbox_save.UseVisualStyleBackColor = true;
            this.checkbox_save.CheckedChanged += new System.EventHandler(this.checkbox_save_CheckedChanged);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(135, 131);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 32);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // pictureBox_user
            // 
            this.pictureBox_user.Image = global::Bimcc.BimEngine.Revit.Properties.Resources.BIMCC_logo;
            this.pictureBox_user.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_user.Name = "pictureBox_user";
            this.pictureBox_user.Size = new System.Drawing.Size(428, 130);
            this.pictureBox_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_user.TabIndex = 1;
            this.pictureBox_user.TabStop = false;
            this.pictureBox_user.Click += new System.EventHandler(this.pictureBox_company_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(452, 334);
            this.Controls.Add(this.pictureBox_user);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "筑云BIM";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkbox_auto;
        private System.Windows.Forms.CheckBox checkbox_save;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.PictureBox pictureBox_user;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Textbox_password;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Textbox_user;
        private System.Windows.Forms.Label name;
    }
}