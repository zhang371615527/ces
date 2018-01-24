using System;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;
using System.Collections.Generic;
namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 定义EasyUI树的相关数据，方便控制器生成Json数据进行传递
    /// </summary>
    [DataContract]
    [Serializable]
    public class EasyTreeData
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [DataMember]
        public string text { get; set; }

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
        public List<EasyTreeData> children { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public EasyTreeData()
        {
            this.children = new List<EasyTreeData>();
            this.state = "open";
        }

        /// <summary>
        /// 常用构造函数
        /// </summary>
        public EasyTreeData(string id, string text, string iconCls , string attributes, string state = "open")
            : this()
        {
            this.id = id;
            this.text = text;
            this.state = state;
            this.attributes = attributes;
            this.iconCls = iconCls;
        }
    }
}

