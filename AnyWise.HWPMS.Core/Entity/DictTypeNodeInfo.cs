namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class DictTypeNodeInfo : DictTypeInfo
    {
        private List<DictTypeNodeInfo> list_0;

        public DictTypeNodeInfo()
        {
            this.list_0 = new List<DictTypeNodeInfo>();
            this.list_0 = new List<DictTypeNodeInfo>();
        }

        public DictTypeNodeInfo(DictTypeInfo typeInfo)
        {
            this.list_0 = new List<DictTypeNodeInfo>();
            base.ID = typeInfo.ID;
            base.Name = typeInfo.Name;
            base.Remark = typeInfo.Remark;
            base.Seq = typeInfo.Seq;
            base.PID = typeInfo.PID;
            base.Editor = typeInfo.Editor;
            base.LastUpdated = typeInfo.LastUpdated;
        }

        [DataMember]
        public List<DictTypeNodeInfo> Children
        {
            get
            {
                return this.list_0;
            }
            set
            {
                this.list_0 = value;
            }
        }
    }
}

