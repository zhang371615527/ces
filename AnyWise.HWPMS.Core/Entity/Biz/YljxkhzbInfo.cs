using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效二次考核子表
    /// </summary>
    [DataContract]
    public class YljxkhzbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public YljxkhzbInfo()
		{
            this.WeightPoint = 0;
            this.Point = 0;
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
        public virtual string JXKH_ID { get; set; }

        /// <summary>
        /// 指标编码
        /// </summary>
		[DataMember]
        public virtual string ZBID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [DataMember]
        public virtual string XMMC { get; set; }
        /// <summary>
        /// 关键名称
        /// </summary>
		[DataMember]
        public virtual string ZBMC { get; set; }

        /// <summary>
        /// 考核标准
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 权重分值
        /// </summary>
		[DataMember]
        public virtual decimal WeightPoint { get; set; }

        /// <summary>
        /// 考核得分
        /// </summary>
		[DataMember]
        public virtual decimal Point { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
		[DataMember]
        public virtual decimal OrderNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }
        [DataMember]
        public virtual string ItemNote { get; set; }
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