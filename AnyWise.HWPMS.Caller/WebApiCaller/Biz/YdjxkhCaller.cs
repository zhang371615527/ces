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
    public class YdjxkhCaller : BaseApiService<YdjxkhInfo>, IYdjxkhService
    {
        public YdjxkhCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Ydjxkh;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<YdjxkhInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<YdjxkhInfo>>.ConvertJson(url);
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

        public bool InsertMainAndSub(string strYear, string strMonth, string strCreator)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strCreator = strCreator
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public bool UpdateStateByID(string ID, string State, string strEditor)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                ID = ID,
                State = State,
                strEditor = strEditor
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public DataTable ExaSumExport(string strYear, string strMonth, string strResKS_ID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strResKS_ID = strResKS_ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strResKS_ID = strResKS_ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }

        public DataTable GetDataTableByCheckKS(string strYear, string strMonth, string strCheckKS_ID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strCheckKS_ID = strCheckKS_ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
    }
}
