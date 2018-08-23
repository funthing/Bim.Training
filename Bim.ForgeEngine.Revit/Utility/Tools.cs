using Bimangle.ForgeEngine.Revit;
using Bimcc.BimEngine.Revit.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Bimcc.BimEngine.Revit.Utility
{
    class Tools
    {
        public static string HttpPostData(string url, MsMultiPartFormData form, string filePath, string fileKeyName = "file", int timeOut = 360000)
        {
            string result = "";
            WebRequest request = WebRequest.Create(url);
            request.Timeout = timeOut;
            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] bb = new byte[file.Length];
            file.Read(bb, 0, (int)file.Length);
            file.Close();
            string fileName = Path.GetFileName(filePath);
            form.AddStreamFile(fileKeyName, fileName, bb);
            form.PrepareFormData();
            request.ContentType = "multipart/form-data; boundary=" + form.Boundary;
            request.Method = "POST";
            Stream stream = request.GetRequestStream();
            foreach (var b in form.GetFormData())
            {
                stream.WriteByte(b);
            }
            stream.Close();
            WebResponse response = request.GetResponse();

            using (var httpStreamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
            {
                result = httpStreamReader.ReadToEnd();
            }
            response.Close();
            request.Abort();
            return result;
        }

        public static string DownloadImage(string uri)
        {
            var path = Path.Combine(Path.GetTempPath(), "Bim_user.jpg");

            if (File.Exists(path))
            {
                return path;
            }
            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Postman-Token", "b8f4df43-32bf-4055-b36f-36e993c3211b");
                request.AddHeader("Cache-Control", "no-cache");
                IRestResponse response = client.Execute(request);
                File.WriteAllBytes(path, response.RawBytes);
                return path;
            }
            catch (Exception e)
            {
                Tools.ShowMessageBox(e.Message);
                return null;
            }
        }

        public static BitmapSource GetImage(IntPtr bm)
        {
            BitmapSource bmSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bm,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bmSource;
        }

        public static string GetLicenseKey()
        {
            var filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Bimcc.BimEngine.lic";

            string LicenseKey = string.Empty;

            if (File.Exists(filename))
            {
                LicenseKey = LicenseSession.LoadLicenseKeyFromFile(filename);
            }

            return LicenseKey;
        }

        public static void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string GetSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void UpdateSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            try
            {
                if (config.AppSettings.Settings[key] != null)
                {
                    config.AppSettings.Settings.Remove(key);
                }

                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception) { }
        }

        public static int GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return Convert.ToInt32(ts.TotalSeconds);
        }

        public static string GetRandomString()
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = string.Empty;
            var str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < 10; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        public static string SHA1(string content)
        {
            return SHA1(content, Encoding.UTF8).ToLower();
        }

        public static string SHA1(string content, Encoding encode)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_in = encode.GetBytes(content);
            byte[] bytes_out = sha1.ComputeHash(bytes_in);
            sha1.Dispose();
            string result = BitConverter.ToString(bytes_out);
            result = result.Replace("-", "");
            return result;
        }
    }

    public class MsMultiPartFormData
    {
        private List<byte> formData;
        public String Boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
        private String fieldName = "Content-Disposition: form-data; name=\"{0}\"";
        private String fileContentType = "Content-Type: {0}";
        private String fileField = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"";
        private Encoding encode = Encoding.GetEncoding("UTF-8");
        public MsMultiPartFormData()
        {
            formData = new List<byte>();
        }
        public void AddFormField(String FieldName, String FieldValue)
        {
            String newFieldName = fieldName;
            newFieldName = string.Format(newFieldName, FieldName);
            formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
            formData.AddRange(encode.GetBytes(newFieldName + "\r\n\r\n"));
            formData.AddRange(encode.GetBytes(FieldValue + "\r\n"));
        }
        public void AddFile(String FieldName, String FileName, byte[] FileContent, String ContentType)
        {
            String newFileField = fileField;
            String newFileContentType = fileContentType;
            newFileField = string.Format(newFileField, FieldName, FileName);
            newFileContentType = string.Format(newFileContentType, ContentType);
            formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
            formData.AddRange(encode.GetBytes(newFileField + "\r\n"));
            formData.AddRange(encode.GetBytes(newFileContentType + "\r\n\r\n"));
            formData.AddRange(FileContent);
            formData.AddRange(encode.GetBytes("\r\n"));
        }
        public void AddStreamFile(String FieldName, String FileName, byte[] FileContent)
        {
            AddFile(FieldName, FileName, FileContent, "application/octet-stream");
        }
        public void PrepareFormData()
        {
            formData.AddRange(encode.GetBytes("--" + Boundary + "--"));
        }
        public List<byte> GetFormData()
        {
            return formData;
        }
    }
}
