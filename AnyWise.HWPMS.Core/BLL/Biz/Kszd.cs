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
    /// 科室字典
    /// </summary>
	public class Kszd : BaseBLL<KszdInfo>
    {
        public Kszd() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
