namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class DictDataInfo : BaseEntity
    {
        private DateTime dateTime_0 = DateTime.Now;
        private string string_1 = "";
        private string string_2 = "";
        private string string_3 = "";
        private string string_4 = "";
        private string string_5 = "";
        private string string_6 = "";
        private string string_7 = "";

        [DataMember]
        public virtual string DictType_ID
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
        [DataMember]
        public virtual string DictType_Name
        {
            get
            {
                return this.string_7;
            }
            set
            {
                this.string_7 = value;
            }
        }
        [DataMember]
        public virtual string Editor
        {
            get
            {
                return this.string_6;
            }
            set
            {
                this.string_6 = value;
            }
        }

        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }

        [DataMember]
        public virtual DateTime LastUpdated
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
            }
        }

        [DataMember]
        public virtual string Name
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        [DataMember]
        public virtual string Remark
        {
            get
            {
                return this.string_4;
            }
            set
            {
                this.string_4 = value;
            }
        }

        [DataMember]
        public virtual string Seq
        {
            get
            {
                return this.string_5;
            }
            set
            {
                this.string_5 = value;
            }
        }

        [DataMember]
        public virtual string Value
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
            }
        }
    }
}

