using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bimangle.ForgeEngine.Dwg;
using Bimangle.ForgeEngine.Dwg.Core;
using Bimcc.BimEngine.Dwg.Config;
using Bimcc.BimEngine.Dwg.Core;
using Bimcc.BimEngine.Dwg.Helpers;
using Bimcc.BimEngine.Dwg.Utility;
using Newtonsoft.Json;
using static Bimcc.BimEngine.Dwg.UI.Login;
using static Bimcc.BimEngine.Dwg.UI.License;
using Newtonsoft.Json.Linq;

namespace Bimcc.BimEngine.Dwg.UI
{
    partial class FormAppXp : Form
    {
        public class model
        {
            public JArray data { get; set; }
        }

        public class GetModel
        {
            public JArray data { get; set; }
        }

        public static int SetType;

        public int model_id;

        public int ProjectId;

        public string ModelName;

        public string ModelType;

        public List<string> id = new List<string>();

        public List<string> title = new List<string>();

        public List<string> modelName = new List<string>();

        public List<string> modelId = new List<string>();

        public class Svfzip
        {
            public string filename { get; set; }
        }

        public class AddModel
        {
            public data data { get; set; }
            public int code { get; set; }
            public bool success { get; set; }
            public string msg { get; set; }
        }

        public class ReModel
        {
            public string msg { get; set; }
            public bool success { get; set; }
        }
        public static string TempPath = Path.GetTempPath();

        private readonly AppConfig _Config;

        private readonly List<FeatureInfo> _Features;
        private bool _IsInit;

        public TimeSpan ExportDuration { get; private set; }

        public FormAppXp(AppConfig appConfig)
            : this()
        {
            _Config = appConfig ?? new AppConfig();

            if (_Config.Local == null)
            {
                _Config.Local = new AppLocalConfig();
            }

            if (_Config.Local.Features == null || _Config.Local.Features.Count == 0)
            {
                _Config.Local.Features = new List<FeatureType>
                {
                    FeatureType.ExportMode2D,
                    FeatureType.ExportMode3D,
                    FeatureType.IncludeInvisibleLayers,
                    FeatureType.IncludeLayouts,
                    FeatureType.GenerateThumbnail,
                    FeatureType.GenerateModelsDb
                };
            }

            _Features = new List<FeatureInfo>
            {
                new FeatureInfo(FeatureType.ExportMode2D, Strings.FeatureNameExportMode2D, Strings.FeatureDescriptionExportMode2D),
                new FeatureInfo(FeatureType.ExportMode3D, Strings.FeatureNameExportMode3D, Strings.FeatureDescriptionExportMode3D),
                new FeatureInfo(FeatureType.IncludeInvisibleLayers, Strings.FeatureNameIncludeInvisibleLayers, Strings.FeatureDescriptionIncludeInvisibleLayers),
                new FeatureInfo(FeatureType.IncludeLayouts, Strings.FeatureNameIncludeLayouts, Strings.FeatureDescriptionIncludeLayouts),
                new FeatureInfo(FeatureType.GenerateModelsDb, Strings.FeatureNameGenerateModelsDb, Strings.FeatureDescriptionGenerateModelsDb),
                new FeatureInfo(FeatureType.GenerateThumbnail, Strings.FeatureNameGenerateThumbnail, Strings.FeatureDescriptionGenerateThumbnail),
            };
        }

        public FormAppXp()
        {
            InitializeComponent();
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            InitUI();

            _IsInit = true;

            RefreshOuputCommand();

            ProjectList.Items.Clear(); id.Clear(); title.Clear(); label_name.Text = UserName;

            Thread t = new Thread(RefreshProjectList)
            {
                IsBackground = false
            };
            t.Start();
        }

        private void InitUI()
        {
            bool IsAllowFeature(FeatureType feature)
            {
                return _Features.Any(x => x.Type == feature && x.Selected);
            }

            void SetAllowFeature(FeatureType feature)
            {
                var item = _Features.FirstOrDefault(x => x.Type == feature);
                item?.ChangeSelected(_Features, true);
            }

            var config = _Config?.Local ?? new AppLocalConfig();

            txtInputFile.Text = config.InputFilePath ?? string.Empty;

            if (config.Features != null && config.Features.Any())
            {
                foreach (var feature in config.Features)
                {
                    _Features.FirstOrDefault(x => x.Type == feature)?.ChangeSelected(_Features, true);
                }
            }
            else
            {
                SetAllowFeature(FeatureType.ExportMode2D);
                SetAllowFeature(FeatureType.IncludeInvisibleLayers);
                SetAllowFeature(FeatureType.GenerateModelsDb);
                SetAllowFeature(FeatureType.GenerateThumbnail);
            }

            #region 模式
            {
                toolTip1.SetToolTip(rbMode2D, Strings.FeatureDescriptionExportMode2D);
                toolTip1.SetToolTip(rbMode3D, Strings.FeatureDescriptionExportMode3D);
                toolTip1.SetToolTip(rbModeAll, Strings.FeatureDescriptionExportModeAll);

                if (IsAllowFeature(FeatureType.ExportMode2D) &&
                    IsAllowFeature(FeatureType.ExportMode3D))
                {
                    rbModeAll.Checked = true;
                }
                else if (IsAllowFeature(FeatureType.ExportMode2D))
                {
                    rbMode2D.Checked = true;
                }
                else if (IsAllowFeature(FeatureType.ExportMode3D))
                {
                    rbMode3D.Checked = true;
                }
                else
                {
                    rbMode2D.Checked = true;
                }
            }
            #endregion

            #region 包括
            {
                toolTip1.SetToolTip(cbIncludeInvisibleLayers, Strings.FeatureDescriptionIncludeInvisibleLayers);
                toolTip1.SetToolTip(cbIncludeLayouts, Strings.FeatureDescriptionIncludeLayouts);

                cbIncludeInvisibleLayers.Checked = IsAllowFeature(FeatureType.IncludeInvisibleLayers);
                cbIncludeLayouts.Checked = IsAllowFeature(FeatureType.IncludeLayouts);
            }
            #endregion

            #region 生成
            {
                toolTip1.SetToolTip(cbGenerateThumbnail, Strings.FeatureDescriptionGenerateThumbnail);
                toolTip1.SetToolTip(cbGeneratePropDbSqlite, Strings.FeatureDescriptionGenerateModelsDb);

                if (IsAllowFeature(FeatureType.GenerateThumbnail))
                {
                    cbGenerateThumbnail.Checked = true;
                }

                if (IsAllowFeature(FeatureType.GenerateModelsDb))
                {
                    cbGeneratePropDbSqlite.Checked = true;
                }
            }
            #endregion

        }

        private void btnBrowseInputFile_Click(object sender, EventArgs e)
        {
            dlgSelectFile.FileName = txtInputFile.Text;

            if (dlgSelectFile.ShowDialog(this) == DialogResult.OK)
            {
                txtInputFile.Text = dlgSelectFile.FileName;
            }
        }

        private void RefreshOuputCommand()
        {
            btnOK.Enabled = GeneralCommandArguments();
        }

        private bool GeneralCommandArguments()
        {
            if (!_IsInit) return false;

            #region 更新界面选项到 _Features

            void SetFeature(FeatureType featureType, bool selected)
            {
                _Features.FirstOrDefault(x => x.Type == featureType)?.ChangeSelected(_Features, selected);
            }

            if (rbMode2D.Checked)
            {
                SetFeature(FeatureType.ExportMode2D, true);
                SetFeature(FeatureType.ExportMode3D, false);
            }
            else if (rbMode3D.Checked)
            {
                SetFeature(FeatureType.ExportMode2D, false);
                SetFeature(FeatureType.ExportMode3D, true);
            }
            else
            {
                SetFeature(FeatureType.ExportMode2D, true);
                SetFeature(FeatureType.ExportMode3D, true);
            }

            SetFeature(FeatureType.IncludeInvisibleLayers, cbIncludeInvisibleLayers.Checked);
            SetFeature(FeatureType.IncludeLayouts, cbIncludeLayouts.Checked);

            SetFeature(FeatureType.GenerateThumbnail, cbGenerateThumbnail.Checked);
            SetFeature(FeatureType.GenerateModelsDb, cbGeneratePropDbSqlite.Checked);

            #endregion

            _Config.Local.InputFilePath = txtInputFile.Text.Trim();
            _Config.Local.LastTargetPath = TempPath + ModelName + ".svfzip";
            _Config.Local.Features = _Features.Where(x => x.Selected && x.Enabled).Select(x => x.Type).ToList();

            if (string.IsNullOrWhiteSpace(_Config.Local.InputFilePath) ||
                string.IsNullOrWhiteSpace(_Config.Local.LastTargetPath))
            {
                return false;
            }

            return true;
        }

        private void ShowMessage(string s)
        {
            MessageBox.Show(this, s, Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            var s = txtInputFile.Text.Trim();
            if (string.IsNullOrWhiteSpace(s))
            {
                lblInputFilePrompt.ForeColor = SystemColors.ControlText;
                lblInputFilePrompt.Text = @"请选择或输入源模型文件.";
            }
            else
            {
                if (File.Exists(s) == false)
                {
                    lblInputFilePrompt.ForeColor = Color.Red;
                    lblInputFilePrompt.Text = @"文件不存在!";
                }
                else
                {
                    lblInputFilePrompt.ForeColor = Color.Green;
                    lblInputFilePrompt.Text = @"文件位置有效!";
                }
            }

            RefreshOuputCommand();
        }

        private void rbMode2D_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void rbMode3D_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void rbModeAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void cbIncludeInvisibleLayers_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void cbIncludeLayouts_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void cbGenerateThumbnail_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void cbGeneratePropDbSqlite_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOuputCommand();
        }

        private void tsmiFontFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var fontFolderPath = App.GetFontFolderPath();

                Process.Start(fontFolderPath);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            new License().ShowDialog(this);
        }

        private void btnResetOptions_Click(object sender, EventArgs e)
        {
            SetType = 0; AddRadioButton.Checked = true; Model.Text = string.Empty;
            _Config.Local.Features = new List<FeatureType>
            {
                FeatureType.ExportMode2D,
                FeatureType.ExportMode3D,
                FeatureType.IncludeInvisibleLayers,
                FeatureType.IncludeLayouts,
                FeatureType.GenerateThumbnail,
                FeatureType.GenerateModelsDb
            };

            _IsInit = false;

            InitUI();

            _IsInit = true;

            RefreshOuputCommand();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Model.Text != "")
            {
                if (ModelList.Text != "")
                {
                    ModelName = Model.Text; ModelType = ModelList.Text;

                    if (AddRadioButton.Checked == true)
                    {
                        SetType = 1;
                    }
                    else
                    {
                        SetType = 2;
                    }

                    Export();
                }
                else
                {
                    MessageBox.Show("请选择模型类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请输入模型名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Export()
        {
            if (!GeneralCommandArguments()) return;

            using (var session = App.CreateLicenseSession())
            {
                if (session.IsValid == false)
                {
                    new License().ShowDialog(this);

                    return;
                }

                _Config.Save();

                bool isCanncelled;
                using (var progress = new ProgressHelper(this, Strings.MessageExporting))
                {
                    var cancellationToken = progress.GetCancellationToken();
                    StartExport(_Config.Local, progress.GetProgressCallback(), cancellationToken);
                    isCanncelled = cancellationToken.IsCancellationRequested;
                }

                if (isCanncelled == false)
                {
                    UploadFile();
                    Enabled = false;
                }
            }

        }

        public void UploadFile()
        {
            WebClient PostWc = new WebClient();
            PostWc.UploadFileAsync(new Uri("http://bim.cme-gc.com:10086/model/uploadSvfzip"), "post", TempPath + ModelName + ".svfzip");
            PostWc.UploadProgressChanged += PostWc_UploadProgressChanged;
            PostWc.UploadFileCompleted += PostWc_UploadFileCompleted;
        }

        public AddModel _AddModel(string path)
        {
            string AddModelUrl = "http://bim.cme-gc.com/api.php?m=rvt&a=addModel";

            StringBuilder AddModelData = new StringBuilder();
            AddModelData.AppendFormat("{0}={1}&", "adminid", uid);
            AddModelData.AppendFormat("{0}={1}&", "token", token);
            AddModelData.AppendFormat("{0}={1}&", "model_name", ModelName);
            AddModelData.AppendFormat("{0}={1}&", "model_url", path);
            AddModelData.AppendFormat("{0}={1}&", "model_type", ModelType);
            AddModelData.AppendFormat("{0}={1}&", "project_id", ProjectId);

            WebClient AddModelWc = new WebClient();
            AddModelWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            AddModel addModel = JsonConvert.DeserializeObject<AddModel>(Encoding.UTF8.GetString(AddModelWc.UploadData(AddModelUrl, Encoding.UTF8.GetBytes(AddModelData.ToString()))));
            return addModel;

        }

        public ReModel _ReModel(string path)
        {
            string ReModelUrl = "http://bim.cme-gc.com/api.php?m=rvt&a=updateModel";

            StringBuilder ReModelData = new StringBuilder();
            ReModelData.AppendFormat("{0}={1}&", "adminid", uid);
            ReModelData.AppendFormat("{0}={1}&", "token", token);
            ReModelData.AppendFormat("{0}={1}&", "model_id", model_id);
            ReModelData.AppendFormat("{0}={1}&", "model_url", path);

            WebClient ReModelWc = new WebClient();
            ReModelWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] ReModelArray = Encoding.UTF8.GetBytes(ReModelData.ToString());
            byte[] ReModelResult = ReModelWc.UploadData(ReModelUrl, ReModelArray);
            ReModel reModel = JsonConvert.DeserializeObject<ReModel>(Encoding.UTF8.GetString(ReModelResult));
            return reModel;
        }

        private void PostWc_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            // 删除导出文件
            File.Delete(TempPath + ModelName + ".svfzip");

            Svfzip svf = JsonConvert.DeserializeObject<Svfzip>(Encoding.UTF8.GetString(e.Result));

            string path = "http://bim.cme-gc.com:10086/offline/" + svf.filename;

            if (SetType == 1)
            {
                for (int i = 0; i < title.Count; i++)
                {
                    if (ProjectId == Convert.ToInt32(id[i]))
                    {
                        AddModel model = _AddModel(path);
                        if (model.success)
                        {
                            MessageBox.Show(title[i] + ":新增成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(title[i] + ":新增失败\n" + model.msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                }
                SetType = 0;

                Enabled = true;
            }
            else if (SetType == 2)
            {
                for (int i = 0; i < title.Count; i++)
                {
                    if (ProjectId == Convert.ToInt32(id[i]))
                    {
                        ReModel model = _ReModel(path);

                        if (model.success)
                        {
                            MessageBox.Show(title[i] + ":修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(title[i] + ":修改失败\n" + model.msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                }
                SetType = 0;

                Enabled = true;
            }
        }

        private void PostWc_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        public void RefreshProjectList()
        {
            foreach (var item in GetProjectList().data)
            {
                id.Add(item["id"].ToString());

                title.Add(item["title"].ToString());
            }

            foreach (var item in title)
            {
                if (ProjectList.Items.Cast<object>().All(x => x.ToString() != item))
                {
                    ProjectList.Items.Add(item);
                }
            }
            ProjectList.Text = ProjectList.Items[0].ToString();
        }

        public model GetProjectList()
        {
            StringBuilder modelData = new StringBuilder();
            modelData.AppendFormat("{0}={1}&", "adminid", Login.uid);
            modelData.AppendFormat("{0}={1}&", "token", Login.token);
            WebClient wlyWc = new WebClient();
            wlyWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string modelUrl = "http://bim.cme-gc.com/api.php?m=rvt&a=getProjectList";
            return JsonConvert.DeserializeObject<model>(Encoding.UTF8.GetString(wlyWc.UploadData(modelUrl, Encoding.UTF8.GetBytes(modelData.ToString()))));
        }

        public model GetModelType()
        {
            StringBuilder modelData = new StringBuilder();
            modelData.AppendFormat("{0}={1}&", "adminid", Login.uid);
            modelData.AppendFormat("{0}={1}&", "token", Login.token);
            WebClient wlyWc = new WebClient();
            wlyWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string modelUrl = "http://bim.cme-gc.com/api.php?m=rvt&a=getModelType";
            return JsonConvert.DeserializeObject<model>(Encoding.UTF8.GetString(wlyWc.UploadData(modelUrl, Encoding.UTF8.GetBytes(modelData.ToString()))));
        }

        public GetModel GetModelList()
        {
            StringBuilder GetModelData = new StringBuilder();
            GetModelData.AppendFormat("{0}={1}&", "adminid", Login.uid);
            GetModelData.AppendFormat("{0}={1}&", "token", Login.token);
            GetModelData.AppendFormat("{0}={1}&", "project_id", ProjectId);
            GetModelData.AppendFormat("{0}={1}&", "model_type", ModelList.Text);
            WebClient GetModeltWc = new WebClient();
            GetModeltWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string GetModelUrl = "http://bim.cme-gc.com/api.php?m=rvt&a=getModelList";
            return JsonConvert.DeserializeObject<GetModel>(Encoding.UTF8.GetString(GetModeltWc.UploadData(GetModelUrl, Encoding.UTF8.GetBytes(GetModelData.ToString()))));
        }

        /// <summary>
        /// 开始导出
        /// </summary>
        /// <param name="localConfig"></param>
        /// <param name="progressCallback"></param>
        /// <param name="cancellationToken"></param>
        private void StartExport(AppLocalConfig localConfig, Action<int> progressCallback, CancellationToken cancellationToken)
        {
            using (var log = new RuntimeLog())
            {
                var config = new ExportConfig();
                config.InputFilePath = localConfig.InputFilePath;
                config.TargetPath = localConfig.LastTargetPath;
                config.Features = localConfig.Features.ToDictionary(x => x, x => true);
                config.Trace = log.Log;
                config.FontPath = new List<string>
                {
                    App.GetFontFolderPath()
                };

                #region Add Plugin - CreatePropDb
                {
                    var cliPath = Path.Combine(
                        App.GetHomePath(),
                        @"Tools",
                        @"CreatePropDb",
                        @"CreatePropDbCLI.exe");
                    if (File.Exists(cliPath))
                    {
                        config.Addins.Add(new ExportPlugin(
                            FeatureType.GenerateModelsDb,
                            cliPath,
                            new[] { @"-i", config.TargetPath }
                        ));
                    }
                }
                #endregion

                Exporter.ExportToSvf(config, x => progressCallback?.Invoke((int)x), cancellationToken);
            }
        }


        private void ProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelList.Text = ""; ModelList.Items.Clear();

            Thread t = new Thread(RefreshModelList)
            {
                IsBackground = false
            };
            t.Start();
        }

        private void ModelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Text = ""; Model.Items.Clear();

            Thread t = new Thread(RefreshModel)
            {
                IsBackground = false
            };
            t.Start();
        }

        private void Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < modelName.Count; i++)
            {
                if (Model.Text == modelName[i])
                {
                    model_id = Convert.ToInt16(modelId[i]); break;
                }
            }
        }

        private void AddRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddRadioButton.Checked == true)
            {
                Model.DropDownStyle = ComboBoxStyle.DropDown;

                Model.Text = "";

                Model.Items.Clear();
            }
        }

        private void ModifyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Model.DropDownStyle = ComboBoxStyle.DropDownList;

            Thread t = new Thread(RefreshradioButton2)
            {
                IsBackground = false
            };
            t.Start();
        }

        public void RefreshradioButton2()
        {
            if (ModelList.Text != "")
            {
                if (ModifyRadioButton.Checked == true)
                {
                    Model.Items.Clear();

                    try
                    {
                        foreach (var item in modelName)
                        {
                            if (Model.Items.Cast<object>().All(x => x.ToString() != item))
                            {
                                Model.Items.Add(item);
                            }
                        }

                        if (Model.Items.Count != 0)
                        {
                            Model.Text = Model.Items[0].ToString();
                        }
                    }
                    catch (Exception)
                    {
                        Model.Text = "";
                    }
                }
            }
        }

        public void RefreshModel()
        {
            modelName.Clear(); modelId.Clear();

            foreach (var item in GetModelList().data)
            {
                modelName.Add(item["model_name"].ToString()); modelId.Add(item["model_id"].ToString());
            }

            if (ModifyRadioButton.Checked == true)
            {
                try
                {
                    foreach (var item in modelName)
                    {
                        if (Model.Items.Cast<object>().All(x => x.ToString() != item))
                        {
                            Model.Items.Add(item);
                        }
                    }

                    if (Model.Items.Count != 0)
                    {
                        Model.Text = Model.Items[0].ToString();
                    }
                }
                catch (Exception)
                {
                    Model.Text = "";
                }
            }
        }

        public void AddModelList()
        {
            List<string> modelType = new List<string>();

            foreach (var item in GetModelType().data)
            {
                modelType.Add(item.ToString());
            }

            foreach (var item in modelType)
            {
                if (ModelList.Items.Cast<object>().All(x => x.ToString() != item))
                {
                    ModelList.Items.Add(item);
                }
            }
            ModelList.Text = ModelList.Items[0].ToString();
        }

        public void RefreshModelList()
        {
            try
            {
                for (int i = 0; i < title.Count; i++)
                {
                    if (ProjectList.Text == title[i])
                    {
                        ProjectId = Convert.ToInt32(id[i]); AddModelList(); break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请稍后再试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginSuccess = false;

            UpdateSetting("auto", "false");

            new Login().ShowDialog();
        }

        private void button_revit_Click(object sender, EventArgs e)
        {
            string path_revit = @"C:\Program Files\Autodesk\Revit 2016\Revit.exe";

            if (File.Exists(path_revit))
            {
                Process.Start(path_revit);
            }

        }
    }
}
