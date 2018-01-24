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
    public class RoleCaller : BaseWCFService<RoleInfo>, IRoleService
    {
        public RoleCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.RoleService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<RoleInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IRoleService CreateSubClient()
        {
            CustomClientChannel<IRoleService> factory = new CustomClientChannel<IRoleService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<RoleInfo> FindByName(string name)
        //{
        //    List<RoleInfo> result = new List<RoleInfo>();

        //    IRoleService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public void AddFunction(int functionID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.AddFunction(functionID, roleID);
            });
        }

        public void AddOU(int ouID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.AddOU(ouID, roleID);
            });
        }

        public void AddUser(int userID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.AddUser(userID, roleID);
            });
        }

        public RoleInfo GetRoleByName(string roleName)
        {
            RoleInfo result = new RoleInfo();
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRoleByName(roleName);
            });
            return result;
        }

        public List<RoleInfo> GetRolesByFunction(int functionID)
        {
            List<RoleInfo> result = new List<RoleInfo>();
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRolesByFunction(functionID);
            });
            return result;
        }

        public List<RoleInfo> GetRolesByOU(int ouID)
        {
            List<RoleInfo> result = new List<RoleInfo>();
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRolesByOU(ouID);
            });
            return result;
        }

        public List<RoleInfo> GetRolesByUser(int userID)
        {
            List<RoleInfo> result = new List<RoleInfo>();
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRolesByUser(userID);
            });
            return result;
        }

        public void RemoveFunction(int functionID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.RemoveFunction(functionID, roleID);
            });
        }

        public void RemoveOU(int ouID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.RemoveOU(ouID, roleID);
            });            
        }

        public void RemoveUser(int userID, int roleID)
        {
            IRoleService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.RemoveUser(userID, roleID);
            });
        }
    }
}
