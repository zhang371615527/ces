namespace AnyWise.HWPMS.DALSQL
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class OU : BaseDALSQL<OUInfo>, IOU
    {
        public OU() : base("T_ACL_OU", "ID")
        {
            base.sortField = "SortCode";
            base.isDescending = false;
        }

        public void AddUser(int userID, int ouID)
        {
            string str = string.Format("INSERT INTO T_ACL_OU_User(User_ID, OU_ID) VALUES({0},{1})", userID, ouID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        protected override OUInfo DataReaderToEntity(IDataReader dataReader)
        {
            OUInfo info = new OUInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.PID = reader.GetInt32("PID");
            info.HandNo = reader.GetString("HandNo");
            info.HISNo = reader.GetString("HISNo");
            info.Name = reader.GetString("Name");
            info.SortCode = reader.GetString("SortCode");
            info.Grade = reader.GetString("Grade");
            info.Category = reader.GetString("Category");
            info.DeptValue = reader.GetDecimal("DeptValue");
            info.Address = reader.GetString("Address");
            info.OuterPhone = reader.GetString("OuterPhone");
            info.InnerPhone = reader.GetString("InnerPhone");
            info.Note = reader.GetString("Note");
            info.Creator = reader.GetString("Creator");
            info.Creator_ID = reader.GetString("Creator_ID");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.Editor_ID = reader.GetString("Editor_ID");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Deleted = reader.GetInt32("Deleted");
            info.Enabled = reader.GetInt32("Enabled");
            info.Company_ID = reader.GetString("Company_ID");
            info.CompanyName = reader.GetString("CompanyName");
            return info;
        }

        public override bool Delete(object key)
        {
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = null;
            DbTransaction transaction = null;
            try
            {
                OUInfo info = this.FindByID(key);
                if (info != null)
                {
                    using (DbConnection connection = database.CreateConnection())
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        string str = string.Format("UPDATE [T_ACL_OU] SET PID={0} Where PID={1}", info.PID, key);
                        sqlStringCommand = database.GetSqlStringCommand(str);
                        database.ExecuteNonQuery(sqlStringCommand, transaction);
                        str = string.Format("Delete From [T_ACL_OU] Where ID={0}", key);
                        sqlStringCommand = database.GetSqlStringCommand(str);
                        database.ExecuteNonQuery(sqlStringCommand, transaction);
                        transaction.Commit();
                    }
                }
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return true;
        }

        protected override Hashtable GetHashByEntity(OUInfo obj)
        {
            OUInfo info = obj;
            Hashtable hash = new Hashtable();
            hash.Add("PID", info.PID);
            hash.Add("HandNo", info.HandNo);
            hash.Add("HISNo", info.HISNo);
            hash.Add("Name", info.Name);
            hash.Add("SortCode", info.SortCode);
            hash.Add("Grade", info.Grade);
            hash.Add("Category", info.Category);
            hash.Add("Address", info.Address);
            hash.Add("DeptValue", info.DeptValue);
            hash.Add("OuterPhone", info.OuterPhone);
            hash.Add("InnerPhone", info.InnerPhone);
            hash.Add("Note", info.Note);
            hash.Add("Creator", info.Creator);
            hash.Add("Creator_ID", info.Creator_ID);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("Editor_ID", info.Editor_ID);
            hash.Add("EditTime", info.EditTime);
            hash.Add("Deleted", info.Deleted);
            hash.Add("Enabled", info.Enabled);
            hash.Add("Company_ID", info.Company_ID);
            hash.Add("CompanyName", info.CompanyName);
            return hash;
        }

        public List<OUInfo> GetOUsByRole(int roleID)
        {
            string sql = "SELECT * FROM T_ACL_OU INNER JOIN T_ACL_OU_Role On [T_ACL_OU].ID=T_ACL_OU_Role.OU_ID WHERE Role_ID = " + roleID;
            return this.GetList(sql, null);
        }

        public List<OUInfo> GetOUsByUser(int userID)
        {
            string sql = "SELECT * FROM T_ACL_OU INNER JOIN T_ACL_OU_User On [T_ACL_OU].ID=T_ACL_OU_User.OU_ID WHERE User_ID = " + userID;
            return this.GetList(sql, null);
        }

        public void RemoveUser(int userID, int ouID)
        {
            string str = string.Format("DELETE FROM T_ACL_OU_User WHERE User_ID={0} AND OU_ID={1}", userID, ouID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public static OU Instance
        {
            get
            {
                return new OU();
            }
        }
    }
}

