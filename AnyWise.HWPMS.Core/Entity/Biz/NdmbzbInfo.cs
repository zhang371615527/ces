using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 年度目标子表
    /// </summary>
    [DataContract]
    public class NdmbzbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public NdmbzbInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                   this.TargetValue= 0;
             this.RealValue= 0;
             this.Ratio= 0;
         
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 传递内码
        /// </summary>
        [DataMember]
        public virtual string ItemID { get; set; }

        /// <summary>
        /// 年度目标内码
        /// </summary>
		[DataMember]
        public virtual string NdmbId { get; set; }

        /// <summary>
        /// 所属医院
        /// </summary>
		[DataMember]
        public virtual string HosID { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
		[DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// 目标等级
        /// </summary>
		[DataMember]
        public virtual string Level { get; set; }

        /// <summary>
        /// 目标内容
        /// </summary>
		[DataMember]
        public virtual string KhzbId { get; set; }

        [DataMember]
        public virtual string KhzbName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
		[DataMember]
        public virtual string Unit { get; set; }
        [DataMember]
        public virtual string UnitName { get; set; }
        /// <summary>
        /// 目标值
        /// </summary>
		[DataMember]
        public virtual decimal TargetValue { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
		[DataMember]
        public virtual decimal RealValue { get; set; }

        /// <summary>
        /// 完成率
        /// </summary>
		[DataMember]
        public virtual decimal Ratio { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
		[DataMember]
        public virtual DateTime CompTime { get; set; }

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
        public virtual string ItemNote { get; set; }


        #endregion

    }
}