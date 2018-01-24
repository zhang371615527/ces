using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// 成本明细表
    /// </summary>
    [DataContract]
    public class CbmxbInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public CbmxbInfo()
		{
            this.ID = System.Guid.NewGuid().ToString();
            this.Kkcb= 0;
            this.Total= 0;
            this.Cb1= 0;
            this.Fkkcb= 0;
             this.Cb2= 0;
             this.Cb3= 0;
             this.Cb4= 0;
             this.Cb5= 0;
             this.Cb6= 0;
             this.Cb7= 0;
             this.Cb8= 0;
             this.Cb9= 0;
             this.Cb10= 0;
             this.Cb11= 0;
             this.Cb12= 0;
             this.Cb13= 0;
             this.Cb14= 0;
             this.Cb15= 0;
             this.Cb16= 0;
             this.Cb17= 0;
             this.Cb18= 0;
             this.Cb19= 0;
             this.Cb20= 0;
             this.Cb21= 0;
             this.Cb22= 0;
             this.Cb23= 0;
             this.Cb24= 0;
             this.Cb25= 0;
             this.Cb26= 0;
             this.Cb27= 0;
             this.Cb28= 0;
             this.Cb29= 0;
             this.Cb30= 0;
             this.Cb31= 0;
             this.Cb32= 0;
             this.Cb33= 0;
             this.Cb34= 0;
             this.Cb35= 0;
             this.Cb36= 0;
             this.Cb37= 0;
             this.Cb38= 0;
             this.Cb39= 0;
             this.Cb40= 0;
             this.Cb41= 0;
             this.Cb42= 0;
             this.Cb43= 0;
             this.Cb44= 0;
             this.Cb45= 0;
             this.Cb46= 0;
             this.Cb47= 0;
             this.Cb48= 0;
             this.Cb49= 0;
             this.Cb50= 0;
  
		}

        #region Property Members
        
        /// <summary>
        /// 所属医院
        /// </summary>
		[DataMember]
        public virtual string HosID { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
		[DataMember]
        public virtual string Month { get; set; }

        /// <summary>
        /// 可控成本
        /// </summary>
		[DataMember]
        public virtual decimal Kkcb { get; set; }

        /// <summary>
        /// 总成本
        /// </summary>
		[DataMember]
        public virtual decimal Total { get; set; }

        /// <summary>
        /// 内码
        /// </summary>
		[DataMember]
        public virtual string ID { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
		[DataMember]
        public virtual string KszdId { get; set; }

        /// <summary>
        /// CB1
        /// </summary>
		[DataMember]
        public virtual decimal Cb1 { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
		[DataMember]
        public virtual string KSZD_Name { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
		[DataMember]
        public virtual string Year { get; set; }

        /// <summary>
        /// 非可控成本
        /// </summary>
		[DataMember]
        public virtual decimal Fkkcb { get; set; }

        /// <summary>
        /// CB2
        /// </summary>
		[DataMember]
        public virtual decimal Cb2 { get; set; }

        /// <summary>
        /// CB3
        /// </summary>
		[DataMember]
        public virtual decimal Cb3 { get; set; }

        /// <summary>
        /// CB4
        /// </summary>
		[DataMember]
        public virtual decimal Cb4 { get; set; }

        /// <summary>
        /// CB5
        /// </summary>
		[DataMember]
        public virtual decimal Cb5 { get; set; }

        /// <summary>
        /// CB6
        /// </summary>
		[DataMember]
        public virtual decimal Cb6 { get; set; }

        /// <summary>
        /// CB7
        /// </summary>
		[DataMember]
        public virtual decimal Cb7 { get; set; }

        /// <summary>
        /// CB8
        /// </summary>
		[DataMember]
        public virtual decimal Cb8 { get; set; }

        /// <summary>
        /// CB9
        /// </summary>
		[DataMember]
        public virtual decimal Cb9 { get; set; }

        /// <summary>
        /// CB10
        /// </summary>
		[DataMember]
        public virtual decimal Cb10 { get; set; }

        /// <summary>
        /// CB11
        /// </summary>
		[DataMember]
        public virtual decimal Cb11 { get; set; }

        /// <summary>
        /// CB12
        /// </summary>
		[DataMember]
        public virtual decimal Cb12 { get; set; }

        /// <summary>
        /// CB13
        /// </summary>
		[DataMember]
        public virtual decimal Cb13 { get; set; }

        /// <summary>
        /// CB14
        /// </summary>
		[DataMember]
        public virtual decimal Cb14 { get; set; }

        /// <summary>
        /// CB15
        /// </summary>
		[DataMember]
        public virtual decimal Cb15 { get; set; }

        /// <summary>
        /// CB16
        /// </summary>
		[DataMember]
        public virtual decimal Cb16 { get; set; }

        /// <summary>
        /// CB17
        /// </summary>
		[DataMember]
        public virtual decimal Cb17 { get; set; }

        /// <summary>
        /// CB18
        /// </summary>
		[DataMember]
        public virtual decimal Cb18 { get; set; }

        /// <summary>
        /// CB19
        /// </summary>
		[DataMember]
        public virtual decimal Cb19 { get; set; }

        /// <summary>
        /// CB20
        /// </summary>
		[DataMember]
        public virtual decimal Cb20 { get; set; }

        /// <summary>
        /// CB21
        /// </summary>
		[DataMember]
        public virtual decimal Cb21 { get; set; }

        /// <summary>
        /// CB22
        /// </summary>
		[DataMember]
        public virtual decimal Cb22 { get; set; }

        /// <summary>
        /// CB23
        /// </summary>
		[DataMember]
        public virtual decimal Cb23 { get; set; }

        /// <summary>
        /// CB24
        /// </summary>
		[DataMember]
        public virtual decimal Cb24 { get; set; }

        /// <summary>
        /// CB25
        /// </summary>
		[DataMember]
        public virtual decimal Cb25 { get; set; }

        /// <summary>
        /// CB26
        /// </summary>
		[DataMember]
        public virtual decimal Cb26 { get; set; }

        /// <summary>
        /// CB27
        /// </summary>
		[DataMember]
        public virtual decimal Cb27 { get; set; }

        /// <summary>
        /// CB28
        /// </summary>
		[DataMember]
        public virtual decimal Cb28 { get; set; }

        /// <summary>
        /// CB29
        /// </summary>
		[DataMember]
        public virtual decimal Cb29 { get; set; }

        /// <summary>
        /// CB30
        /// </summary>
		[DataMember]
        public virtual decimal Cb30 { get; set; }

        /// <summary>
        /// CB31
        /// </summary>
		[DataMember]
        public virtual decimal Cb31 { get; set; }

        /// <summary>
        /// CB32
        /// </summary>
		[DataMember]
        public virtual decimal Cb32 { get; set; }

        /// <summary>
        /// CB33
        /// </summary>
		[DataMember]
        public virtual decimal Cb33 { get; set; }

        /// <summary>
        /// CB34
        /// </summary>
		[DataMember]
        public virtual decimal Cb34 { get; set; }

        /// <summary>
        /// CB35
        /// </summary>
		[DataMember]
        public virtual decimal Cb35 { get; set; }

        /// <summary>
        /// CB36
        /// </summary>
		[DataMember]
        public virtual decimal Cb36 { get; set; }

        /// <summary>
        /// CB37
        /// </summary>
		[DataMember]
        public virtual decimal Cb37 { get; set; }

        /// <summary>
        /// CB38
        /// </summary>
		[DataMember]
        public virtual decimal Cb38 { get; set; }

        /// <summary>
        /// CB39
        /// </summary>
		[DataMember]
        public virtual decimal Cb39 { get; set; }

        /// <summary>
        /// CB40
        /// </summary>
		[DataMember]
        public virtual decimal Cb40 { get; set; }

        /// <summary>
        /// CB41
        /// </summary>
		[DataMember]
        public virtual decimal Cb41 { get; set; }

        /// <summary>
        /// CB42
        /// </summary>
		[DataMember]
        public virtual decimal Cb42 { get; set; }

        /// <summary>
        /// CB43
        /// </summary>
		[DataMember]
        public virtual decimal Cb43 { get; set; }

        /// <summary>
        /// CB44
        /// </summary>
		[DataMember]
        public virtual decimal Cb44 { get; set; }

        /// <summary>
        /// CB45
        /// </summary>
		[DataMember]
        public virtual decimal Cb45 { get; set; }

        /// <summary>
        /// CB46
        /// </summary>
		[DataMember]
        public virtual decimal Cb46 { get; set; }

        /// <summary>
        /// CB47
        /// </summary>
		[DataMember]
        public virtual decimal Cb47 { get; set; }

        /// <summary>
        /// CB48
        /// </summary>
		[DataMember]
        public virtual decimal Cb48 { get; set; }

        /// <summary>
        /// CB49
        /// </summary>
		[DataMember]
        public virtual decimal Cb49 { get; set; }

        /// <summary>
        /// CB50
        /// </summary>
		[DataMember]
        public virtual decimal Cb50 { get; set; }


        #endregion

    }
}