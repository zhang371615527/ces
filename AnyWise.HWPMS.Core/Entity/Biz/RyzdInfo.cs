using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 人员字典
    /// </summary>
    [DataContract]
    public class RyzdInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RyzdInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                      
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 人员编号
        /// </summary>
		[DataMember]
        public virtual string Code { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
		[DataMember]
        public virtual string CardNum { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
		[DataMember]
        public virtual string KszdId { get; set; }
        [DataMember]
        public virtual string KszdName { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
		[DataMember]
        public virtual string GwzdId { get; set; }
        [DataMember]
        public virtual string GwzdName { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
		[DataMember]
        public virtual string ZczdId { get; set; }
        [DataMember]
        public virtual string ZczdName { get; set; }
        /// <summary>
        /// 职系
        /// </summary>
		[DataMember]
        public virtual string ZxzdId { get; set; }
        [DataMember]
        public virtual string ZxzdName { get; set; }
        /// <summary>
        /// 分配类别
        /// </summary>
        [DataMember]
        public virtual string FPLBZD_ID { get; set; }
        [DataMember]
        public virtual string FPLBZD_Name { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [DataMember]
        public virtual string ZWZD_ID { get; set; }

        /// <summary>
        /// 职等
        /// </summary>
        [DataMember]
        public virtual string ZDZD_ID { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        [DataMember]
        public virtual string ZJZD_ID { get; set; }

        /// <summary>
        /// 年资
        /// </summary>
        [DataMember]
        public virtual string NZZD_ID { get; set; }

        /// <summary>
        /// 医师代码
        /// </summary>
		[DataMember]
        public virtual string DocNum { get; set; }

        /// <summary>
        /// HIS代码
        /// </summary>
		[DataMember]
        public virtual string HISNum { get; set; }

        /// <summary>
        /// 工资代码
        /// </summary>
		[DataMember]
        public virtual string SalNum { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
		[DataMember]
        public virtual DateTime Birth { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
		[DataMember]
        public virtual string CardID { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
		[DataMember]
        public virtual string Sex { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
		[DataMember]
        public virtual string Link { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
		[DataMember]
        public virtual string Record { get; set; }

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