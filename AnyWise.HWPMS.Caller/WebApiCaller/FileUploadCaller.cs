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
    public class FileUploadCaller : BaseApiService<FileUploadInfo>, IFileUploadService
    {
        public FileUploadCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.FileUpload;
        }

        public List<FileUploadInfo> GetByAttachGUID(string attachmentGUID)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string url = GetTokenUrl(action) + string.Format("&attachmentGUID={0}", attachmentGUID);

            var result = JsonHelper<List<FileUploadInfo>>.ConvertJson(url);
            return result;
        }
        public string GetFilePath(FileUploadInfo info)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = info.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<String>.ConvertJson(url, postData);
            return result;
        }
    }
}
