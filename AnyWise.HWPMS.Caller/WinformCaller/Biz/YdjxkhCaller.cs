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
    public class YdjxkhCaller : BaseLocalService<YdjxkhInfo>, IYdjxkhService
    {
        private Ydjxkh bll = null;

        public YdjxkhCaller() : base(BLLFactory<Ydjxkh>.Instance)
        {
            bll = baseBLL as Ydjxkh;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YdjxkhInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool InsertMainAndSub(string strYear, string strMonth, string strCreator)
        {
            return bll.InsertMainAndSub(strYear, strMonth, strCreator);
        }

        public bool UpdateStateByID(string ID, string State, string strEditor)
        {
            return bll.UpdateStateByID(ID, State, strEditor);
        }

        public DataTable ExaSumExport(string strYear, string strMonth, string strResKS_ID)
        {
            return bll.ExaSumExport(strYear, strMonth, strResKS_ID);
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID)
        {
            return bll.GetDataTable(strYear, strMonth, strResKS_ID);
        }

        public DataTable GetDataTableByCheckKS(string strYear, string strMonth, string strCheckKS_ID)
        {
            return bll.GetDataTableByCheckKS(strYear, strMonth, strCheckKS_ID);
        }
    }
}
