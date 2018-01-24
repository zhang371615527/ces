namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class FunctionInfo : BaseEntity
    {
        private int int_ID = 0;
        private int int_PID = -1;
        private string string_Name;
        private string string_ControlID;
        private string string_SystemType = "";
        private string string_SortCode;

        [DataMember]
        public virtual string ControlID
        {
            get
            {
                return this.string_ControlID;
            }
            set
            {
                this.string_ControlID = value;
            }
        }

        [DataMember]
        public virtual int ID
        {
            get
            {
                return this.int_ID;
            }
            set
            {
                this.int_ID = value;
            }
        }

        [DataMember]
        public virtual string Name
        {
            get
            {
                return this.string_Name;
            }
            set
            {
                this.string_Name = value;
            }
        }

        [DataMember]
        public virtual int PID
        {
            get
            {
                return this.int_PID;
            }
            set
            {
                this.int_PID = value;
            }
        }

        [DataMember]
        public virtual string SystemType_ID
        {
            get
            {
                return this.string_SystemType;
            }
            set
            {
                this.string_SystemType = value;
            }
        }

        [DataMember]
        public virtual string SortCode
        {
            get
            {
                return this.string_SortCode;
            }
            set
            {
                this.string_SortCode = value;
            }
        }
    }
}

