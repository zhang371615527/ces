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
    public class YljxjjmxCaller : BaseWCFService<YljxjjmxInfo>, IYljxjjmxService
    {
        public YljxjjmxCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YljxjjmxService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YljxjjmxInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYljxjjmxService CreateSubClient()
        {
            CustomClientChannel<IYljxjjmxService> factory = new CustomClientChannel<IYljxjjmxService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxjjmxInfo> FindByName(string name)
        //{
        //    List<YljxjjmxInfo> result = new List<YljxjjmxInfo>();

        //    IYljxjjmxService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool SaveExcelData(List<YljxjjmxInfo> list)
        {
            bool result = false;
            IYljxjjmxService service = this.CreateSubClient();
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
        public List<YljxjjmxInfo> Yljxjjmx_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            List<YljxjjmxInfo> result = new List<YljxjjmxInfo>();

            IYljxjjmxService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjmx_FWP(intRecordCount,intPageSize, intPageCount, where);
            });

            return result;
        }

        /// <summary>
        /// 医疗绩效奖金明细表Calculate
        /// </summary>
        public DataTable Yljxjjmx_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            DataTable result = new DataTable();

            IYljxjjmxService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjmx_Cal(strYear, strMonth, strKSID, strZXZD_ID);
            });

            return result;
        }
        public bool Yljxjjmx_Insert(List<YljxjjmxInfo> listjj)
        {
            bool result = false;
            IYljxjjmxService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjmx_Insert(listjj);
            });
            return result;
        }

        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        public DataTable Yljxjjmx_BDD(string strYear, string strMonth, string strKSZD_ID, string strFPLBID)
        {
            DataTable result = new DataTable();

            IYljxjjmxService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjmx_BDD(strYear, strMonth, strKSZD_ID, strFPLBID);
            });

            return result;
        }
    }
}
