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
    public class OuCaller : BaseWCFService<OUInfo>, IOuService
    {
        public OuCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.OuService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<OUInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IOuService CreateSubClient()
        {
            CustomClientChannel<IOuService> factory = new CustomClientChannel<IOuService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<OuInfo> FindByName(string name)
        //{
        //    List<OuInfo> result = new List<OuInfo>();

        //    IOuService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}
        public void AddUser(int userID, int ouID)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.AddUser(userID, ouID);
            });
        }

        public void RemoveUser(int userID, int ouID)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.RemoveUser(userID, ouID);
            });
        }

        public List<OUInfo> GetOUsByRole(int roleID)
        {
            List<OUInfo> result = null;
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetOUsByRole(roleID);
            });
            return result;
        }

        public List<OUInfo> GetOUsByUser(int userID)
        {
            List<OUInfo> result = null;
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetOUsByUser(userID);
            });
            return result;
        }

        public OUInfo GetTopGroup()
        {
            OUInfo result = null;
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetTopGroup();
            });
            return result;
            
        }

        public List<OUInfo> GetAllCompany()
        {
            List<OUInfo> result = null;
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetAllCompany();
            });
            return result;
        }

        public List<OUInfo> GetGroupCompany()
        {
            List<OUInfo> result = null;
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetGroupCompany();
            });
            return result;
        }

        public void DeleteByFlag(string IDs, string flag)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.DeleteByFlag(IDs, flag);
            });
        }
        public void Truncate(string flag)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.Truncate(flag);
            });
        }

        public void SaveGZLData(YljxflgzlInfo info)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.SaveGZLData(info);
            });
        }
        public void GZLZH(string IDs)
        {
            IOuService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                service.GZLZH(IDs);
            });
        }
    }
}
