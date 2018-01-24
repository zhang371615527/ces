namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.Serialization;
    using AnyWise.Framework.ControlUtil;

    [Serializable, DataContract]
    public class FileUploadInfo : BaseEntity
    {
        private byte[] byte_0;
        private DateTime dateTime_0 = DateTime.Now;
        private string enCmSdUkfS;
        private int int_0 = 0;
        private int int_1 = 0;
        private string string_0 = Guid.NewGuid().ToString();
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        [DataMember]
        public virtual DateTime AddTime
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
        public virtual string AttachmentGUID
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
        public virtual string BasePath
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
        public virtual string Category
        {
            get
            {
                return this.enCmSdUkfS;
            }
            set
            {
                this.enCmSdUkfS = value;
            }
        }

        [DataMember]
        public virtual int DeleteFlag
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
        public virtual string Editor
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
        public byte[] FileData
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        [DataMember]
        public virtual string FileExtend
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
        public virtual string FileName
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
        public virtual int FileSize
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
        public string Owner_ID
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
        public virtual string SavePath
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
    }
}

