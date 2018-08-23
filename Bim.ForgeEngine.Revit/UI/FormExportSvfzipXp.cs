using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Bimangle.ForgeEngine.Revit;
using Bimangle.ForgeEngine.Revit.Core;
using Bimcc.BimEngine.Revit.Config;
using Bimcc.BimEngine.Revit.Core;
using Bimcc.BimEngine.Revit.Helpers;
using Bimcc.BimEngine.Revit.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using static Bimcc.BimEngine.Revit.UI.Login;
using Form = System.Windows.Forms.Form;

namespace Bimcc.BimEngine.Revit.UI
{
    partial class FormExportSvfzipXp : Form
    {
        public static int SetType;

        public string modelName;

        public string modelType;

        public string pid;

        public string option_id;

        public string id;

        public List<data> datas;

        public static string TempPath = Path.GetTempPath();

        private readonly UIDocument _UIDocument;
        private readonly View3D _View;
        private readonly AppConfig _Config;
        private readonly Dictionary<int, bool> _ElementIds;
        private readonly List<FeatureInfo> _Features;
        private readonly List<VisualStyleInfo> _VisualStyles;
        private readonly VisualStyleInfo _VisualStyleDefault;
        private readonly List<ComboItemInfo> _LevelOfDetails;
        private readonly ComboItemInfo _LevelOfDetailDefault;

        public FormExportSvfzipXp()
        {
            InitializeComponent();
        }

        public FormExportSvfzipXp(UIDocument uidoc, View3D view, AppConfig config, Dictionary<int, bool> elementIds)
            : this()
        {
            _UIDocument = uidoc;
            _View = view;
            _Config = config;
            _ElementIds = elementIds;

            _Features = new List<FeatureInfo>
            {
                new FeatureInfo(FeatureType.ExcludeProperties, Strings.FeatureNameExcludeProperties, Strings.FeatureDescriptionExcludeProperties),
                new FeatureInfo(FeatureType.ExcludeTexture, Strings.FeatureNameExcludeTexture, Strings.FeatureDescriptionExcludeTexture, true, false),
                new FeatureInfo(FeatureType.ExcludeLines, Strings.FeatureNameExcludeLines, Strings.FeatureDescriptionExcludeLines),
                new FeatureInfo(FeatureType.ExcludePoints, Strings.FeatureNameExcludePoints, Strings.FeatureDescriptionExcludePoints, true, false),
                new FeatureInfo(FeatureType.UseLevelCategory, Strings.FeatureNameUseLevelCategory, Strings.FeatureDescriptionUseLevelCategory),
                new FeatureInfo(FeatureType.UseNwLevelCategory, Strings.FeatureNameUseNwLevelCategory, Strings.FeatureDescriptionUseNwLevelCategory),
                new FeatureInfo(FeatureType.UseBoundLevelCategory, Strings.FeatureNameUseBoundLevelCategory, Strings.FeatureDescriptionUseBoundLevelCategory),
                new FeatureInfo(FeatureType.OnlySelected, Strings.FeatureNameOnlySelected, Strings.FeatureDescriptionOnlySelected),
                new FeatureInfo(FeatureType.GenerateElementData, Strings.FeatureNameGenerateElementData, Strings.FeatureDescriptionGenerateElementData),
                new FeatureInfo(FeatureType.ExportGrids, Strings.FeatureNameExportGrids, Strings.FeatureDescriptionExportGrids),
                new FeatureInfo(FeatureType.ExportRooms, Strings.FeatureNameExportRooms, Strings.FeatureDescriptionExportRooms),
                new FeatureInfo(FeatureType.ConsolidateGroup, Strings.FeatureNameConsolidateGroup, Strings.FeatureDescriptionConsolidateGroup),
                new FeatureInfo(FeatureType.ConsolidateAssembly, Strings.FeatureNameConsolidateAssembly, Strings.FeatureDescriptionConsolidateAssembly),
                new FeatureInfo(FeatureType.Wireframe, Strings.FeatureNameWireframe, Strings.FeatureDescriptionWireframe, true, false),
                new FeatureInfo(FeatureType.Gray, Strings.FeatureNameGray, Strings.FeatureDescriptionGray, true, false),
                new FeatureInfo(FeatureType.GenerateModelsDb, Strings.FeatureNameGenerateModelsDb, Strings.FeatureDescriptionGenerateModelsDb),
                new FeatureInfo(FeatureType.GenerateThumbnail, Strings.FeatureNameGenerateThumbnail, Strings.FeatureDescriptionGenerateThumbnail),
                new FeatureInfo(FeatureType.UseCurrentViewport, Strings.FeatureNameUseCurrentViewport, Strings.FeatureDescriptionUseCurrentViewport),
                new FeatureInfo(FeatureType.UseViewOverrideGraphic, Strings.FeatureNameUseViewOverrideGraphic, Strings.FeatureDescriptionUseViewOverrideGraphic, true, false),
                new FeatureInfo(FeatureType.UseBasicRenderColor, string.Empty, string.Empty, true, false),
                new FeatureInfo(FeatureType.Export2DViewOnlySheet, Strings.FeatureNameExport2DViewOnlySheet, Strings.FeatureDescriptionExport2DViewOnlySheet),
                new FeatureInfo(FeatureType.Export2DViewAll, Strings.FeatureNameExport2DViewAll, Strings.FeatureDescriptionExport2DViewAll),
            };

            _VisualStyles = new List<VisualStyleInfo>();
            _VisualStyles.Add(new VisualStyleInfo(@"Wireframe", Strings.VisualStyleWireframe, new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, true},
                {FeatureType.Wireframe, true},
                {FeatureType.UseViewOverrideGraphic, false},
                {FeatureType.UseBasicRenderColor, false},
                {FeatureType.Gray, false}
            }));
            _VisualStyles.Add(new VisualStyleInfo(@"Gray", Strings.VisualStyleGray, new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, true},
                {FeatureType.Wireframe, false},
                {FeatureType.UseViewOverrideGraphic, false},
                {FeatureType.UseBasicRenderColor, false},
                {FeatureType.Gray, true}
            }));
            _VisualStyles.Add(new VisualStyleInfo(@"Colored", Strings.VisualStyleColored, new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, true},
                {FeatureType.Wireframe, false},
                {FeatureType.UseViewOverrideGraphic, true},
                {FeatureType.UseBasicRenderColor, false},
                {FeatureType.Gray, false}
            }));
            _VisualStyles.Add(new VisualStyleInfo(@"Textured", Strings.VisualStyleTextured + $@"({Strings.TextDefault})", new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, false},
                {FeatureType.Wireframe, false},
                {FeatureType.UseViewOverrideGraphic, false},
                {FeatureType.UseBasicRenderColor, true},
                {FeatureType.Gray, false}
            }));
            _VisualStyles.Add(new VisualStyleInfo(@"Realistic", Strings.VisualStyleRealistic, new Dictionary<FeatureType, bool>
            {
                {FeatureType.ExcludeTexture, false},
                {FeatureType.Wireframe, false},
                {FeatureType.UseViewOverrideGraphic, false},
                {FeatureType.UseBasicRenderColor, false},
                {FeatureType.Gray, false}
            }));
            _VisualStyleDefault = _VisualStyles.First(x => x.Key == @"Textured");

            _LevelOfDetails = new List<ComboItemInfo>();
            _LevelOfDetails.Add(new ComboItemInfo(-1, Strings.TextAuto));
            for (var i = 0; i <= 15; i++)
            {
                string text;
                switch (i)
                {
                    case 0:
                        text = $@"{i} ({Strings.TextLowest})";
                        break;
                    case 8:
                        text = $@"{i} ({Strings.TextNormal})";
                        break;
                    case 15:
                        text = $@"{i} ({Strings.TextHighest})";
                        break;
                    default:
                        text = i.ToString();
                        break;
                }

                _LevelOfDetails.Add(new ComboItemInfo(i, text));
            }
            _LevelOfDetailDefault = _LevelOfDetails.Find(x => x.Value == -1);

            cbVisualStyle.Items.Clear();
            cbVisualStyle.Items.AddRange(_VisualStyles.Select(x => (object)x).ToArray());

            cbLevelOfDetail.Items.Clear();
            cbLevelOfDetail.Items.AddRange(_LevelOfDetails.Select(x => (object)x).ToArray());
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            InitUI();

            GetAllData(token);
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

        /// <summary>
        /// 开始导出
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="view"></param>
        /// <param name="localConfig"></param>
        /// <param name="exportType"></param>
        /// <param name="outputStream"></param>
        /// <param name="features"></param>
        /// <param name="useShareTexture"></param>
        /// <param name="progressCallback"></param>
        /// <param name="cancellationToken"></param>
        private void StartExport(UIDocument uidoc, View3D view, AppLocalConfig localConfig, ExportType exportType, Stream outputStream, Dictionary<FeatureType, bool> features, bool useShareTexture, Action<int> progressCallback, CancellationToken cancellationToken)
        {
            using (var log = new RuntimeLog())
            {
                var config = new ExportConfig();
                config.TargetPath = localConfig.LastTargetPath;
                config.ExportType = exportType;
                config.UseShareTexture = useShareTexture;
                config.OutputStream = outputStream;
                config.Features = features ?? new Dictionary<FeatureType, bool>();
                config.Trace = log.Log;
                config.ElementIds = (features?.FirstOrDefault(x => x.Key == FeatureType.OnlySelected).Value ?? false)
                    ? _ElementIds
                    : null;
                config.LevelOfDetail = localConfig.LevelOfDetail;

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

                Exporter.ExportToSvf(uidoc, view, config, x => progressCallback?.Invoke((int)x), cancellationToken);
            }
        }

        private void InitUI()
        {
            label_user.Text = user_name;

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

            toolTip1.SetToolTip(cbUseCurrentViewport, Strings.FeatureDescriptionUseCurrentViewport);
            cbUseCurrentViewport.Checked = IsAllowFeature(FeatureType.UseCurrentViewport);

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

                //详细程度
                var levelOfDetail = _LevelOfDetails.FirstOrDefault(x => x.Value == config.LevelOfDetail) ??
                                    _LevelOfDetailDefault;
                cbLevelOfDetail.SelectedItem = levelOfDetail;
            }
            #endregion

            #region 二维视图
            {
                toolTip1.SetToolTip(rb2DViewsAll, Strings.FeatureDescriptionExport2DViewAll);
                toolTip1.SetToolTip(rb2DViewsOnlySheet, Strings.FeatureDescriptionExport2DViewOnlySheet);

                if (IsAllowFeature(FeatureType.Export2DViewAll))
                {
                    rb2DViewsAll.Checked = true;
                }
                else if (IsAllowFeature(FeatureType.Export2DViewOnlySheet))
                {
                    rb2DViewsOnlySheet.Checked = true;
                }
                else
                {
                    rb2DViewsBypass.Checked = true;
                }
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

            #region 包含
            {
                toolTip1.SetToolTip(cbIncludeGrids, Strings.FeatureDescriptionExportGrids);
                toolTip1.SetToolTip(cbIncludeRooms, Strings.FeatureDescriptionExportRooms);

                if (IsAllowFeature(FeatureType.ExportGrids))
                {
                    cbIncludeGrids.Checked = true;
                }

                if (IsAllowFeature(FeatureType.ExportRooms))
                {
                    cbIncludeRooms.Checked = true;
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

            #region 融合
            {
                toolTip1.SetToolTip(cbConsolidateArrayGroup, Strings.FeatureDescriptionConsolidateGroup);
                toolTip1.SetToolTip(cbConsolidateAssembly, Strings.FeatureDescriptionConsolidateAssembly);

                if (IsAllowFeature(FeatureType.ConsolidateGroup))
                {
                    cbConsolidateArrayGroup.Checked = true;
                }

                if (IsAllowFeature(FeatureType.ConsolidateAssembly))
                {
                    cbConsolidateAssembly.Checked = true;
                }
            }
            #endregion

            #region 按楼层分组
            {
                toolTip1.SetToolTip(rbGroupByLevelDefault, Strings.FeatureDescriptionUseLevelCategory);
                toolTip1.SetToolTip(rbGroupByLevelNavisworks, Strings.FeatureDescriptionUseNwLevelCategory);
                toolTip1.SetToolTip(rbGroupByLevelBoundingBox, Strings.FeatureDescriptionUseBoundLevelCategory);

                if (IsAllowFeature(FeatureType.UseLevelCategory))
                {
                    rbGroupByLevelDefault.Checked = true;
                }
                else if (IsAllowFeature(FeatureType.UseNwLevelCategory))
                {
                    rbGroupByLevelNavisworks.Checked = true;
                }
                else if (IsAllowFeature(FeatureType.UseBoundLevelCategory))
                {
                    rbGroupByLevelBoundingBox.Checked = true;
                }
                else
                {
                    rbGroupByLevelDisable.Checked = true;
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

        private void label_logout_Click(object sender, EventArgs e)
        {
            Close();

            LoginSuccess = false;

            Tools.UpdateSetting("auto", "false");
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (Combobox_modelName.Text == "")
            {
                Tools.ShowMessageBox("请输入模型名称"); return;
            }

            if (Combobox_modelType.Text == "")
            {
                Tools.ShowMessageBox("请选择模型类型"); return;
            }

            if (Combobox_projectName.Text == "")
            {
                Tools.ShowMessageBox("请选择项目名称"); return;
            }

            modelName = Combobox_modelName.Text;

            modelType = Combobox_modelType.Text;

            if (RadioButton_add.Checked)
            {
                SetType = 1;
            }
            else
            {
                SetType = 2;
            }

            Export();
        }

        public void Export()
        {
#if !R2014
            if (CustomExporter.IsRenderingSupported() == false)
            {
                var message = @"检测到当前 Revit 实例对数据导出的支持存在问题, 原因可能是材质库未正确安装。 本次操作可能无法成功执行, 确定要继续吗?";
                if (MessageBox.Show(this, message, Text,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    return;
                }
            }
#endif            
            var visualStyle = cbVisualStyle.SelectedItem as VisualStyleInfo;

            if (visualStyle != null)
            {
                foreach (var p in visualStyle.Features)
                {
                    _Features.FirstOrDefault(x => x.Type == p.Key)?.ChangeSelected(_Features, p.Value);
                }
            }

            var levelOfDetail = (cbLevelOfDetail.SelectedItem as ComboItemInfo) ?? _LevelOfDetailDefault;

            #region 更新界面选项到 _Features

            void SetFeature(FeatureType featureType, bool selected)
            {
                _Features.FirstOrDefault(x => x.Type == featureType)?.ChangeSelected(_Features, selected);
            }

            SetFeature(FeatureType.Export2DViewAll, rb2DViewsAll.Checked);
            SetFeature(FeatureType.Export2DViewOnlySheet, rb2DViewsOnlySheet.Checked);

            SetFeature(FeatureType.GenerateThumbnail, cbGenerateThumbnail.Checked);
            SetFeature(FeatureType.GenerateElementData, cbGeneratePropDbJson.Checked);
            SetFeature(FeatureType.GenerateModelsDb, cbGeneratePropDbSqlite.Checked);

            SetFeature(FeatureType.ExportGrids, cbIncludeGrids.Checked);
            SetFeature(FeatureType.ExportRooms, cbIncludeRooms.Checked);

            SetFeature(FeatureType.ExcludeProperties, cbExcludeElementProperties.Checked);
            SetFeature(FeatureType.ExcludeLines, cbExcludeLines.Checked);
            SetFeature(FeatureType.ExcludePoints, cbExcludeModelPoints.Checked);
            SetFeature(FeatureType.OnlySelected, cbExcludeUnselectedElements.Checked);

            SetFeature(FeatureType.ConsolidateGroup, cbConsolidateArrayGroup.Checked);
            SetFeature(FeatureType.ConsolidateAssembly, cbConsolidateAssembly.Checked);

            SetFeature(FeatureType.UseLevelCategory, rbGroupByLevelDefault.Checked);
            SetFeature(FeatureType.UseNwLevelCategory, rbGroupByLevelNavisworks.Checked);
            SetFeature(FeatureType.UseBoundLevelCategory, rbGroupByLevelBoundingBox.Checked);

            SetFeature(FeatureType.UseCurrentViewport, cbUseCurrentViewport.Checked);

            #endregion

            var isCanncelled = false;

            using (var session = App.CreateSession(Application.licenseKey))
            {
                if (session.IsValid == false)
                {
                    new Plugin_manage().ShowDialog();

                    return;
                }

                #region 保存设置

                var config = _Config.Local;
                config.Features = _Features.Where(x => x.Selected).Select(x => x.Type).ToList();
                config.LastTargetPath = Path.Combine(TempPath, modelName + ".svfzip");
                config.VisualStyle = visualStyle?.Key;
                config.LevelOfDetail = levelOfDetail?.Value ?? -1;
                _Config.Save();

                #endregion

                var features = _Features.Where(x => x.Selected && x.Enabled).ToDictionary(x => x.Type, x => true);

                using (var progress = new ProgressHelper(this, Strings.MessageExporting))
                {
                    var cancellationToken = progress.GetCancellationToken();
                    StartExport(_UIDocument, _View, config, ExportType.Zip, null, features, false, progress.GetProgressCallback(), cancellationToken);
                    isCanncelled = cancellationToken.IsCancellationRequested;
                }

                if (isCanncelled == false)
                {
                    var t = new Thread(UploadFile);
                    t.IsBackground = false;
                    t.Start();

                    Enabled = false;

                    progressBar1.Value = 50;
                }
            }
        }

        public void UploadFile()
        {
            var api = Tools.GetSetting("上传模型");
            if (api == null)
            {
                return;
            }
            try
            {
                var path = Path.Combine(TempPath, modelName + ".svfzip");
                var client = new RestClient(api);
                var form = new MsMultiPartFormData();
                form.AddFormField("token", token);
                var response = Tools.HttpPostData("http://192.168.2.132/api/upload/model/svfzip", form, path);
                var obj = JsonConvert.DeserializeObject(response) as JObject;

                if ((int)obj["status"] == 1)
                {
                    //File.Delete(TempPath + modelName + ".svfzip");

                    progressBar1.Value = 100;

                    if (SetType == 1)
                    {
                        var obj_add = _AddModel(token, obj["objectKey"].ToString(), option_id, modelName, pid);

                        Tools.ShowMessageBox(obj_add["msg"].ToString());
                    }
                    else if (SetType == 2)
                    {
                        var obj_re = _ReModel(token, obj["objectKey"].ToString(), option_id, modelName, pid, id);

                        Tools.ShowMessageBox(obj_re["msg"].ToString());

                    }
                    SetType = 0;

                    Enabled = true;
                }
                else
                {
                    Tools.ShowMessageBox(obj["msg"].ToString());
                }

            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message);
            }
        }

        public JObject _AddModel(string token, string key, string option_id, string name, string pid)
        {
            var api = Tools.GetSetting("新增模型");
            if (api == null)
            {
                return null;
            }
            try
            {
                var client = new RestClient(api);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Postman-Token", "3bbd006d-9d59-4fdd-8c4f-e0b5884e5a60");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "token=" + token + "&key=" + key + "&options_id=" + option_id + "&display_name=" + name + "&pid=" + pid, RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject(response.Content) as JObject;
            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message); return null;
            }

        }

        public JObject _ReModel(string token, string key, string option_id, string name, string pid, string id)
        {
            var api = Tools.GetSetting("修改模型");
            if (api == null)
            {
                return null;
            }
            try
            {
                var client = new RestClient(api);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Postman-Token", "3bbd006d-9d59-4fdd-8c4f-e0b5884e5a60");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "token=" + token + "&key=" + key + "&options_id=" + option_id + "&display_name=" + name + "&pid=" + pid + "&id=" + id, RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject(response.Content) as JObject;
            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message); return null;
            }
        }

        void GetAllData(string token)
        {
            datas = new List<data>();
            var api = Tools.GetSetting("获取数据");
            if (api == null)
            {
                return;
            }
            try
            {
                var client = new RestClient(api + "?token=" + token);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Postman-Token", "62b4ee7d-86d5-4f36-b4d4-9feaac3327d4");
                request.AddHeader("Cache-Control", "no-cache");
                client.ExecuteAsync(request, response =>
                {
                    var obj = JsonConvert.DeserializeObject(response.Content) as JObject;
                    if ((int)obj["status"] == 1)
                    {
                        foreach (var item in obj["data"])
                        {
                            var data = new data();
                            data.id = item["id"].ToString();
                            data.display_name = item["display_name"].ToString();

                            foreach (var item1 in item["options"])
                            {
                                var option = new option();
                                option.id = item1["id"].ToString();
                                option.display_name = item1["display_name"].ToString();

                                foreach (var item2 in item1["models"])
                                {
                                    var model = new model();
                                    model.id = item2["id"].ToString();
                                    model.display_name = item2["display_name"].ToString();
                                    option.models.Add(model);
                                }
                                data.options.Add(option);
                            }
                            datas.Add(data);
                        }

                        Combobox_projectName.Items.Clear();

                        foreach (var item in datas)
                        {
                            Combobox_projectName.Items.Add(item.display_name);
                        }
                        if (Combobox_projectName.Items.Count > 0)
                        {
                            Combobox_projectName.Text = Combobox_projectName.Items[0].ToString();
                        }
                    }
                });
            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            SetType = 0; RadioButton_add.Checked = true; Combobox_modelName.Text = string.Empty;
            cbVisualStyle.SelectedItem = _VisualStyleDefault;
            cbLevelOfDetail.SelectedItem = _LevelOfDetailDefault;

            rb2DViewsOnlySheet.Checked = true;

            cbGenerateThumbnail.Checked = true;
            cbGeneratePropDbSqlite.Checked = true;
            cbGeneratePropDbJson.Checked = false;

            cbIncludeGrids.Checked = false;
            cbIncludeRooms.Checked = false;

            cbExcludeElementProperties.Checked = false;
            cbExcludeLines.Checked = false;
            cbExcludeModelPoints.Checked = false;
            cbExcludeUnselectedElements.Checked = false;

            cbConsolidateArrayGroup.Checked = false;
            cbConsolidateAssembly.Checked = false;

            rbGroupByLevelDisable.Checked = true;

            cbUseCurrentViewport.Checked = false;
        }

        private void button_licence_Click(object sender, EventArgs e)
        {
            new Plugin_manage().ShowDialog();
        }

        private void Combobox_projectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combobox_modelType.Items.Clear();

            foreach (var data in datas)
            {
                if (data.display_name == Combobox_projectName.Text)
                {
                    pid = data.id;

                    foreach (var option in data.options)
                    {
                        Combobox_modelType.Items.Add(option.display_name);
                    }
                }
            }

            if (Combobox_modelType.Items.Count > 0)
            {
                Combobox_modelType.Text = Combobox_modelType.Items[0].ToString();
            }
            else
            {
                Combobox_modelName.Items.Clear(); Combobox_modelName.Text = "";
            }
        }

        private void Combobox_modelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combobox_modelName.Items.Clear();

            foreach (var data in datas)
            {
                if (data.display_name == Combobox_projectName.Text)
                {
                    foreach (var option in data.options)
                    {
                        if (option.display_name == Combobox_modelType.Text)
                        {
                            option_id = option.id;

                            if (RadioButton_modify.Checked)
                            {
                                foreach (var model in option.models)
                                {
                                    Combobox_modelName.Items.Add(model.display_name);
                                }
                            }
                        }
                    }
                }
            }

            if (Combobox_modelName.Items.Count > 0)
            {
                Combobox_modelName.Text = Combobox_modelName.Items[0].ToString();
            }
        }

        private void Combobox_modelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                if (data.display_name == Combobox_projectName.Text)
                {
                    foreach (var option in data.options)
                    {
                        if (option.display_name == Combobox_modelType.Text)
                        {
                            foreach (var model in option.models)
                            {
                                if (model.display_name == Combobox_modelName.Text)
                                {
                                    id = model.id;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RadioButton_add_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_add.Checked)
            {
                Combobox_modelName.DropDownStyle = ComboBoxStyle.DropDown;

                Combobox_modelName.Text = "";

                Combobox_modelName.Items.Clear();
            }
        }

        private void RadioButton_modify_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_modify.Checked)
            {
                Combobox_modelName.Items.Clear();

                GetAllData(token);

                Combobox_modelName.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }

    public class data
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public List<option> options = new List<option>();
    }

    public class option
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public List<model> models = new List<model>();
    }

    public class model
    {
        public string id { get; set; }
        public string display_name { get; set; }
    }
}
