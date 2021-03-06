﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 月度目标表
    /// </summary>
    [DataContract]
    public class YdmbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YdmbInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                  
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 目标编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 所属医院
        /// </summary>
		[DataMember]
        public virtual string HosID { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
		[DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
		[DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 管理部门
        /// </summary>
        [DataMember]
        public virtual string ManDep_ID { get; set; }
        [DataMember]
        public virtual string ManDep_Name { get; set; }

        /// <summary>
        /// 提报部门
        /// </summary>
        [DataMember]
        public virtual string SubDep_ID { get; set; }
        [DataMember]
        public virtual string SubDep_Name { get; set; }

        /// <summary>
        /// 提报人
        /// </summary>
        [DataMember]
        public virtual string SubUser_ID { get; set; }
        [DataMember]
        public virtual string SubUser_Name { get; set; }

        /// <summary>
        /// 提报时间
        /// </summary>
		[DataMember]
        public virtual DateTime SubTime { get; set; }

        /// <summary>
        /// 提报状态
        /// </summary>
		[DataMember]
        public virtual string SubState { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
		[DataMember]
        public virtual string Checker { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
		[DataMember]
        public virtual DateTime CheckTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
		[DataMember]
        public virtual string Editor { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime EditTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }

        /// <summary>
        /// 年度目标子表ID
        /// </summary>
        [DataMember]
        public virtual string Ndmbzb_ID { get; set; }

        /// <summary>
        /// 年度目标名称
        /// </summary>
        [DataMember]
        public virtual string Ndmb_Name { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
        [DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// 考核指标ID
        /// </summary>
        [DataMember]
        public virtual string KHZB_ID { get; set; }

        /// <summary>
        /// 考核指标名称
        /// </summary>
        [DataMember]
        public virtual string KHZB_Name { get; set; }
        /// <summary>
        /// 审批流程内码
        /// </summary>
        [DataMember]
        public virtual string WorkFlowID { get; set; }
        /// <summary>
        /// 提价审核人
        /// </summary>
        [DataMember]
        public virtual string SubmitUser { get; set; }
        #endregion

    }
}