namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class DrgsSortInfo : BaseEntity
    {
        private DateTime dateTime_0 = DateTime.Now;
        private string string_0 = Guid.NewGuid().ToString();
        private string string_1 = "";
        private string string_2 = "";
        private string string_3 = "";
        private string string_4 = "";
        private string string_5 = "";
        private string string_6 = "";
        private string string_7 = "";
        private string string_8 = "";
        private string string_9 = "";

        [DataMember]
        public virtual string ID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        [DataMember]
        public virtual string Code
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
        public virtual string CustomField1
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

        [DataMember]
        public virtual string CustomField2
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
        public virtual string CustomField3
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
        public virtual string CustomField4
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
        public virtual decimal WeightPoint
        {
            get;
            set;
        }
        [DataMember]
        public virtual decimal Price
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Creator
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
        public virtual DateTime CreateTime
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Editor
        {
            get
            {
                return this.string_8;
            }
            set
            {
                this.string_8 = value;
            }
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
        public virtual string Enabled
        {
            get
            {
                return this.string_9;
            }
            set
            {
                this.string_9 = value;
            }
        }

        [DataMember]
        public virtual string Note
        {
            get;
            set;
        }
    }
}
