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
    public class YljxkhCaller : BaseWCFService<YljxkhInfo>, IYljxkhService
    {
        public YljxkhCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YljxkhService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YljxkhInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYljxkhService CreateSubClient()
        {
            CustomClientChannel<IYljxkhService> factory = new CustomClientChannel<IYljxkhService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxkhInfo> FindByName(string name)
        //{
        //    List<YljxkhInfo> result = new List<YljxkhInfo>();

        //    IYljxkhService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool SaveExcelData(List<YljxkhInfo> list)
        {
            bool result = false;
            IYljxkhService service = this.CreateSubClient();
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
        public List<YljxkhInfo> Yljxkh_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            List<YljxkhInfo> result = new List<YljxkhInfo>();

            IYljxkhService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxkh_FWP(intRecordCount, intPageSize, intPageCount, where);
            });

            return result;
        }

        public int UpdateState(string IDs)
        {
            int result = 0;
            IYljxkhService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.UpdateState(IDs);
            });
            return result;
        }
    }
}
