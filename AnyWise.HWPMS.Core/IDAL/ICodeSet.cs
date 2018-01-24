using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.HWPMS.Entity;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.IDAL
{
    /// <summary>
    /// 编码规则配置表
    /// </summary>
	public interface ICodeSet : IBaseDAL<CodeSetInfo>
	{
    }
}