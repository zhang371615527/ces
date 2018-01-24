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

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class TaskCaller : BaseLocalService<TaskInfo>, ITaskService
    {
        private Task bll = null;

        public TaskCaller() : base(BLLFactory<Task>.Instance)
        {
            bll = baseBLL as Task;
        }

        public DataTable GetYdmbWfData(string vsRoles)
        {
            return bll.GetYdmbWfData(vsRoles);
        }
        public DataTable GetJxysWfData(string vsRoles)
        {
            return bll.GetJxysWfData(vsRoles);
        }
        public DataTable GetAuditSteps(string WorkFlowID, string StepID)
        {
            return bll.GetAuditSteps(WorkFlowID, StepID);
        }
        public bool SubmitToWorkFlow(string TableName, string WFCol, string BillStateCol, string TaskID, string SubUserCol, string SubTimeCol, string IDs, string CurrentUserName)
        {
            return bll.SubmitToWorkFlow(TableName, WFCol, BillStateCol, TaskID, SubUserCol, SubTimeCol, IDs, CurrentUserName);
        }

        public bool AuditMethod(string BillID, string WorkFlowID, string StepID, string BizType, string Flag, string Opinion, string Step, string CurrentUserName)
        {
            return bll.AuditMethod(BillID, WorkFlowID, StepID, BizType, Flag, Opinion, Step, CurrentUserName);
        }
    }
}
