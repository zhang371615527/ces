namespace AnyWise.HWPMS.DALSQL
{
    using System;
    using System.Collections;
    using System.Data;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class JZXSZD : BaseDALSQL<JZXSZDInfo>, IBaseDAL<JZXSZDInfo>, IJZXSZD
    {
        public JZXSZD()
            : base("tb_JZXSZD", "ID")
        {
            base.sortField = "Sort";
            base.IsDescending = false;
        }

        protected override JZXSZDInfo DataReaderToEntity(IDataReader dataReader)
        {
            JZXSZDInfo info = new JZXSZDInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.JZXSLB_ID = reader.GetString("JZXSLB_ID");
            info.Code = reader.GetString("Code");
            info.Name = reader.GetString("Name");
            info.DictCode = reader.GetString("DictCode");
            info.HISCode = reader.GetString("HISCode");
            info.Value = reader.GetDecimal("Value");
            info.Sort = reader.GetInt32("Sort");
            info.Enabled = reader.GetString("Enabled");
            info.Note = reader.GetString("Note");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Creator = reader.GetString("Creator");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Editor = reader.GetString("Editor");
            return info;
        }

        protected override Hashtable GetHashByEntity(JZXSZDInfo obj)
        {
            JZXSZDInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("JZXSLB_ID", info.JZXSLB_ID);
            hashtable.Add("Code", info.Code);
            hashtable.Add("Name", info.Name);
            hashtable.Add("DictCode", info.DictCode);
            hashtable.Add("HISCode", info.HISCode);
            hashtable.Add("Value", info.Value);
            hashtable.Add("Sort", info.Sort);
            hashtable.Add("Enabled", info.Enabled);
            hashtable.Add("Note", info.Note);
            hashtable.Add("CreateTime", info.CreateTime);
            hashtable.Add("Creator", info.Creator);
            hashtable.Add("EditTime", info.EditTime);
            hashtable.Add("Editor", info.Editor);
            return hashtable;
        }

        public static JZXSZD Instance
        {
            get
            {
                return new JZXSZD();
            }
        }
    }
}

