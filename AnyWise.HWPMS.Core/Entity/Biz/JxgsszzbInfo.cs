using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 绩效公式设置子表
    /// </summary>
    [DataContract]
    public class JxgsszzbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public JxgsszzbInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
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
        /// 公式内码
        /// </summary>
		[DataMember]
        public virtual string Jxgs_ID { get; set; }

        /// <summary>
        /// 左表达式
        /// </summary>
		[DataMember]
        public virtual string LeftOperator { get; set; }

        /// <summary>
        /// 参数内码
        /// </summary>
        [DataMember]
        public virtual string ParamID { get; set; }
        [DataMember]
        public virtual string ParamName { get; set; }
        /// <summary>
        /// 右表达式
        /// </summary>
        [DataMember]
        public virtual string RightOperator { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public virtual int OrderNo { get; set; }
        [DataMember]
        public virtual int ItemOrderNo { get; set; }

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
        /// 修改时间
        /// </summary>
        [DataMember]
        public virtual DateTime EditTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [DataMember]
        public virtual string Editor { get; set; }
		///<summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }
        [DataMember]
        public virtual string ItemNote { get; set; }
        #endregion

    }
}