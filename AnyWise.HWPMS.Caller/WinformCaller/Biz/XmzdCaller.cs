using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class XmzdCaller : BaseLocalService<XmzdInfo>, IXmzdService
    {
        private Xmzd bll = null;

        public XmzdCaller() : base(BLLFactory<Xmzd>.Instance)
        {
            bll = baseBLL as Xmzd;
        }

        public bool SaveExcelData(List<XmzdInfo> list)
        {
            return bll.SaveExcelData(list);
        }

    }
}
