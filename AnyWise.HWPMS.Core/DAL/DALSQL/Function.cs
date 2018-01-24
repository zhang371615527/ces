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

    public class Function : BaseDALSQL<FunctionInfo>, IFunction
    {
        public Function() : base("T_ACL_Function", "ID")
        {
        }

        protected override FunctionInfo DataReaderToEntity(IDataReader dataReader)
        {
            FunctionInfo info = new FunctionInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.PID = reader.GetInt32("PID");
            info.Name = reader.GetString("Name");
            info.ControlID = reader.GetString("ControlID");
            info.SystemType_ID = reader.GetString("SystemType_ID");
            info.SortCode = reader.GetString("SortCode");
            return info;
        }

        public List<FunctionInfo> GetAllFunction(string systemType)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("Where SystemType_ID='{0}'", systemType) : "";
            string sql = string.Format("Select * From {0} {1} Order  By PID, SortCode  ", base.tableName, str);
            return this.GetList(sql, null);
        }

        public List<FunctionNodeInfo> GetFunctionNodes(string roleIDs, string typeID)
        {
            string str = "SELECT * FROM T_ACL_Function    INNER JOIN T_ACL_Role_Function On T_ACL_Function.ID=T_ACL_Role_Function.Function_ID WHERE Role_ID IN (" + roleIDs + ")";
            if (typeID.Length > 0)
            {
                str = str + string.Format(" AND SystemType_ID='{0}' ", typeID);
            }
            List<FunctionNodeInfo> list = new List<FunctionNodeInfo>();
            DataTable table = base.SqlTable(str, null);
            string sort = string.Format("{0} {1}", base.GetSafeFileName(base.sortField), base.isDescending ? "DESC" : "ASC");
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}' ", -1), sort);
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str3 = rowArray[i]["ID"].ToString();
                FunctionNodeInfo item = this.GetNodeInfo(str3, table);
                list.Add(item);
            }
            return list;
        }

        public List<FunctionInfo> GetFunctions(string roleIDs, string typeID)
        {
            string sql = "SELECT DISTINCT [ID],PID,[NAME],ControlID,SystemType_ID,SortCode FROM [T_ACL_Function] \r\n            INNER JOIN T_ACL_Role_Function On [T_ACL_Function].ID=T_ACL_Role_Function.Function_ID WHERE Role_ID IN (" + roleIDs + ")";
            if (typeID.Length > 0)
            {
                sql = sql + string.Format(" AND SystemType_ID='{0}' ", typeID);
            }
            return this.GetList(sql, null);
        }

        public List<FunctionInfo> GetFunctionsByRole(int roleID)
        {
            string sql = "SELECT * FROM [T_ACL_Function] \r\n            LEFT JOIN T_ACL_Role_Function On [T_ACL_Function].ID=T_ACL_Role_Function.Function_ID WHERE Role_ID = " + roleID;
            return this.GetList(sql, null);
        }

        protected override Hashtable GetHashByEntity(FunctionInfo obj)
        {
            FunctionInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("PID", info.PID);
            hashtable.Add("Name", info.Name);
            hashtable.Add("ControlID", info.ControlID);
            hashtable.Add("SystemType_ID", info.SystemType_ID);
            hashtable.Add("SortCode",info.SortCode);
            return hashtable;
        }

        public List<FunctionNodeInfo> GetTree(string systemType)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("Where SystemType_ID='{0}'", systemType) : "";
            List<FunctionNodeInfo> list = new List<FunctionNodeInfo>();
            string sql = string.Format("Select * From {0} {1} Order By PID, Name ", base.tableName, str);
            DataTable table = base.SqlTable(sql);
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}' ", -1));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str3 = rowArray[i]["ID"].ToString();
                FunctionNodeInfo item = this.GetNodeInfo(str3, table);
                list.Add(item);
            }
            return list;
        }

        public List<FunctionNodeInfo> GetTreeByID(string mainID)
        {
            List<FunctionNodeInfo> list = new List<FunctionNodeInfo>();
            string sql = string.Format("Select * From {0} Order By PID, Name ", base.tableName);
            DataTable table = this.SqlTable(sql);
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}'", mainID));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str2 = rowArray[i]["ID"].ToString();
                FunctionNodeInfo item = this.GetNodeInfo(str2, table);
                list.Add(item);
            }
            return list;
        }

        private FunctionNodeInfo GetNodeInfo(string string_0, DataTable dataTable_0)
        {
            FunctionNodeInfo info2 = new FunctionNodeInfo(this.FindByID(string_0));
            DataRow[] rowArray = dataTable_0.Select(string.Format(" PID='{0}'", string_0));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str = rowArray[i]["ID"].ToString();
                FunctionNodeInfo item = this.GetNodeInfo(str, dataTable_0);
                info2.Children.Add(item);
            }
            return info2;
        }

        public static Function Instance
        {
            get
            {
                return new Function();
            }
        }
    }
}

