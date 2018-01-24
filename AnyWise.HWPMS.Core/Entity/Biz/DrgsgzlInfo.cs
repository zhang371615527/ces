using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// DRGs工作量
    /// </summary>
    [DataContract]
    public class DrgsgzlInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public DrgsgzlInfo()
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
        /// 年
        /// </summary>
        [DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// DRGs代码
        /// </summary>
        [DataMember]
        public virtual string DrgsID { get; set; }
        [DataMember]
        public virtual string Drgs_Name { get; set; }

        /// <summary>
        /// 主要诊断
        /// </summary>
        [DataMember]
        public virtual string MainDiagnosis { get; set; }

        /// <summary>
        /// 次要诊断
        /// </summary>
        [DataMember]
        public virtual string OtherDiagnostics { get; set; }

        /// <summary>
        /// ICD疾病代码
        /// </summary>
        [DataMember]
        public virtual string ICD_ID { get; set; }
        [DataMember]
        public virtual string ICD_Name { get; set; }

        /// <summary>
        /// 手术代码
        /// </summary>
        [DataMember]
        public virtual string Surgery_ID { get; set; }
        [DataMember]
        public virtual string Surgery_Name { get; set; }

        /// <summary>
        /// 出院方式
        /// </summary>
        [DataMember]
        public virtual string DischargeMethod { get; set; }

        /// <summary>
        /// 开单科室代码
        /// </summary>
        [DataMember]
        public virtual string KSZD_ID { get; set; }
        [DataMember]
        public virtual string KSZD_Name { get; set; }

        /// <summary>
        /// 开单医生代码
        /// </summary>
        [DataMember]
        public virtual string RYZD_ID { get; set; }
        [DataMember]
        public virtual string RYZD_Name { get; set; }


        /// <summary>
        /// 执行科室代码
        /// </summary>
        [DataMember]
        public virtual string ExecKSID { get; set; }
        [DataMember]
        public virtual string ExecKSName { get; set; }

        /// <summary>
        /// 执行医生代码
        /// </summary>
        [DataMember]
        public virtual string ExecRYZD_ID { get; set; }
        [DataMember]
        public virtual string ExecRYZD_Name { get; set; }

        /// <summary>
        /// 计量单位代码
        /// </summary>
        [DataMember]
        public virtual string Unit { get; set; }
        [DataMember]
        public virtual string Unit_Name { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public virtual decimal Value { get; set; }

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
