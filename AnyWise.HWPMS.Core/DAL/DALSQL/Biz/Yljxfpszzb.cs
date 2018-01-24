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
    /// 医疗绩效分配设置子表
    /// </summary>
	public class Yljxfpszzb : BaseDALSQL<YljxfpszzbInfo>, IYljxfpszzb
	{
		#region 对象实例及构造函数

		public static Yljxfpszzb Instance
		{
			get
			{
				return new Yljxfpszzb();
			}
		}
		public Yljxfpszzb() : base("BIZ_YLJXFPSZZB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YljxfpszzbInfo DataReaderToEntity(IDataReader dataReader)
		{
			YljxfpszzbInfo info = new YljxfpszzbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Jxfpsz_ID = reader.GetString("Jxfpsz_ID");
            info.Ryzd_ID = reader.GetString("Ryzd_ID");
            info.OrderNo = reader.GetInt32("OrderNo");
            info.Creator = reader.GetString("Creator");
            info.OrderNo = reader.GetInt32("OrderNo");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Note = reader.GetString("Note");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(YljxfpszzbInfo obj)
		{
		    YljxfpszzbInfo info = obj as YljxfpszzbInfo;
			Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("Jxfpsz_ID", info.Jxfpsz_ID);
            hash.Add("Ryzd_ID", info.Ryzd_ID);
            hash.Add("OrderNo", info.OrderNo);
            hash.Add("Creator", info.Creator);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("EditTime", info.EditTime);
            hash.Add("Note", info.Note);
 				
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
            dict.Add("Jxfpsz_ID", "绩效分配设置内码");
            dict.Add("Ryzd_ID", "人员内码");
            dict.Add("OrderNo", "排序号");
            dict.Add("Creator", "创建人");
            dict.Add("OrderNo", "排序");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            dict.Add("Note", "备注");
            #endregion

            return dict;
        }

        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(List<YljxfpszzbInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (YljxfpszzbInfo detail in list)
                    {
                        detail.CreateTime = DateTime.Now;
                        //detail.Creator = CurrentUser.ID.ToString();
                        //detail.Editor = CurrentUser.ID.ToString();
                        //detail.EditTime = DateTime.Now;
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