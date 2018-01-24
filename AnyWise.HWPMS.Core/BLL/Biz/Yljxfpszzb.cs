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
    /// 医疗绩效分配设置子表
    /// </summary>
	public class Yljxfpszzb : BaseBLL<YljxfpszzbInfo>
    {
        private IYljxfpszzb iYljxfpszzb_0;
        public Yljxfpszzb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxfpszzb_0 = base.baseDal as IYljxfpszzb;
        }
        public bool InsertBatch(List<YljxfpszzbInfo> list)
        {
            return iYljxfpszzb_0.InsertBatch(list);
        }
    }
}
