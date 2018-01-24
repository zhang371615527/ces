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
    /// 科室用人费用比率
    /// </summary>
	public class Ksyrfyblb : BaseBLL<KsyrfyblbInfo>
    {
        private IKsyrfyblb iKsyrfyblb_0;
        public Ksyrfyblb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iKsyrfyblb_0 = base.baseDal as IKsyrfyblb;
        }
        public bool InsertBatch(List<KsyrfyblbInfo> list)
        {
            return iKsyrfyblb_0.InsertBatch(list);
        }
    }
}
