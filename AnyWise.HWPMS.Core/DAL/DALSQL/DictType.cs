namespace AnyWise.HWPMS.DALSQL
{
    using System;
    using System.Collections;
    using System.Data;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class DictType : BaseDALSQL<DictTypeInfo>, IBaseDAL<DictTypeInfo>, IDictType
    {
        public DictType()
            : base("tb_DictType", "ID")
        {
            base.sortField = "Seq";
            base.IsDescending = false;
        }

        protected override DictTypeInfo DataReaderToEntity(IDataReader dataReader)
        {
            DictTypeInfo info = new DictTypeInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.Name = reader.GetString("Name");
            info.Remark = reader.GetString("Remark");
            info.Seq = reader.GetString("Seq");
            info.Editor = reader.GetString("Editor");
            info.LastUpdated = reader.GetDateTime("LastUpdated");
            info.PID = reader.GetString("PID");
            return info;
        }

        protected override Hashtable GetHashByEntity(DictTypeInfo obj)
        {
            DictTypeInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Name", info.Name);
            hashtable.Add("Remark", info.Remark);
            hashtable.Add("Seq", info.Seq);
            hashtable.Add("Editor", info.Editor);
            hashtable.Add("LastUpdated", info.LastUpdated);
            hashtable.Add("PID", info.PID);
            return hashtable;
        }

        public static DictType Instance
        {
            get
            {
                return new DictType();
            }
        }
    }
}

