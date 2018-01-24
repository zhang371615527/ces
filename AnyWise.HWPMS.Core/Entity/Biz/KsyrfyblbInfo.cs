using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 科室用人费用比率
    /// </summary>
    [DataContract]
    public class KsyrfyblbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public KsyrfyblbInfo()
		{
               this.Ratio= 0;
              this.OrderNo= 0;
        
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 科室编号
        /// </summary>
		[DataMember]
        public virtual string KszdId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
		[DataMember]
        public virtual string KSZD_Name { get; set; }

        /// <summary>
        /// 费用比率
        /// </summary>
		[DataMember]
        public virtual decimal Ratio { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
		[DataMember]
        public virtual int OrderNo { get; set; }

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
        /// 是否启用
        /// </summary>
		[DataMember]
        public virtual string Enabled { get; set; }


        #endregion

    }
}