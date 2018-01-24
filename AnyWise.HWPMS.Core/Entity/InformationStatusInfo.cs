namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [DataContract]
    public class InformationStatusInfo : BaseEntity
    {
        private int int_0 = 0;
        private string string_0 = Guid.NewGuid().ToString();
        private string string_1;
        private string string_2;
        private string string_3;

        [DataMember]
        public virtual string Category
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
        public virtual string Information_ID
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
        public virtual int Status
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
        public virtual string User_ID
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

