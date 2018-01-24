using System;
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
    /// 月度绩效考核子表
    /// </summary>
	public interface IYdjxkhzb : IBaseDAL<YdjxkhzbInfo>
    {
        bool SaveScore(string Mid, string Ids);
    }
}