namespace AnyWise.HWPMS.Entity
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable, DataContract]
    public class LoginResult
    {
        
        private bool bool_0;
        
        private string string_0;
        
        private AnyWise.HWPMS.Entity.UserInfo userInfo_0;

        [DataMember]
        public string ErrorMessage
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
        public bool Success
        {
            
            get
            {
                return this.bool_0;
            }
            
            set
            {
                this.bool_0 = value;
            }
        }

        [DataMember]
        public AnyWise.HWPMS.Entity.UserInfo UserInfo
        {
            
            get
            {
                return this.userInfo_0;
            }
            
            set
            {
                this.userInfo_0 = value;
            }
        }
    }
}

