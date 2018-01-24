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
    public class EasyComboTreeDataOU
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string id { get; set; }

        /// <summary>
        /// PID
        /// </summary>
        [DataMember]
        public string pid { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public string handNo { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [DataMember]
        public string category { get; set; }

        /// <summary>
        /// 职系
        /// </summary>
        [DataMember]
        public string grade { get; set; }

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
        public List<EasyComboTreeDataOU> children { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public EasyComboTreeDataOU()
        {
            this.children = new List<EasyComboTreeDataOU>();
            this.state = "open";
        }

        /// <summary>
        /// 常用构造函数
        /// </summary>
        public EasyComboTreeDataOU(string id, string pid, string handNo, string name, string category, string grade, string iconCls, string attributes, string state = "open")
            : this()
        {
            this.id = id;
            this.pid = pid;
            this.handNo = handNo;
            this.name = name;
            this.category = category;
            this.grade = grade;
            this.state = state;
            this.attributes = attributes;
            this.iconCls = iconCls;
        }
    }
}

