﻿using System;
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
    public class YljxkhzbCaller : BaseApiService<YljxkhzbInfo>, IYljxkhzbService
    {
        public YljxkhzbCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Yljxkhzb;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<YljxkhzbInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<YljxkhzbInfo>>.ConvertJson(url);
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

        public bool SaveExcelData(List<YljxkhzbInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        /// <summary>
        /// 医疗绩效考核
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public int SqlExe_Update(string id)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                id = id
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 更改绩效考核状态
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public int SqlExe_SSI(string ids)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                ids = ids
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return Convert.ToInt32(result);
        }
    }
}
