﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 绩效预算金额
    /// </summary>
    [DataContract]
    public class JxysInfo : BaseEntity
    {
        public JxysInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
            this.Value = 0;
       
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
		[DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 职系
        /// </summary>
		[DataMember]
        public virtual string ZXZD_ID { get; set; }
        [DataMember]
        public virtual string ZXZD_Name { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
		[DataMember]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
		[DataMember]
        public virtual string KSZD_ID { get; set; }
        [DataMember]
        public virtual string KSZD_Name { get; set; }
        /// <summary>
        /// 核算比率
        /// </summary>
        [DataMember]
        public virtual string Ratio { get; set; }
        
        /// <summary>
        /// 预算金额
        /// </summary>
		[DataMember]
        public virtual decimal YsMoney { get; set; }

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
