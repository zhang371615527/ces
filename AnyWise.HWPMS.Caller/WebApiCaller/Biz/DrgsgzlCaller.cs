using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Dynamic;
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
    public class DrgsgzlCaller : BaseApiService<DrgsgzlInfo>, IDrgsgzlService
    {
        public DrgsgzlCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Drgsgzl;
        }
		
        #region 示例代码
	   
        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例，GET方式)
        ///// </summary>
        //public List<DrgsgzlInfo> FindByName(string name)
        //{
        //    var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    string url = GetTokenUrl(action) + string.Format("&name={0}", name);
		//
        //    var result = JsonHelper<List<DrgsgzlInfo>>.ConvertJson(url);
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

        public bool InsertBatch(List<DrgsgzlInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        /// <summary>
        /// 返回CMI折线图数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable DRGSAna_CMIAna(string where)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&where={0}", where);

            var result = JsonHelper<DataTable>.ConvertJson(url);
            return result;
        }

        #region 收入折线图
        public string DRGSAna_GetxAxis(string Year)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&Year={0}", Year);

            var result = JsonHelper<String>.ConvertJson(url);
            return result;
        }
        public string DRGSAna_GetIncome(string Year)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&Year={0}", Year);

            var result = JsonHelper<String>.ConvertJson(url);
            return result;
        }
        #endregion

        /// <summary>
        /// DRGs绩效指标查询
        /// </summary>
        public List<ExpandoObject> DRGSAna_DRGsDetail(string BeginPeriod, string EndPeriod)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&BeginPeriod={0}&EndPeriod={1}", BeginPeriod, EndPeriod);

            var result = JsonHelper<List<ExpandoObject>>.ConvertJson(url);
            return result;
        }
    }
}
