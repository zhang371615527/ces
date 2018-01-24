namespace AnyWise.HWPMS.DALSQL
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class SystemType : BaseDALSQL<SystemTypeInfo>, IBaseDAL<SystemTypeInfo>, ISystemType
    {
        public SystemType() : base("T_ACL_SystemType", "OID")
        {
            base.SortField = "OID";
        }

        protected override SystemTypeInfo DataReaderToEntity(IDataReader dataReader)
        {
            SystemTypeInfo info = new SystemTypeInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.OID = reader.GetString("OID");
            info.Name = reader.GetString("Name");
            info.CustomID = reader.GetString("CustomID");
            info.Authorize = reader.GetString("Authorize");
            info.Note = reader.GetString("Note");
            return info;
        }


        protected override Hashtable GetHashByEntity(SystemTypeInfo obj)
        {
            SystemTypeInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("OID", info.OID);
            hashtable.Add("Name", info.Name);
            hashtable.Add("CustomID", info.CustomID);
            hashtable.Add("Authorize", info.Authorize);
            hashtable.Add("Note", info.Note);
            return hashtable;
        }

        public SystemTypeInfo imethod_1(string oid)
        {
            string condition = string.Format("OID='{0}'", oid);
            return base.FindSingle(condition);
        }

        public bool VerifySystem(string serialNumber, string typeID, int authorizeAmount)
        {
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = null;
            bool flag = false;
            string str = string.Format("SELECT Count(ID) As Records FROM T_ACL_SystemAuthorize WHERE SystemType_OID='{0}' ", typeID);
            sqlStringCommand = database.GetSqlStringCommand(str);
            int num = Convert.ToInt32(database.ExecuteScalar(sqlStringCommand).ToString());
            if (num <= authorizeAmount)
            {
                str = string.Format("SELECT * FROM T_ACL_SystemAuthorize WHERE Content='{0}'  And SystemType_OID='{1}' ", serialNumber, typeID);
                sqlStringCommand = database.GetSqlStringCommand(str);
                using (IDataReader reader = database.ExecuteReader(sqlStringCommand))
                {
                    flag = reader.Read();
                    reader.Close();
                }
                if (!flag && (flag = num < authorizeAmount))
                {
                    str = string.Format("INSERT INTO T_ACL_SystemAuthorize (SystemType_OID,Content) VALUES ('{0}', '{1}') ", typeID, serialNumber);
                    sqlStringCommand = database.GetSqlStringCommand(str);
                    database.ExecuteNonQuery(sqlStringCommand);
                }
            }
            return flag;
        }

        public static SystemType Instance
        {
            get
            {
                return new SystemType();
            }
        }
    }
}

