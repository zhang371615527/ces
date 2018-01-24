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

    public class Menu : BaseDALSQL<MenuInfo>, IBaseDAL<MenuInfo>, IMenu
    {
        public Menu() : base("T_ACL_Menu", "ID")
        {
            base.sortField = "Seq";
            base.isDescending = false;
        }

        protected override MenuInfo DataReaderToEntity(IDataReader dataReader)
        {
            MenuInfo info = new MenuInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetString("ID");
            info.PID = reader.GetString("PID");
            info.Name = reader.GetString("Name");
            info.Icon = reader.GetString("Icon");
            info.Seq = reader.GetString("Seq");
            info.FunctionId = reader.GetString("FunctionId");
            info.Visible = reader.GetInt32("Visible") > 0;
            info.WinformType = reader.GetString("WinformType");
            info.Url = reader.GetString("Url");
            info.WebIcon = reader.GetString("WebIcon");
            info.SystemType_ID = reader.GetString("SystemType_ID");
            return info;
        }

        public List<MenuInfo> GetAllMenu(string systemType)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("Where SystemType_ID='{0}'", systemType) : "";
            string sql = string.Format("Select * From {0} {1} Order  By PID, Seq  ", base.tableName, str);
            return this.GetList(sql, null);
        }

        protected override Hashtable GetHashByEntity(MenuInfo obj)
        {
            MenuInfo info = obj;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ID", info.ID);
            hashtable.Add("PID", info.PID);
            hashtable.Add("Name", info.Name);
            hashtable.Add("Icon", info.Icon);
            hashtable.Add("Seq", info.Seq);
            hashtable.Add("FunctionId", info.FunctionId);
            hashtable.Add("Visible", info.Visible ? 1 : 0);
            hashtable.Add("WinformType", info.WinformType);
            hashtable.Add("Url", info.Url);
            hashtable.Add("WebIcon", info.WebIcon);
            hashtable.Add("SystemType_ID", info.SystemType_ID);
            return hashtable;
        }

        public List<MenuInfo> GetMenuByID(string PID)
        {
            string sql = string.Format("Select t.*,case pid when '-1' then '0' else pid end as parentId From {1} t \r\n                                         Where  PID='{0}' Order By Seq ", PID, base.tableName);
            return this.GetList(sql, null);
        }

        public List<MenuInfo> GetTopMenu(string systemType)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("AND SystemType_ID='{0}'", systemType) : "";
            string sql = string.Format("Select * From {0} Where Visible > 0 and PID='-1' {1} Order By Seq  ", base.tableName, str);
            return this.GetList(sql, null);
        }

        public List<MenuNodeInfo> GetTree(string systemType)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("AND SystemType_ID='{0}'", systemType) : "";
            List<MenuNodeInfo> list = new List<MenuNodeInfo>();
            string sql = string.Format("Select * From {0} Where Visible > 0 {1} Order By PID, Seq ", base.tableName, str);
            DataTable table = base.SqlTable(sql);
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}' ", -1));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str3 = rowArray[i]["ID"].ToString();
                MenuNodeInfo item = this.TableToInfo(str3, table);
                list.Add(item);
            }
            return list;
        }

        public List<MenuNodeInfo> GetTreeByID(string mainMenuID)
        {
            List<MenuNodeInfo> list = new List<MenuNodeInfo>();
            string sql = string.Format("Select * From {0} Where Visible > 0 Order By PID, Seq ", base.tableName);
            DataTable table = this.SqlTable(sql);
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}'", mainMenuID));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str2 = rowArray[i]["ID"].ToString();
                MenuNodeInfo item = this.TableToInfo(str2, table);
                list.Add(item);
            }
            return list;
        }

        public List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions)
        {
            string str = !string.IsNullOrEmpty(systemType) ? string.Format("AND SystemType_ID='{0}'", systemType) : "";
            List<MenuNodeInfo> list = new List<MenuNodeInfo>();
            string str2 = string.Format("Select * From {0} Where Visible > 0 {1} Order By PID, Seq ", base.tableName, str);
            DataTable table = base.SqlTable(str2);
            string sort = string.Format("{0} {1}", base.GetSafeFileName(base.sortField), base.isDescending ? "DESC" : "ASC");
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}' and FunctionId in ({1})", -1, Functions), sort);
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str4 = rowArray[i]["ID"].ToString();
                MenuNodeInfo item = this.TableToInfo(str4, table);
                list.Add(item);
            }
            return list;
        }

        public List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions)
        {
            string str = string.Format(" and PID = '{0}' and FunctionId in ({1})", mainMenuID, Functions);
            string sql = string.Format("Select * From {0} Where Visible > 0 {1} Order  By PID, Seq  ", base.tableName, str);
            return this.GetList(sql, null);
        }

        public List<MenuNodeInfo> GetTreeFunctionByID(string mainMenuID, string Functions)
        {
            List<MenuNodeInfo> list = new List<MenuNodeInfo>();
            string str = string.Format("Select * From {0} Where Visible > 0 Order By PID, Seq ", base.tableName);
            DataTable table = this.SqlTable(str);
            string sort = string.Format("{0} {1}", base.GetSafeFileName(base.sortField), base.isDescending ? "DESC" : "ASC");
            DataRow[] rowArray = table.Select(string.Format(" PID = '{0}' and FunctionId in ({1})", mainMenuID, Functions), sort);
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str3 = rowArray[i]["ID"].ToString();
                MenuNodeInfo item = this.TableToInfo(str3, table);
                list.Add(item);
            }
            return list;
        }

        private MenuNodeInfo TableToInfo(string string_0, DataTable dataTable_0)
        {
            MenuNodeInfo info2 = new MenuNodeInfo(this.FindByID(string_0));
            DataRow[] rowArray = dataTable_0.Select(string.Format(" PID='{0}'", string_0));
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str = rowArray[i]["ID"].ToString();
                MenuNodeInfo item = this.TableToInfo(str, dataTable_0);
                info2.Children.Add(item);
            }
            return info2;
        }

        public static Menu Instance
        {
            get
            {
                return new Menu();
            }
        }
    }
}

