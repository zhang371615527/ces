using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 考核分类表
    /// </summary>
    [DataContract]
    public class KhflbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public KhflbInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
            this.NodeType = "Leaf";
            this.WebIcon = "icon-project";
        }

        #region Property Members



        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 指标编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 父级编号
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
        /// 考核类别
        /// </summary>
		[DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
		[DataMember]
        public virtual decimal Weight { get; set; }

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
        public virtual decimal LowerLimit { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
		[DataMember]
        public virtual decimal StandValue { get; set; }

        /// <summary>
        /// 目标值
        /// </summary>
		[DataMember]
        public virtual decimal TargetValue { get; set; }

        /// <summary>
        /// 警戒值上线
        /// </summary>
		[DataMember]
        public virtual decimal HighLimit { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
		[DataMember]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 值计量单位
        /// </summary>
		[DataMember]
        public virtual string Unit { get; set; }
        [DataMember]
        public virtual string UnitName { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
		[DataMember]
        public virtual string Source { get; set; }

        /// <summary>
        /// 执行公式
        /// </summary>
		[DataMember]
        public virtual string Formula { get; set; }

        /// <summary>
        /// 考核得分
        /// </summary>
        [DataMember]
        public virtual decimal Point { get; set; }

        /// <summary>
        /// 责任部门
        /// </summary>
        [DataMember]
        public virtual string ResKS_ID { get; set; }
        [DataMember]
        public virtual string ResKS_Name { get; set; }
        /// <summary>
        /// 考核部门
        /// </summary>
        [DataMember]
        public virtual string CheckKS_ID { get; set; }
        [DataMember]
        public virtual string CheckKS_Name { get; set; }
        /// <summary>
        /// 考核角色
        /// </summary>
        [DataMember]
        public virtual string CheckRole { get; set; }

        /// <summary>
        /// 考核人
        /// </summary>
        [DataMember]
        public virtual string Checker { get; set; }

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

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public virtual string WebIcon { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
		[DataMember]
        public virtual bool Enabled { get; set; }


        #endregion

    }
}