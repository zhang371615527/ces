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
    public class SrmxbCaller : BaseWCFService<SrmxbInfo>, ISrmxbService
    {
        public SrmxbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.SrmxbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<SrmxbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ISrmxbService CreateSubClient()
        {
            CustomClientChannel<ISrmxbService> factory = new CustomClientChannel<ISrmxbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        
        public DataTable GetDataCount(string where)
        {
            DataTable result = new DataTable();
            ISrmxbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetDataCount(where);
            });
            return result;
        }
        public DataTable GetSrmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            DataTable result = new DataTable();
            ISrmxbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetSrmxbData(intPageSize, intPageCount, mSizeBackup, where);
            });
            return result;
        }
        public DataTable GetSrhzSumData(string where)
        {
            DataTable result = new DataTable();
            ISrmxbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetSrhzSumData(where);
            });
            return result;
        }
        public bool SaveExcelData(List<SrmxbInfo> list)
        {
            bool result = false;

            ISrmxbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });

            return result;
        }

    }
}
