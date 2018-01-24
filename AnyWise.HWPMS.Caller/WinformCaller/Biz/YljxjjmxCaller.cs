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
    public class YljxjjmxCaller : BaseLocalService<YljxjjmxInfo>, IYljxjjmxService
    {
        private Yljxjjmx bll = null;

        public YljxjjmxCaller() : base(BLLFactory<Yljxjjmx>.Instance)
        {
            bll = baseBLL as Yljxjjmx;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxjjmxInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool SaveExcelData(List<YljxjjmxInfo> list)
        {
            return bll.SaveExcelData(list);
        }

        /// <summary>
        /// 医疗绩效奖金明细表
        /// </summary>
        public List<YljxjjmxInfo> Yljxjjmx_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            return bll.Yljxjjmx_FWP(intRecordCount, intPageSize, intPageCount, where);
        }

        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        public DataTable Yljxjjmx_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            return bll.Yljxjjmx_Cal(strYear, strMonth, strKSID, strZXZD_ID);
        }
        public bool Yljxjjmx_Insert(List<YljxjjmxInfo> list)
        {
            return bll.Yljxjjmx_Insert(list);
        }
        /// <summary>
        /// 医疗绩效奖金明细表bsd
        /// </summary>
        public DataTable Yljxjjmx_BDD(string strYear, string strMonth, string strKSZD_ID, string strFPLBID)
        {
            return bll.Yljxjjmx_BDD(strYear, strMonth, strKSZD_ID, strFPLBID);
        }
    }
}
