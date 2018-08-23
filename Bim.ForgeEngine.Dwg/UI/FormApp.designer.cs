namespace Bimcc.BimEngine.Dwg.UI
{
    partial class FormAppXp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppXp));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFontFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabpage_dwg = new System.Windows.Forms.TabPage();
            this.btnResetOptions = new System.Windows.Forms.Button();
            this.btnLicense = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gpContainer = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProjectList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.ComboBox();
            this.ModifyRadioButton = new System.Windows.Forms.RadioButton();
            this.AddRadioButton = new System.Windows.Forms.RadioButton();
            this.ModelList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_logout = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbInclude = new System.Windows.Forms.GroupBox();
            this.cbIncludeLayouts = new System.Windows.Forms.CheckBox();
            this.cbIncludeInvisibleLayers = new System.Windows.Forms.CheckBox();
            this.gpMode = new System.Windows.Forms.GroupBox();
            this.rbModeAll = new System.Windows.Forms.RadioButton();
            this.rbMode3D = new System.Windows.Forms.RadioButton();
            this.rbMode2D = new System.Windows.Forms.RadioButton();
            this.lblInputFilePrompt = new System.Windows.Forms.Label();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpGenerate = new System.Windows.Forms.GroupBox();
            this.cbGeneratePropDbSqlite = new System.Windows.Forms.CheckBox();
            this.cbGenerateThumbnail = new System.Windows.Forms.CheckBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.tabPage_revit = new System.Windows.Forms.TabPage();
            this.button_revit = new System.Windows.Forms.Button();
            this.tabPage_cloud = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabpage_dwg.SuspendLayout();
            this.gpContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbInclude.SuspendLayout();
            this.gpMode.SuspendLayout();
            this.gpGenerate.SuspendLayout();
            this.tabPage_revit.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfig});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiConfig
            // 
            this.tsmiConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFontFolder});
            this.tsmiConfig.Name = "tsmiConfig";
            this.tsmiConfig.Size = new System.Drawing.Size(74, 21);
            this.tsmiConfig.Text = "Config(&C)";
            // 
            // tsmiFontFolder
            // 
            this.tsmiFontFolder.Name = "tsmiFontFolder";
            this.tsmiFontFolder.Size = new System.Drawing.Size(148, 22);
            this.tsmiFontFolder.Text = "Fonts Folder";
            this.tsmiFontFolder.Click += new System.EventHandler(this.tsmiFontFolder_Click);
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.Filter = "Drawing File|*.dwg|All Files|*.*";
            this.dlgSelectFile.Title = "Select Source File";
            // 
            // dlgSelectFolder
            // 
            this.dlgSelectFolder.Description = "Select Output Folder Path";
            this.dlgSelectFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabpage_dwg);
            this.tabControl.Controls.Add(this.tabPage_revit);
            this.tabControl.Controls.Add(this.tabPage_cloud);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(799, 381);
            this.tabControl.TabIndex = 9;
            // 
            // tabpage_dwg
            // 
            this.tabpage_dwg.Controls.Add(this.btnResetOptions);
            this.tabpage_dwg.Controls.Add(this.btnLicense);
            this.tabpage_dwg.Controls.Add(this.btnCancel);
            this.tabpage_dwg.Controls.Add(this.btnOK);
            this.tabpage_dwg.Controls.Add(this.gpContainer);
            this.tabpage_dwg.Location = new System.Drawing.Point(4, 23);
            this.tabpage_dwg.Name = "tabpage_dwg";
            this.tabpage_dwg.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_dwg.Size = new System.Drawing.Size(791, 354);
            this.tabpage_dwg.TabIndex = 0;
            this.tabpage_dwg.Text = "DWG轻量化转换";
            this.tabpage_dwg.UseVisualStyleBackColor = true;
            // 
            // btnResetOptions
            // 
            this.btnResetOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetOptions.Location = new System.Drawing.Point(228, 299);
            this.btnResetOptions.Name = "btnResetOptions";
            this.btnResetOptions.Size = new System.Drawing.Size(114, 32);
            this.btnResetOptions.TabIndex = 10;
            this.btnResetOptions.Text = "重置高级选项";
            this.btnResetOptions.UseVisualStyleBackColor = true;
            this.btnResetOptions.Click += new System.EventHandler(this.btnResetOptions_Click);
            // 
            // btnLicense
            // 
            this.btnLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLicense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLicense.Location = new System.Drawing.Point(108, 299);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(114, 32);
            this.btnLicense.TabIndex = 9;
            this.btnLicense.Text = "授权管理 ...";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(705, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(624, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpContainer
            // 
            this.gpContainer.Controls.Add(this.label7);
            this.gpContainer.Controls.Add(this.groupBox1);
            this.gpContainer.Controls.Add(this.progressBar1);
            this.gpContainer.Controls.Add(this.groupBox2);
            this.gpContainer.Controls.Add(this.gbInclude);
            this.gpContainer.Controls.Add(this.gpMode);
            this.gpContainer.Controls.Add(this.lblInputFilePrompt);
            this.gpContainer.Controls.Add(this.btnBrowseInputFile);
            this.gpContainer.Controls.Add(this.txtInputFile);
            this.gpContainer.Controls.Add(this.label1);
            this.gpContainer.Controls.Add(this.gpGenerate);
            this.gpContainer.Controls.Add(this.lblOptions);
            this.gpContainer.Location = new System.Drawing.Point(6, 6);
            this.gpContainer.Name = "gpContainer";
            this.gpContainer.Size = new System.Drawing.Size(779, 265);
            this.gpContainer.TabIndex = 2;
            this.gpContainer.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(31, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "上传进度：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProjectList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Model);
            this.groupBox1.Controls.Add(this.ModifyRadioButton);
            this.groupBox1.Controls.Add(this.AddRadioButton);
            this.groupBox1.Controls.Add(this.ModelList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(531, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 132);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // ProjectList
            // 
            this.ProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectList.FormattingEnabled = true;
            this.ProjectList.ItemHeight = 14;
            this.ProjectList.Location = new System.Drawing.Point(87, 25);
            this.ProjectList.Name = "ProjectList";
            this.ProjectList.Size = new System.Drawing.Size(147, 22);
            this.ProjectList.TabIndex = 18;
            this.ProjectList.SelectedIndexChanged += new System.EventHandler(this.ProjectList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "项目名称：";
            // 
            // Model
            // 
            this.Model.FormattingEnabled = true;
            this.Model.ItemHeight = 14;
            this.Model.Location = new System.Drawing.Point(87, 81);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(147, 22);
            this.Model.TabIndex = 16;
            this.Model.SelectedIndexChanged += new System.EventHandler(this.Model_SelectedIndexChanged);
            // 
            // ModifyRadioButton
            // 
            this.ModifyRadioButton.AutoSize = true;
            this.ModifyRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ModifyRadioButton.Location = new System.Drawing.Point(185, 106);
            this.ModifyRadioButton.Name = "ModifyRadioButton";
            this.ModifyRadioButton.Size = new System.Drawing.Size(49, 18);
            this.ModifyRadioButton.TabIndex = 15;
            this.ModifyRadioButton.Text = "修改";
            this.ModifyRadioButton.UseVisualStyleBackColor = true;
            this.ModifyRadioButton.CheckedChanged += new System.EventHandler(this.ModifyRadioButton_CheckedChanged);
            // 
            // AddRadioButton
            // 
            this.AddRadioButton.AutoSize = true;
            this.AddRadioButton.Checked = true;
            this.AddRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddRadioButton.Location = new System.Drawing.Point(130, 106);
            this.AddRadioButton.Name = "AddRadioButton";
            this.AddRadioButton.Size = new System.Drawing.Size(49, 18);
            this.AddRadioButton.TabIndex = 14;
            this.AddRadioButton.TabStop = true;
            this.AddRadioButton.Text = "新增";
            this.AddRadioButton.UseVisualStyleBackColor = true;
            this.AddRadioButton.CheckedChanged += new System.EventHandler(this.AddRadioButton_CheckedChanged);
            // 
            // ModelList
            // 
            this.ModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelList.FormattingEnabled = true;
            this.ModelList.ItemHeight = 14;
            this.ModelList.Location = new System.Drawing.Point(87, 53);
            this.ModelList.Name = "ModelList";
            this.ModelList.Size = new System.Drawing.Size(147, 22);
            this.ModelList.TabIndex = 12;
            this.ModelList.SelectedIndexChanged += new System.EventHandler(this.ModelList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "模型类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(24, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "模型名称：";
            // 
            // progressBar1
            // 
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.Location = new System.Drawing.Point(104, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(415, 23);
            this.progressBar1.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_logout);
            this.groupBox2.Controls.Add(this.label_name);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label_state);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(531, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 95);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态";
            // 
            // label_logout
            // 
            this.label_logout.AutoSize = true;
            this.label_logout.BackColor = System.Drawing.SystemColors.Control;
            this.label_logout.Font = new System.Drawing.Font("宋体", 9F);
            this.label_logout.ForeColor = System.Drawing.Color.Red;
            this.label_logout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_logout.Location = new System.Drawing.Point(150, 30);
            this.label_logout.Name = "label_logout";
            this.label_logout.Size = new System.Drawing.Size(29, 12);
            this.label_logout.TabIndex = 16;
            this.label_logout.Text = "退出";
            this.label_logout.Click += new System.EventHandler(this.label_logout_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("宋体", 9F);
            this.label_name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_name.Location = new System.Drawing.Point(97, 60);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 12);
            this.label_name.TabIndex = 15;
            this.label_name.Text = "123456";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(26, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "登录账号：";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("宋体", 9F);
            this.label_state.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_state.Location = new System.Drawing.Point(97, 30);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(41, 12);
            this.label_state.TabIndex = 13;
            this.label_state.Text = "已登录";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(26, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "登录状态：";
            // 
            // gbInclude
            // 
            this.gbInclude.Controls.Add(this.cbIncludeLayouts);
            this.gbInclude.Controls.Add(this.cbIncludeInvisibleLayers);
            this.gbInclude.Location = new System.Drawing.Point(248, 120);
            this.gbInclude.Name = "gbInclude";
            this.gbInclude.Size = new System.Drawing.Size(122, 95);
            this.gbInclude.TabIndex = 12;
            this.gbInclude.TabStop = false;
            this.gbInclude.Text = "包括";
            // 
            // cbIncludeLayouts
            // 
            this.cbIncludeLayouts.AutoSize = true;
            this.cbIncludeLayouts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbIncludeLayouts.Location = new System.Drawing.Point(16, 45);
            this.cbIncludeLayouts.Name = "cbIncludeLayouts";
            this.cbIncludeLayouts.Size = new System.Drawing.Size(99, 18);
            this.cbIncludeLayouts.TabIndex = 2;
            this.cbIncludeLayouts.Text = "布局(2D图纸)";
            this.cbIncludeLayouts.UseVisualStyleBackColor = true;
            // 
            // cbIncludeInvisibleLayers
            // 
            this.cbIncludeInvisibleLayers.AutoSize = true;
            this.cbIncludeInvisibleLayers.Checked = true;
            this.cbIncludeInvisibleLayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeInvisibleLayers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbIncludeInvisibleLayers.Location = new System.Drawing.Point(16, 21);
            this.cbIncludeInvisibleLayers.Name = "cbIncludeInvisibleLayers";
            this.cbIncludeInvisibleLayers.Size = new System.Drawing.Size(86, 18);
            this.cbIncludeInvisibleLayers.TabIndex = 1;
            this.cbIncludeInvisibleLayers.Text = "不可见图层";
            this.cbIncludeInvisibleLayers.UseVisualStyleBackColor = true;
            // 
            // gpMode
            // 
            this.gpMode.Controls.Add(this.rbModeAll);
            this.gpMode.Controls.Add(this.rbMode3D);
            this.gpMode.Controls.Add(this.rbMode2D);
            this.gpMode.Location = new System.Drawing.Point(102, 120);
            this.gpMode.Name = "gpMode";
            this.gpMode.Size = new System.Drawing.Size(140, 95);
            this.gpMode.TabIndex = 11;
            this.gpMode.TabStop = false;
            this.gpMode.Text = "模式";
            // 
            // rbModeAll
            // 
            this.rbModeAll.AutoSize = true;
            this.rbModeAll.Location = new System.Drawing.Point(19, 69);
            this.rbModeAll.Name = "rbModeAll";
            this.rbModeAll.Size = new System.Drawing.Size(115, 18);
            this.rbModeAll.TabIndex = 2;
            this.rbModeAll.Text = "2D图纸和3D模型";
            this.rbModeAll.UseVisualStyleBackColor = true;
            // 
            // rbMode3D
            // 
            this.rbMode3D.AutoSize = true;
            this.rbMode3D.Location = new System.Drawing.Point(19, 45);
            this.rbMode3D.Name = "rbMode3D";
            this.rbMode3D.Size = new System.Drawing.Size(64, 18);
            this.rbMode3D.TabIndex = 1;
            this.rbMode3D.Text = "3D模型";
            this.rbMode3D.UseVisualStyleBackColor = true;
            // 
            // rbMode2D
            // 
            this.rbMode2D.AutoSize = true;
            this.rbMode2D.Checked = true;
            this.rbMode2D.Location = new System.Drawing.Point(19, 21);
            this.rbMode2D.Name = "rbMode2D";
            this.rbMode2D.Size = new System.Drawing.Size(64, 18);
            this.rbMode2D.TabIndex = 0;
            this.rbMode2D.TabStop = true;
            this.rbMode2D.Text = "2D图纸";
            this.rbMode2D.UseVisualStyleBackColor = true;
            // 
            // lblInputFilePrompt
            // 
            this.lblInputFilePrompt.AutoSize = true;
            this.lblInputFilePrompt.Location = new System.Drawing.Point(99, 89);
            this.lblInputFilePrompt.Name = "lblInputFilePrompt";
            this.lblInputFilePrompt.Size = new System.Drawing.Size(95, 14);
            this.lblInputFilePrompt.TabIndex = 3;
            this.lblInputFilePrompt.Text = "请选择输入文件.";
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Location = new System.Drawing.Point(488, 68);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(31, 21);
            this.btnBrowseInputFile.TabIndex = 2;
            this.btnBrowseInputFile.Text = "...";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(104, 65);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(375, 22);
            this.txtInputFile.TabIndex = 1;
            this.txtInputFile.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入文件:";
            // 
            // gpGenerate
            // 
            this.gpGenerate.Controls.Add(this.cbGeneratePropDbSqlite);
            this.gpGenerate.Controls.Add(this.cbGenerateThumbnail);
            this.gpGenerate.Location = new System.Drawing.Point(376, 120);
            this.gpGenerate.Name = "gpGenerate";
            this.gpGenerate.Size = new System.Drawing.Size(143, 95);
            this.gpGenerate.TabIndex = 10;
            this.gpGenerate.TabStop = false;
            this.gpGenerate.Text = "生成";
            // 
            // cbGeneratePropDbSqlite
            // 
            this.cbGeneratePropDbSqlite.AutoSize = true;
            this.cbGeneratePropDbSqlite.Checked = true;
            this.cbGeneratePropDbSqlite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGeneratePropDbSqlite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbGeneratePropDbSqlite.Location = new System.Drawing.Point(15, 46);
            this.cbGeneratePropDbSqlite.Name = "cbGeneratePropDbSqlite";
            this.cbGeneratePropDbSqlite.Size = new System.Drawing.Size(120, 18);
            this.cbGeneratePropDbSqlite.TabIndex = 1;
            this.cbGeneratePropDbSqlite.Text = "属性数据(SQLite)";
            this.cbGeneratePropDbSqlite.UseVisualStyleBackColor = true;
            // 
            // cbGenerateThumbnail
            // 
            this.cbGenerateThumbnail.AutoSize = true;
            this.cbGenerateThumbnail.Checked = true;
            this.cbGenerateThumbnail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGenerateThumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbGenerateThumbnail.Location = new System.Drawing.Point(15, 22);
            this.cbGenerateThumbnail.Name = "cbGenerateThumbnail";
            this.cbGenerateThumbnail.Size = new System.Drawing.Size(62, 18);
            this.cbGenerateThumbnail.TabIndex = 0;
            this.cbGenerateThumbnail.Text = "缩略图";
            this.cbGenerateThumbnail.UseVisualStyleBackColor = true;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOptions.Location = new System.Drawing.Point(30, 120);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(59, 14);
            this.lblOptions.TabIndex = 7;
            this.lblOptions.Text = "高级选项:";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage_revit
            // 
            this.tabPage_revit.Controls.Add(this.button_revit);
            this.tabPage_revit.Location = new System.Drawing.Point(4, 23);
            this.tabPage_revit.Name = "tabPage_revit";
            this.tabPage_revit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_revit.Size = new System.Drawing.Size(815, 354);
            this.tabPage_revit.TabIndex = 1;
            this.tabPage_revit.Text = "Revit轻量化转换";
            this.tabPage_revit.UseVisualStyleBackColor = true;
            // 
            // button_revit
            // 
            this.button_revit.Location = new System.Drawing.Point(284, 116);
            this.button_revit.Name = "button_revit";
            this.button_revit.Size = new System.Drawing.Size(218, 64);
            this.button_revit.TabIndex = 0;
            this.button_revit.Text = "点击这里打开Revit";
            this.button_revit.UseVisualStyleBackColor = true;
            this.button_revit.Click += new System.EventHandler(this.button_revit_Click);
            // 
            // tabPage_cloud
            // 
            this.tabPage_cloud.Location = new System.Drawing.Point(4, 23);
            this.tabPage_cloud.Name = "tabPage_cloud";
            this.tabPage_cloud.Size = new System.Drawing.Size(815, 354);
            this.tabPage_cloud.TabIndex = 2;
            this.tabPage_cloud.Text = "Cloud云端轻量化转换";
            this.tabPage_cloud.UseVisualStyleBackColor = true;
            // 
            // FormAppXp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(799, 408);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAppXp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bimcc BimEngine Dwg";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabpage_dwg.ResumeLayout(false);
            this.gpContainer.ResumeLayout(false);
            this.gpContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbInclude.ResumeLayout(false);
            this.gbInclude.PerformLayout();
            this.gpMode.ResumeLayout(false);
            this.gpMode.PerformLayout();
            this.gpGenerate.ResumeLayout(false);
            this.gpGenerate.PerformLayout();
            this.tabPage_revit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiFontFolder;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabpage_dwg;
        private System.Windows.Forms.GroupBox gpContainer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ProjectList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Model;
        private System.Windows.Forms.RadioButton ModifyRadioButton;
        private System.Windows.Forms.RadioButton AddRadioButton;
        private System.Windows.Forms.ComboBox ModelList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_logout;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbInclude;
        private System.Windows.Forms.CheckBox cbIncludeLayouts;
        private System.Windows.Forms.CheckBox cbIncludeInvisibleLayers;
        private System.Windows.Forms.GroupBox gpMode;
        private System.Windows.Forms.RadioButton rbModeAll;
        private System.Windows.Forms.RadioButton rbMode3D;
        private System.Windows.Forms.RadioButton rbMode2D;
        private System.Windows.Forms.Label lblInputFilePrompt;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpGenerate;
        private System.Windows.Forms.CheckBox cbGeneratePropDbSqlite;
        private System.Windows.Forms.CheckBox cbGenerateThumbnail;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.TabPage tabPage_revit;
        private System.Windows.Forms.TabPage tabPage_cloud;
        private System.Windows.Forms.Button btnResetOptions;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button_revit;
    }
}