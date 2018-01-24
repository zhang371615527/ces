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

    public class Role : BaseDALSQL<RoleInfo>, IBaseDAL<RoleInfo>, IRole
    {
        public Role() : base("T_ACL_Role", "ID")
        {
            base.sortField = "SortCode";
            base.isDescending = false;
        }

        public void AddFunction(int functionID, int roleID)
        {
            string str = string.Format("INSERT INTO T_ACL_Role_Function(Function_ID, Role_ID) VALUES({0},{1})", functionID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public void AddOU(int ouID, int roleID)
        {
            string str = string.Format("INSERT INTO T_ACL_OU_Role(OU_ID, Role_ID) VALUES({0},{1})", ouID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public void AddUser(int userID, int roleID)
        {
            string str = string.Format("INSERT INTO T_ACL_User_Role(User_ID, Role_ID) VALUES({0},{1})", userID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        protected override RoleInfo DataReaderToEntity(IDataReader dataReader)
        {
            RoleInfo info = new RoleInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.PID = reader.GetInt32("PID");
            info.HandNo = reader.GetString("HandNo");
            info.Name = reader.GetString("Name");
            info.Note = reader.GetString("Note");
            info.SortCode = reader.GetString("SortCode");
            info.Category = reader.GetString("Category");
            info.Company_ID = reader.GetString("Company_ID");
            info.CompanyName = reader.GetString("CompanyName");
            info.Creator = reader.GetString("Creator");
            info.Creator_ID = reader.GetString("Creator_ID");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.Editor_ID = reader.GetString("Editor_ID");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Deleted = reader.GetInt32("Deleted");
            info.Enabled = reader.GetInt32("Enabled");
            return info;
        }

        protected override Hashtable GetHashByEntity(RoleInfo obj)
        {
            RoleInfo info = obj;
            Hashtable hash = new Hashtable();

            hash.Add("PID", info.PID);
            hash.Add("HandNo", info.HandNo);
            hash.Add("Name", info.Name);
            hash.Add("Note", info.Note);
            hash.Add("SortCode", info.SortCode);
            hash.Add("Category", info.Category);
            hash.Add("Company_ID", info.Company_ID);
            hash.Add("CompanyName", info.CompanyName);
            hash.Add("Creator", info.Creator);
            hash.Add("Creator_ID", info.Creator_ID);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("Editor_ID", info.Editor_ID);
            hash.Add("EditTime", info.EditTime);
            hash.Add("Deleted", info.Deleted);
            hash.Add("Enabled", info.Enabled);

            return hash;
        }

        public List<RoleInfo> GetRolesByFunction(int functionID)
        {
            string sql = "SELECT * FROM T_ACL_Role INNER JOIN T_ACL_Role_Function On T_ACL_Role.ID=T_ACL_Role_Function.Role_ID WHERE Function_ID = " + functionID;
            return this.GetList(sql, null);
        }

        public List<RoleInfo> GetRolesByOU(int ouID)
        {
            string sql = "SELECT * FROM T_ACL_Role INNER JOIN T_ACL_OU_Role ON T_ACL_Role.ID=Role_ID WHERE OU_ID = " + ouID;
            return this.GetList(sql, null);
        }

        public List<RoleInfo> GetRolesByUser(int userID)
        {
            string sql = "SELECT * FROM T_ACL_Role INNER JOIN T_ACL_User_Role On T_ACL_Role.ID=T_ACL_User_Role.Role_ID WHERE User_ID = " + userID;
            return this.GetList(sql, null);
        }

        public void RemoveFunction(int functionID, int roleID)
        {
            string str = string.Format("DELETE FROM T_ACL_Role_Function WHERE Function_ID={0} AND Role_ID={1}", functionID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public void RemoveOU(int ouID, int roleID)
        {
            string str = string.Format("DELETE FROM T_ACL_OU_Role WHERE OU_ID={0} AND Role_ID={1}", ouID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public void RemoveUser(int userID, int roleID)
        {
            string str = string.Format("DELETE FROM T_ACL_User_Role WHERE User_ID={0} AND Role_ID={1}", userID, roleID);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
        }

        public static Role Instance
        {
            get
            {
                return new Role();
            }
        }
    }
}

