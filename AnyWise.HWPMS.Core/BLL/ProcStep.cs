using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using System.Reflection;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 流程配置步骤表
    /// </summary>
    public class ProcStep : BaseBLL<ProcStepInfo>
    {
        private IProcStep iprocstep_0;

        public ProcStep()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iprocstep_0 = (IProcStep) base.baseDal;
        }
    }
}
