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
    public class UserCaller : BaseLocalService<UserInfo>, IUserService
    {
        private User bll = null;

        public UserCaller() : base(BLLFactory<User>.Instance)
        {
            bll = baseBLL as User;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<UserInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public List<UserInfo> GetUsersByOU(int ouID)
        {
            return bll.GetUsersByOU(ouID);
        }

        public List<UserInfo> GetUsersByRole(int roleID)
        {
            return bll.GetUsersByRole(roleID);
        }

        public bool ModifyPassword(string userName, string userPassword)
        {
            return bll.ModifyPassword(userName, userPassword);
        }

        public bool ModifyPassword(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            return bll.ModifyPassword(userName, userPassword, systemType, ip, macAddr);
        }

        public string VerifyUser(string userName, string userPassword, string systemType)
        {
            return bll.VerifyUser(userName, userPassword, systemType);
        }

        public string VerifyUser(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            return bll.VerifyUser(userName, userPassword, systemType, ip, macAddr);
        }

        public string VerifyUser2(string userName, string userPassword, string systemType, string ip, string macAddr)
        {
            return bll.VerifyUser2(userName, userPassword, systemType, ip, macAddr);
        }

        public UserInfo GetUserByName(string userName)
        {
            return bll.GetUserByName(userName);
        }

        public bool InsertBatch(List<UserInfo> list)
        {
            return bll.InsertBatch(list);
        }
    }
}
