namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization;

    
    [Serializable, DataContract]
    public class KhflbNodeInfo : KhflbInfo
    {
        private List<KhflbNodeInfo> list_0;

        public KhflbNodeInfo()
        {
            this.list_0 = new List<KhflbNodeInfo>();
        }

        public KhflbNodeInfo(KhflbInfo khflbInfo)
        {
            this.list_0 = new List<KhflbNodeInfo>();
            base.Code = khflbInfo.Code;
            base.ParentCode = khflbInfo.ParentCode;
            base.Name = khflbInfo.Name;
            base.Content = khflbInfo.Content;
            base.Type = khflbInfo.Type;
            
            base.Creator = khflbInfo.Creator;
            base.CreateTime = khflbInfo.CreateTime;
            base.EditTime = khflbInfo.EditTime;
            base.Editor = khflbInfo.Editor;
            base.Note = khflbInfo.Note;
            base.WebIcon = khflbInfo.WebIcon;
            base.Enabled = khflbInfo.Enabled;
        }

        [DataMember]
        public List<KhflbNodeInfo> Children
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