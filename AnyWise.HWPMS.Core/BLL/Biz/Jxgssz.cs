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
    /// 绩效公式设置
    /// </summary>
	public class Jxgssz : BaseBLL<JxgsszInfo>
    {
        private IJxgssz iJxgssz_0;
        public Jxgssz() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iJxgssz_0 = base.baseDal as IJxgssz;
        }

        public bool InsertBatch(List<JxgsszInfo> list)
        {
            return iJxgssz_0.InsertBatch(list);
        }
    }
}
