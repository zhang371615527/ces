﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 职称字典
    /// </summary>
    [DataContract]
    public class ZczdInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ZczdInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
               this.Ratio= 0;
       
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 职称编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 职称名称
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 职称系数
        /// </summary>
		[DataMember]
        public virtual decimal Ratio { get; set; }

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