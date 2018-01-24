namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class Role : BaseBLL<RoleInfo>
    {
        private static int intRoleID = -99;
        private IRole irole_0;

        public Role()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.irole_0 = base.baseDal as IRole;
        }

        public void AddFunction(int functionID, int roleID)
        {
            this.irole_0.AddFunction(functionID, roleID);
        }

        public void AddOU(int ouID, int roleID)
        {
            this.irole_0.AddOU(ouID, roleID);
        }

        public void AddUser(int userID, int roleID)
        {
            this.getRoleID();
            if (roleID == intRoleID)
            {
                new User().method_0(userID);
            }
            this.irole_0.AddUser(userID, roleID);
        }

        public override bool Delete(object key)
        {
            this.getRoleID();
            if (Convert.ToInt32(key) == intRoleID)
            {
                throw new MyException("管理员角色不能被删除！");
            }
            return base.baseDal.Delete(key);
        }
        public List<RoleInfo> GetRolesByCompany(string companyId)
        {
            string str = string.Format("Company_ID='{0}' and Deleted = 0 ", companyId);
            return this.Find(str);
        }

        public RoleInfo GetRoleByName(string roleName)
        {
            string condition = string.Format("Name='{0}'", roleName);
            return this.irole_0.FindSingle(condition);
        }

        public List<RoleInfo> GetRolesByFunction(int functionID)
        {
            return this.irole_0.GetRolesByFunction(functionID);
        }

        public List<RoleInfo> GetRolesByOU(int ouID)
        {
            return this.irole_0.GetRolesByOU(ouID);
        }

        public List<RoleInfo> GetRolesByUser(int userID)
        {
            List<RoleInfo> rolesByUser = this.irole_0.GetRolesByUser(userID);
            ArrayList list2 = new ArrayList();
            foreach (RoleInfo info in rolesByUser)
            {
                list2.Add(info.ID);
            }
            OU ou = new OU();
            foreach (OUInfo info2 in ou.GetOUsByUser(userID))
            {
                foreach (RoleInfo info3 in this.irole_0.GetRolesByOU(info2.ID))
                {
                    if (list2.IndexOf(info3.ID) < 0)
                    {
                        rolesByUser.Add(info3);
                        list2.Add(info3.ID);
                    }
                }
            }
            return rolesByUser;
        }

        internal bool hasRoleUser()
        {
            this.getRoleID();
            User user = new User();
            return (user.GetSimpleUsersByRole(intRoleID).Count > 0);
        }

        private void hasUserByRole(int roleID)
        {
            this.getRoleID();
            if ((roleID == intRoleID) && (this.getSimpleUserList().Count <= 1))
            {
                throw new MyException("管理员角色至少需要包含一个用户！");
            }
        }

        private void getRoleID()
        {
            if (intRoleID == -99)
            {
                RoleInfo roleByName = this.GetRoleByName("超级管理员");
                if (roleByName != null)
                {
                    intRoleID = roleByName.ID;
                }
            }
        }

        internal List<int> getOULists()
        {
            this.getRoleID();
            List<OUInfo> oUsByRole = new OU().GetOUsByRole(intRoleID);
            List<int> list2 = new List<int>();
            foreach (OUInfo info in oUsByRole)
            {
                list2.Add(info.ID);
            }
            return list2;
        }

        internal List<SimpleUserInfo> getSimpleUserList()
        {
            this.getRoleID();
            User user = new User();
            List<SimpleUserInfo> simpleUsersByRole = user.GetSimpleUsersByRole(intRoleID);
            int count = simpleUsersByRole.Count;
            if (count <= 1)
            {
                OU ou = new OU();
                foreach (OUInfo info in ou.GetOUsByRole(intRoleID))
                {
                    List<SimpleUserInfo> simpleUsersByOU = user.GetSimpleUsersByOU(info.ID);
                    if (simpleUsersByOU.Count > 0)
                    {
                        simpleUsersByRole.Add(simpleUsersByOU[0]);
                        count++;
                        if (simpleUsersByOU.Count > 1)
                        {
                            simpleUsersByRole.Add(simpleUsersByOU[1]);
                            count++;
                        }
                        if (count > 1)
                        {
                            return simpleUsersByRole;
                        }
                    }
                }
                return simpleUsersByRole;
            }
            return simpleUsersByRole;
        }

        public void RemoveFunction(int functionID, int roleID)
        {
            this.irole_0.RemoveFunction(functionID, roleID);
        }

        public void RemoveOU(int ouID, int roleID)
        {
            this.getRoleID();
            if (roleID != intRoleID)
            {
                goto Label_00E1;
            }
            User user = new User();
            List<SimpleUserInfo> simpleUsersByRole = user.GetSimpleUsersByRole(intRoleID);
            if (simpleUsersByRole.Count >= 1)
            {
                goto Label_00E1;
            }
            simpleUsersByRole.Clear();
            List<UserInfo> usersByOU = user.GetUsersByOU(ouID);
            if (usersByOU.Count <= 0)
            {
                goto Label_00E1;
            }
            usersByOU.Clear();
            bool flag = false;
            List<OUInfo> oUsByRole = new OU().GetOUsByRole(intRoleID);
            using (List<OUInfo>.Enumerator enumerator = oUsByRole.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    OUInfo current = enumerator.Current;
                    if ((current.ID != ouID) && (user.GetSimpleUsersByOU(current.ID).Count > 0))
                    {
                        goto Label_00B8;
                    }
                }
                goto Label_00CB;
            Label_00B8:
                flag = true;
            }
        Label_00CB:
            oUsByRole.Clear();
            if (!flag)
            {
                throw new MyException("管理员角色至少需要包含一个用户！");
            }
        Label_00E1:
            this.irole_0.RemoveOU(ouID, roleID);
        }

        public void RemoveUser(int userID, int roleID)
        {
            this.hasUserByRole(roleID);
            this.irole_0.RemoveUser(userID, roleID);
        }

        public override bool Update(RoleInfo obj, object primaryKeyValue)
        {
            RoleInfo info = obj;
            if (info.ID == intRoleID)
            {
                info.Name = "超级管理员";
            }
            return base.Update(info, primaryKeyValue);
        }
    }
}

