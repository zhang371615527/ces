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
    public class YdjxkhzbCaller : BaseWCFService<YdjxkhzbInfo>, IYdjxkhzbService
    {
        public YdjxkhzbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YdjxkhzbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YdjxkhzbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYdjxkhzbService CreateSubClient()
        {
            CustomClientChannel<IYdjxkhzbService> factory = new CustomClientChannel<IYdjxkhzbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YdjxkhzbInfo> FindByName(string name)
        //{
        //    List<YdjxkhzbInfo> result = new List<YdjxkhzbInfo>();

        //    IYdjxkhzbService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool SaveScore(string Mid, string Ids)
        {
            bool result = false;
            IYdjxkhzbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveScore(Mid, Ids);
            });

            return result;
        }

        public bool SaveExcelData(List<YdjxkhzbInfo> list)
        {
            bool result = false;
            IYdjxkhzbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });

            return result;
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID, string strCheckKS_ID)
        {
            DataTable result = new DataTable ();
            IYdjxkhzbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetDataTable(strYear, strMonth, strResKS_ID, strCheckKS_ID);
            });

            return result;
        }
    }
}
