using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Dynamic;
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
    public class DrgsgzlCaller : BaseWCFService<DrgsgzlInfo>, IDrgsgzlService
    {
        public DrgsgzlCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.DrgsgzlService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<DrgsgzlInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IDrgsgzlService CreateSubClient()
        {
            CustomClientChannel<IDrgsgzlService> factory = new CustomClientChannel<IDrgsgzlService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<DrgsgzlInfo> FindByName(string name)
        //{
        //    List<DrgsgzlInfo> result = new List<DrgsgzlInfo>();

        //    IDrgsgzlService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

        public bool InsertBatch(List<DrgsgzlInfo> list)
        {
            bool result = false;
            IDrgsgzlService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.InsertBatch(list);
            });
            return result;
        }

        /// <summary>
        /// 返回CMI折线图数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable DRGSAna_CMIAna(string where)
        {
            DataTable dt = new DataTable();
            IDrgsgzlService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                dt = service.DRGSAna_CMIAna(where);
            });
            return dt;
        }

        #region 收入折线图
        public string DRGSAna_GetxAxis(string Year)
        {
            string s="";
            IDrgsgzlService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                s = service.DRGSAna_GetxAxis(Year);
            });
            return s;
        }
        public string DRGSAna_GetIncome(string Year)
        {
            string s="";
            IDrgsgzlService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                s = service.DRGSAna_GetIncome(Year);
            });
            return s;
        }
        #endregion

        /// <summary>
        /// DRGs绩效指标查询
        /// </summary>
        public List<ExpandoObject> DRGSAna_DRGsDetail(string BeginPeriod, string EndPeriod)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();

            IDrgsgzlService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.DRGSAna_DRGsDetail(BeginPeriod,EndPeriod);
            });

            return result;
        }
    }
}
