using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 医疗绩效分类工作量
    /// </summary>
    [DataContract]
    public class YljxflgzlInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YljxflgzlInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
            this.Quantity = 0;
            this.Value = 0;

        }

        #region Property Members

        /// <summary>
        /// 内码
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 原始工作量内码
        /// </summary>
        [DataMember]
        public virtual string GZLID { get; set; }

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
        /// 费用来源
        /// </summary>
        [DataMember]
        public virtual string Source { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        [DataMember]
        public virtual string XmzdId { get; set; }

        [DataMember]
        public virtual string XmzdName { get; set; }
        /// <summary>
        /// 项目大类
        /// </summary>
        [DataMember]
        public virtual string Xmlbid { get; set; }

        [DataMember]
        public virtual string XmlbName { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        [DataMember]
        public virtual string ZxzdId { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
        [DataMember]
        public virtual string KszdId { get; set; }
        [DataMember]
        public virtual string KszdName { get; set; }
        /// <summary>
        /// 病区代码
        /// </summary>
        [DataMember]
        public virtual string Bqid { get; set; }

        /// <summary>
        /// 医生代码
        /// </summary>
        [DataMember]
        public virtual string RyzdId { get; set; }
        [DataMember]
        public virtual string RyzdName { get; set; }
        /// <summary>
        /// 执行/判断类型
        /// </summary>
        [DataMember]
        public virtual string Type { get; set; }
        /// <summary>
        /// 计量单位代码
        /// </summary>
        [DataMember]
        public virtual string Unit { get; set; }

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
        /// 是否药品收入
        /// </summary>
        [DataMember]
        public virtual string IsDrugIncome { get; set; }

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