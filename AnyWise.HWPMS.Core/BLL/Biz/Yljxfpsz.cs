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
    /// 医疗绩效分配设置
    /// </summary>
	public class Yljxfpsz : BaseBLL<YljxfpszInfo>
    {
        private IYljxfpsz iYljxfpsz_0;
        public Yljxfpsz() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxfpsz_0 = base.baseDal as IYljxfpsz;
        }
        public bool InsertBatch(List<YljxfpszInfo> list)
        {
            return iYljxfpsz_0.InsertBatch(list);
        }
    }
}
