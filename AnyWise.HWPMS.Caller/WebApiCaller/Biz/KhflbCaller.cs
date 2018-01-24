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
    public class KhflbCaller : BaseApiService<KhflbInfo>, IKhflbService
    {
        public KhflbCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Khflb;
        }
		
       #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<KhflbInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<KhflbInfo>>.ConvertJson(url);
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

        public List<KhflbInfo> GetAllTree(string nodeType)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&nodeType={0}", nodeType);
            var result = JsonHelper<List<KhflbInfo>>.ConvertJson(url);
            return result;
        }

        public List<KhflbInfo> GetKhflbByID(string parentcode)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&parentcode={0}", parentcode);
            var result = JsonHelper<List<KhflbInfo>>.ConvertJson(url);
            return result;
        }

        public bool DeleteByCode(string strCode)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                strCode = strCode
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public bool SaveExcelData(List<KhflbInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //var postData1 = list.ToJson();
            var postData = new
            {
                list = list
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
    }
}
