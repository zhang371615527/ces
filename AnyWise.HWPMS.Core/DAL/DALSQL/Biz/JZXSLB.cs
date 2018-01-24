using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyWise.HWPMS.Core.DAL.DALSQL
{
    class JZXSLB
    {
    }
}
namespace AnyWise.HWPMS.DALSQL
{
    using System;
    using System.Collections;
    using System.Data;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class JZXSLB : BaseDALSQL<JZXSLBInfo>, IBaseDAL<JZXSLBInfo>, IJZXSLB
    {
        public JZXSLB()
            : base("tb_JZXSLB", "ID")
        {
            base.sortField = "Sort";
            base.IsDescending = false;
        }

        protected override JZXSLBInfo DataReaderToEntity(IDataReader dataReader)
        {
            JZXSLBInfo info = new JZXSLBInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.PID = reader.GetString("PID");
            info.Code = reader.GetString("Code");
            info.Name = reader.GetString("Name");
            info.DictCode = reader.GetString("DictCode");
            info.HISCode = reader.GetString("HISCode");
            info.Sort = reader.GetInt32("Sort");
            info.LayerNumber = reader.GetInt32("LayerNumber");
            info.Note = reader.GetString("Note");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Creator = reader.GetString("Creator");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Editor = reader.GetString("Editor");
            return info;
        }

        protected override Hashtable GetHashByEntity(JZXSLBInfo obj)
        {
            JZXSLBInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("PID", info.PID);
            hashtable.Add("Code", info.Code);
            hashtable.Add("Name", info.Name);
            hashtable.Add("DictCode", info.DictCode);
            hashtable.Add("HISCode", info.HISCode);
            hashtable.Add("Sort", info.Sort);
            hashtable.Add("LayerNumber", info.LayerNumber);
            hashtable.Add("Note", info.Note);
            hashtable.Add("CreateTime", info.CreateTime);
            hashtable.Add("Creator", info.Creator);
            hashtable.Add("EditTime", info.EditTime);
            hashtable.Add("Editor", info.Editor);
            return hashtable;
        }

        public static JZXSLB Instance
        {
            get
            {
                return new JZXSLB();
            }
        }
    }
}