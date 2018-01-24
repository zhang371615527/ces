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
using AnyWise.Pager.Entity;

namespace AnyWise.HWPMS.WebApiCaller
{
	/// <summary>
	/// 基于WebAPI方式的Facade接口实现类
	/// </summary>
    public class InformationCaller : BaseApiService<InformationInfo>, IInformationService
    {
        public InformationCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Information;
        }

        public List<InformationInfo> FindAll4(PagerInfo info, string fieldToSort, bool isDescending)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = this.GetPostUrlWithToken(action) + string.Format("&fieldToSort={0}&isDescending={1}", fieldToSort, isDescending);
            string postData = info.ToJson();

            var result = JsonHelper<List<InformationInfo>>.ConvertJson(url, postData);
            return result;
        }
    }
}
