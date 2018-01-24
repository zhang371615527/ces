namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class JZXSLBInfo : BaseEntity
    {
        private DateTime dateTime_3 = DateTime.Now;
        private int id=0;
        [DataMember]
        public virtual int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [DataMember]
        public virtual string PID
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
        public virtual string HISCode
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
        public virtual int LayerNumber
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
                return this.dateTime_3;
            }
            set
            {
                this.dateTime_3 = value;
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

