﻿using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.HWPMS.Entity;

namespace AnyWise.HWPMS.IDAL
{
    /// <summary>
    /// 流程配置步骤表
    /// </summary>
    public interface IProcStep : IBaseDAL<ProcStepInfo>
    {
    }
}