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

    public class InformationStatus : BaseDALSQL<InformationStatusInfo>, IBaseDAL<InformationStatusInfo>, GInterface0
    {
        public InformationStatus() : base("TB_InformationStatus", "ID")
        {
        }

        public bool CheckStatus(string UserID, InformationCategory InfoType, string InfoID, int Status)
        {
            return base.IsExistRecord(string.Format("USER_ID='{0}' and Category='{1}' and Information_ID='{2}' and STATUS={3}", new object[] { UserID, InfoType.ToString(), InfoID, Status }));
        }

        protected override InformationStatusInfo DataReaderToEntity(IDataReader dataReader)
        {
            InformationStatusInfo info = new InformationStatusInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetString("ID");
            info.Category = reader.GetString("Category");
            info.Information_ID = reader.GetString("Information_ID");
            info.Status = reader.GetInt32("Status");
            info.User_ID = reader.GetString("User_ID");
            return info;
        }

        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("ID", "");
            dictionary.Add("Category", "信息类型");
            dictionary.Add("Information_ID", "信息ID");
            dictionary.Add("Status", "阅读状态");
            dictionary.Add("User_ID", "用户ID");
            return dictionary;
        }

        protected override Hashtable GetHashByEntity(InformationStatusInfo obj)
        {
            InformationStatusInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ID", info.ID);
            hashtable.Add("Category", info.Category);
            hashtable.Add("Information_ID", info.Information_ID);
            hashtable.Add("Status", info.Status);
            hashtable.Add("User_ID", info.User_ID);
            return hashtable;
        }

        public void SetStatus(string UserID, InformationCategory InfoType, string InfoID, int Status)
        {
            InformationStatusInfo info;
            if (!this.IsExistRecord(string.Format("USER_ID='{0}' and Category='{1}' and Information_ID='{2}'", UserID, InfoType, InfoID)))
            {
                info = new InformationStatusInfo {
                    User_ID = UserID,
                    Category = InfoType.ToString(),
                    Information_ID = InfoID,
                    Status = Status
                };
                base.Insert(info);
            }
            else
            {
                info = this.FindSingle(string.Format("USER_ID='{0}' and Category='{1}' and Information_ID='{2}'", UserID, InfoType, InfoID));
                info.Status = Status;
                base.Update(info, info.ID);
            }
        }

        public static InformationStatus Instance
        {
            get
            {
                return new InformationStatus();
            }
        }
    }
}

