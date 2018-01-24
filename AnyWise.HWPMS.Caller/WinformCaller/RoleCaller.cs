using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class RoleCaller : BaseLocalService<RoleInfo>, IRoleService
    {
        private Role bll = null;

        public RoleCaller() : base(BLLFactory<Role>.Instance)
        {
            bll = baseBLL as Role;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<RoleInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public void AddFunction(int functionID, int roleID)
        {
            bll.AddFunction(functionID, roleID);
        }

        public void AddOU(int ouID, int roleID)
        {
            bll.AddOU(ouID, roleID);
        }

        public void AddUser(int userID, int roleID)
        {
            bll.AddUser(userID, roleID);
        }

        public RoleInfo GetRoleByName(string roleName)
        {
            return bll.GetRoleByName(roleName);
        }

        public List<RoleInfo> GetRolesByFunction(int functionID)
        {
            return bll.GetRolesByFunction(functionID);
        }

        public List<RoleInfo> GetRolesByOU(int ouID)
        {
            return bll.GetRolesByOU(ouID);
        }

        public List<RoleInfo> GetRolesByUser(int userID)
        {
            return bll.GetRolesByUser(userID);
        }

        public void RemoveFunction(int functionID, int roleID)
        {
            bll.RemoveFunction(functionID, roleID);
        }

        public void RemoveOU(int ouID, int roleID)
        {
            bll.RemoveOU(ouID, roleID);
        }

        public void RemoveUser(int userID, int roleID)
        {
            bll.RemoveUser(userID, roleID);
        }
    }
}
