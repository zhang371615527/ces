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
    public class CodeSetCaller : BaseWCFService<CodeSetInfo>, ICodeSetService
    {
        public CodeSetCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.CodeSetService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<CodeSetInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ICodeSetService CreateSubClient()
        {
            CustomClientChannel<ICodeSetService> factory = new CustomClientChannel<ICodeSetService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<CodeSetInfo> FindByName(string name)
        //{
        //    List<CodeSetInfo> result = new List<CodeSetInfo>();

        //    ICodeSetService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}
        public List<CListItem> GetTableItems()
        {
            List<CListItem> result = new List<CListItem>();

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetTableItems();
            });

            return result;
        }
        public List<CListItem> GetColumnItems(string TableName)
        {
            List<CListItem> result = new List<CListItem>();

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetColumnItems(TableName);
            });

            return result;
        }
        public string GenerateTreeCode(string strParentCode, string strTableName, string strFieldName, int Layer, string ParentColumn)
        {
            string result = "";

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GenerateTreeCode(strParentCode, strTableName, strFieldName, Layer, ParentColumn);
            });

            return result;
        }

        public string GenerateTreeChildCode(string strParentCode, string strTableName, string strChildName, string strFieldName, int Layer, string ParentColumn)
        {
            string result = "";

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GenerateTreeChildCode(strParentCode, strTableName, strChildName, strFieldName, Layer, ParentColumn);
            });

            return result;
        }
        public string GenerateCode(string strTableName, string strFieldName, string strType)
        {
            string result = "";

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GenerateCode(strTableName, strFieldName, strType);
            });

            return result;
        }
        public string GenerateCodeEx(string strTableName, string strBusType, string strFieldName, string strType)
        {
            string result = "";

            ICodeSetService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GenerateCodeEx(strTableName, strBusType, strFieldName, strType);
            });

            return result;
        }
    }
}
