﻿using System;
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
    public class JxcsbCaller : BaseWCFService<JxcsbInfo>, IJxcsbService
    {
        public JxcsbCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.JxcsbService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<JxcsbInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IJxcsbService CreateSubClient()
        {
            CustomClientChannel<IJxcsbService> factory = new CustomClientChannel<IJxcsbService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<JxcsbInfo> FindByName(string name)
        //{
        //    List<JxcsbInfo> result = new List<JxcsbInfo>();

        //    IJxcsbService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}
        public bool InsertBatch(List<JxcsbInfo> list)
        {
            bool result = false;
            IJxcsbService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.InsertBatch(list);
            });
            return result;
        }
    }
}
