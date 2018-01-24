using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 考核分类表
    /// </summary>
	public class Khflb : BaseBLL<KhflbInfo>
    {
        private IKhflb ikhflb_0;
        public Khflb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.ikhflb_0 = base.baseDal as IKhflb;
        }

        public List<KhflbInfo> GetAllTree(string nodeType)
        {
            return this.ikhflb_0.GetAllKhflb(nodeType);
        }
        public List<KhflbInfo> GetKhflbByID(string parentcode)
        {
            return this.ikhflb_0.GetKhflbByID(parentcode);
        }

        public bool DeleteByCode(string strCode)
        {
            bool result = false;
            string WhereCondition = string.Format(" ParentCode like '{0}%'", strCode);
            List<KhflbInfo> list = ikhflb_0.Find(WhereCondition);
            if (list == null || list.Count == 0)
            {
                string delCondition = string.Format(" Code ='{0}'", strCode);
                result = ikhflb_0.DeleteByCondition(delCondition);
            }
            return result;

        }

        public bool SaveExcelData(List<KhflbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (KhflbInfo detail in list)
                    {
                        ikhflb_0.Insert(detail, transaction);
                    }
                    transaction.Commit();
                    result = true;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    LogTextHelper.Error(exception);
                }
            }
            return result;
        }
    }
}
