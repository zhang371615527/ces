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
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.ServiceCaller
{
	/// <summary>
	/// 基于WCF服务的Facade接口实现类
	/// </summary>
    public class FileUploadCaller : BaseWCFService<FileUploadInfo>, IFileUploadService
    {
        public FileUploadCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.FileUploadService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<FileUploadInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IFileUploadService CreateSubClient()
        {
            CustomClientChannel<IFileUploadService> factory = new CustomClientChannel<IFileUploadService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        public List<FileUploadInfo> GetByAttachGUID(string attachmentGUID)
        {
            List<FileUploadInfo> result = new List<FileUploadInfo>();

            IFileUploadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetByAttachGUID(attachmentGUID);
            });

            return result;
        }
        public string GetFilePath(FileUploadInfo info)
        {
            string result = "";

            IFileUploadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetFilePath(info);
            });

            return result;
        }
    }
}
