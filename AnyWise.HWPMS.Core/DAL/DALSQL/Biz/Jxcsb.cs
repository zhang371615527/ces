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
    /// 绩效参数表
    /// </summary>
	public class Jxcsb : BaseDALSQL<JxcsbInfo>, IJxcsb
	{
		#region 对象实例及构造函数

		public static Jxcsb Instance
		{
			get
			{
				return new Jxcsb();
			}
		}
		public Jxcsb() : base("TB_JXCSB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override JxcsbInfo DataReaderToEntity(IDataReader dataReader)
		{
			JxcsbInfo info = new JxcsbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.Name = reader.GetString("Name");
			info.Define = reader.GetString("Define");
			info.Formula = reader.GetString("Formula");
			info.Source = reader.GetString("Source");
			info.Value = reader.GetDecimal("Value");
			info.OrderNo = reader.GetInt32("OrderNo");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Note = reader.GetString("Note");
			info.Enabled = reader.GetString("Enabled");
            info.Type = reader.GetString("Type");
            info.ZXZD_ID = reader.GetString("ZXZD_ID");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(JxcsbInfo obj)
		{
		    JxcsbInfo info = obj as JxcsbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("Name", info.Name);
 			hash.Add("Define", info.Define);
 			hash.Add("Formula", info.Formula);
 			hash.Add("Source", info.Source);
 			hash.Add("Value", info.Value);
 			hash.Add("OrderNo", info.OrderNo);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Note", info.Note);
 			hash.Add("Enabled", info.Enabled);
            hash.Add("Type", info.Type);
            hash.Add("ZXZD_ID", info.ZXZD_ID);
	
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
             dict.Add("Code", "参数编号");
             dict.Add("Name", "参数名称");
             dict.Add("Define", "参数定义");
             dict.Add("Formula", "参数公式");
             dict.Add("Source", "参数来源");
             dict.Add("Value", "默认值");
             dict.Add("OrderNo", "排序");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Note", "备注");
             dict.Add("Enabled", "是否启用");
             dict.Add("Type", "参数类型");
             dict.Add("ZXZD_ID", "职系");
             #endregion

            return dict;
        }
        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(List<JxcsbInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (JxcsbInfo detail in list)
                    {
                        detail.CreateTime = DateTime.Now;
                        //detail.Creator = CurrentUser.ID.ToString();
                        //detail.Editor = CurrentUser.ID.ToString();
                        //detail.EditTime = DateTime.Now;

                        detail.Enabled = detail.Enabled == "是" ? "1" : "0";

                        if (detail.Type == "常量")
                        { detail.Type = "C"; }
                        else if (detail.Type == "变量")
                        { detail.Type = "V"; }
                        else { detail.Type = "E"; }

                        if (detail.Source == "人工录入")
                        { detail.Source = "1"; }
                        else if (detail.Source == "系统接口")
                        { detail.Source = "2"; }
                        else if (detail.Source == "中间值")
                        { detail.Source = "3"; }
                        else { detail.Source = "4"; }
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