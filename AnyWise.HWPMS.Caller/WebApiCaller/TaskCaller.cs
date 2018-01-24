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
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WebApiCaller
{
	/// <summary>
	/// 基于WebAPI方式的Facade接口实现类
	/// </summary>
    public class TaskCaller : BaseApiService<TaskInfo>, ITaskService
    {
        public TaskCaller() : base()
        {
            this.ConfigurationPath = ApiConfig.ConfigFileName; //Web API配置文件
            this.configurationName = ApiConfig.Task;
        }

        public DataTable GetYdmbWfData(string vsRoles)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                vsRoles = vsRoles
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetJxysWfData(string vsRoles)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                vsRoles = vsRoles
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }
        public DataTable GetAuditSteps(string WorkFlowID, string StepID)
        {

            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                WorkFlowID = WorkFlowID,
                StepID = StepID
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<DataTable>.ConvertJson(url, postData);
            return result;
        }

        public bool SubmitToWorkFlow(string TableName, string WFCol, string BillStateCol, string TaskID, string SubUserCol, string SubTimeCol, string IDs, string CurrentUserName)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                TableName = TableName,
                WFCol = WFCol,
                BillStateCol = BillStateCol,
                TaskID = TaskID,
                SubUserCol = SubUserCol,
                SubTimeCol = SubTimeCol,
                IDs = IDs,
                CurrentUserName = CurrentUserName
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }

        public bool AuditMethod(string BillID, string WorkFlowID, string StepID, string BizType, string Flag, string Opinion, string Step, string CurrentUserName)
        {
            var action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var postData = new
            {
                BillID = BillID,
                WorkFlowID = WorkFlowID,
                StepID = StepID,
                BizType = BizType,
                Flag = Flag,
                Opinion = Opinion,
                Step = Step,
                CurrentUserName = CurrentUserName
            }.ToJson();
            string url = GetPostUrlWithToken(action);

            var result = JsonHelper<CommonResult>.ConvertJson(url, postData);
            return (result != null) ? result.Success : false;
        }
    }
}
