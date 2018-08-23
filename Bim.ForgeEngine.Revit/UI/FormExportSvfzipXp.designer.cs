namespace Bimcc.BimEngine.Revit.UI
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
            this.button_ok = new System.Windows.Forms.Button();
            this.gpContainer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_logout = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Combobox_projectName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Combobox_modelName = new System.Windows.Forms.ComboBox();
            this.RadioButton_modify = new System.Windows.Forms.RadioButton();
            this.RadioButton_add = new System.Windows.Forms.RadioButton();
            this.Combobox_modelType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUseCurrentViewport = new System.Windows.Forms.CheckBox();
            this.gpGeneral = new System.Windows.Forms.GroupBox();
            this.cbVisualStyle = new System.Windows.Forms.ComboBox();
            this.lblVisualStyle = new System.Windows.Forms.Label();
            this.cbLevelOfDetail = new System.Windows.Forms.ComboBox();
            this.lblLevelOfDetail = new System.Windows.Forms.Label();
            this.gpGenerate = new System.Windows.Forms.GroupBox();
            this.cbGeneratePropDbSqlite = new System.Windows.Forms.CheckBox();
            this.cbGeneratePropDbJson = new System.Windows.Forms.CheckBox();
            this.cbGenerateThumbnail = new System.Windows.Forms.CheckBox();
            this.gpInclude = new System.Windows.Forms.GroupBox();
            this.cbIncludeRooms = new System.Windows.Forms.CheckBox();
            this.cbIncludeGrids = new System.Windows.Forms.CheckBox();
            this.gpExclude = new System.Windows.Forms.GroupBox();
            this.cbExcludeUnselectedElements = new System.Windows.Forms.CheckBox();
            this.cbExcludeModelPoints = new System.Windows.Forms.CheckBox();
            this.cbExcludeLines = new System.Windows.Forms.CheckBox();
            this.cbExcludeElementProperties = new System.Windows.Forms.CheckBox();
            this.gpConsolidate = new System.Windows.Forms.GroupBox();
            this.cbConsolidateAssembly = new System.Windows.Forms.CheckBox();
            this.cbConsolidateArrayGroup = new System.Windows.Forms.CheckBox();
            this.gp2DViews = new System.Windows.Forms.GroupBox();
            this.rb2DViewsAll = new System.Windows.Forms.RadioButton();
            this.rb2DViewsOnlySheet = new System.Windows.Forms.RadioButton();
            this.rb2DViewsBypass = new System.Windows.Forms.RadioButton();
            this.gpGroupByLevel = new System.Windows.Forms.GroupBox();
            this.rbGroupByLevelBoundingBox = new System.Windows.Forms.RadioButton();
            this.rbGroupByLevelNavisworks = new System.Windows.Forms.RadioButton();
            this.rbGroupByLevelDefault = new System.Windows.Forms.RadioButton();
            this.rbGroupByLevelDisable = new System.Windows.Forms.RadioButton();
            this.lblOptions = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_reset = new System.Windows.Forms.Button();
            this.gpContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpGeneral.SuspendLayout();
            this.gpGenerate.SuspendLayout();
            this.gpInclude.SuspendLayout();
            this.gpExclude.SuspendLayout();
            this.gpConsolidate.SuspendLayout();
            this.gp2DViews.SuspendLayout();
            this.gpGroupByLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            resources.ApplyResources(this.button_ok, "button_ok");
            this.button_ok.Name = "button_ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // gpContainer
            // 
            this.gpContainer.Controls.Add(this.label2);
            this.gpContainer.Controls.Add(this.groupBox2);
            this.gpContainer.Controls.Add(this.progressBar1);
            this.gpContainer.Controls.Add(this.groupBox1);
            this.gpContainer.Controls.Add(this.cbUseCurrentViewport);
            this.gpContainer.Controls.Add(this.gpGeneral);
            this.gpContainer.Controls.Add(this.gpGenerate);
            this.gpContainer.Controls.Add(this.gpInclude);
            this.gpContainer.Controls.Add(this.gpExclude);
            this.gpContainer.Controls.Add(this.gpConsolidate);
            this.gpContainer.Controls.Add(this.gp2DViews);
            this.gpContainer.Controls.Add(this.gpGroupByLevel);
            this.gpContainer.Controls.Add(this.lblOptions);
            resources.ApplyResources(this.gpContainer, "gpContainer");
            this.gpContainer.Name = "gpContainer";
            this.gpContainer.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_logout);
            this.groupBox2.Controls.Add(this.label_user);
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
            // label_user
            // 
            resources.ApplyResources(this.label_user, "label_user");
            this.label_user.Name = "label_user";
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
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Combobox_projectName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Combobox_modelName);
            this.groupBox1.Controls.Add(this.RadioButton_modify);
            this.groupBox1.Controls.Add(this.RadioButton_add);
            this.groupBox1.Controls.Add(this.Combobox_modelType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // Combobox_projectName
            // 
            this.Combobox_projectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combobox_projectName.FormattingEnabled = true;
            resources.ApplyResources(this.Combobox_projectName, "Combobox_projectName");
            this.Combobox_projectName.Name = "Combobox_projectName";
            this.Combobox_projectName.SelectedIndexChanged += new System.EventHandler(this.Combobox_projectName_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Combobox_modelName
            // 
            this.Combobox_modelName.FormattingEnabled = true;
            resources.ApplyResources(this.Combobox_modelName, "Combobox_modelName");
            this.Combobox_modelName.Name = "Combobox_modelName";
            this.Combobox_modelName.SelectedIndexChanged += new System.EventHandler(this.Combobox_modelName_SelectedIndexChanged);
            // 
            // RadioButton_modify
            // 
            resources.ApplyResources(this.RadioButton_modify, "RadioButton_modify");
            this.RadioButton_modify.Name = "RadioButton_modify";
            this.RadioButton_modify.UseVisualStyleBackColor = true;
            this.RadioButton_modify.CheckedChanged += new System.EventHandler(this.RadioButton_modify_CheckedChanged);
            // 
            // RadioButton_add
            // 
            resources.ApplyResources(this.RadioButton_add, "RadioButton_add");
            this.RadioButton_add.Checked = true;
            this.RadioButton_add.Name = "RadioButton_add";
            this.RadioButton_add.TabStop = true;
            this.RadioButton_add.UseVisualStyleBackColor = true;
            this.RadioButton_add.CheckedChanged += new System.EventHandler(this.RadioButton_add_CheckedChanged);
            // 
            // Combobox_modelType
            // 
            this.Combobox_modelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combobox_modelType.FormattingEnabled = true;
            resources.ApplyResources(this.Combobox_modelType, "Combobox_modelType");
            this.Combobox_modelType.Name = "Combobox_modelType";
            this.Combobox_modelType.SelectedIndexChanged += new System.EventHandler(this.Combobox_modelType_SelectedIndexChanged);
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
            // cbUseCurrentViewport
            // 
            resources.ApplyResources(this.cbUseCurrentViewport, "cbUseCurrentViewport");
            this.cbUseCurrentViewport.Name = "cbUseCurrentViewport";
            this.cbUseCurrentViewport.UseVisualStyleBackColor = true;
            // 
            // gpGeneral
            // 
            this.gpGeneral.Controls.Add(this.cbVisualStyle);
            this.gpGeneral.Controls.Add(this.lblVisualStyle);
            this.gpGeneral.Controls.Add(this.cbLevelOfDetail);
            this.gpGeneral.Controls.Add(this.lblLevelOfDetail);
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
            // cbLevelOfDetail
            // 
            this.cbLevelOfDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevelOfDetail.FormattingEnabled = true;
            resources.ApplyResources(this.cbLevelOfDetail, "cbLevelOfDetail");
            this.cbLevelOfDetail.Name = "cbLevelOfDetail";
            // 
            // lblLevelOfDetail
            // 
            resources.ApplyResources(this.lblLevelOfDetail, "lblLevelOfDetail");
            this.lblLevelOfDetail.Name = "lblLevelOfDetail";
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
            // gpInclude
            // 
            this.gpInclude.Controls.Add(this.cbIncludeRooms);
            this.gpInclude.Controls.Add(this.cbIncludeGrids);
            resources.ApplyResources(this.gpInclude, "gpInclude");
            this.gpInclude.Name = "gpInclude";
            this.gpInclude.TabStop = false;
            // 
            // cbIncludeRooms
            // 
            resources.ApplyResources(this.cbIncludeRooms, "cbIncludeRooms");
            this.cbIncludeRooms.Name = "cbIncludeRooms";
            this.cbIncludeRooms.UseVisualStyleBackColor = true;
            // 
            // cbIncludeGrids
            // 
            resources.ApplyResources(this.cbIncludeGrids, "cbIncludeGrids");
            this.cbIncludeGrids.Name = "cbIncludeGrids";
            this.cbIncludeGrids.UseVisualStyleBackColor = true;
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
            // gpConsolidate
            // 
            this.gpConsolidate.Controls.Add(this.cbConsolidateAssembly);
            this.gpConsolidate.Controls.Add(this.cbConsolidateArrayGroup);
            resources.ApplyResources(this.gpConsolidate, "gpConsolidate");
            this.gpConsolidate.Name = "gpConsolidate";
            this.gpConsolidate.TabStop = false;
            // 
            // cbConsolidateAssembly
            // 
            resources.ApplyResources(this.cbConsolidateAssembly, "cbConsolidateAssembly");
            this.cbConsolidateAssembly.Name = "cbConsolidateAssembly";
            this.cbConsolidateAssembly.UseVisualStyleBackColor = true;
            // 
            // cbConsolidateArrayGroup
            // 
            resources.ApplyResources(this.cbConsolidateArrayGroup, "cbConsolidateArrayGroup");
            this.cbConsolidateArrayGroup.Name = "cbConsolidateArrayGroup";
            this.cbConsolidateArrayGroup.UseVisualStyleBackColor = true;
            // 
            // gp2DViews
            // 
            this.gp2DViews.Controls.Add(this.rb2DViewsAll);
            this.gp2DViews.Controls.Add(this.rb2DViewsOnlySheet);
            this.gp2DViews.Controls.Add(this.rb2DViewsBypass);
            resources.ApplyResources(this.gp2DViews, "gp2DViews");
            this.gp2DViews.Name = "gp2DViews";
            this.gp2DViews.TabStop = false;
            // 
            // rb2DViewsAll
            // 
            resources.ApplyResources(this.rb2DViewsAll, "rb2DViewsAll");
            this.rb2DViewsAll.Name = "rb2DViewsAll";
            this.rb2DViewsAll.TabStop = true;
            this.rb2DViewsAll.UseVisualStyleBackColor = true;
            // 
            // rb2DViewsOnlySheet
            // 
            resources.ApplyResources(this.rb2DViewsOnlySheet, "rb2DViewsOnlySheet");
            this.rb2DViewsOnlySheet.Name = "rb2DViewsOnlySheet";
            this.rb2DViewsOnlySheet.TabStop = true;
            this.rb2DViewsOnlySheet.UseVisualStyleBackColor = true;
            // 
            // rb2DViewsBypass
            // 
            resources.ApplyResources(this.rb2DViewsBypass, "rb2DViewsBypass");
            this.rb2DViewsBypass.Name = "rb2DViewsBypass";
            this.rb2DViewsBypass.TabStop = true;
            this.rb2DViewsBypass.UseVisualStyleBackColor = true;
            // 
            // gpGroupByLevel
            // 
            this.gpGroupByLevel.Controls.Add(this.rbGroupByLevelBoundingBox);
            this.gpGroupByLevel.Controls.Add(this.rbGroupByLevelNavisworks);
            this.gpGroupByLevel.Controls.Add(this.rbGroupByLevelDefault);
            this.gpGroupByLevel.Controls.Add(this.rbGroupByLevelDisable);
            resources.ApplyResources(this.gpGroupByLevel, "gpGroupByLevel");
            this.gpGroupByLevel.Name = "gpGroupByLevel";
            this.gpGroupByLevel.TabStop = false;
            // 
            // rbGroupByLevelBoundingBox
            // 
            resources.ApplyResources(this.rbGroupByLevelBoundingBox, "rbGroupByLevelBoundingBox");
            this.rbGroupByLevelBoundingBox.Name = "rbGroupByLevelBoundingBox";
            this.rbGroupByLevelBoundingBox.TabStop = true;
            this.rbGroupByLevelBoundingBox.UseVisualStyleBackColor = true;
            // 
            // rbGroupByLevelNavisworks
            // 
            resources.ApplyResources(this.rbGroupByLevelNavisworks, "rbGroupByLevelNavisworks");
            this.rbGroupByLevelNavisworks.Name = "rbGroupByLevelNavisworks";
            this.rbGroupByLevelNavisworks.TabStop = true;
            this.rbGroupByLevelNavisworks.UseVisualStyleBackColor = true;
            // 
            // rbGroupByLevelDefault
            // 
            resources.ApplyResources(this.rbGroupByLevelDefault, "rbGroupByLevelDefault");
            this.rbGroupByLevelDefault.Name = "rbGroupByLevelDefault";
            this.rbGroupByLevelDefault.TabStop = true;
            this.rbGroupByLevelDefault.UseVisualStyleBackColor = true;
            // 
            // rbGroupByLevelDisable
            // 
            resources.ApplyResources(this.rbGroupByLevelDisable, "rbGroupByLevelDisable");
            this.rbGroupByLevelDisable.Name = "rbGroupByLevelDisable";
            this.rbGroupByLevelDisable.TabStop = true;
            this.rbGroupByLevelDisable.UseVisualStyleBackColor = true;
            // 
            // lblOptions
            // 
            resources.ApplyResources(this.lblOptions, "lblOptions");
            this.lblOptions.Name = "lblOptions";
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_reset
            // 
            resources.ApplyResources(this.button_reset, "button_reset");
            this.button_reset.Name = "button_reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // FormExportSvfzipXp
            // 
            this.AcceptButton = this.button_ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.button_cancel;
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.gpContainer);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportSvfzipXp";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.gpContainer.ResumeLayout(false);
            this.gpContainer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpGeneral.ResumeLayout(false);
            this.gpGeneral.PerformLayout();
            this.gpGenerate.ResumeLayout(false);
            this.gpGenerate.PerformLayout();
            this.gpInclude.ResumeLayout(false);
            this.gpInclude.PerformLayout();
            this.gpExclude.ResumeLayout(false);
            this.gpExclude.PerformLayout();
            this.gpConsolidate.ResumeLayout(false);
            this.gpConsolidate.PerformLayout();
            this.gp2DViews.ResumeLayout(false);
            this.gp2DViews.PerformLayout();
            this.gpGroupByLevel.ResumeLayout(false);
            this.gpGroupByLevel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.GroupBox gpContainer;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbVisualStyle;
        private System.Windows.Forms.Label lblVisualStyle;
        private System.Windows.Forms.ComboBox cbLevelOfDetail;
        private System.Windows.Forms.Label lblLevelOfDetail;
        private System.Windows.Forms.GroupBox gp2DViews;
        private System.Windows.Forms.RadioButton rb2DViewsAll;
        private System.Windows.Forms.RadioButton rb2DViewsOnlySheet;
        private System.Windows.Forms.RadioButton rb2DViewsBypass;
        private System.Windows.Forms.GroupBox gpGroupByLevel;
        private System.Windows.Forms.RadioButton rbGroupByLevelBoundingBox;
        private System.Windows.Forms.RadioButton rbGroupByLevelNavisworks;
        private System.Windows.Forms.RadioButton rbGroupByLevelDefault;
        private System.Windows.Forms.RadioButton rbGroupByLevelDisable;
        private System.Windows.Forms.GroupBox gpGeneral;
        private System.Windows.Forms.GroupBox gpGenerate;
        private System.Windows.Forms.CheckBox cbGeneratePropDbSqlite;
        private System.Windows.Forms.CheckBox cbGeneratePropDbJson;
        private System.Windows.Forms.CheckBox cbGenerateThumbnail;
        private System.Windows.Forms.GroupBox gpInclude;
        private System.Windows.Forms.CheckBox cbIncludeRooms;
        private System.Windows.Forms.CheckBox cbIncludeGrids;
        private System.Windows.Forms.GroupBox gpExclude;
        private System.Windows.Forms.CheckBox cbExcludeUnselectedElements;
        private System.Windows.Forms.CheckBox cbExcludeModelPoints;
        private System.Windows.Forms.CheckBox cbExcludeLines;
        private System.Windows.Forms.CheckBox cbExcludeElementProperties;
        private System.Windows.Forms.GroupBox gpConsolidate;
        private System.Windows.Forms.CheckBox cbConsolidateAssembly;
        private System.Windows.Forms.CheckBox cbConsolidateArrayGroup;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.CheckBox cbUseCurrentViewport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_logout;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Combobox_projectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Combobox_modelName;
        private System.Windows.Forms.RadioButton RadioButton_modify;
        private System.Windows.Forms.RadioButton RadioButton_add;
        private System.Windows.Forms.ComboBox Combobox_modelType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOptions;
    }
}