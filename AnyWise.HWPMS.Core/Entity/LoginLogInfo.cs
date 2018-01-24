namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class LoginLogInfo : BaseEntity
    {
        private DateTime m_LastUpdated;
        private int m_ID = 0;
        private string m_User_ID;
        private string m_LoginName;
        private string m_FullName;
        private string m_Note;
        private string m_IPAddress;
        private string m_MacAddress;
        private string m_SystemType_ID = "";
        private string m_Company_ID;
        private string m_CompanyName;

        [DataMember]
        public virtual string FullName
        {
            get
            {
                return this.m_FullName;
            }
            set
            {
                this.m_FullName = value;
            }
        }

        [DataMember]
        public virtual int ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                this.m_ID = value;
            }
        }

        [DataMember]
        public virtual DateTime LastUpdated
        {
            get
            {
                return this.m_LastUpdated;
            }
            set
            {
                this.m_LastUpdated = value;
            }
        }

        [DataMember]
        public virtual string LoginName
        {
            get
            {
                return this.m_LoginName;
            }
            set
            {
                this.m_LoginName = value;
            }
        }

        [DataMember]
        public virtual string MacAddress
        {
            get
            {
                return this.m_MacAddress;
            }
            set
            {
                this.m_MacAddress = value;
            }
        }

        [DataMember]
        public virtual string Note
        {
            get
            {
                return this.m_Note;
            }
            set
            {
                this.m_Note = value;
            }
        }

        [DataMember]
        public virtual string IPAddress
        {
            get
            {
                return this.m_IPAddress;
            }
            set
            {
                this.m_IPAddress = value;
            }
        }

        [DataMember]
        public virtual string SystemType_ID
        {
            get
            {
                return this.m_SystemType_ID;
            }
            set
            {
                this.m_SystemType_ID = value;
            }
        }

        [DataMember]
        public virtual string User_ID
        {
            get
            {
                return this.m_User_ID;
            }
            set
            {
                this.m_User_ID = value;
            }
        }

        [DataMember]
        public virtual string Company_ID
        {
            get
            {
                return this.m_Company_ID;
            }
            set
            {
                this.m_Company_ID = value;
            }
        }

        [DataMember]
        public virtual string CompanyName
        {
            get
            {
                return this.m_CompanyName;
            }
            set
            {
                this.m_CompanyName = value;
            }
        }
    }
}

