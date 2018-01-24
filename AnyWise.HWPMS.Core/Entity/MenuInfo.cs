namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class MenuInfo : BaseEntity
    {
        private bool flag = true;
        private string _ID = Guid.NewGuid().ToString();
        private string _PID = "-1";
        private string _Name;
        private string _Icon;
        private string _Seq;
        private string _FunctionId;
        private string _WinformType;
        private string _Url;
        private string _SystemType = "";
        private string _WebIcon;

        [DataMember]
        public virtual string FunctionId
        {
            get
            {
                return this._FunctionId;
            }
            set
            {
                this._FunctionId = value;
            }
        }

        [DataMember]
        public virtual string Icon
        {
            get
            {
                return this._Icon;
            }
            set
            {
                this._Icon = value;
            }
        }

        [DataMember]
        public virtual string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        [DataMember]
        public virtual string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        [DataMember]
        public virtual string PID
        {
            get
            {
                return this._PID;
            }
            set
            {
                this._PID = value;
            }
        }

        [DataMember]
        public virtual string Seq
        {
            get
            {
                return this._Seq;
            }
            set
            {
                this._Seq = value;
            }
        }

        [DataMember]
        public virtual string SystemType_ID
        {
            get
            {
                return this._SystemType;
            }
            set
            {
                this._SystemType = value;
            }
        }

        [DataMember]
        public virtual string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        [DataMember]
        public virtual bool Visible
        {
            get
            {
                return this.flag;
            }
            set
            {
                this.flag = value;
            }
        }

        [DataMember]
        public virtual string WebIcon
        {
            get
            {
                return this._WebIcon;
            }
            set
            {
                this._WebIcon = value;
            }
        }

        [DataMember]
        public virtual string WinformType
        {
            get
            {
                return this._WinformType;
            }
            set
            {
                this._WinformType = value;
            }
        }
    }
}

