using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using System.Data;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface ITaskService : IBaseService<TaskInfo>
    {
        [OperationContract]
        DataTable GetYdmbWfData(string vsRoles);

        [OperationContract]
        DataTable GetJxysWfData(string vsRoles);

        [OperationContract]
        DataTable GetAuditSteps(string WorkFlowID, string StepID);
        
        [OperationContract]
        bool SubmitToWorkFlow(string TableName, string WFCol, string BillStateCol, string TaskID, string SubUserCol, string SubTimeCol, string IDs, string CurrentUserName);

        [OperationContract]
        bool AuditMethod(string BillID, string WorkFlowID, string StepID, string BizType, string Flag, string Opinion, string Step, string CurrentUserName);
    }
}
