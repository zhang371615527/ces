using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 月度绩效考核表
    /// </summary>
    [DataContract]
    public class YdjxkhInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YdjxkhInfo()
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
        /// 类型
        /// </summary>
		[DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
		[DataMember]
        public virtual DateTime? BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
		[DataMember]
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// 责任部门
        /// </summary>
		[DataMember]
        public virtual string ResKS_ID { get; set; }

        /// <summary>
        /// 考核部门
        /// </summary>
		[DataMember]
        public virtual string CheckKS_ID { get; set; }

        /// <summary>
        /// 考核时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CheckTime { get; set; }

        /// <summary>
        /// 考核人
        /// </summary>
		[DataMember]
        public virtual string Checker { get; set; }

        /// <summary>
        /// 总考核得分
        /// </summary>
        [DataMember]
        public virtual decimal? TotalPoint { get; set; }

        /// <summary>
        /// 平均完成率
        /// </summary>
        [DataMember]
        public virtual decimal? AverageRatio { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
		[DataMember]
        public virtual string State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
		[DataMember]
        public virtual string Editor { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? EditTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }


        #endregion

    }
}