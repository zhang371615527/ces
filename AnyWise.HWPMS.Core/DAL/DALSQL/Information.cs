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

    public class Information : BaseDALSQL<InformationInfo>, IBaseDAL<InformationInfo>, IInformation
    {
        public Information() : base("TB_Information", "ID")
        {
            base.sortField = "EditTime";
            base.IsDescending = true;
        }

        protected override InformationInfo DataReaderToEntity(IDataReader dataReader)
        {
            InformationInfo info = new InformationInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetString("ID");
            info.Title = reader.GetString("Title");
            info.Content = reader.GetString("Content");
            info.Attachment_GUID = reader.GetString("Attachment_GUID");
            info.Category = this.method_3(reader.GetString("CATEGORY"));
            info.SubType = reader.GetString("SubType");
            info.Editor = reader.GetString("Editor");
            info.EditTime = reader.GetDateTime("EditTime");
            info.IsChecked = reader.GetInt32("IsChecked");
            info.CheckUser = reader.GetString("CheckUser");
            info.CheckTime = reader.GetDateTime("CheckTime");
            info.ForceExpire = reader.GetInt32("ForceExpire");
            info.TimeOut = reader.GetDateTime("TimeOut");
            return info;
        }

        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("ID", "");
            dictionary.Add("Title", "标题");
            dictionary.Add("Content", "内容");
            dictionary.Add("Attachment_GUID", "附件GUID");
            dictionary.Add("Category", "大类名称");
            dictionary.Add("SubType", "子类名称");
            dictionary.Add("Editor", "编辑者");
            dictionary.Add("EditTime", "编辑时间");
            dictionary.Add("IsChecked", "是否审批通过");
            dictionary.Add("CheckUser", "审批者");
            dictionary.Add("CheckTime", "审批时间");
            dictionary.Add("ForceExpire", "是否强制过期");
            dictionary.Add("TimeOut", "过期截止时间");
            return dictionary;
        }

        protected override Hashtable GetHashByEntity(InformationInfo obj)
        {
            InformationInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ID", info.ID);
            hashtable.Add("Title", info.Title);
            hashtable.Add("Content", info.Content);
            hashtable.Add("Attachment_GUID", info.Attachment_GUID);
            hashtable.Add("Category", info.Category.ToString());
            hashtable.Add("SubType", info.SubType);
            hashtable.Add("Editor", info.Editor);
            hashtable.Add("EditTime", info.EditTime);
            hashtable.Add("IsChecked", info.IsChecked);
            hashtable.Add("CheckUser", info.CheckUser);
            hashtable.Add("CheckTime", info.CheckTime);
            hashtable.Add("ForceExpire", info.ForceExpire);
            hashtable.Add("TimeOut", info.TimeOut);
            return hashtable;
        }

        public DataTable GetMyInformation(int userId, InformationCategory infoType)
        {
            string str = string.Format("select INFORMATION_ID from TB_InformationStatus \r\n            where USER_ID='{0}' and CATEGORY='{1}' and STATUS=1 ", userId, infoType.ToString());
            string sql = string.Format(" SELECT ID, TITLE, ATTACHMENT_GUID, EDITOR, EDITTIME FROM TB_INFORMATION \r\n            WHERE Category='{2}' \r\n            AND (ID NOT IN ({0})  OR (ForceExpire=1 AND TIME_OUT>'{1}') ) \r\n            ORDER BY EDITTIME DESC", str, DateTime.Now.ToShortDateString(), infoType.ToString());
            return this.SqlTable(sql);
        }

        private InformationCategory method_3(string string_0)
        {
            InformationCategory category = InformationCategory.const_4;
            try
            {
                category = (InformationCategory) Enum.Parse(typeof(InformationCategory), string_0);
            }
            catch
            {
            }
            return category;
        }

        public static Information Instance
        {
            get
            {
                return new Information();
            }
        }
    }
}

