using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 列映射关系表
    /// </summary>
    [DataContract]
    public class ColumnMappingInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ColumnMappingInfo()
		{
            this.ID = System.Guid.NewGuid().ToString();
		}

        #region Property Members

        /// <summary>
        /// 内码
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }
        [DataMember]
        public virtual string ItemID { get; set; }

        /// <summary>
        /// 主表内码
        /// </summary>
        [DataMember]
        public virtual string TabMapID { get; set; }

        /// <summary>
        /// 目标列
        /// </summary>
        [DataMember]
        public virtual string TargetCol { get; set; }

        /// <summary>
        /// 源列
        /// </summary>
        [DataMember]
        public virtual string SourceCol { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
		[DataMember]
        public virtual string ColType { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        [DataMember]
        public virtual string IsPK { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string ItemNote { get; set; }

        #endregion

    }
}