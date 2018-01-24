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
    public class YljxjjhzCaller : BaseWCFService<YljxjjhzInfo>, IYljxjjhzService
    {
        public YljxjjhzCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.YljxjjhzService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<YljxjjhzInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IYljxjjhzService CreateSubClient()
        {
            CustomClientChannel<IYljxjjhzService> factory = new CustomClientChannel<IYljxjjhzService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxjjhzInfo> FindByName(string name)
        //{
        //    List<YljxjjhzInfo> result = new List<YljxjjhzInfo>();

        //    IYljxjjhzService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool SaveExcelData(List<YljxjjhzInfo> list)
        {
            bool result = false;
            IYljxjjhzService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });
            return result;
        }

        /// <summary>
        /// 医疗绩效奖金汇总表
        /// </summary>
        public List<YljxjjhzInfo> Yljxjjhz_FWP(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            List<YljxjjhzInfo> result = new List<YljxjjhzInfo>();

            IYljxjjhzService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjhz_FWP(intPageSize, intPageCount, mSizeBackup, where);
            });

            return result;
        }

        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        public DataTable Yljxjjhz_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            DataTable result = new DataTable();

            IYljxjjhzService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjhz_Cal(strYear, strMonth, strKSID, strZXZD_ID);
            });

            return result;
        }
        public bool Yljxjjhz_Insert(List<YljxjjhzInfo> listjj)
        {
            bool result = false;
            IYljxjjhzService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjhz_Insert(listjj);
            });
            return result;
        }
        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        public DataTable Yljxjjhz_BSD(string strYear, string strMonth, string strKSZD_ID)
        {
            DataTable result = new DataTable();

            IYljxjjhzService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.Yljxjjhz_BSD(strYear, strMonth, strKSZD_ID);
            });

            return result;
        }
    }
}
