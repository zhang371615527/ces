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
    /// 绩效公式设置子表
    /// </summary>
    public class Jxgsszzb : BaseBLL<JxgsszzbInfo>
    {
        public Jxgsszzb()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
