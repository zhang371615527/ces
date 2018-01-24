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
    public class SrmxbCaller : BaseApiService<SrmxbInfo>, ISrmxbService
    {
        public SrmxbCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Srmxb;
        }

        public DataTable GetDataCount(string where)
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
        public DataTable GetSrmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
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

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetSrhzSumData(string where)
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
        public bool SaveExcelData(List<SrmxbInfo> list)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = list.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
    }
}
