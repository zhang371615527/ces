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
    /// 绩效分配参数表
    /// </summary>
    public class Yljxfpcsb : BaseBLL<YljxfpcsbInfo>
    {
        private IYljxfpcsb iYljxfpcsb_0;
        public Yljxfpcsb()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxfpcsb_0 = base.baseDal as IYljxfpcsb;
        }
        public bool InsertBatch(List<YljxfpcsbInfo> list)
        {
            return iYljxfpcsb_0.InsertBatch(list);
        }
    }
}
