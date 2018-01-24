namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class MenuNodeInfo : MenuInfo
    {
        private List<MenuNodeInfo> list_0;

        public MenuNodeInfo()
        {
            this.list_0 = new List<MenuNodeInfo>();
            this.list_0 = new List<MenuNodeInfo>();
        }

        public MenuNodeInfo(MenuInfo menuInfo)
        {
            this.list_0 = new List<MenuNodeInfo>();
            base.ID = menuInfo.ID;
            base.Name = menuInfo.Name;
            base.PID = menuInfo.PID;
            base.Seq = menuInfo.Seq;
            base.Visible = menuInfo.Visible;
            base.FunctionId = menuInfo.FunctionId;
            base.Icon = menuInfo.Icon;
            base.WebIcon = menuInfo.WebIcon;
            base.WinformType = menuInfo.WinformType;
            base.Url = menuInfo.Url;
            base.SystemType_ID = menuInfo.SystemType_ID;
        }

        [DataMember]
        public List<MenuNodeInfo> Children
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

