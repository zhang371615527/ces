namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class UserInfo : SimpleUserInfo
    {
        #region Field Members
          
        private int m_PID = -1; //          
        private string m_HandNo; //   
        private string m_Nickname; //          
        private bool m_IsExpire = false; //          
        private string m_Title; //          
        private string m_IdentityCard; //          
        private string m_MobilePhone; //          
        private string m_OfficePhone; //          
        private string m_HomePhone; //          
        private string m_Email; //          
        private string m_Address; //          
        private string m_WorkAddr; //          
        private string m_Gender; //          
        private DateTime m_Birthday; //          
        private string m_QQ; //          
        private string m_Signature; //          
        private string m_AuditStatus; //          
        private byte[] m_Portrait; //          
        private string m_Note; //          
        private string m_CustomField; //          
        private string m_Dept_ID; //          
        private string m_DeptName; //          
        private string m_Company_ID; //          
        private string m_CompanyName; //          
        private string m_SortCode; //          
        private string m_Creator; //          
        private string m_Creator_ID; //          
        private DateTime m_CreateTime = System.DateTime.Now; //          
        private string m_Editor; //          
        private string m_Editor_ID; //          
        private DateTime m_EditTime = System.DateTime.Now; //          
        private int m_Deleted = 0; //          
        private string m_Question; //          
        private string m_Answer; //          
        private string m_LastLoginIP; //          
        private DateTime m_LastLoginTime; //          
        private string m_LastMacAddress; //          
        private string m_CurrentLoginIP; //          
        private DateTime m_CurrentLoginTime; //          
        private string m_CurrentMacAddress; //          
        private DateTime m_LastPasswordTime; //          

        #endregion

        #region Property Members

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
        public virtual string Nickname
        {
            get
            {
                return this.m_Nickname;
            }
            set
            {
                this.m_Nickname = value;
            }
        }

        [DataMember]
        public virtual bool IsExpire
        {
            get
            {
                return this.m_IsExpire;
            }
            set
            {
                this.m_IsExpire = value;
            }
        }

        [DataMember]
        public virtual string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        [DataMember]
        public virtual string IdentityCard
        {
            get
            {
                return this.m_IdentityCard;
            }
            set
            {
                this.m_IdentityCard = value;
            }
        }

        [DataMember]
        public virtual string MobilePhone
        {
            get
            {
                return this.m_MobilePhone;
            }
            set
            {
                this.m_MobilePhone = value;
            }
        }

        [DataMember]
        public virtual string OfficePhone
        {
            get
            {
                return this.m_OfficePhone;
            }
            set
            {
                this.m_OfficePhone = value;
            }
        }

        [DataMember]
        public virtual string HomePhone
        {
            get
            {
                return this.m_HomePhone;
            }
            set
            {
                this.m_HomePhone = value;
            }
        }

        [DataMember]
        public virtual string Email
        {
            get
            {
                return this.m_Email;
            }
            set
            {
                this.m_Email = value;
            }
        }

        [DataMember]
        public virtual string Address
        {
            get
            {
                return this.m_Address;
            }
            set
            {
                this.m_Address = value;
            }
        }

        [DataMember]
        public virtual string WorkAddr
        {
            get
            {
                return this.m_WorkAddr;
            }
            set
            {
                this.m_WorkAddr = value;
            }
        }

        [DataMember]
        public virtual string Gender
        {
            get
            {
                return this.m_Gender;
            }
            set
            {
                this.m_Gender = value;
            }
        }

        [DataMember]
        public virtual DateTime Birthday
        {
            get
            {
                return this.m_Birthday;
            }
            set
            {
                this.m_Birthday = value;
            }
        }

        [DataMember]
        public virtual string QQ
        {
            get
            {
                return this.m_QQ;
            }
            set
            {
                this.m_QQ = value;
            }
        }

        [DataMember]
        public virtual string Signature
        {
            get
            {
                return this.m_Signature;
            }
            set
            {
                this.m_Signature = value;
            }
        }

        [DataMember]
        public virtual string AuditStatus
        {
            get
            {
                return this.m_AuditStatus;
            }
            set
            {
                this.m_AuditStatus = value;
            }
        }

        [DataMember]
        public virtual byte[] Portrait
        {
            get
            {
                return this.m_Portrait;
            }
            set
            {
                this.m_Portrait = value;
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
        public virtual string CustomField
        {
            get
            {
                return this.m_CustomField;
            }
            set
            {
                this.m_CustomField = value;
            }
        }

        [DataMember]
        public virtual string Dept_ID
        {
            get
            {
                return this.m_Dept_ID;
            }
            set
            {
                this.m_Dept_ID = value;
            }
        }

        [DataMember]
        public virtual string DeptName
        {
            get
            {
                return this.m_DeptName;
            }
            set
            {
                this.m_DeptName = value;
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
        public virtual string Question
        {
            get
            {
                return this.m_Question;
            }
            set
            {
                this.m_Question = value;
            }
        }

        [DataMember]
        public virtual string Answer
        {
            get
            {
                return this.m_Answer;
            }
            set
            {
                this.m_Answer = value;
            }
        }

        [DataMember]
        public virtual string LastLoginIP
        {
            get
            {
                return this.m_LastLoginIP;
            }
            set
            {
                this.m_LastLoginIP = value;
            }
        }

        [DataMember]
        public virtual DateTime LastLoginTime
        {
            get
            {
                return this.m_LastLoginTime;
            }
            set
            {
                this.m_LastLoginTime = value;
            }
        }

        [DataMember]
        public virtual string LastMacAddress
        {
            get
            {
                return this.m_LastMacAddress;
            }
            set
            {
                this.m_LastMacAddress = value;
            }
        }

        [DataMember]
        public virtual string CurrentLoginIP
        {
            get
            {
                return this.m_CurrentLoginIP;
            }
            set
            {
                this.m_CurrentLoginIP = value;
            }
        }

        [DataMember]
        public virtual DateTime CurrentLoginTime
        {
            get
            {
                return this.m_CurrentLoginTime;
            }
            set
            {
                this.m_CurrentLoginTime = value;
            }
        }

        [DataMember]
        public virtual string CurrentMacAddress
        {
            get
            {
                return this.m_CurrentMacAddress;
            }
            set
            {
                this.m_CurrentMacAddress = value;
            }
        }

        [DataMember]
        public virtual DateTime LastPasswordTime
        {
            get
            {
                return this.m_LastPasswordTime;
            }
            set
            {
                this.m_LastPasswordTime = value;
            }
        }


        #endregion
    }
}

