using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Bimcc.BimEngine.Navisworks.Core;
using Bimcc.BimEngine.Navisworks.Config;
using Bimcc.BimEngine.Navisworks.Helpers;
using Form = System.Windows.Forms.Form;
using Bimangle.ForgeEngine.Navisworks.Core;
using Bimangle.ForgeEngine.Navisworks;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using static Bimcc.BimEngine.Navisworks.UI.Login;

namespace Bimcc.BimEngine.Navisworks.UI
{
    partial class FormExportSvfzipXp : Form
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

        private readonly List<VisualStyleInfo> _VisualStyles;
        private readonly VisualStyleInfo _VisualStyleDefault;

        public FormExportSvfzipXp()
        {
            InitializeComponent();
        }

        public FormExportSvfzipXp(AppConfig config)
            : this()
        {
            _Config = config;

            _Features = new List<FeatureInfo>
            {
                new FeatureInfo(FeatureType.ExcludeProperties, Strings.FeatureNameExcludeProperties, Strings.FeatureDescriptionExcludeProperties),
                new FeatureInfo(FeatureType.ExcludeTexture, Strings.FeatureNameExcludeTexture, Strings.FeatureDescriptionExcludeTexture, true, false),
                new FeatureInfo(FeatureType.ExcludeLines, Strings.FeatureNameExcludeLines, Strings.FeatureDescriptionExcludeLines),
                new FeatureInfo(FeatureType.ExcludePoints, Strings.FeatureNameExcludePoints, Strings.FeatureDescriptionExcludePoints, true, false),
                new FeatureInfo(FeatureType.OnlySelected, Strings.FeatureNameOnlySelected, Strings.FeatureDescriptionOnlySelected),
                new FeatureInfo(FeatureType.GenerateElementData, Strings.FeatureNameGenerateElementData, Strings.FeatureDescriptionGenerateElementData),
                new FeatureInfo(FeatureType.GenerateModelsDb, Strings.FeatureNameGenerateModelsDb, Strings.FeatureDescriptionGenerateModelsDb),
                new FeatureInfo(FeatureType.GenerateThumbnail, Strings.FeatureNameGenerateThumbnail, Strings.FeatureDescriptionGenerateThumbnail),
                new FeatureInfo(FeatureType.ExportHyperlink, Strings.FeatureNameExportHyperlink, Strings.FeatureDescriptionExportHyperlink),
            };

            _VisualStyles = new List<VisualStyleInfo>();

            _VisualStyles.Add(new VisualStyleInfo(@"Colored", Strings.VisualStyleColored + $@"({Strings.TextDefault})", new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, true}
            }));
            _VisualStyles.Add(new VisualStyleInfo(@"Textured", Strings.VisualStyleTextured, new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, false}
            }));
            _VisualStyleDefault = _VisualStyles.First(x => x.Key == @"Colored");

            cbVisualStyle.Items.Clear();

            cbVisualStyle.Items.AddRange(_VisualStyles.Select(x => (object)x).ToArray());

        }

        private void FormExport_Load(object sender, EventArgs e)
        {

#if R2014 || R2015 || R2016
            cbHyperlink.Visible = false;
#endif

            InitUI();

            ProjectList.Items.Clear(); id.Clear(); title.Clear(); label_name.Text = UserName;

            Thread t = new Thread(RefreshProjectList)
            {
                IsBackground = false
            };
            t.Start();
        }

        private void FormExportSvfzip_Shown(object sender, EventArgs e)
        {
        }

        private void cbVisualStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var visualStyle = cbVisualStyle.SelectedItem as VisualStyleInfo;

            if (visualStyle == null) return;

            foreach (var p in visualStyle.Features)
            {
                _Features.FirstOrDefault(x => x.Type == p.Key)?.ChangeSelected(_Features, p.Value);
            }
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
            if (Autodesk.Navisworks.Api.Application.ActiveDocument.Models.Count == 0)
            {
                var message = @"未打开任何模型, 确定要继续吗?";
                if (MessageBox.Show(this, message, Text,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    return;
                }
                return;
            }

            var visualStyle = cbVisualStyle.SelectedItem as VisualStyleInfo;
            if (visualStyle != null)
            {
                foreach (var p in visualStyle.Features)
                {
                    _Features.FirstOrDefault(x => x.Type == p.Key)?.ChangeSelected(_Features, p.Value);
                }
            }


            #region 更新界面选项到 _Features

            void SetFeature(FeatureType featureType, bool selected)
            {
                _Features.FirstOrDefault(x => x.Type == featureType)?.ChangeSelected(_Features, selected);
            }
            SetFeature(FeatureType.ExportHyperlink, cbHyperlink.Checked);

            SetFeature(FeatureType.GenerateThumbnail, cbGenerateThumbnail.Checked);
            SetFeature(FeatureType.GenerateElementData, cbGeneratePropDbJson.Checked);
            SetFeature(FeatureType.GenerateModelsDb, cbGeneratePropDbSqlite.Checked);

            SetFeature(FeatureType.ExcludeProperties, cbExcludeElementProperties.Checked);
            SetFeature(FeatureType.ExcludeLines, cbExcludeLines.Checked);
            SetFeature(FeatureType.ExcludePoints, cbExcludeModelPoints.Checked);
            SetFeature(FeatureType.OnlySelected, cbExcludeUnselectedElements.Checked);

            #endregion

            var isCanncelled = false;
            using (var session = App.CreateSession())
            {
                if (session.IsValid == false)
                {
                    new License().ShowDialog(this);
                    return;
                }

                var config = _Config.Local;
                config.Features = _Features.Where(x => x.Selected).Select(x => x.Type).ToList();
                config.LastTargetPath = TempPath + ModelName + ".svfzip";
                config.VisualStyle = visualStyle?.Key;
                _Config.Save();

                var features = _Features.Where(x => x.Selected && x.Enabled).ToDictionary(x => x.Type, x => true);

                using (var progress = new ProgressHelper(this, Strings.MessageExporting))
                {
                    var cancellationToken = progress.GetCancellationToken();
                    StartExport(config, ExportType.Zip, null, features, false, progress.GetProgressCallback(), cancellationToken);
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
            PostWc.UploadFileAsync(new Uri("http://" + server + ":10086/model/uploadSvfzip"), "post", TempPath + ModelName + ".svfzip");
            PostWc.UploadProgressChanged += PostWc_UploadProgressChanged;
            PostWc.UploadFileCompleted += PostWc_UploadFileCompleted;
        }

        public AddModel _AddModel(string path)
        {
            string AddModelUrl = "http://" + server + "/api.php?m=rvt&a=addModel";

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
            string ReModelUrl = "http://" + server + "/api.php?m=rvt&a=updateModel";

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

            string path = "http://" + server + ":10086/offline/" + svf.filename;

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

            string modelUrl = "http://" + server + "/api.php?m=rvt&a=getProjectList";
            return JsonConvert.DeserializeObject<model>(Encoding.UTF8.GetString(wlyWc.UploadData(modelUrl, Encoding.UTF8.GetBytes(modelData.ToString()))));
        }

        public model GetModelType()
        {
            StringBuilder modelData = new StringBuilder();
            modelData.AppendFormat("{0}={1}&", "adminid", Login.uid);
            modelData.AppendFormat("{0}={1}&", "token", Login.token);
            WebClient wlyWc = new WebClient();
            wlyWc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            string modelUrl = "http://" + server + "/api.php?m=rvt&a=getModelType";
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

            string GetModelUrl = "http://" + server + "/api.php?m=rvt&a=getModelList";
            return JsonConvert.DeserializeObject<GetModel>(Encoding.UTF8.GetString(GetModeltWc.UploadData(GetModelUrl, Encoding.UTF8.GetBytes(GetModelData.ToString()))));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 开始导出
        /// </summary>
        /// <param name="localConfig"></param>
        /// <param name="exportType"></param>
        /// <param name="outputStream"></param>
        /// <param name="features"></param>
        /// <param name="useShareTexture"></param>
        /// <param name="progressCallback"></param>
        /// <param name="cancellationToken"></param>
        private void StartExport(AppLocalConfig localConfig, ExportType exportType, Stream outputStream, Dictionary<FeatureType, bool> features, bool useShareTexture, Action<int> progressCallback, CancellationToken cancellationToken)
        {
            using (var log = new RuntimeLog())
            {
                var config = new ExportConfig();
                config.TargetPath = localConfig.LastTargetPath;
                config.ExportType = exportType;
                config.OutputStream = outputStream;
                config.Features = features?.Keys.ToList() ?? new List<FeatureType>();
                config.Trace = log.Log;

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

                #region Add Plugin - CreateThumbnail
                {
                    var cliPath = Path.Combine(
                        App.GetHomePath(),
                        @"Tools",
                        @"CreateThumbnail",
                        @"CreateThumbnailCLI.exe");
                    if (File.Exists(cliPath))
                    {
                        config.Addins.Add(new ExportPlugin(
                            FeatureType.GenerateThumbnail,
                            cliPath,
                            new[] { @"-i", config.TargetPath }
                        ));
                    }
                }
                #endregion

                Exporter.ExportToSvf(config, x => progressCallback?.Invoke((int)x), cancellationToken);
            }
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            new License().ShowDialog(this);
        }


        private void InitUI()
        {
            var config = _Config.Local;

            if (config.Features != null && config.Features.Count > 0)
            {
                foreach (var featureType in config.Features)
                {
                    _Features.FirstOrDefault(x => x.Type == featureType)?.ChangeSelected(_Features, true);
                }
            }

            bool IsAllowFeature(FeatureType feature)
            {
                return _Features.Any(x => x.Type == feature && x.Selected);
            }

            #region 基本
            {
                //视觉样式
                var visualStyle = _VisualStyles.FirstOrDefault(x => x.Key == config.VisualStyle) ??
                                  _VisualStyleDefault;
                foreach (var p in visualStyle.Features)
                {
                    _Features.FirstOrDefault(x => x.Type == p.Key)?.ChangeSelected(_Features, p.Value);
                }
                cbVisualStyle.SelectedItem = visualStyle;
            }
            #endregion

            #region 包含
            {
                toolTip1.SetToolTip(cbHyperlink, Strings.FeatureDescriptionExportHyperlink);

                cbHyperlink.Checked = IsAllowFeature(FeatureType.ExportHyperlink);

            }
            #endregion

            #region 生成
            {
                toolTip1.SetToolTip(cbGenerateThumbnail, Strings.FeatureDescriptionGenerateThumbnail);
                toolTip1.SetToolTip(cbGeneratePropDbJson, Strings.FeatureDescriptionGenerateElementData);
                toolTip1.SetToolTip(cbGeneratePropDbSqlite, Strings.FeatureDescriptionGenerateModelsDb);

                if (IsAllowFeature(FeatureType.GenerateThumbnail))
                {
                    cbGenerateThumbnail.Checked = true;
                }

                if (IsAllowFeature(FeatureType.GenerateElementData))
                {
                    cbGeneratePropDbJson.Checked = true;
                }

                if (IsAllowFeature(FeatureType.GenerateModelsDb))
                {
                    cbGeneratePropDbSqlite.Checked = true;
                }
            }
            #endregion

            #region 排除
            {
                toolTip1.SetToolTip(cbExcludeElementProperties, Strings.FeatureDescriptionExcludeProperties);
                toolTip1.SetToolTip(cbExcludeLines, Strings.FeatureDescriptionExcludeLines);
                toolTip1.SetToolTip(cbExcludeModelPoints, Strings.FeatureDescriptionExcludePoints);
                toolTip1.SetToolTip(cbExcludeUnselectedElements, Strings.FeatureDescriptionOnlySelected);

                if (IsAllowFeature(FeatureType.ExcludeProperties))
                {
                    cbExcludeElementProperties.Checked = true;
                }

                if (IsAllowFeature(FeatureType.ExcludeLines))
                {
                    cbExcludeLines.Checked = true;
                }

                if (IsAllowFeature(FeatureType.ExcludePoints))
                {
                    cbExcludeModelPoints.Checked = true;
                }

                if (IsAllowFeature(FeatureType.OnlySelected))
                {
                    cbExcludeUnselectedElements.Checked = true;
                }
            }
            #endregion
        }


        private class VisualStyleInfo
        {
            public string Key { get; }

            private string Text { get; }

            public Dictionary<FeatureType, bool> Features { get; }

            public VisualStyleInfo(string key, string text, Dictionary<FeatureType, bool> features)
            {
                Key = key;
                Text = text;
                Features = features;
            }

            #region Overrides of Object

            public override string ToString()
            {
                return Text;
            }

            #endregion
        }


        private class ComboItemInfo
        {
            public int Value { get; }

            private string Text { get; }

            public ComboItemInfo(int value, string text)
            {
                Value = value;
                Text = text;
            }

            #region Overrides of Object

            public override string ToString()
            {
                return Text;
            }

            #endregion
        }

        private void btnResetOptions_Click(object sender, EventArgs e)
        {
            SetType = 0; AddRadioButton.Checked = true; Model.Text = string.Empty;
            cbVisualStyle.SelectedItem = _VisualStyleDefault;

            cbHyperlink.Checked = false;
            cbGenerateThumbnail.Checked = true;
            cbGeneratePropDbSqlite.Checked = true;
            cbGeneratePropDbJson.Checked = false;

            cbExcludeElementProperties.Checked = false;
            cbExcludeLines.Checked = false;
            cbExcludeModelPoints.Checked = false;
            cbExcludeUnselectedElements.Checked = false;
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
    }
}
