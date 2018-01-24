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
    /// 考核分类表
    /// </summary>
	public interface IKhflb : IBaseDAL<KhflbInfo>
	{
        List<KhflbInfo> GetAllKhflb(string nodeType);
        List<KhflbInfo> GetKhflbByID(string parentcode);
    }
}