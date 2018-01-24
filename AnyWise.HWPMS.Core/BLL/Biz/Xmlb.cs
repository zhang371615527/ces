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
    /// 项目类别表
    /// </summary>
    public class Xmlb : BaseBLL<XmlbInfo>
    {
        private IXmlb ixmlb_0;

        public Xmlb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ixmlb_0 = (IXmlb)base.baseDal;
        }
       
    }
}
