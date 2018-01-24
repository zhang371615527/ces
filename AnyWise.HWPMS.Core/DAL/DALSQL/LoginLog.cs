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

    public class LoginLog : BaseDALSQL<LoginLogInfo>, IBaseDAL<LoginLogInfo>, ILoginLog
    {
        public LoginLog() : base("T_ACL_LoginLog", "ID")
        {
            base.sortField = "LastUpdated";
        }

        protected override LoginLogInfo DataReaderToEntity(IDataReader dataReader)
        {
            LoginLogInfo info = new LoginLogInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.User_ID = reader.GetString("User_ID");
            info.LoginName = reader.GetString("LoginName");
            info.FullName = reader.GetString("FullName");
            info.Note = reader.GetString("Note");
            info.IPAddress = reader.GetString("IPAddress");
            info.MacAddress = reader.GetString("MacAddress");
            info.LastUpdated = reader.GetDateTime("LastUpdated");
            info.SystemType_ID = reader.GetString("SystemType_ID");
            info.Company_ID = reader.GetString("Company_ID");
            info.CompanyName = reader.GetString("CompanyName");
            return info;
        }

        protected override Hashtable GetHashByEntity(LoginLogInfo obj)
        {
            LoginLogInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("User_ID", info.User_ID);
            hashtable.Add("LoginName", info.LoginName);
            hashtable.Add("FullName", info.FullName);
            hashtable.Add("Note", info.Note);
            hashtable.Add("IPAddress", info.IPAddress);
            hashtable.Add("MacAddress", info.MacAddress);
            hashtable.Add("LastUpdated", info.LastUpdated);
            hashtable.Add("SystemType_ID", info.SystemType_ID);
            hashtable.Add("Company_ID", info.Company_ID);
            hashtable.Add("CompanyName", info.CompanyName);
            return hashtable;
        }

        public LoginLogInfo GetLastLoginInfo(string userId)
        {
            string sql = string.Format("Select Top 2 * from {0} where User_ID='{1}' order by LastUpdated desc", base.tableName, userId);
            List<LoginLogInfo> list = this.GetList(sql, null);
            if (list.Count == 2)
            {
                return list[1];
            }
            return null;
        }

        public static LoginLog Instance
        {
            get
            {
                return new LoginLog();
            }
        }
    }
}

