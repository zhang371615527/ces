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
    public class YljxjjmxCaller : BaseApiService<YljxjjmxInfo>, IYljxjjmxService
    {
        public YljxjjmxCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Yljxjjmx;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<YljxjjmxInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<YljxjjmxInfo>>.ConvertJson(url);
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

        public bool SaveExcelData(List<YljxjjmxInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        /// <summary>
        /// 医疗绩效奖金明细表
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public List<YljxjjmxInfo> Yljxjjmx_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                intRecordCount = intRecordCount,
                intPageSize = intPageSize,
                intPageCount = intPageCount,
                where = where
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            List<YljxjjmxInfo> result = JsonHelper<List<YljxjjmxInfo>>.ConvertJson(url, postData);
            return result;
        }

        /// <summary>
        /// 医疗绩效奖金明细表Calculate
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public DataTable Yljxjjmx_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strKSID = strKSID,
                strZXZD_ID = strZXZD_ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            DataTable result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public bool Yljxjjmx_Insert(List<YljxjjmxInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
        /// <summary>
        /// 医疗绩效奖金明细表Calculate
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public DataTable Yljxjjmx_BDD(string strYear, string strMonth, string strKSZD_ID, string strFPLBID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strKSZD_ID = strKSZD_ID,
                strFPLBID=strFPLBID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            DataTable result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
    }
}
