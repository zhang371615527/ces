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
    public class YljxkhzbCaller : BaseWCFService<YljxkhzbInfo>, IYljxkhzbService
    {
        public YljxkhzbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YljxkhzbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YljxkhzbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYljxkhzbService CreateSubClient()
        {
            CustomClientChannel<IYljxkhzbService> factory = new CustomClientChannel<IYljxkhzbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxkhzbInfo> FindByName(string name)
        //{
        //    List<YljxkhzbInfo> result = new List<YljxkhzbInfo>();

        //    IYljxkhzbService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool SaveExcelData(List<YljxkhzbInfo> list)
        {
            bool result = false;
            IYljxkhzbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });
            return result;
        }

        /// <summary>
        /// 医疗绩效奖金明细表
        /// </summary>
        public int SqlExe_SSI(string ids)
        {
            int result = 0;

            IYljxkhzbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SqlExe_SSI(ids);
            });

            return result;
        }

        public int SqlExe_Update(string id)
        {
            int result = 0;
            IYljxkhzbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SqlExe_Update(id);
            });
            return result;
        }
    }
}
