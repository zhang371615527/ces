using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 医疗绩效分类工作量
    /// </summary>
    public class Yljxflgzl : BaseBLL<YljxflgzlInfo>
    {
        private IYljxflgzl iYljxflgzl_0;
        public Yljxflgzl()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxflgzl_0 = base.baseDal as IYljxflgzl;
        }
        public bool InsertBatch(List<YljxflgzlInfo> list)
        {
            return iYljxflgzl_0.InsertBatch(list);
        }
    }
}
