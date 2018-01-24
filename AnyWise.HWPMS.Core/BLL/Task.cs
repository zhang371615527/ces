using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using System.Reflection;
using AnyWise.Framework.Commons;
using System.Text;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 流程配置表
    /// </summary>
    public class Task : BaseBLL<TaskInfo>
    {
        private ITask itask_0;

        public Task()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.itask_0 = base.baseDal as ITask;
        }
        public DataTable GetYdmbWfData(string vsRoles) 
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            // 待拓展 通过WorkFlowID 关联业务表数据 
            sbsql.Append("Select Biz_Ydmb.ID as BillID,BIZ_WORKFLOWSTEP.WorkFlowID as WorkFlowID,* from BIZ_WORKFLOWSTEP ");
            sbsql.Append("Inner Join Biz_Ydmb on Biz_Ydmb.WorkFlowID = BIZ_WORKFLOWSTEP.WorkFlowID ");
            sbsql.Append(" Where BizType = 'YDMBSP' and StepState = '0' and StepRoleID in (" + vsRoles + ") ");

            dt = itask_0.SqlTable(sbsql.ToString());

            return dt;
        }

        public DataTable GetJxysWfData(string vsRoles)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            // 待拓展 通过WorkFlowID 关联业务表数据 
            sbsql.Append("Select Biz_Jxyszb.ID as BillID,BIZ_WORKFLOWSTEP.WorkFlowID as WorkFlowID, ");
            sbsql.Append("Year,Month,T_ACL_OU.Name as KSZD_Name,Biz_Jxyszb.Value,LjMoney,Biz_Jxyszb.Note,StepID,Stepname,BizType ");
            sbsql.Append("from BIZ_WORKFLOWSTEP ");
            sbsql.Append("Inner Join Biz_Jxyszb on Biz_Jxyszb.WorkFlowID = BIZ_WORKFLOWSTEP.WorkFlowID ");
            sbsql.Append("Inner Join Biz_Jxys on Biz_Jxys.ID = Biz_Jxyszb.PID ");
            sbsql.Append("Left Join T_ACL_OU on Biz_Jxys.KSZD_ID = T_ACL_OU.ID ");
            sbsql.Append("Where BizType = 'JXYSSP' and StepState = '0' and StepRoleID in (" + vsRoles + ") ");

            dt = itask_0.SqlTable(sbsql.ToString());

            return dt;
        }

        public DataTable GetAuditSteps(string WorkFlowID, string StepID)
        {
            DataTable dt = new DataTable();
            string vsSql = "";

            vsSql = "select BizType,StepID,StepName,StepRoleID,T_ACL_Role.Name as StepRoleName from BIZ_WORKFLOWSTEP "
                    + " Left Join T_ACL_Role on BIZ_WORKFLOWSTEP.StepRoleID = T_ACL_Role.ID "
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID < " + Convert.ToInt16(StepID) + " order by StepID";
            dt = itask_0.SqlTable(vsSql);

            return dt;
        }
        public bool SubmitToWorkFlow(string TableName, string WFCol, string BillStateCol, string TaskID, string SubUserCol, string SubTimeCol, string IDs, string CurrentUserName)
        {
            DbTransaction tr = base.CreateTransaction();
            string[] sArray = IDs.Split(new char[] { ',' });
            string BillID = "";
            try
            {
                for (int i = 0; i < sArray.Length; i++)
                {
                    BillID = sArray[i];
                    string guid = Guid.NewGuid().ToString();
                    //更新业务单据 审批流ID 初始化审批状态
                    string vsUpdateSql = "update " + TableName + " set " + WFCol + " = '" + guid + "'," + BillStateCol + " = '0'," + SubUserCol + " = '" + CurrentUserName + "'," + SubTimeCol + " = '" + DateTime.Now + "' "
                        + " where ID = '" + BillID + "'";
                    itask_0.SqlExecute(vsUpdateSql,tr);
                    //插入审批流程表流程配置数据
                    string vsInsertSql = "Insert Into Biz_WorkFlowStep(WorkFlowID,BizType,StepID,StepName,StepRoleId)"
                        + " select '" + guid + "',BizType,StepID,StepName,StepRoleId from WF_Task "
                        + " inner join WF_ProcStep on WF_Task.ID = WF_ProcStep.TaskID "
                        + " where WF_Task.ID = '" + TaskID + "' ";
                    itask_0.SqlExecute(vsInsertSql,tr);
                    //设置审批流初始步骤
                    vsUpdateSql = "update Biz_WorkFlowStep set StepState = '0'"
                        + " where WorkFlowID = '" + guid + "' and StepID = (Select Min(StepID) from Biz_WorkFlowStep where WorkFlowID = '" + guid + "')";
                    itask_0.SqlExecute(vsUpdateSql, tr);
                }
                tr.Commit();
                return true;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                tr.Rollback();
                return false;
            }
            finally
            {
                tr.Dispose();
            }
        }
        public bool AuditMethod(string BillID, string WorkFlowID, string StepID, string BizType, string Flag, string Opinion, string Step, string CurrentUserName)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string vsSql = "";
            DbTransaction tr = base.CreateTransaction();
            try
            {
                //Flag 1 审批通过 2 回退 3 驳回
                if (Flag == "1")
                {
                    //获取后续节点
                    vsSql = "select BizType,StepID,StepName,StepRoleID,T_ACL_Role.Name as StepRoleName from BIZ_WORKFLOWSTEP "
                    + " Left Join T_ACL_Role on BIZ_WORKFLOWSTEP.StepRoleID = T_ACL_Role.ID "
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID > " + Convert.ToInt16(StepID) + " order by StepID";
                    dt = itask_0.SqlTable(vsSql);

                    //审批流状态更新
                    string vsUpdateSql = "update Biz_WorkFlowStep set StepState = '1',Approver = '" + CurrentUserName + "',AppTime = '" + DateTime.Now + "',Opinion = '" + Opinion + "'"
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID = '" + Convert.ToInt16(StepID) + "'";
                    i = itask_0.SqlExecute(vsUpdateSql,tr);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        vsUpdateSql = "update Biz_WorkFlowStep set StepState = '0'"
                        + " where WorkFlowID = '" + WorkFlowID + "' and StepID = '" + Convert.ToInt16(dt.Rows[0]["StepID"]) + "'";
                        i = itask_0.SqlExecute(vsUpdateSql,tr);
                    }
                    //业务单据状态更新
                    if (BizType == "YDMBSP")
                    {
                        if (dt != null && dt.Rows.Count == 0)
                        {
                            vsUpdateSql = "update Biz_Ydmb set SubState = '1',Checker = '" + CurrentUserName + "',CheckTime = '" + DateTime.Now + "' "
                        + " where WorkFlowID = '" + WorkFlowID + "' and ID = '" + BillID + "' ";
                            i = itask_0.SqlExecute(vsUpdateSql,tr);
                        }
                    }
                    else if (BizType == "JXYSSP")
                    {
                        if (dt != null && dt.Rows.Count == 0)
                        {
                            vsUpdateSql = "update Biz_Jxyszb set BillState = '1',Approver = '" + CurrentUserName + "',AppTime = '" + DateTime.Now + "' "
                        + " where WorkFlowID = '" + WorkFlowID + "' and ID = '" + BillID + "' ";
                            i = itask_0.SqlExecute(vsUpdateSql,tr);
                        }
                    }
                    else { }
                }
                else if (Flag == "2")
                {
                    //回退处理
                    string vsUpdateSql = "update Biz_WorkFlowStep set StepState = '0'"
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID = '" + Convert.ToInt16(Step) + "'";
                    i = itask_0.SqlExecute(vsUpdateSql,tr);
                    vsUpdateSql = "update Biz_WorkFlowStep set StepState = ''"
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID > '" + Convert.ToInt16(Step) + "'";
                    i = itask_0.SqlExecute(vsUpdateSql,tr);
                }
                else
                {
                    //审批流状态更新
                    string vsUpdateSql = "update Biz_WorkFlowStep set StepState = '3',Approver = '" + CurrentUserName + "',AppTime = '" + DateTime.Now + "',Opinion = '" + Opinion + "'"
                    + " where WorkFlowID = '" + WorkFlowID + "' and StepID = '" + Convert.ToInt16(StepID) + "'";
                    i = itask_0.SqlExecute(vsUpdateSql,tr);
                    //业务单据状态更新
                    if (BizType == "YDMBSP")
                    {
                        vsUpdateSql = "update Biz_Ydmb set SubState = '3',Checker = '" + CurrentUserName + "',CheckTime = '" + DateTime.Now + "' "
                        + " where WorkFlowID = '" + WorkFlowID + "' and ID = '" + BillID + "' ";
                        i = itask_0.SqlExecute(vsUpdateSql,tr);
                    }
                    else if (BizType == "JXYSSP")
                    {
                        vsUpdateSql = "update Biz_Jxyszb set BillState = '3',Approver = '" + CurrentUserName + "',AppTime = '" + DateTime.Now + "' "
                        + " where WorkFlowID = '" + WorkFlowID + "' and ID = '" + BillID + "' ";
                        i = itask_0.SqlExecute(vsUpdateSql,tr);
                    }
                    else { }
                }
                tr.Commit();
                return true;

            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                tr.Rollback();
                return false;
            }
            finally
            {
                tr.Dispose();
            }
        }
    }
}
