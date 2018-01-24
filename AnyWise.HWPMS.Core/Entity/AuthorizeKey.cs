namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class AuthorizeKey
    {

        private bool canInsert;

        private bool canUpdate;

        private bool canDelete;

        private bool canList;

        private bool canView;

        private bool canExport;

        private string insertKey;

        private string updateKey;

        private string deleteKey;

        private string lstKey;

        private string viewKey;

        private string exportKey;

        public AuthorizeKey()
        {
        }

        public AuthorizeKey(string insert, string update, string delete, string view = "")
        {
            this.InsertKey = insert;
            this.UpdateKey = update;
            this.DeleteKey = delete;
            this.ViewKey = view;
        }

        public bool CanDelete
        {
            
            get
            {
                return this.canDelete;
            }
            
            set
            {
                this.canDelete = value;
            }
        }

        public bool CanExport
        {
            
            get
            {
                return this.canExport;
            }
            
            set
            {
                this.canExport = value;
            }
        }

        public bool CanInsert
        {
            
            get
            {
                return this.canInsert;
            }
            
            set
            {
                this.canInsert = value;
            }
        }

        public bool CanList
        {
            
            get
            {
                return this.canList;
            }
            
            set
            {
                this.canList = value;
            }
        }

        public bool CanUpdate
        {
            
            get
            {
                return this.canUpdate;
            }
            
            set
            {
                this.canUpdate = value;
            }
        }

        public bool CanView
        {
            
            get
            {
                return this.canView;
            }
            
            set
            {
                this.canView = value;
            }
        }

        public string DeleteKey
        {
            
            get
            {
                return this.deleteKey;
            }
            
            set
            {
                this.deleteKey = value;
            }
        }

        public string ExportKey
        {
            
            get
            {
                return this.exportKey;
            }
            
            set
            {
                this.exportKey = value;
            }
        }

        public string InsertKey
        {
            
            get
            {
                return this.insertKey;
            }
            
            set
            {
                this.insertKey = value;
            }
        }

        public string ListKey
        {
            
            get
            {
                return this.lstKey;
            }
            
            set
            {
                this.lstKey = value;
            }
        }

        public string UpdateKey
        {
            
            get
            {
                return this.updateKey;
            }
            
            set
            {
                this.updateKey = value;
            }
        }

        public string ViewKey
        {
            
            get
            {
                return this.viewKey;
            }
            
            set
            {
                this.viewKey = value;
            }
        }
    }
}

