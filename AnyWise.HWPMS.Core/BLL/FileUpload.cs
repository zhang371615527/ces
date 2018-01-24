namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class FileUpload : BaseBLL<FileUploadInfo>
    {
        public FileUpload()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }

        public override bool Delete(object key)
        {
            FileUploadInfo info = this.FindByID(key);
            if ((info != null) && !string.IsNullOrEmpty(info.SavePath))
            {
                string path = Path.Combine(info.BasePath, info.SavePath.Trim(new char[] { '\\' }));
                if (!Path.IsPathRooted(path))
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    if (File.Exists(path))
                    {
                        try
                        {
                            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine(info.BasePath, "DeletedFiles"));
                            DirectoryUtil.AssertDirExist(filePath);
                            string str3 = Path.Combine(filePath, info.FileName);
                            str3 = this.method_1(str3, 1);
                            File.Move(path, str3);
                        }
                        catch (Exception exception)
                        {
                            LogTextHelper.Error(exception);
                        }
                    }
                }
            }
            return base.Delete(key);
        }

        public bool DeleteByAttachGUID(string attachment_GUID)
        {
            string condition = string.Format("AttachmentGUID ='{0}' ", attachment_GUID);
            foreach (FileUploadInfo info in base.Find(condition))
            {
                this.Delete(info.ID);
            }
            return true;
        }

        public List<FileUploadInfo> GetByAttachGUID(string attachmentGUID)
        {
            IFileUpload baseDal = base.baseDal as IFileUpload;
            return baseDal.GetByAttachGUID(attachmentGUID);
        }

        public string GetFilePath(FileUploadInfo info)
        {
            string fileName = info.FileName;
            string category = info.Category;
            if (string.IsNullOrEmpty(category))
            {
                category = "Photo";
            }
            string path = Path.Combine(info.BasePath, category);
            string str6 = path;
            if (!Path.IsPathRooted(path))
            {
                str6 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
            if (!Directory.Exists(str6))
            {
                Directory.CreateDirectory(str6);
            }
            return Path.Combine(path, fileName);
        }

        private string method_0(FileUploadInfo fileUploadInfo_0)
        {
            string filePath = this.GetFilePath(fileUploadInfo_0);
            string str2 = filePath.Replace(fileUploadInfo_0.BasePath, "").Trim(new char[] { '\\' });
            string str3 = filePath;
            if (!Path.IsPathRooted(filePath))
            {
                str3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }
            str3 = this.method_1(str3, 1);
            FileUtil.CreateFile(str3, fileUploadInfo_0.FileData);
            if (FileUtil.IsExistFile(str3))
            {
                return str2;
            }
            return string.Empty;
        }

        private string method_1(string string_1, int int_0)
        {
            if (FileUtil.IsExistFile(string_1))
            {
                string fileName = FileUtil.GetFileName(string_1, true);
                int length = string_1.LastIndexOf(fileName);
                string str2 = string_1.Substring(0, length);
                string extension = FileUtil.GetExtension(string_1);
                string filePath = string.Format("{0}{1}({2}){3}", new object[] { str2, fileName, int_0, extension });
                if (FileUtil.IsExistFile(filePath))
                {
                    int_0++;
                    return this.method_1(string_1, int_0);
                }
                return filePath;
            }
            return string_1;
        }

        public CommonResult Upload(FileUploadInfo info)
        {
            Exception exception;
            CommonResult result = new CommonResult();
            try
            {
                string fileName = "";
                if (string.IsNullOrEmpty(info.BasePath))
                {
                    string str2 = new AppConfig().AppConfigGet("AttachmentBasePath");
                    if (string.IsNullOrEmpty(str2))
                    {
                        info.BasePath = "UploadFiles";
                    }
                    else
                    {
                        info.BasePath = str2;
                    }
                    fileName = this.method_0(info);
                }
                else
                {
                    fileName = info.FileName;
                }
                if (string.IsNullOrEmpty(fileName))
                {
                    return result;
                }
                info.SavePath = fileName.Trim(new char[] { '\\' });
                info.AddTime = DateTime.Now;
                try
                {
                    bool flag;
                    if (flag = base.Insert(info))
                    {
                        result.Success = flag;
                        return result;
                    }
                    result.ErrorMessage = "数据写入数据库出错。";
                    return result;
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    result.ErrorMessage = exception.Message;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                result.ErrorMessage = exception.Message;
            }
            return result;
        }
    }
}

