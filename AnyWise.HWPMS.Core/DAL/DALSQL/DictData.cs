namespace AnyWise.HWPMS.DALSQL
{
    using System;
    using System.Collections;
    using System.Data;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class DictData : BaseDALSQL<DictDataInfo>, IBaseDAL<DictDataInfo>, IDictData
    {
        public DictData() : base("tb_DictData", "ID")
        {
            base.sortField = "Seq";
            base.IsDescending = false;
        }

        protected override DictDataInfo DataReaderToEntity(IDataReader dataReader)
        {
            DictDataInfo info = new DictDataInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.DictType_ID = reader.GetString("DictType_ID");
            info.Name = reader.GetString("Name");
            info.Value = reader.GetString("Value");
            info.Remark = reader.GetString("Remark");
            info.Seq = reader.GetString("Seq");
            info.Editor = reader.GetString("Editor");
            info.LastUpdated = reader.GetDateTime("LastUpdated");
            return info;
        }

        protected override Hashtable GetHashByEntity(DictDataInfo obj)
        {
            DictDataInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("DictType_ID", info.DictType_ID);
            hashtable.Add("Name", info.Name);
            hashtable.Add("Value", info.Value);
            hashtable.Add("Remark", info.Remark);
            hashtable.Add("Seq", info.Seq);
            hashtable.Add("Editor", info.Editor);
            hashtable.Add("LastUpdated", info.LastUpdated);
            return hashtable;
        }

        public static DictData Instance
        {
            get
            {
                return new DictData();
            }
        }
    }
}

