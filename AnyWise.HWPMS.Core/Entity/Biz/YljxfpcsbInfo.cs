using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 绩效分配参数表
    /// </summary>
    [DataContract]
    public class YljxfpcsbInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public YljxfpcsbInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
            this.Value = 0;
            this.OrderNo = 0;

        }

        #region Property Members

        /// <summary>
        /// 内码
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 参数编号
        /// </summary>
        [DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 参数定义
        /// </summary>
        [DataMember]
        public virtual string Define { get; set; }

        /// <summary>
        /// 参数公式
        /// </summary>
        [DataMember]
        public virtual string Formula { get; set; }

        /// <summary>
        /// 参数来源
        /// </summary>
        [DataMember]
        public virtual string Source { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        [DataMember]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 排序
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

        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual string Enabled { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        [DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// 职系
        /// </summary>
        [DataMember]
        public virtual string ZXZD_ID { get; set; }

        #endregion

    }
}