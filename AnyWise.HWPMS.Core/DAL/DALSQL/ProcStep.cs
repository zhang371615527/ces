using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;

namespace AnyWise.HWPMS.DALSQL
{
    /// <summary>
    /// 流程配置步骤表
    /// </summary>
    public class ProcStep : BaseDALSQL<ProcStepInfo>, IProcStep
    {
        #region 对象实例及构造函数

        public static ProcStep Instance
        {
            get
            {
                return new ProcStep();
            }
        }
        public ProcStep()
            : base("WF_ProcStep", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override ProcStepInfo DataReaderToEntity(IDataReader dataReader)
        {
            ProcStepInfo info = new ProcStepInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.TaskID = reader.GetString("TaskID");
            info.StepID = reader.GetInt32("StepID");
            info.StepName = reader.GetString("StepName");
            info.StepRoleId = reader.GetString("StepRoleId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ProcStepInfo obj)
        {
            ProcStepInfo info = obj as ProcStepInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("TaskID", info.TaskID);
            hash.Add("StepID", info.StepID);
            hash.Add("StepName", info.StepName);
            hash.Add("StepRoleId", info.StepRoleId);

            return hash;
        }

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("ID", "内码");
            dict.Add("TaskID", "流程ID");
            dict.Add("StepID", "步骤号");
            dict.Add("StepName", "步骤名称");
            dict.Add("StepRoleId", "步骤角色");
            #endregion

            return dict;
        }

    }
}