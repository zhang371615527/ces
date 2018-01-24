using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 项目类别表
    /// </summary>
    [DataContract]
    public class XmlbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public XmlbInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
            this.LayerNumber= 0;
		}

        #region Property Members

        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 父级码
        /// </summary>
		[DataMember]
        public virtual string PID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }
		
        /// <summary>
        /// 名称
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

		/// <summary>
        /// 职系
        /// </summary>
		[DataMember]
        public virtual string ZXZD_ID { get; set; }
		
        /// <summary>
        /// 层数
        /// </summary>
		[DataMember]
        public virtual int LayerNumber { get; set; }

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

		///<summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }
        #endregion

    }
}