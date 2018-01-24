using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class CodeSetCaller : BaseLocalService<CodeSetInfo>, ICodeSetService
    {
        private CodeSet bll = null;

        public CodeSetCaller() : base(BLLFactory<CodeSet>.Instance)
        {
            bll = baseBLL as CodeSet;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<CodeSetInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public List<CListItem> GetTableItems()
        {
            List<CListItem> data = new List<CListItem>();
            DataTable dt = bll.GetTableItems();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new CListItem(dr["TableDesc"].ToString(), dr["TableName"].ToString()));
            }

            return data;
        }
        public List<CListItem> GetColumnItems(string TableName)
        {
            List<CListItem> data = new List<CListItem>();
            DataTable dt = bll.GetColumnItems(TableName);
            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new CListItem(dr["ColumnDesc"].ToString(), dr["ColumnName"].ToString()));
            }

            return data;
        }
        public string GenerateTreeCode(string strParentCode, string strTableName, string strFieldName, int Layer, string ParentColumn)
        {
            return bll.GenerateTreeCode(strParentCode, strTableName, strFieldName, Layer, ParentColumn);
        }

        public string GenerateTreeChildCode(string strParentCode, string strTableName, string strChildName, string strFieldName, int Layer, string ParentColumn)
        {
            return bll.GenerateTreeChildCode(strParentCode, strTableName, strChildName, strFieldName, Layer, ParentColumn);
        }
        public string GenerateCode(string strTableName, string strFieldName, string strType)
        {
            return bll.GenerateCode(strTableName, strFieldName, strType);
        }
        public string GenerateCodeEx(string strTableName, string strBusType, string strFieldName, string strType)
        {
            return bll.GenerateCodeEx(strTableName, strBusType, strFieldName, strType);
        }
    }
}
