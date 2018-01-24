using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 表映射关系表
    /// </summary>
    [DataContract]
    public class TableMappingInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public TableMappingInfo()
		{
            this.ID = System.Guid.NewGuid().ToString();
		}

        #region Property Members

        /// <summary>
        /// 内码
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 目标表
        /// </summary>
        [DataMember]
        public virtual string TargetTable { get; set; }

        /// <summary>
        /// 源表
        /// </summary>
        [DataMember]
        public virtual string SourceTable { get; set; }
        /// <summary>
        /// 年列
        /// </summary>
        [DataMember]
        public virtual string ColYear { get; set; }
        /// <summary>
        /// 月列
        /// </summary>
        [DataMember]
        public virtual string ColMonth { get; set; }
        /// <summary>
        /// 日列
        /// </summary>
        [DataMember]
        public virtual string ColDataConfig { get; set; }

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