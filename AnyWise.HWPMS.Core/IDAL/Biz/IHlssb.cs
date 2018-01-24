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
    /// 护理时数
    /// </summary>
	public interface IHlssb : IBaseDAL<HlssbInfo>
	{
        bool InsertBatch(List<HlssbInfo> list);
    }
}