using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 编码规则配置表
    /// </summary>
    [DataContract]
    public class CodeSetInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public CodeSetInfo()
		{
            this.ID = System.Guid.NewGuid().ToString();
		}

        #region Property Members

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// PID
        /// </summary>
        [DataMember]
        public virtual string PID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [DataMember]
        public virtual string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
		[DataMember]
        public virtual string FieldName { get; set; }

        /// <summary>
        /// 是否前缀
        /// </summary>
		[DataMember]
        public virtual bool HasPrefix { get; set; }

        /// <summary>
        /// 前缀规则，（例如"","yyyy","yyyyMM","yyyyMMDD"）
        /// </summary>
		[DataMember]
        public virtual string PrefixRule { get; set; }

        /// <summary>
        /// 前缀标识
        /// </summary>
		[DataMember]
        public virtual string StrPrefix { get; set; }

        /// <summary>
        /// 层数
        /// </summary>
		[DataMember]
        public virtual int LayerNumber { get; set; }

        /// <summary>
        /// 层长度
        /// </summary>
		[DataMember]
        public virtual int LayerLength { get; set; }

        /// <summary>
        /// 每层步数
        /// </summary>
		[DataMember]
        public virtual int LayerStep { get; set; }

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