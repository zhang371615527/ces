namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class SystemTypeInfo : BaseEntity
    {
        private string string_0 = Guid.NewGuid().ToString();
        private string string_1 = "";
        private string string_2 = "";
        private string string_3 = "";
        private string string_4 = "";

        [DataMember]
        public virtual string Authorize
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
        public virtual string CustomID
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
        public virtual string Name
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
        public virtual string Note
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
        public virtual string OID
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
    }
}

