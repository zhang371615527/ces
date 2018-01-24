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
    public class OuCaller : BaseLocalService<OUInfo>, IOuService
    {
        private OU bll = null;

        public OuCaller() : base(BLLFactory<OU>.Instance)
        {
            bll = baseBLL as OU;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<OuInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public void AddUser(int userID, int ouID)
        {
            bll.AddUser(userID, ouID);
        }

        public void RemoveUser(int userID, int ouID)
        {
            bll.RemoveUser(userID, ouID);
        }

        public List<OUInfo> GetOUsByRole(int roleID)
        {
            return bll.GetOUsByRole(roleID);
        }

        public List<OUInfo> GetOUsByUser(int userID)
        {
            return bll.GetOUsByUser(userID);
        }

        public OUInfo GetTopGroup()
        {
            return bll.GetTopGroup();
        }
        public List<OUInfo> GetAllCompany()
        {
            return bll.GetAllCompany();
        }

        public List<OUInfo> GetGroupCompany()
        {
            return bll.GetGroupCompany();
        }

        public void DeleteByFlag(string IDs, string flag)
        {
            bll.DeleteByFlag(IDs, flag);
        }
        public void Truncate(string flag)
        {
            bll.Truncate(flag);
        }
        public void SaveGZLData(YljxflgzlInfo info)
        {
            bll.SaveGZLData(info);
        }
        public void GZLZH(string IDs)
        {
            bll.GZLZH(IDs);
        }
    }
}
