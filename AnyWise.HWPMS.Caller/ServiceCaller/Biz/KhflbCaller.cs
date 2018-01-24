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
    public class KhflbCaller : BaseWCFService<KhflbInfo>, IKhflbService
    {
        public KhflbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.KhflbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<KhflbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IKhflbService CreateSubClient()
        {
            CustomClientChannel<IKhflbService> factory = new CustomClientChannel<IKhflbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<KhflbInfo> FindByName(string name)
        //{
        //    List<KhflbInfo> result = new List<KhflbInfo>();

        //    IKhflbService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public List<KhflbInfo> GetAllTree(string nodeType)
        {
            List<KhflbInfo> result = new List<KhflbInfo>();
            IKhflbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetAllTree(nodeType);
            });

            return result;
            
        }

        public List<KhflbInfo> GetKhflbByID(string parentcode)
        {
            List<KhflbInfo> result = new List<KhflbInfo>();
            IKhflbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetKhflbByID(parentcode);
            });

            return result;

        }

        public bool DeleteByCode(string strCode)
        {
            bool result = false;
            IKhflbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.DeleteByCode(strCode);
            });

            return result;

        }

        public bool SaveExcelData(List<KhflbInfo> list)
        {
            bool result = false;
            IKhflbService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });

            return result;

        }

    }
}
