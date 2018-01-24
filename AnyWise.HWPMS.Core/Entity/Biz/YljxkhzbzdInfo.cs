using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效考核指标字典
    /// </summary>
    [DataContract]
    public class YljxkhzbzdInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YljxkhzbzdInfo()
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
        /// 所属医院
        /// </summary>
        [DataMember]
        public virtual string HosID { get; set; }

        /// <summary>
        /// 职系
        /// </summary>
        [DataMember]
        public virtual string ZXZD_ID { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        [DataMember]
        public virtual string ResPersion { get; set; }
        [DataMember]
        public virtual string ResPersionName { get; set; }
        /// <summary>
        /// 除外人员
        /// </summary>
        [DataMember]
        public virtual string ExpResPersion { get; set; }
        [DataMember]
        public virtual string ExpResPersionName { get; set; }
        /// <summary>
        /// 责任科室
        /// </summary>
        [DataMember]
        public virtual string ResKS_ID { get; set; }
        [DataMember]
        public virtual string ResKS_Name { get; set; }

        /// <summary>
        /// 考核科室
        /// </summary>
        [DataMember]
        public virtual string CheckKS_ID { get; set; }
        [DataMember]
        public virtual string CheckKS_Name { get; set; }
        /// <summary>
        /// 考核人
        /// </summary>
        [DataMember]
        public virtual string Checker { get; set; }
        [DataMember]
        public virtual string CheckerName { get; set; }
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


        #endregion

    }
}