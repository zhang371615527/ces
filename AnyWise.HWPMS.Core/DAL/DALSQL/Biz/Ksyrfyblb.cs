using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;

namespace AnyWise.HWPMS.DALSQL
{
    /// <summary>
    /// 科室用人费用比率
    /// </summary>
	public class Ksyrfyblb : BaseDALSQL<KsyrfyblbInfo>, IKsyrfyblb
	{
		#region 对象实例及构造函数

		public static Ksyrfyblb Instance
		{
			get
			{
				return new Ksyrfyblb();
			}
		}
		public Ksyrfyblb() : base("BIZ_KSYRFYBLB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override KsyrfyblbInfo DataReaderToEntity(IDataReader dataReader)
		{
			KsyrfyblbInfo info = new KsyrfyblbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.KszdId = reader.GetString("KSZD_ID");
			info.KSZD_Name = reader.GetString("KSZD_Name");
			info.Ratio = reader.GetDecimal("Ratio");
			info.Desc = reader.GetString("Desc");
			info.OrderNo = reader.GetInt32("OrderNo");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Note = reader.GetString("Note");
			info.Enabled = reader.GetString("Enabled");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(KsyrfyblbInfo obj)
		{
		    KsyrfyblbInfo info = obj as KsyrfyblbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("KSZD_ID", info.KszdId);
 			hash.Add("KSZD_Name", info.KSZD_Name);
 			hash.Add("Ratio", info.Ratio);
 			hash.Add("Desc", info.Desc);
 			hash.Add("OrderNo", info.OrderNo);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Note", info.Note);
 			hash.Add("Enabled", info.Enabled);
 				
			return hash;
		}

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("ID", "内码");
             dict.Add("KszdId", "科室编号");
             dict.Add("KSZD_Name", "科室名称");
             dict.Add("Ratio", "费用比率");
             dict.Add("Desc", "说明");
             dict.Add("OrderNo", "排序");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Note", "备注");
             dict.Add("Enabled", "是否启用");
             #endregion

            return dict;
        }
        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(List<KsyrfyblbInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (KsyrfyblbInfo detail in list)
                    {
                        detail.ID = Guid.NewGuid().ToString();
                        //detail.Seq = seq++;//增加1
                        /*
                        detail.CreateTime = DateTime.Now;
                        detail.Creator = CurrentUser.ID.ToString();
                        detail.Editor = CurrentUser.ID.ToString();
                        detail.EditTime = DateTime.Now;
                        */
                        this.Insert(detail, sqlDbTransaction);
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