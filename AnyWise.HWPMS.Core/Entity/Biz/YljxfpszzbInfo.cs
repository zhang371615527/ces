using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效分配设置子表
    /// </summary>
    [DataContract]
    public class YljxfpszzbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YljxfpszzbInfo()
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
        /// 主表内码
        /// </summary>
        [DataMember]
        public virtual string Jxfpsz_ID { get; set; }

        /// <summary>
        /// 人员内码
        /// </summary>
        [DataMember]
        public virtual string Ryzd_ID { get; set; }
        [DataMember]
        public virtual string Ryzd_Name { get; set; }

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