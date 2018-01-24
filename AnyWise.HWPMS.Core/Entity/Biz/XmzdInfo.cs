using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 项目字典
    /// </summary>
    [DataContract]
    public class XmzdInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public XmzdInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                     this.PriceStand= 0;
             this.OrderNo= 0;
          
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// HIS分类编码
        /// </summary>
		[DataMember]
        public virtual string HISCode { get; set; }

        /// <summary>
        /// HIS分类名称
        /// </summary>
		[DataMember]
        public virtual string HISName { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
		[DataMember]
        public virtual string ZxzdId { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
		[DataMember]
        public virtual string Pym { get; set; }

        /// <summary>
        /// 除外内容
        /// </summary>
		[DataMember]
        public virtual string Except { get; set; }

        /// <summary>
        /// 计价单位
        /// </summary>
		[DataMember]
        public virtual string Unit { get; set; }
        [DataMember]
        public virtual string UnitName { get; set; }
        /// <summary>
        /// 价格标准
        /// </summary>
		[DataMember]
        public virtual decimal PriceStand { get; set; }

        /// <summary>
        /// 开单点值
        /// </summary>
        [DataMember]
        public virtual decimal BillPoint { get; set; }

        /// <summary>
        /// 执行点值
        /// </summary>
        [DataMember]
        public virtual decimal ExecPoint { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
		[DataMember]
        public virtual int OrderNo { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
		[DataMember]
        public virtual string Flag { get; set; }

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
        /// 是否启用
        /// </summary>
		[DataMember]
        public virtual string Enabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string Note { get; set; }

        /// <summary>
        /// 项目类别ID
        /// </summary>
        [DataMember]
        public virtual string Xmlb_ID { get; set; }
        [DataMember]
        public virtual string Xmlb_Name { get; set; }
        #endregion

    }
}