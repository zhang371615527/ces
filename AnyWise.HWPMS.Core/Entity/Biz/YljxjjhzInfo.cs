using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效奖金汇总
    /// </summary>
    [DataContract]
    public class YljxjjhzInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YljxjjhzInfo()
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
        /// 职系
        /// </summary>
		[DataMember]
        public virtual string ZxzdId { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
		[DataMember]
        public virtual string KszdId { get; set; }

        [DataMember]
        public virtual string KszdName { get; set; }

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
        /// 明细项
        /// </summary>
		[DataMember]
        public virtual string Detail { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
		[DataMember]
        public virtual decimal Value { get; set; }

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