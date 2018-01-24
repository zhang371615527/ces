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
    public class FunctionCaller : BaseWCFService<FunctionInfo>, IFunctionService
    {
        public FunctionCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.FunctionService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<FunctionInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IFunctionService CreateSubClient()
        {
            CustomClientChannel<IFunctionService> factory = new CustomClientChannel<IFunctionService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<FunctionInfo> FindByName(string name)
        //{
        //    List<FunctionInfo> result = new List<FunctionInfo>();

        //    IFunctionService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}


        public List<FunctionInfo> GetAllFunction(string systemType)
        {
            List<FunctionInfo> result = new List<FunctionInfo>();

            IFunctionService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetAllFunction(systemType);
            });

            return result;
        }

        public List<FunctionInfo> GetFunctions(string roleIDs, string typeID)
        {
            List<FunctionInfo> result = new List<FunctionInfo>();

            IFunctionService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetFunctions(roleIDs, typeID);
            });

            return result;
        }

        public List<FunctionInfo> GetFunctionsByRole(int roleID)
        {
            List<FunctionInfo> result = new List<FunctionInfo>();

            IFunctionService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetFunctionsByRole(roleID);
            });

            return result;
        }

        public List<FunctionInfo> GetFunctionsByUser(int userID, string typeID)
        {
            List<FunctionInfo> result = new List<FunctionInfo>();

            IFunctionService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetFunctionsByUser(userID, typeID);
            });

            return result;
        }
    }
}
