﻿using System;
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
    public class ProcStepCaller : BaseLocalService<ProcStepInfo>, IProcStepService
    {
        private ProcStep bll = null;

        public ProcStepCaller() : base(BLLFactory<ProcStep>.Instance)
        {
            bll = baseBLL as ProcStep;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<ProcStepInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}
