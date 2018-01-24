using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 绩效公式设置
    /// </summary>
    [DataContract]
    public class JxgsszInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public JxgsszInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                   this.OrderNo= 0;
       
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 公式编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 公式名称
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 公式编码
        /// </summary>
		[DataMember]
        public virtual string Formula { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
		[DataMember]
        public virtual string ZXZD_ID { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
		[DataMember]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
		[DataMember]
        public virtual int OrderNo { get; set; }

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
        /// 科室内码
        /// </summary>
        [DataMember]
        public virtual string KSID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [DataMember]
        public virtual string KSName { get; set; }

        #endregion

    }
}