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
    /// 护理时数
    /// </summary>
	public class Hlssb : BaseBLL<HlssbInfo>
    {
        private IHlssb iHlssb_0;
        public Hlssb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iHlssb_0 = base.baseDal as IHlssb;
        }
        public bool InsertBatch(List<HlssbInfo> list)
        {
            return iHlssb_0.InsertBatch(list);
        }
    }
}
