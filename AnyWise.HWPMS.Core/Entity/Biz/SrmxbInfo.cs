using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 收入明细表
    /// </summary>
    [DataContract]
    public class SrmxbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public SrmxbInfo()
		{
            this.ID = System.Guid.NewGuid().ToString();
             this.Ylsr= 0;
             this.Ypsr= 0;
             this.Qtsr = 0;
             this.Total= 0;
             this.Sr1= 0;
             this.Sr2= 0;
             this.Sr3= 0;
             this.Sr4= 0;
             this.Sr5= 0;
             this.Sr6= 0;
             this.Sr7= 0;
             this.Sr8= 0;
             this.Sr9= 0;
             this.Sr10= 0;
             this.Sr11= 0;
             this.Sr12= 0;
             this.Sr13= 0;
             this.Sr14= 0;
             this.Sr15= 0;
             this.Sr16= 0;
             this.Sr17= 0;
             this.Sr18= 0;
             this.Sr19= 0;
             this.Sr20= 0;
             this.Sr21= 0;
             this.Sr22= 0;
             this.Sr23= 0;
             this.Sr24= 0;
             this.Sr25= 0;
             this.Sr26= 0;
             this.Sr27= 0;
             this.Sr28= 0;
             this.Sr29= 0;
             this.Sr30= 0;
             this.Sr31= 0;
             this.Sr32= 0;
             this.Sr33= 0;
             this.Sr34= 0;
             this.Sr35= 0;
             this.Sr36= 0;
             this.Sr37= 0;
             this.Sr38= 0;
             this.Sr39= 0;
             this.Sr40= 0;
             this.Sr41= 0;
             this.Sr42= 0;
             this.Sr43= 0;
             this.Sr44= 0;
             this.Sr45= 0;
             this.Sr46= 0;
             this.Sr47= 0;
             this.Sr48= 0;
             this.Sr49= 0;
             this.Sr50= 0;
  
		}

        #region Property Members
        
        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 所属医院
        /// </summary>
		[DataMember]
        public virtual string HosID { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
		[DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
		[DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
		[DataMember]
        public virtual string KszdId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
		[DataMember]
        public virtual string KSZD_Name { get; set; }

        /// <summary>
        /// 医疗收入
        /// </summary>
		[DataMember]
        public virtual decimal Ylsr { get; set; }

        /// <summary>
        /// 药品收入
        /// </summary>
		[DataMember]
        public virtual decimal Ypsr { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        [DataMember]
        public virtual decimal Qtsr { get; set; }
        /// <summary>
        /// 总收入
        /// </summary>
		[DataMember]
        public virtual decimal Total { get; set; }

        /// <summary>
        /// SR1
        /// </summary>
		[DataMember]
        public virtual decimal Sr1 { get; set; }

        /// <summary>
        /// SR2
        /// </summary>
		[DataMember]
        public virtual decimal Sr2 { get; set; }

        /// <summary>
        /// SR3
        /// </summary>
		[DataMember]
        public virtual decimal Sr3 { get; set; }

        /// <summary>
        /// SR4
        /// </summary>
		[DataMember]
        public virtual decimal Sr4 { get; set; }

        /// <summary>
        /// SR5
        /// </summary>
		[DataMember]
        public virtual decimal Sr5 { get; set; }

        /// <summary>
        /// SR6
        /// </summary>
		[DataMember]
        public virtual decimal Sr6 { get; set; }

        /// <summary>
        /// SR7
        /// </summary>
		[DataMember]
        public virtual decimal Sr7 { get; set; }

        /// <summary>
        /// SR8
        /// </summary>
		[DataMember]
        public virtual decimal Sr8 { get; set; }

        /// <summary>
        /// SR9
        /// </summary>
		[DataMember]
        public virtual decimal Sr9 { get; set; }

        /// <summary>
        /// SR10
        /// </summary>
		[DataMember]
        public virtual decimal Sr10 { get; set; }

        /// <summary>
        /// SR11
        /// </summary>
		[DataMember]
        public virtual decimal Sr11 { get; set; }

        /// <summary>
        /// SR12
        /// </summary>
		[DataMember]
        public virtual decimal Sr12 { get; set; }

        /// <summary>
        /// SR13
        /// </summary>
		[DataMember]
        public virtual decimal Sr13 { get; set; }

        /// <summary>
        /// SR14
        /// </summary>
		[DataMember]
        public virtual decimal Sr14 { get; set; }

        /// <summary>
        /// SR15
        /// </summary>
		[DataMember]
        public virtual decimal Sr15 { get; set; }

        /// <summary>
        /// SR16
        /// </summary>
		[DataMember]
        public virtual decimal Sr16 { get; set; }

        /// <summary>
        /// SR17
        /// </summary>
		[DataMember]
        public virtual decimal Sr17 { get; set; }

        /// <summary>
        /// SR18
        /// </summary>
		[DataMember]
        public virtual decimal Sr18 { get; set; }

        /// <summary>
        /// SR19
        /// </summary>
		[DataMember]
        public virtual decimal Sr19 { get; set; }

        /// <summary>
        /// SR20
        /// </summary>
		[DataMember]
        public virtual decimal Sr20 { get; set; }

        /// <summary>
        /// SR21
        /// </summary>
		[DataMember]
        public virtual decimal Sr21 { get; set; }

        /// <summary>
        /// SR22
        /// </summary>
		[DataMember]
        public virtual decimal Sr22 { get; set; }

        /// <summary>
        /// SR23
        /// </summary>
		[DataMember]
        public virtual decimal Sr23 { get; set; }

        /// <summary>
        /// SR24
        /// </summary>
		[DataMember]
        public virtual decimal Sr24 { get; set; }

        /// <summary>
        /// SR25
        /// </summary>
		[DataMember]
        public virtual decimal Sr25 { get; set; }

        /// <summary>
        /// SR26
        /// </summary>
		[DataMember]
        public virtual decimal Sr26 { get; set; }

        /// <summary>
        /// SR27
        /// </summary>
		[DataMember]
        public virtual decimal Sr27 { get; set; }

        /// <summary>
        /// SR28
        /// </summary>
		[DataMember]
        public virtual decimal Sr28 { get; set; }

        /// <summary>
        /// SR29
        /// </summary>
		[DataMember]
        public virtual decimal Sr29 { get; set; }

        /// <summary>
        /// SR30
        /// </summary>
		[DataMember]
        public virtual decimal Sr30 { get; set; }

        /// <summary>
        /// SR31
        /// </summary>
		[DataMember]
        public virtual decimal Sr31 { get; set; }

        /// <summary>
        /// SR32
        /// </summary>
		[DataMember]
        public virtual decimal Sr32 { get; set; }

        /// <summary>
        /// SR33
        /// </summary>
		[DataMember]
        public virtual decimal Sr33 { get; set; }

        /// <summary>
        /// SR34
        /// </summary>
		[DataMember]
        public virtual decimal Sr34 { get; set; }

        /// <summary>
        /// SR35
        /// </summary>
		[DataMember]
        public virtual decimal Sr35 { get; set; }

        /// <summary>
        /// SR36
        /// </summary>
		[DataMember]
        public virtual decimal Sr36 { get; set; }

        /// <summary>
        /// SR37
        /// </summary>
		[DataMember]
        public virtual decimal Sr37 { get; set; }

        /// <summary>
        /// SR38
        /// </summary>
		[DataMember]
        public virtual decimal Sr38 { get; set; }

        /// <summary>
        /// SR39
        /// </summary>
		[DataMember]
        public virtual decimal Sr39 { get; set; }

        /// <summary>
        /// SR40
        /// </summary>
		[DataMember]
        public virtual decimal Sr40 { get; set; }

        /// <summary>
        /// SR41
        /// </summary>
		[DataMember]
        public virtual decimal Sr41 { get; set; }

        /// <summary>
        /// SR42
        /// </summary>
		[DataMember]
        public virtual decimal Sr42 { get; set; }

        /// <summary>
        /// SR43
        /// </summary>
		[DataMember]
        public virtual decimal Sr43 { get; set; }

        /// <summary>
        /// SR44
        /// </summary>
		[DataMember]
        public virtual decimal Sr44 { get; set; }

        /// <summary>
        /// SR45
        /// </summary>
		[DataMember]
        public virtual decimal Sr45 { get; set; }

        /// <summary>
        /// SR46
        /// </summary>
		[DataMember]
        public virtual decimal Sr46 { get; set; }

        /// <summary>
        /// SR47
        /// </summary>
		[DataMember]
        public virtual decimal Sr47 { get; set; }

        /// <summary>
        /// SR48
        /// </summary>
		[DataMember]
        public virtual decimal Sr48 { get; set; }

        /// <summary>
        /// SR49
        /// </summary>
		[DataMember]
        public virtual decimal Sr49 { get; set; }

        /// <summary>
        /// SR50
        /// </summary>
		[DataMember]
        public virtual decimal Sr50 { get; set; }


        #endregion

    }
}