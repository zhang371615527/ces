using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 绩效预算金额子表
    /// </summary>
    [DataContract]
    public class JxyszbInfo : BaseEntity
    {
        public JxyszbInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
            this.Value= 0;       
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
		[DataMember]
        public virtual string PID { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
		[DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 核算方式
        /// </summary>
		[DataMember]
        public virtual string AccountWay { get; set; }

        /// <summary>
        /// 核算公式
        /// </summary>
		[DataMember]
        public virtual string Formula { get; set; }
        
        /// <summary>
        /// 核算比率
        /// </summary>
        [DataMember]
        public virtual string Ratio { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
		[DataMember]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 累计金额
        /// </summary>
        [DataMember]
        public virtual decimal LjMoney { get; set; }

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
        /// 流程实例内码
        /// </summary>
        [DataMember]
        public virtual string WorkFlowID { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        [DataMember]
        public virtual string SubmitUser { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        [DataMember]
        public virtual string BillState { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        [DataMember]
        public virtual string Approver { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        [DataMember]
        public virtual DateTime AppTime { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        public virtual DateTime SubTime { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }

        #endregion
    }
}
