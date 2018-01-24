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
    /// 绩效参数表
    /// </summary>
	public class Jxcsb : BaseBLL<JxcsbInfo>
    {
        private IJxcsb iJxcsb_0;
        public Jxcsb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iJxcsb_0 = base.baseDal as IJxcsb;
        }
        public bool InsertBatch(List<JxcsbInfo> list)
        {
            return iJxcsb_0.InsertBatch(list);
        }
    }
}
