using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;
using System.Collections.Generic;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 月度绩效考核子表GridTree
    /// </summary>
    [DataContract]
    [Serializable]
    public class YdjxkhzbTreeGridInfo : YdjxkhzbInfo
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YdjxkhzbTreeGridInfo()
        {
            this.children = new List<YdjxkhzbTreeGridInfo>();
            this.state = "open";
        }

        /// <summary>
        /// 是否展开
        /// </summary>
        [DataMember]
        public string state { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        [DataMember]
        public string attributes { get; set; }

        /// <summary>
        /// 图标样式
        /// </summary>
        [DataMember]
        public string iconCls { get; set; }

        /// <summary>
        /// 子节点集合
        /// </summary>
        [DataMember]
        public List<YdjxkhzbTreeGridInfo> children { get; set; }

    }
}