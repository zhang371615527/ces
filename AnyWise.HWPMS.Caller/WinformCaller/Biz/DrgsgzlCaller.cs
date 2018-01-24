using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Dynamic;
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
    public class DrgsgzlCaller : BaseLocalService<DrgsgzlInfo>, IDrgsgzlService
    {
        private Drgsgzl bll = null;

        public DrgsgzlCaller() : base(BLLFactory<Drgsgzl>.Instance)
        {
            bll = baseBLL as Drgsgzl;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<DrgsgzlInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool InsertBatch(List<DrgsgzlInfo> list)
        {
            return bll.InsertBatch(list);
        }

        /// <summary>
        /// 返回CMI折线图数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable DRGSAna_CMIAna(string where)
        {
            return bll.DRGSAna_CMIAna(where);
        }
        #region 收入折线图
        public string DRGSAna_GetxAxis(string Year)
        {
            return bll.DRGSAna_GetxAxis(Year);
        }
        public string DRGSAna_GetIncome(string Year)
        {
            return bll.DRGSAna_GetIncome(Year);
        }
        #endregion

        public List<ExpandoObject> DRGSAna_DRGsDetail(string BeginPeriod, string EndPeriod)
        {
            return bll.DRGSAna_DRGsDetail(BeginPeriod, EndPeriod); ;
        }
    }
}
