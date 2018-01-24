namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class RoleInfo : BaseEntity
    {
        public const string AdminName = "管理员";
        #region Field Members

        private int m_ID = 0; //          
        private int m_PID = -1; //          
        private string m_HandNo; //          
        private string m_Name; //          
        private string m_Note; //          
        private string m_SortCode; //          
        private string m_Category; //          
        private string m_Company_ID; //          
        private string m_CompanyName; //          
        private string m_Creator; //          
        private string m_Creator_ID; //          
        private DateTime m_CreateTime = System.DateTime.Now; //          
        private string m_Editor; //          
        private string m_Editor_ID; //          
        private DateTime m_EditTime = System.DateTime.Now; //          
        private int m_Deleted = 0; //          
        private int m_Enabled = 0; //          

        #endregion

        #region Property Members

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
        public virtual int PID
        {
            get
            {
                return this.m_PID;
            }
            set
            {
                this.m_PID = value;
            }
        }

        [DataMember]
        public virtual string HandNo
        {
            get
            {
                return this.m_HandNo;
            }
            set
            {
                this.m_HandNo = value;
            }
        }

        [DataMember]
        public virtual string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
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
        public virtual string SortCode
        {
            get
            {
                return this.m_SortCode;
            }
            set
            {
                this.m_SortCode = value;
            }
        }

        [DataMember]
        public virtual string Category
        {
            get
            {
                return this.m_Category;
            }
            set
            {
                this.m_Category = value;
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

        [DataMember]
        public virtual string Creator
        {
            get
            {
                return this.m_Creator;
            }
            set
            {
                this.m_Creator = value;
            }
        }

        [DataMember]
        public virtual string Creator_ID
        {
            get
            {
                return this.m_Creator_ID;
            }
            set
            {
                this.m_Creator_ID = value;
            }
        }

        [DataMember]
        public virtual DateTime CreateTime
        {
            get
            {
                return this.m_CreateTime;
            }
            set
            {
                this.m_CreateTime = value;
            }
        }

        [DataMember]
        public virtual string Editor
        {
            get
            {
                return this.m_Editor;
            }
            set
            {
                this.m_Editor = value;
            }
        }

        [DataMember]
        public virtual string Editor_ID
        {
            get
            {
                return this.m_Editor_ID;
            }
            set
            {
                this.m_Editor_ID = value;
            }
        }

        [DataMember]
        public virtual DateTime EditTime
        {
            get
            {
                return this.m_EditTime;
            }
            set
            {
                this.m_EditTime = value;
            }
        }

        [DataMember]
        public virtual int Deleted
        {
            get
            {
                return this.m_Deleted;
            }
            set
            {
                this.m_Deleted = value;
            }
        }

        [DataMember]
        public virtual int Enabled
        {
            get
            {
                return this.m_Enabled;
            }
            set
            {
                this.m_Enabled = value;
            }
        }


        #endregion
    }
}

