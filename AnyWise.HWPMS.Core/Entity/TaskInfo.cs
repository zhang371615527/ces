using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 流程配置表
    /// </summary>
    [DataContract]
    public class TaskInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public TaskInfo()
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
        /// 业务类型
        /// </summary>
        [DataMember]
        public virtual string BizType { get; set; }

        /// <summary>
        /// TaskName
        /// </summary>
        [DataMember]
        public virtual string TaskName { get; set; }

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
        public virtual String Note { get; set; }
        #endregion

    }
}