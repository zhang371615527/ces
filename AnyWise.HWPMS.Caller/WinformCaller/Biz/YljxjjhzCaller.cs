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
    public class YljxjjhzCaller : BaseLocalService<YljxjjhzInfo>, IYljxjjhzService
    {
        private Yljxjjhz bll = null;

        public YljxjjhzCaller() : base(BLLFactory<Yljxjjhz>.Instance)
        {
            bll = baseBLL as Yljxjjhz;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxjjhzInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool SaveExcelData(List<YljxjjhzInfo> list)
        {
            return bll.SaveExcelData(list);
        }

        /// <summary>
        /// 医疗绩效奖金汇总表
        /// </summary>
        public List<YljxjjhzInfo> Yljxjjhz_FWP(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            return bll.Yljxjjhz_FWP(intPageSize, intPageCount, mSizeBackup, where);
        }

        /// <summary>
        /// 医疗绩效奖金汇总表Calculate
        /// </summary>
        public DataTable Yljxjjhz_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            return bll.Yljxjjhz_Cal(strYear, strMonth, strKSID, strZXZD_ID); 
        }
        public bool Yljxjjhz_Insert(List<YljxjjhzInfo> listjj)
        {
            return bll.Yljxjjhz_Insert(listjj);
        }
        /// <summary>
        /// 医疗绩效奖金汇总表bsd
        /// </summary>
        public DataTable Yljxjjhz_BSD(string strYear, string strMonth, string strKSZD_ID)
        {
            return bll.Yljxjjhz_BSD(strYear, strMonth, strKSZD_ID); 
        }
    }
}
