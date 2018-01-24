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
    public class UserCaller : BaseApiService<UserInfo>, IUserService
    {
        public UserCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.User;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<UserInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<UserInfo>>.ConvertJson(url);
        //    return result;
        //}

	#endregion

        public List<UserInfo> GetUsersByOU(int ouID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&ouID={0}", ouID);

            var result = JsonHelper<List<UserInfo>>.ConvertJson(url);
            return result;
        }

        public List<UserInfo> GetUsersByRole(int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&roleID={0}", roleID);

            var result = JsonHelper<List<UserInfo>>.ConvertJson(url);
            return result;
        }

        /// <summary>
        /// 修改用户密码(自定义接口使用范例, POST方式)
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassword">修改的密码</param>
        /// <returns>如果修改成功返回true，否则返回false</returns>
        public bool ModifyPassword(string userName, string userPassword)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                userName = userName,
                userPassword = userPassword
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public bool ModifyPassword(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            var action = "ModifyPassword1";
            var postData = new
            {
                userName = userName,
                userPassword = userPassword,
                systemType = systemType,
                ip = ip,
                macAddr = macAddr
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public string VerifyUser(string userName, string userPassword, string systemType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                userName = userName,
                userPassword = userPassword,
                systemType = systemType
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
            return result;
        
        }

        public string VerifyUser(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            var action = "VerifyUser1";
            var postData = new
            {
                userName = userName,
                userPassword = userPassword,
                systemType = systemType,
                ip = ip,
                macAddr = macAddr
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
            return result;
        }

        public string VerifyUser2(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                userName = userName,
                userPassword = userPassword,
                systemType = systemType,
                ip = ip,
                macAddr = macAddr
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
            return result;
        }

        public UserInfo GetUserByName(string userName)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&userName={0}", userName);

            var result = JsonHelper<UserInfo>.ConvertJson(url);
            return result;
        }

        public bool InsertBatch(List<UserInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
    }
}
