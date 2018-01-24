using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 流程配置步骤表
    /// </summary>
    [DataContract]
    public class ProcStepInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ProcStepInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
        }

        #region Property Members

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }
        [DataMember]
        public virtual string ItemID { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        [DataMember]
        public virtual string TaskID { get; set; }

        /// <summary>
        /// 步骤号
        /// </summary>
        [DataMember]
        public virtual int StepID { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        [DataMember]
        public virtual string StepName { get; set; }

        /// <summary>
        /// 步骤角色
        /// </summary>
        [DataMember]
        public virtual string StepRoleId { get; set; }
        [DataMember]
        public virtual string StepRoleName { get; set; }
        #endregion

    }
}