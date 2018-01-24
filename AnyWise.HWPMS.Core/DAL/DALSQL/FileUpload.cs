namespace AnyWise.HWPMS.DALSQL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class FileUpload : BaseDALSQL<FileUploadInfo>, IBaseDAL<FileUploadInfo>, IFileUpload
    {
        public FileUpload() : base("TB_FileUpload", "ID")
        {
            base.sortField = "AddTime";
        }

        protected override FileUploadInfo DataReaderToEntity(IDataReader dataReader)
        {
            FileUploadInfo info = new FileUploadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetString("ID");
            info.Owner_ID = reader.GetString("Owner_ID");
            info.AttachmentGUID = reader.GetString("AttachmentGUID");
            info.FileName = reader.GetString("FileName");
            info.BasePath = reader.GetString("BasePath");
            info.SavePath = reader.GetString("SavePath");
            info.Category = reader.GetString("Category");
            info.FileSize = reader.GetInt32("FileSize");
            info.FileExtend = reader.GetString("FileExtend");
            info.Editor = reader.GetString("Editor");
            info.AddTime = reader.GetDateTime("AddTime");
            info.DeleteFlag = reader.GetInt32("DeleteFlag");
            return info;
        }

        public List<FileUploadInfo> GetByAttachGUID(string attachmentGUID)
        {
            if (string.IsNullOrEmpty(attachmentGUID))
            {
                throw new ArgumentException("附件组GUID不能为空", attachmentGUID);
            }
            string condition = string.Format("AttachmentGUID='{0}' ", attachmentGUID);
            return this.Find(condition);
        }

        protected override Hashtable GetHashByEntity(FileUploadInfo obj)
        {
            FileUploadInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ID", info.ID);
            hashtable.Add("Owner_ID", info.Owner_ID);
            hashtable.Add("AttachmentGUID", info.AttachmentGUID);
            hashtable.Add("FileName", info.FileName);
            hashtable.Add("BasePath", info.BasePath);
            hashtable.Add("SavePath", info.SavePath);
            hashtable.Add("Category", info.Category);
            hashtable.Add("FileSize", info.FileSize);
            hashtable.Add("FileExtend", info.FileExtend);
            hashtable.Add("Editor", info.Editor);
            hashtable.Add("AddTime", info.AddTime);
            hashtable.Add("DeleteFlag", info.DeleteFlag);
            return hashtable;
        }

        public static FileUpload Instance
        {
            get
            {
                return new FileUpload();
            }
        }
    }
}

