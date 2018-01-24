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
    public class HljxjjgzlCaller : BaseWCFService<HljxjjgzlInfo>, IHljxjjgzlService
    {
        public HljxjjgzlCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.HljxjjgzlService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<HljxjjgzlInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IHljxjjgzlService CreateSubClient()
        {
            CustomClientChannel<IHljxjjgzlService> factory = new CustomClientChannel<IHljxjjgzlService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        public bool SaveExcelData(List<HljxjjgzlInfo> list)
        {
            bool result = false;
            IHljxjjgzlService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });
            return result;
        }

    }
}