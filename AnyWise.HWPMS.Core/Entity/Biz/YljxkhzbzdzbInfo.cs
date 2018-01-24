using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效考核指标字典子表
    /// </summary>
    [DataContract]
    public class YljxkhzbzdzbInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YljxkhzbzdzbInfo()
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
        /// 指标字典内码
        /// </summary>
        [DataMember]
        public virtual string ZBZD_ID { get; set; }

        /// <summary>
        /// 项目标号
        /// </summary>
        [DataMember]
        public virtual string XMBH { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [DataMember]
        public virtual string XMMC { get; set; }

        /// <summary>
        /// 指标名称
        /// </summary>
        [DataMember]
        public virtual string ZBMC { get; set; }

        /// <summary>
        ///指标描述
        /// </summary>
        [DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 权重分值
        /// </summary>
        [DataMember]
        public virtual decimal WeightPoint { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual int OrderNo { get; set; }

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
        public virtual string Note { get; set; }
        [DataMember]
        public virtual string ItemNote { get; set; }


        #endregion

    }
}