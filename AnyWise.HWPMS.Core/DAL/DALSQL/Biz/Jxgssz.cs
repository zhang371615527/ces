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
    /// 绩效公式设置
    /// </summary>
	public class Jxgssz : BaseDALSQL<JxgsszInfo>, IJxgssz
	{
		#region 对象实例及构造函数

		public static Jxgssz Instance
		{
			get
			{
				return new Jxgssz();
			}
		}
		public Jxgssz() : base("TB_JXGSSZ","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override JxgsszInfo DataReaderToEntity(IDataReader dataReader)
		{
			JxgsszInfo info = new JxgsszInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.Name = reader.GetString("Name");
			info.Formula = reader.GetString("Formula");
			info.ZXZD_ID = reader.GetString("ZXZD_ID");
			info.Desc = reader.GetString("Desc");
			info.Creator = reader.GetString("Creator");
			info.OrderNo = reader.GetInt32("OrderNo");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Note = reader.GetString("Note");
			info.Enabled = reader.GetString("Enabled");
            info.KSID = reader.GetString("KSID");

			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(JxgsszInfo obj)
		{
		    JxgsszInfo info = obj as JxgsszInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("Name", info.Name);
 			hash.Add("Formula", info.Formula);
 			hash.Add("ZXZD_ID", info.ZXZD_ID);
 			hash.Add("Desc", info.Desc);
 			hash.Add("Creator", info.Creator);
 			hash.Add("OrderNo", info.OrderNo);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Note", info.Note);
 			hash.Add("Enabled", info.Enabled);
            hash.Add("KSID", info.KSID);

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
             dict.Add("Code", "公式编号");
             dict.Add("Name", "公式名称");
             dict.Add("Formula", "公式编码");
             dict.Add("ZxzdId", "项目类别");
             dict.Add("Desc", "说明");
             dict.Add("Creator", "创建人");
             dict.Add("OrderNo", "排序");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Note", "备注");
             dict.Add("Enabled", "是否启用");
             dict.Add("KSID", "科室内码");
             #endregion

            return dict;
        }
        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(List<JxgsszInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (JxgsszInfo detail in list)
                    {
                        detail.CreateTime = DateTime.Now;
                        //detail.Creator = CurrentUser.ID.ToString();
                        //detail.Editor = CurrentUser.ID.ToString();
                        //detail.EditTime = DateTime.Now;

                        detail.Enabled = detail.Enabled == "是" ? "1" : "0";
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