using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 医疗绩效工作量
    /// </summary>
	public class Yljxgzl : BaseBLL<YljxgzlInfo>
    {
        private IYljxgzl iYljxgzl_0;
        public Yljxgzl() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxgzl_0 = base.baseDal as IYljxgzl;
        }
        public bool SaveExcelData(List<YljxgzlInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (YljxgzlInfo detail in list)
                    {
                        BLLFactory<Yljxgzl>.Instance.Insert(detail, sqlDbTransaction);
                        //开单科室工作量
                        YljxflgzlInfo info1 = new YljxflgzlInfo();
                        info1.GZLID = detail.ID;
                        info1.Year = detail.Year;
                        info1.Month = detail.Month;
                        info1.Date = detail.Date;
                        info1.Source = detail.Source;
                        info1.KszdId = detail.KszdId;
                        info1.KszdName = detail.KszdName;
                        info1.RyzdId = detail.RyzdId;
                        info1.RyzdName = detail.RyzdName;
                        info1.Xmlbid = detail.Xmlbid;
                        info1.XmlbName = detail.XmlbName;
                        info1.XmzdId = detail.XmzdId;
                        info1.XmzdName = detail.XmzdName;
                        info1.Unit = detail.Unit;
                        info1.Quantity = detail.Quantity;
                        info1.Value = detail.Value;
                        info1.IsDrugIncome = detail.IsDrugIncome;
                        info1.Bqid = detail.Bqid;
                        info1.Type = "O";
                        info1.ZxzdId = detail.ZxzdId;
                        info1.Note = detail.Note;
                        info1.CreateTime = DateTime.Now;
                        info1.Creator = detail.Creator;
                        info1.Editor = detail.Editor;
                        info1.EditTime = DateTime.Now;
                        BLLFactory<Yljxflgzl>.Instance.Insert(info1, sqlDbTransaction);

                        YljxflgzlInfo info2 = new YljxflgzlInfo();
                        info2.GZLID = detail.ID;
                        info2.Year = detail.Year;
                        info2.Month = detail.Month;
                        info2.Date = detail.Date;
                        info2.Source = detail.Source;
                        info2.KszdId = detail.ExecKSID;
                        info2.KszdName = detail.ExecKSName;
                        info2.RyzdId = detail.ExecRYZDID;
                        info2.RyzdName = detail.ExecRYZDName;
                        info2.Xmlbid = detail.Xmlbid;
                        info2.XmlbName = detail.XmlbName;
                        info2.XmzdId = detail.XmzdId;
                        info2.XmzdName = detail.XmzdName;
                        info2.Unit = detail.Unit;
                        info2.Quantity = detail.Quantity;
                        info2.Value = detail.Value;
                        info2.IsDrugIncome = detail.IsDrugIncome;
                        info2.Bqid = detail.Bqid;
                        info2.Type = "E";
                        info2.ZxzdId = detail.ZxzdId;
                        info2.Note = detail.Note;
                        info2.CreateTime = DateTime.Now;
                        info2.Creator = detail.Creator;
                        info2.Editor = detail.Editor;
                        info2.EditTime = DateTime.Now;
                        BLLFactory<Yljxflgzl>.Instance.Insert(info2, sqlDbTransaction);
                    }
                    sqlDbTransaction.Commit();
                    flag = true;
                }
                catch
                {
                    sqlDbTransaction.Rollback();
                    throw;
                }
            }
            return flag;
        }
    }
}
