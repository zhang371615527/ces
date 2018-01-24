namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [DataContract]
    public class InformationInfo : BaseEntity
    {
        private DateTime dateTime_0 = DateTime.Now;
        private DateTime dateTime_1;
        private DateTime dateTime_2;
        private InformationCategory informationCategory_0 = InformationCategory.const_4;
        private int int_0 = 0;
        private int int_1 = 0;
        private string string_0 = Guid.NewGuid().ToString();
        private string string_1;
        private string string_2;
        private string string_3 = Guid.NewGuid().ToString();
        private string string_4;
        private string string_5;
        private string string_6;

        [DataMember]
        public virtual string Attachment_GUID
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
        public virtual InformationCategory Category
        {
            get
            {
                return this.informationCategory_0;
            }
            set
            {
                this.informationCategory_0 = value;
            }
        }

        [DataMember]
        public virtual DateTime CheckTime
        {
            get
            {
                return this.dateTime_1;
            }
            set
            {
                this.dateTime_1 = value;
            }
        }

        [DataMember]
        public virtual string CheckUser
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
        public virtual string Content
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
        public virtual string Editor
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
        public virtual int ForceExpire
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

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
        public virtual int IsChecked
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        [DataMember]
        public virtual string SubType
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
        public virtual DateTime TimeOut
        {
            get
            {
                return this.dateTime_2;
            }
            set
            {
                this.dateTime_2 = value;
            }
        }

        [DataMember]
        public virtual string Title
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
    }
}

