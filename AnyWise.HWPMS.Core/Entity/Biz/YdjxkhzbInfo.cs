using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;
using System.Collections.Generic;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 月度绩效考核子表
    /// </summary>
    [DataContract]
    public class YdjxkhzbInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YdjxkhzbInfo()
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
        /// 主表内码
        /// </summary>
        [DataMember]
        public virtual string YdjxkhId { get; set; }

        /// <summary>
        /// 指标编码
        /// </summary>
        [DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 父级编码
        /// </summary>
        [DataMember]
        public virtual string ParentCode { get; set; }

        /// <summary>
        /// 指标名称
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 基本内容
        /// </summary>
        [DataMember]
        public virtual string Content { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        [DataMember]
        public virtual string NodeType { get; set; }

        /// <summary>
        /// 权重分值
        /// </summary>
        [DataMember]
        public virtual decimal? WeightPoint { get; set; }

        /// <summary>
        /// 考核时限
        /// </summary>
        [DataMember]
        public virtual string Time { get; set; }

        /// <summary>
        /// 考核方法
        /// </summary>
        [DataMember]
        public virtual string Method { get; set; }

        /// <summary>
        /// 警戒值下线
        /// </summary>
        [DataMember]
        public virtual decimal? LowerLimit { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        [DataMember]
        public virtual decimal? StandValue { get; set; }

        /// <summary>
        /// 目标值
        /// </summary>
        [DataMember]
        public virtual decimal? TargetValue { get; set; }

        /// <summary>
        /// 警戒值上线
        /// </summary>
        [DataMember]
        public virtual decimal? HighLimit { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
        [DataMember]
        public virtual decimal? Value { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string Unit { get; set; }

        /// <summary>
        /// 考核得分
        /// </summary>
        [DataMember]
        public virtual decimal? Point { get; set; }

        /// <summary>
        /// 完成率
        /// </summary>
        [DataMember]
        public virtual decimal? Ratio { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string Note { get; set; }

        #endregion

    }
}