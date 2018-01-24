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
    public class YljxjjhzCaller : BaseApiService<YljxjjhzInfo>, IYljxjjhzService
    {
        public YljxjjhzCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Yljxjjhz;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<YljxjjhzInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<YljxjjhzInfo>>.ConvertJson(url);
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

        public bool SaveExcelData(List<YljxjjhzInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        /// <summary>
        /// 医疗绩效奖金汇总表
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public List<YljxjjhzInfo> Yljxjjhz_FWP(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                intPageSize = intPageSize,
                intPageCount = intPageCount,
                mSizeBackup = mSizeBackup,
                where = where
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            List<YljxjjhzInfo> result = JsonHelper<List<YljxjjhzInfo>>.ConvertJson(url, postData);
            return result;
        }

        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public DataTable Yljxjjhz_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
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
        public bool Yljxjjhz_Insert(List<YljxjjhzInfo> listjj)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = listjj.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public DataTable Yljxjjhz_BSD(string strYear, string strMonth, string strKSZD_ID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strYear = strYear,
                strMonth = strMonth,
                strKSZD_ID = strKSZD_ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            DataTable result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
    }
}
