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
    public class YdjxkhCaller : BaseWCFService<YdjxkhInfo>, IYdjxkhService
    {
        public YdjxkhCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YdjxkhService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YdjxkhInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYdjxkhService CreateSubClient()
        {
            CustomClientChannel<IYdjxkhService> factory = new CustomClientChannel<IYdjxkhService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YdjxkhInfo> FindByName(string name)
        //{
        //    List<YdjxkhInfo> result = new List<YdjxkhInfo>();

        //    IYdjxkhService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool InsertMainAndSub(string strYear, string strMonth, string strCreator)
        {
            bool result = false;
            IYdjxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.InsertMainAndSub(strYear,strMonth,strCreator);
            });

            return result;
        }

        public bool UpdateStateByID(string ID, string State, string strEditor)
        {
            bool result = false;
            IYdjxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.UpdateStateByID(ID, State, strEditor);
            });

            return result;
        }

        public DataTable ExaSumExport(string strYear, string strMonth, string strResKS_ID)
        {
            DataTable result = new DataTable();
            IYdjxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.ExaSumExport(strYear, strMonth, strResKS_ID);
            });

            return result;
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID)
        {
            DataTable result = new DataTable();
            IYdjxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetDataTable(strYear, strMonth, strResKS_ID);
            });

            return result;
        }

        public DataTable GetDataTableByCheckKS(string strYear, string strMonth, string strCheckKS_ID)
        {
            DataTable result = new DataTable();
            IYdjxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetDataTableByCheckKS(strYear, strMonth, strCheckKS_ID);
            });

            return result;
        }
    }
}
