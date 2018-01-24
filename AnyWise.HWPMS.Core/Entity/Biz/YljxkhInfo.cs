using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效二次考核
    /// </summary>
    [DataContract]
    public class YljxkhInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YljxkhInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                 this.Weight= 0;
                 
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 考核编号
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
        /// 考核得分
        /// </summary>
		[DataMember]
        public virtual decimal Weight { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
		[DataMember]
        public virtual string ResPersion { get; set; }
        [DataMember]
        public virtual string ResPersionName { get; set; }
        /// <summary>
        /// 责任部门
        /// </summary>
        [DataMember]
        public virtual string ResKS_ID { get; set; }
        [DataMember]
        public virtual string ResKS_Name { get; set; }

        /// <summary>
        /// 考核部门
        /// </summary>
        [DataMember]
        public virtual string CheckKS_ID { get; set; }
        [DataMember]
        public virtual string CheckKS_Name { get; set; }

        /// <summary>
        /// 考核人
        /// </summary>
		[DataMember]
        public virtual string Checker { get; set; }
        [DataMember]
        public virtual string CheckerName { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
		[DataMember]
        public virtual DateTime BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
		[DataMember]
        public virtual DateTime EndDate { get; set; }

        /// <summary>
        /// 考核时间
        /// </summary>
		[DataMember]
        public virtual DateTime CheckTime { get; set; }

        /// <summary>
        /// 职系
        /// </summary>
		[DataMember]
        public virtual string ZXZD_ID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
		[DataMember]
        public virtual string Type { get; set; }
        [DataMember]
        public virtual string TypeName { get; set; }
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


        #endregion

    }
}