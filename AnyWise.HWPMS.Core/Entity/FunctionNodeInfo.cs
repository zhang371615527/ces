namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class FunctionNodeInfo : FunctionInfo
    {
        private List<FunctionNodeInfo> list_0;

        public FunctionNodeInfo()
        {
            this.list_0 = new List<FunctionNodeInfo>();
            this.list_0 = new List<FunctionNodeInfo>();
        }

        public FunctionNodeInfo(FunctionInfo functionInfo)
        {
            this.list_0 = new List<FunctionNodeInfo>();
            base.ControlID = functionInfo.ControlID;
            base.ID = functionInfo.ID;
            base.Name = functionInfo.Name;
            base.PID = functionInfo.PID;
            base.SystemType_ID = functionInfo.SystemType_ID;
        }

        [DataMember]
        public List<FunctionNodeInfo> Children
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

