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
    public class ColumnMappingCaller : BaseWCFService<ColumnMappingInfo>, IColumnMappingService
    {
        public ColumnMappingCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.ColumnMappingService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<ColumnMappingInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IColumnMappingService CreateSubClient()
        {
            CustomClientChannel<IColumnMappingService> factory = new CustomClientChannel<IColumnMappingService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        public bool SaveExcelData(List<ColumnMappingInfo> list)
        {
            bool result = false;

            IColumnMappingService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveExcelData(list);
            });

            return result;
        }

    }
}
