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
    public class RoleCaller : BaseApiService<RoleInfo>, IRoleService
    {
        public RoleCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Role;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<RoleInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<RoleInfo>>.ConvertJson(url);
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

        public void AddFunction(int functionID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                functionID = functionID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }

        public void AddOU(int ouID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                ouID = ouID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }

        public void AddUser(int userID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                userID = userID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }

        public RoleInfo GetRoleByName(string roleName)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&roleName={0}", roleName);

            var result = JsonHelper<RoleInfo>.ConvertJson(url);
            return result;
        }

        public List<RoleInfo> GetRolesByFunction(int functionID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&functionID={0}", functionID);

            var result = JsonHelper<List<RoleInfo>>.ConvertJson(url);
            return result;
        }

        public List<RoleInfo> GetRolesByOU(int ouID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&ouID={0}", ouID);

            var result = JsonHelper<List<RoleInfo>>.ConvertJson(url);
            return result;
        }

        public List<RoleInfo> GetRolesByUser(int userID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&userID={0}", userID);

            var result = JsonHelper<List<RoleInfo>>.ConvertJson(url);
            return result;
        }

        public void RemoveFunction(int functionID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                functionID = functionID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }

        public void RemoveOU(int ouID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                ouID = ouID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }

        public void RemoveUser(int userID, int roleID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                userID = userID,
                roleID = roleID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertString(url, postData);
        }
    }
}
