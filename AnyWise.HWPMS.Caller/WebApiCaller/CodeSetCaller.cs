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
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WebApiCaller
{
	/// <summary>
	/// 基于WebAPI方式的Facade接口实现类
	/// </summary>
    public class CodeSetCaller : BaseApiService<CodeSetInfo>, ICodeSetService
    {
        public CodeSetCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.CodeSet;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<CodeSetInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<CodeSetInfo>>.ConvertJson(url);
        //    return result;
        //}

        ///// <summary>
        ///// 修改用户密码(自定义接口使用范例, POST方式)
        ///// </summary>
        ///// <param name="userName">用户名称</param>
        ///// <param name="userPassword">修改的密码</param>
        ///// <returns>如果修改成功返回true，否则返回false</returns>
        //public bool ModifyPassword(string userName, string userPassword)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var postData = new
        //    {
        //        userName = userName,
        //        userPassword = userPassword
        //    }.ToJson();
        //    string url = GetTokenUrl(action);
		//
        //    var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
        //    return (result != null) ? result.Success : false;
        //}
	#endregion

        public List<CListItem> GetTableItems()
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action);

            DataTable result = JsonHelper<DataTable>.ConvertJson(url);
            List<CListItem> data = new List<CListItem>();
            foreach (DataRow dr in result.Rows)
            {
                data.Add(new CListItem(dr["TableDesc"].ToString(), dr["TableName"].ToString()));
            }

            return data;
        }
        public List<CListItem> GetColumnItems(string TableName)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&TableName={0}", TableName);

            DataTable result = JsonHelper<DataTable>.ConvertJson(url);
            List<CListItem> data = new List<CListItem>();
            foreach (DataRow dr in result.Rows)
            {
                data.Add(new CListItem(dr["ColumnDesc"].ToString(), dr["ColumnName"].ToString()));
            }

            return data;
        }
        public string GenerateTreeCode(string strParentCode, string strTableName, string strFieldName, int Layer, string ParentColumn)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strParentCode = strParentCode,
                strTableName = strTableName,
                strFieldName = strFieldName,
                Layer = Layer,
                ParentColumn = ParentColumn
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<string>.ConvertJson(url, postData);
            return result;
        }
        public string GenerateTreeChildCode(string strParentCode, string strTableName, string strChildName, string strFieldName, int Layer, string ParentColumn)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strParentCode = strParentCode,
                strTableName = strTableName,
                strChildName = strChildName,
                strFieldName = strFieldName,
                Layer = Layer,
                ParentColumn = ParentColumn
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<string>.ConvertJson(url, postData);
            return result;
        }
        public string GenerateCode(string strTableName, string strFieldName, string strType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strTableName = strTableName,
                strFieldName = strFieldName,
                strType = strType
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<string>.ConvertJson(url, postData);
            return result;
        }
        public string GenerateCodeEx(string strTableName, string strBusType, string strFieldName, string strType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strTableName = strTableName,
                strBusType = strBusType,
                strFieldName = strFieldName,
                strType = strType
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<string>.ConvertJson(url, postData);
            return result;
        }
    }
}
