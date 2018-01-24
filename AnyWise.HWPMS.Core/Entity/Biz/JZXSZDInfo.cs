namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class JZXSZDInfo : BaseEntity
    {
        private DateTime dateTime_0 = DateTime.Now;

        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }

        [DataMember]
        public virtual string JZXSLB_ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual string JZXSLB_Name
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Code
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Name
        {
            get;
            set;
        }

        [DataMember]
        public virtual string DictCode
        {
            get;
            set;
        }
        [DataMember]
        public virtual string DictName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string HISCode
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal Value
        {
            get;
            set;
        }

        [DataMember]
        public virtual int Sort
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Enabled
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Note
        {
            get;
            set;
        }

        [DataMember]
        public virtual DateTime CreateTime
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Creator
        {
            get;
            set;
        }
        [DataMember]
        public virtual DateTime EditTime
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
        public virtual string Editor
        {
            get;
            set;
        }
    }
}

