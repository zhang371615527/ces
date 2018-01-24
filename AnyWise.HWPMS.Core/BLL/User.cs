namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class User : BaseBLL<UserInfo>
    {
        private IUser iuser_0;

        public User()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iuser_0 = (IUser) base.baseDal;
        }

        public override bool Delete(object key)
        {
            List<SimpleUserInfo> list = new Role().getSimpleUserList();
            if (list.Count == 1)
            {
                SimpleUserInfo info = list[0];
                if (Convert.ToInt32(key) == info.ID)
                {
                    throw new MyException("管理员角色至少需要包含一个用户！");
                }
            }
            return base.baseDal.Delete(key);
        }

        public byte[] GetPersonImageBytes(UserImageType imagetype, int userId)
        {
            IUser baseDal = base.baseDal as IUser;
            return baseDal.GetPersonImageBytes(imagetype, userId);
        }

        public List<SimpleUserInfo> GetSimpleUsers()
        {
            return this.iuser_0.GetSimpleUsers();
        }

        public List<SimpleUserInfo> GetSimpleUsers(string userIds)
        {
            return this.iuser_0.GetSimpleUsers(userIds);
        }

        public List<SimpleUserInfo> GetSimpleUsersByOU(int ouID)
        {
            return this.iuser_0.GetSimpleUsersByOU(ouID);
        }

        public List<SimpleUserInfo> GetSimpleUsersByRole(int roleID)
        {
            return this.iuser_0.GetSimpleUsersByRole(roleID);
        }

        public UserInfo GetUserByName(string userName)
        {
            UserInfo info = null;
            if (!string.IsNullOrEmpty(userName))
            {
                string condition = string.Format("Name ='{0}' ", userName);
                info = this.iuser_0.FindSingle(condition);
            }
            return info;
        }

        public List<FunctionInfo> GetUserFunctions(string identity, string sessionID, string typeID)
        {
            string userName = this.GetUserName(identity, sessionID);
            UserInfo userByName = this.GetUserByName(userName);
            List<FunctionInfo> functionsByUser = null;
            if (userByName != null)
            {
                functionsByUser = new Function().GetFunctionsByUser(userByName.ID, typeID);
            }
            return functionsByUser;
        }

        public string GetUserName(string identity, string sessionID)
        {
            if ((sessionID == null) || (sessionID == string.Empty))
            {
                return "";
            }
            string str = Convert.ToString(Convert.ToChar(1));
            identity = EncryptHelper.UnEncryptStr(identity, sessionID);
            int index = identity.IndexOf(str);
            return identity.Substring(0, index);
        }

        public List<UserInfo> GetUsersByOU(int ouID)
        {
            return this.iuser_0.GetUsersByOU(ouID);
        }

        public List<UserInfo> GetUsersByRole(int roleID)
        {
            return this.iuser_0.GetUsersByRole(roleID);
        }

        public override bool Insert(UserInfo obj)
        {
            UserInfo info = obj;
            info.Password = EncryptHelper.ComputeHash(info.Password, info.Name.ToLower());
            return base.Insert(obj);
        }

        internal void method_0(int int_0)
        {
            UserInfo info = this.FindByID(int_0.ToString());
            if (info.IsExpire)
            {
                info.IsExpire = false;
                this.Update(info, info.ID.ToString());
            }
        }

        public bool ModifyPassword(string userName, string userPassword)
        {
            return this.ModifyPassword(userName, userPassword, "", "", "");
        }

        public bool ModifyPassword(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            bool flag = false;
            UserInfo userByName = this.GetUserByName(userName);
            if (userByName != null)
            {
                userPassword = EncryptHelper.ComputeHash(userPassword, userName.ToLower());
                userByName.Password = userPassword;
                userByName.LastPasswordTime = DateTime.Now;
                if (flag = this.iuser_0.Update(userByName, userByName.ID.ToString()))
                {
                    BLLFactory<LoginLog>.Instance.AddLoginLog(userByName, systemType, ip, macAddr, "用户修改密码");
                }
            }
            return flag;
        }

        public override bool Update(UserInfo obj, object primaryKeyValue)
        {
            UserInfo info = obj;
            if (info.Password.Length < 50)
            {
                info.Password = EncryptHelper.ComputeHash(info.Password, info.Name.ToLower());
            }
            return this.iuser_0.Update(info, primaryKeyValue);
        }

        public bool UpdatePersonImageBytes(UserImageType imagetype, int userId, byte[] imageBytes)
        {
            IUser baseDal = base.baseDal as IUser;
            return baseDal.UpdatePersonImageBytes(imagetype, userId, imageBytes);
        }

        public bool UserInRole(string userName, string roleName)
        {
            UserInfo userByName = this.GetUserByName(userName);
            Role role = new Role();
            foreach (RoleInfo info2 in role.GetRolesByUser(userByName.ID))
            {
                if (info2.Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }

        public string VerifyUser(string userName, string userPassword, string systemType)
        {
            return this.VerifyUser(userName, userPassword, systemType, "", "");
        }

        public string VerifyUser(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            if (string.IsNullOrEmpty(systemType))
            {
                return "";
            }
            string str = "";
            UserInfo userByName = this.GetUserByName(userName);
            if (!((userByName == null) || userByName.IsExpire))
            {
                userPassword = EncryptHelper.ComputeHash(userPassword, userName.ToLower());
                if (userPassword == userByName.Password)
                {
                    iuser_0.UpdateUserLoginData(userByName.ID, ip, macAddr);
                    str = EncryptHelper.EncryptStr(userName + Convert.ToString(Convert.ToChar(1)) + userPassword, systemType);
                    BLLFactory<LoginLog>.Instance.AddLoginLog(userByName, systemType, ip, macAddr, "用户登录");
                }
            }
            return str;
        }

        public string VerifyUser2(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            string str = "";
            if (string.IsNullOrEmpty(systemType))
            {
                str = "系统禁止授权此应用";
            }
            else
            {
                UserInfo userByName = this.GetUserByName(userName);
                if (!((userByName == null) || userByName.IsExpire))
                {
                    userPassword = EncryptHelper.ComputeHash(userPassword, userName.ToLower());
                    if (userPassword == userByName.Password)
                    {
                        iuser_0.UpdateUserLoginData(userByName.ID, ip, macAddr);
                        BLLFactory<LoginLog>.Instance.AddLoginLog(userByName, systemType, ip, macAddr, "用户登录");
                    }
                    else
                    {
                        str = "用户密码输入错误";
                    }
                }
                else
                {
                    str = "用户名输入错误或者您已经被禁用";
                }
            }
            return str;
        }

        public bool InsertBatch(List<UserInfo> list)
        {
            return iuser_0.InsertBatch(list);
        }
    }
}

