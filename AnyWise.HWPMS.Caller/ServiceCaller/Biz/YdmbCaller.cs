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
    public class YdmbCaller : BaseWCFService<YdmbInfo>, IYdmbService
    {
        public YdmbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YdmbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YdmbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYdmbService CreateSubClient()
        {
            CustomClientChannel<IYdmbService> factory = new CustomClientChannel<IYdmbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }
        
        public DataTable GetNdmbDataByYear(string Year)
        {
            DataTable result = new DataTable();
            IYdmbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetNdmbDataByYear(Year);
            });
            return result;
        }
        public DataTable GetNdmbDataByCond(string where)
        {
            DataTable result = new DataTable();
            IYdmbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetNdmbDataByCond(where);
            });
            return result;
        }
        public DataTable GetNdmbDataById(string ID)
        {
            DataTable result = new DataTable();
            IYdmbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetNdmbDataById(ID);
            });
            return result;
        }
        public DataTable GetNdmbDataByIds(string IDs)
        {
            DataTable result = new DataTable();
            IYdmbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetNdmbDataByIds(IDs);
            });
            return result;
        }
        public bool SaveExcelData(List<YdmbInfo> list)
        {
            bool result = false;

            IYdmbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });

            return result;
        }
    }
}
