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
    public class MenuCaller : BaseApiService<MenuInfo>, IMenuService
    {
        public MenuCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Menu;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<MenuInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<MenuInfo>>.ConvertJson(url);
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

        public List<MenuInfo> GetAllTree(string systemType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&systemType={0}", systemType);

            var result = JsonHelper<List<MenuInfo>>.ConvertJson(url);
            return result;
        }

        public List<MenuInfo> GetTopMenu(string systemType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&systemType={0}", systemType);

            var result = JsonHelper<List<MenuInfo>>.ConvertJson(url);
            return result;
        }

        public List<MenuNodeInfo> GetTreeByID(string mainMenuID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&mainMenuID={0}", mainMenuID);

            var result = JsonHelper<List<MenuNodeInfo>>.ConvertJson(url);
            return result;
        }

        public List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                systemType = systemType,
                Functions = Functions
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<List<MenuNodeInfo>>.ConvertJson(url, postData);
            return result;
        }

        public List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                mainMenuID = mainMenuID,
                Functions = Functions
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<List<MenuInfo>>.ConvertJson(url, postData);
            return result;
        }
    }
}
