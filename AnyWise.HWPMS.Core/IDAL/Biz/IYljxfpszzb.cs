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
    /// 医疗绩效分配设置子表
    /// </summary>
	public interface IYljxfpszzb : IBaseDAL<YljxfpszzbInfo>
	{
        bool InsertBatch(List<YljxfpszzbInfo> list);
    }
}