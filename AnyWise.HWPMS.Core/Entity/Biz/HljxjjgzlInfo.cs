using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 护理绩效间接工作量
    /// </summary>
    [DataContract]
    public class HljxjjgzlInfo:BaseEntity
    {
        public HljxjjgzlInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
        }
        #region 护理绩效间接工作量
        /// <summary>
        /// 内码
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        [DataMember]
        public string Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        [DataMember]
        public string Month { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }
        /// <summary>
        /// 科室内码
        /// </summary>
        [DataMember]
        public string KSZD_ID { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [DataMember]
        public string KSZD_Name { get; set; }
        /// <summary>
        /// 编制床位数
        /// </summary>
        [DataMember]
        public decimal BZCWS { get; set; }
        /// <summary>
        /// 实际开放床位数
        /// </summary>
        [DataMember]
        public decimal KFCWS { get; set; }
        /// <summary>
        /// 实际占用床位数
        /// </summary>
        [DataMember]
        public decimal ZYCWS { get; set; }
        /// <summary>
        /// 床位使用率
        /// </summary>
        [DataMember]
        public decimal CWSYL { get; set; }
        /// <summary>
        /// 平均住院日
        /// </summary>
        [DataMember]
        public decimal PJZYR { get; set; }
        /// <summary>
        /// 入院人数
        /// </summary>
        [DataMember]
        public decimal RYRS { get; set; }
        /// <summary>
        /// 出院人数
        /// </summary>
        [DataMember]
        public decimal CYRS { get; set; }
        /// <summary>
        /// 手术例数
        /// </summary>
        [DataMember]
        public decimal SSLS { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [DataMember]
        public string Editor { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        public DateTime EditTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Note { get; set; }
        #endregion
    }
}
