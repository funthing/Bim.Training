namespace Bimcc.BimEngine.Navisworks.UI
{
    partial class FormExportSvfzipXp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportSvfzipXp));
            this.btnOK = new System.Windows.Forms.Button();
            this.gpContainer = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProjectList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.ComboBox();
            this.ModifyRadioButton = new System.Windows.Forms.RadioButton();
            this.AddRadioButton = new System.Windows.Forms.RadioButton();
            this.ModelList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_logout = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gpInclude = new System.Windows.Forms.GroupBox();
            this.cbHyperlink = new System.Windows.Forms.CheckBox();
            this.gpGeneral = new System.Windows.Forms.GroupBox();
            this.cbVisualStyle = new System.Windows.Forms.ComboBox();
            this.lblVisualStyle = new System.Windows.Forms.Label();
            this.gpGenerate = new System.Windows.Forms.GroupBox();
            this.cbGeneratePropDbSqlite = new System.Windows.Forms.CheckBox();
            this.cbGeneratePropDbJson = new System.Windows.Forms.CheckBox();
            this.cbGenerateThumbnail = new System.Windows.Forms.CheckBox();
            this.gpExclude = new System.Windows.Forms.GroupBox();
            this.cbExcludeUnselectedElements = new System.Windows.Forms.CheckBox();
            this.cbExcludeModelPoints = new System.Windows.Forms.CheckBox();
            this.cbExcludeLines = new System.Windows.Forms.CheckBox();
            this.cbExcludeElementProperties = new System.Windows.Forms.CheckBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnLicense = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnResetOptions = new System.Windows.Forms.Button();
            this.gpContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpInclude.SuspendLayout();
            this.gpGeneral.SuspendLayout();
            this.gpGenerate.SuspendLayout();
            this.gpExclude.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpContainer
            // 
            resources.ApplyResources(this.gpContainer, "gpContainer");
            this.gpContainer.Controls.Add(this.groupBox1);
            this.gpContainer.Controls.Add(this.groupBox2);
            this.gpContainer.Controls.Add(this.label2);
            this.gpContainer.Controls.Add(this.progressBar1);
            this.gpContainer.Controls.Add(this.gpInclude);
            this.gpContainer.Controls.Add(this.gpGeneral);
            this.gpContainer.Controls.Add(this.gpGenerate);
            this.gpContainer.Controls.Add(this.gpExclude);
            this.gpContainer.Controls.Add(this.lblOptions);
            this.gpContainer.Name = "gpContainer";
            this.gpContainer.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProjectList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Model);
            this.groupBox1.Controls.Add(this.ModifyRadioButton);
            this.groupBox1.Controls.Add(this.AddRadioButton);
            this.groupBox1.Controls.Add(this.ModelList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ProjectList
            // 
            this.ProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectList.FormattingEnabled = true;
            resources.ApplyResources(this.ProjectList, "ProjectList");
            this.ProjectList.Name = "ProjectList";
            this.ProjectList.SelectedIndexChanged += new System.EventHandler(this.ProjectList_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Model
            // 
            this.Model.FormattingEnabled = true;
            resources.ApplyResources(this.Model, "Model");
            this.Model.Name = "Model";
            this.Model.SelectedIndexChanged += new System.EventHandler(this.Model_SelectedIndexChanged);
            // 
            // ModifyRadioButton
            // 
            resources.ApplyResources(this.ModifyRadioButton, "ModifyRadioButton");
            this.ModifyRadioButton.Name = "ModifyRadioButton";
            this.ModifyRadioButton.UseVisualStyleBackColor = true;
            this.ModifyRadioButton.CheckedChanged += new System.EventHandler(this.ModifyRadioButton_CheckedChanged);
            // 
            // AddRadioButton
            // 
            resources.ApplyResources(this.AddRadioButton, "AddRadioButton");
            this.AddRadioButton.Checked = true;
            this.AddRadioButton.Name = "AddRadioButton";
            this.AddRadioButton.TabStop = true;
            this.AddRadioButton.UseVisualStyleBackColor = true;
            this.AddRadioButton.CheckedChanged += new System.EventHandler(this.AddRadioButton_CheckedChanged);
            // 
            // ModelList
            // 
            this.ModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelList.FormattingEnabled = true;
            resources.ApplyResources(this.ModelList, "ModelList");
            this.ModelList.Name = "ModelList";
            this.ModelList.SelectedIndexChanged += new System.EventHandler(this.ModelList_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_logout);
            this.groupBox2.Controls.Add(this.label_name);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label_state);
            this.groupBox2.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label_logout
            // 
            resources.ApplyResources(this.label_logout, "label_logout");
            this.label_logout.BackColor = System.Drawing.SystemColors.Control;
            this.label_logout.ForeColor = System.Drawing.Color.Red;
            this.label_logout.Name = "label_logout";
            this.label_logout.Click += new System.EventHandler(this.label_logout_Click);
            // 
            // label_name
            // 
            resources.ApplyResources(this.label_name, "label_name");
            this.label_name.Name = "label_name";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label_state
            // 
            resources.ApplyResources(this.label_state, "label_state");
            this.label_state.Name = "label_state";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // gpInclude
            // 
            this.gpInclude.Controls.Add(this.cbHyperlink);
            resources.ApplyResources(this.gpInclude, "gpInclude");
            this.gpInclude.Name = "gpInclude";
            this.gpInclude.TabStop = false;
            // 
            // cbHyperlink
            // 
            resources.ApplyResources(this.cbHyperlink, "cbHyperlink");
            this.cbHyperlink.Name = "cbHyperlink";
            this.cbHyperlink.UseVisualStyleBackColor = true;
            // 
            // gpGeneral
            // 
            this.gpGeneral.Controls.Add(this.cbVisualStyle);
            this.gpGeneral.Controls.Add(this.lblVisualStyle);
            resources.ApplyResources(this.gpGeneral, "gpGeneral");
            this.gpGeneral.Name = "gpGeneral";
            this.gpGeneral.TabStop = false;
            // 
            // cbVisualStyle
            // 
            this.cbVisualStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisualStyle.FormattingEnabled = true;
            resources.ApplyResources(this.cbVisualStyle, "cbVisualStyle");
            this.cbVisualStyle.Name = "cbVisualStyle";
            this.cbVisualStyle.SelectedIndexChanged += new System.EventHandler(this.cbVisualStyle_SelectedIndexChanged);
            // 
            // lblVisualStyle
            // 
            resources.ApplyResources(this.lblVisualStyle, "lblVisualStyle");
            this.lblVisualStyle.Name = "lblVisualStyle";
            // 
            // gpGenerate
            // 
            this.gpGenerate.Controls.Add(this.cbGeneratePropDbSqlite);
            this.gpGenerate.Controls.Add(this.cbGeneratePropDbJson);
            this.gpGenerate.Controls.Add(this.cbGenerateThumbnail);
            resources.ApplyResources(this.gpGenerate, "gpGenerate");
            this.gpGenerate.Name = "gpGenerate";
            this.gpGenerate.TabStop = false;
            // 
            // cbGeneratePropDbSqlite
            // 
            resources.ApplyResources(this.cbGeneratePropDbSqlite, "cbGeneratePropDbSqlite");
            this.cbGeneratePropDbSqlite.Name = "cbGeneratePropDbSqlite";
            this.cbGeneratePropDbSqlite.UseVisualStyleBackColor = true;
            // 
            // cbGeneratePropDbJson
            // 
            resources.ApplyResources(this.cbGeneratePropDbJson, "cbGeneratePropDbJson");
            this.cbGeneratePropDbJson.Name = "cbGeneratePropDbJson";
            this.cbGeneratePropDbJson.UseVisualStyleBackColor = true;
            // 
            // cbGenerateThumbnail
            // 
            resources.ApplyResources(this.cbGenerateThumbnail, "cbGenerateThumbnail");
            this.cbGenerateThumbnail.Name = "cbGenerateThumbnail";
            this.cbGenerateThumbnail.UseVisualStyleBackColor = true;
            // 
            // gpExclude
            // 
            this.gpExclude.Controls.Add(this.cbExcludeUnselectedElements);
            this.gpExclude.Controls.Add(this.cbExcludeModelPoints);
            this.gpExclude.Controls.Add(this.cbExcludeLines);
            this.gpExclude.Controls.Add(this.cbExcludeElementProperties);
            resources.ApplyResources(this.gpExclude, "gpExclude");
            this.gpExclude.Name = "gpExclude";
            this.gpExclude.TabStop = false;
            // 
            // cbExcludeUnselectedElements
            // 
            resources.ApplyResources(this.cbExcludeUnselectedElements, "cbExcludeUnselectedElements");
            this.cbExcludeUnselectedElements.Name = "cbExcludeUnselectedElements";
            this.cbExcludeUnselectedElements.UseVisualStyleBackColor = true;
            // 
            // cbExcludeModelPoints
            // 
            resources.ApplyResources(this.cbExcludeModelPoints, "cbExcludeModelPoints");
            this.cbExcludeModelPoints.Name = "cbExcludeModelPoints";
            this.cbExcludeModelPoints.UseVisualStyleBackColor = true;
            // 
            // cbExcludeLines
            // 
            resources.ApplyResources(this.cbExcludeLines, "cbExcludeLines");
            this.cbExcludeLines.Name = "cbExcludeLines";
            this.cbExcludeLines.UseVisualStyleBackColor = true;
            // 
            // cbExcludeElementProperties
            // 
            resources.ApplyResources(this.cbExcludeElementProperties, "cbExcludeElementProperties");
            this.cbExcludeElementProperties.Name = "cbExcludeElementProperties";
            this.cbExcludeElementProperties.UseVisualStyleBackColor = true;
            // 
            // lblOptions
            // 
            resources.ApplyResources(this.lblOptions, "lblOptions");
            this.lblOptions.Name = "lblOptions";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLicense
            // 
            resources.ApplyResources(this.btnLicense, "btnLicense");
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnResetOptions
            // 
            resources.ApplyResources(this.btnResetOptions, "btnResetOptions");
            this.btnResetOptions.Name = "btnResetOptions";
            this.btnResetOptions.UseVisualStyleBackColor = true;
            this.btnResetOptions.Click += new System.EventHandler(this.btnResetOptions_Click);
            // 
            // FormExportSvfzipXp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnResetOptions);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpContainer);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportSvfzipXp";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.gpContainer.ResumeLayout(false);
            this.gpContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpInclude.ResumeLayout(false);
            this.gpInclude.PerformLayout();
            this.gpGeneral.ResumeLayout(false);
            this.gpGeneral.PerformLayout();
            this.gpGenerate.ResumeLayout(false);
            this.gpGenerate.PerformLayout();
            this.gpExclude.ResumeLayout(false);
            this.gpExclude.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gpContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.ComboBox cbVisualStyle;
        private System.Windows.Forms.Label lblVisualStyle;
        private System.Windows.Forms.GroupBox gpGeneral;
        private System.Windows.Forms.GroupBox gpGenerate;
        private System.Windows.Forms.CheckBox cbGeneratePropDbSqlite;
        private System.Windows.Forms.CheckBox cbGeneratePropDbJson;
        private System.Windows.Forms.CheckBox cbGenerateThumbnail;
        private System.Windows.Forms.GroupBox gpExclude;
        private System.Windows.Forms.CheckBox cbExcludeUnselectedElements;
        private System.Windows.Forms.CheckBox cbExcludeModelPoints;
        private System.Windows.Forms.CheckBox cbExcludeLines;
        private System.Windows.Forms.CheckBox cbExcludeElementProperties;
        private System.Windows.Forms.Button btnResetOptions;
        private System.Windows.Forms.GroupBox gpInclude;
        private System.Windows.Forms.CheckBox cbHyperlink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ProjectList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Model;
        private System.Windows.Forms.RadioButton ModifyRadioButton;
        private System.Windows.Forms.RadioButton AddRadioButton;
        private System.Windows.Forms.ComboBox ModelList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_logout;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}