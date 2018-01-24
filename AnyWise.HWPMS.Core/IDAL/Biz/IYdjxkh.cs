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
    /// 月度绩效考核表
    /// </summary>
	public interface IYdjxkh : IBaseDAL<YdjxkhInfo>
    {
        bool InsertMainAndSub(string strYear, string strMonth, string strCreator);
        bool UpdateStateByID(string ID, string State, string strEditor);
    }
}