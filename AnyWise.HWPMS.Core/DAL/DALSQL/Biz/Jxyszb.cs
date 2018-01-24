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
    /// 绩效奖金预算子表
    /// </summary>
    public class Jxyszb : BaseDALSQL<JxyszbInfo>, IJxyszb
    {
        #region 对象实例及构造函数
        public static Jxyszb Instance
		{
			get
			{
                return new Jxyszb();
			}
		}
        public Jxyszb()
            : base("BIZ_Jxyszb", "ID")
		{
		}
		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
        protected override JxyszbInfo DataReaderToEntity(IDataReader dataReader)
		{
            JxyszbInfo info = new JxyszbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
            info.PID = reader.GetString("PID");
			info.Month = reader.GetString("Month");
            info.AccountWay = reader.GetString("AccountWay");
            info.Formula = reader.GetString("Formula");
            info.Ratio = reader.GetString("Ratio");
			info.Value = reader.GetDecimal("Value");
            info.LjMoney = reader.GetDecimal("LjMoney");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
            info.WorkFlowID = reader.GetString("WorkFlowID");
            info.SubmitUser = reader.GetString("SubmitUser");
            info.BillState = reader.GetString("BillState");
            info.Approver = reader.GetString("Approver");
            info.AppTime = reader.GetDateTime("AppTime");
            info.SubTime = reader.GetDateTime("SubTime");
			info.Note = reader.GetString("Note");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(JxyszbInfo obj)
		{
            JxyszbInfo info = obj as JxyszbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
            hash.Add("PID", info.PID);
 			hash.Add("Month", info.Month);
 			hash.Add("AccountWay", info.AccountWay);
 			hash.Add("Formula", info.Formula);
            hash.Add("Ratio", info.Ratio);
 			hash.Add("Value", info.Value);
            hash.Add("LjMoney", info.LjMoney);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
            hash.Add("WorkFlowID", info.WorkFlowID);
            hash.Add("SubmitUser", info.SubmitUser);
            hash.Add("BillState", info.BillState);
            hash.Add("Approver", info.Approver);
            hash.Add("AppTime", info.AppTime);
            hash.Add("SubTime", info.SubTime);
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
            dict.Add("ID", "内码");
            dict.Add("PID", "主表ID");
             dict.Add("Month", "月度");
             dict.Add("AccountWay", "核算方式");
             dict.Add("Formula", "核算公式");
             dict.Add("Ratio", "核算比率");
             dict.Add("Value", "金额");
             dict.Add("LjMoney", "累计金额");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("WorkFlowID", "流程实例内码");
             dict.Add("SubmitUser", "提交审批人");
             dict.Add("BillState", "审批状态");
             dict.Add("Approver", "审批人");
             dict.Add("AppTime", "审批时间");
             dict.Add("SubTime", "提交审批人");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }
    }
}
