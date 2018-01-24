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
    public class TaskCaller : BaseWCFService<TaskInfo>, ITaskService
    {
        public TaskCaller()  : base()
        {	
            this.ConfigurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.TaskService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<TaskInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ITaskService CreateSubClient()
        {
            CustomClientChannel<ITaskService> factory = new CustomClientChannel<ITaskService>(endpointConfigurationName, ConfigurationPath);
            return factory.CreateChannel();
        }

        public DataTable GetYdmbWfData(string vsRoles)
        {
            DataTable result = new DataTable();
            ITaskService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetYdmbWfData(vsRoles);
            });
            return result;
        }
        public DataTable GetJxysWfData(string vsRoles)
        {
            DataTable result = new DataTable();
            ITaskService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetJxysWfData(vsRoles);
            });
            return result;
        }
        public DataTable GetAuditSteps(string WorkFlowID, string StepID)
        {
            DataTable result = new DataTable();
            ITaskService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetAuditSteps(WorkFlowID, StepID);
            });
            return result;
        }
        
        public bool SubmitToWorkFlow(string TableName, string WFCol, string BillStateCol, string TaskID, string SubUserCol, string SubTimeCol, string IDs, string CurrentUserName)
        {
            bool result = false;
            ITaskService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SubmitToWorkFlow(TableName, WFCol, BillStateCol, TaskID, SubUserCol, SubTimeCol, IDs, CurrentUserName);
            });
            return result;
        }
        public bool AuditMethod(string BillID, string WorkFlowID, string StepID, string BizType, string Flag, string Opinion, string Step, string CurrentUserName)
        {
            bool result = false;
            ITaskService service = this.CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.AuditMethod(BillID, WorkFlowID, StepID, BizType, Flag, Opinion, Step, CurrentUserName);
            });
            return result;
        }
    }
}
