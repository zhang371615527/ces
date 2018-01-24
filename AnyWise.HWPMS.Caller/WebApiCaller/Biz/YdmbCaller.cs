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
    public class YdmbCaller : BaseApiService<YdmbInfo>, IYdmbService
    {
        public YdmbCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Ydmb;
        }
        
        public DataTable GetNdmbDataByYear(string Year)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                Year = Year
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetNdmbDataByCond(string where)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                where = where
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetNdmbDataById(string ID)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                ID = ID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetNdmbDataByIds(string IDs)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                IDs = IDs
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public bool SaveExcelData(List<YdmbInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

    }
}
