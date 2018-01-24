using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效工作量
    /// </summary>
    [DataContract]
    public class YljxgzlInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YljxgzlInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                         this.Quantity= 0;
             this.Value= 0;
        
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 年
        /// </summary>
		[DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
		[DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
		[DataMember]
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// 费用来源
        /// </summary>
		[DataMember]
        public virtual string Source { get; set; }

        /// <summary>
        /// 开单科室代码
        /// </summary>
        [DataMember]
        public virtual string KszdId { get; set; }

        /// <summary>
        /// 开单科室名称
        /// </summary>
        [DataMember]
        public virtual string KszdName { get; set; }

        /// <summary>
        /// 开单医生代码
        /// </summary>
        [DataMember]
        public virtual string RyzdId { get; set; }

        /// <summary>
        /// 开单医生名称
        /// </summary>
        [DataMember]
        public virtual string RyzdName { get; set; }

        /// <summary>
        /// 项目大类
        /// </summary>
        [DataMember]
        public virtual string Xmlbid { get; set; }

        /// <summary>
        /// 项目大类名称
        /// </summary>
        [DataMember]
        public virtual string XmlbName { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
		[DataMember]
        public virtual string XmzdId { get; set; }

        /// <summary>
        /// 项目代码名称
        /// </summary>
        [DataMember]
        public virtual string XmzdName { get; set; }

        /// <summary>
        /// 计量单位代码
        /// </summary>
        [DataMember]
        public virtual string Unit { get; set; }

        /// <summary>
        /// 计量单位名称
        /// </summary>
        [DataMember]
        public virtual string UnitName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 执行科室代码
        /// </summary>
        [DataMember]
        public virtual string ExecKSID { get; set; }

        /// <summary>
        /// 执行科室名称
        /// </summary>
        [DataMember]
        public virtual string ExecKSName { get; set; }

        /// <summary>
        /// 执行医生代码
        /// </summary>
        [DataMember]
        public virtual string ExecRYZDID { get; set; }

        /// <summary>
        /// 执行医生名称
        /// </summary>
        [DataMember]
        public virtual string ExecRYZDName { get; set; }

        /// <summary>
        /// 是否药品收入
        /// </summary>
        [DataMember]
        public virtual string IsDrugIncome { get; set; }

        /// <summary>
        /// 病区代码
        /// </summary>
        [DataMember]
        public virtual string Bqid { get; set; }

        /// <summary>
        /// 病区Name
        /// </summary>
        [DataMember]
        public virtual string BqName { get; set; }

        /// <summary>
        /// 职系类别
        /// </summary>
		[DataMember]
        public virtual string ZxzdId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string Note { get; set; }

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

        #endregion

    }
}