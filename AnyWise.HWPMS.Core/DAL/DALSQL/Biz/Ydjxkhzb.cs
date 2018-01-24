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
    /// 月度绩效考核子表
    /// </summary>
	public class Ydjxkhzb : BaseDALSQL<YdjxkhzbInfo>, IYdjxkhzb
	{
		#region 对象实例及构造函数

		public static Ydjxkhzb Instance
		{
			get
			{
				return new Ydjxkhzb();
			}
		}
		public Ydjxkhzb() : base("BIZ_YDJXKHZB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YdjxkhzbInfo DataReaderToEntity(IDataReader dataReader)
		{
			YdjxkhzbInfo info = new YdjxkhzbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.YdjxkhId = reader.GetString("YDJXKH_ID");
            info.Code = reader.GetString("Code");
			info.ParentCode = reader.GetString("ParentCode");
            info.Name = reader.GetString("Name");
            info.Content = reader.GetString("Content");
            info.NodeType = reader.GetString("NodeType");
            info.WeightPoint = reader.GetDecimalNullable("WeightPoint");
			info.Time = reader.GetString("Time");
			info.Method = reader.GetString("Method");
            info.LowerLimit = reader.GetDecimalNullable("LowerLimit");
            info.StandValue = reader.GetDecimalNullable("StandValue");
            info.TargetValue = reader.GetDecimalNullable("TargetValue");
            info.HighLimit = reader.GetDecimalNullable("HighLimit");
            info.Value = reader.GetDecimalNullable("Value");
            info.Unit = reader.GetString("Unit");
            info.Point = reader.GetDecimalNullable("Point");
            info.Ratio = reader.GetDecimalNullable("Ratio");
			info.Note = reader.GetString("Note");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(YdjxkhzbInfo obj)
		{
		    YdjxkhzbInfo info = obj as YdjxkhzbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("YDJXKH_ID", info.YdjxkhId);
            hash.Add("Code", info.Code);
 			hash.Add("ParentCode", info.ParentCode);
            hash.Add("Name", info.Name);
            hash.Add("Content", info.Content);
            hash.Add("NodeType", info.NodeType);
 			hash.Add("WeightPoint", info.WeightPoint);
 			hash.Add("Time", info.Time);
 			hash.Add("Method", info.Method);
 			hash.Add("LowerLimit", info.LowerLimit);
 			hash.Add("StandValue", info.StandValue);
 			hash.Add("TargetValue", info.TargetValue);
 			hash.Add("HighLimit", info.HighLimit);
 			hash.Add("Value", info.Value);
            hash.Add("Unit",info.Unit);
 			hash.Add("Point", info.Point);
 			hash.Add("Ratio", info.Ratio);
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
             dict.Add("YdjxkhId", "主表内码");
             dict.Add("ZbzdId", "指标编码");
             dict.Add("ParentCode", "父级编码");
             dict.Add("Name", "指标名称");
             dict.Add("Content", "基本内容");
             dict.Add("NodeType", "节点类型");
             dict.Add("WeightPoint", "权重分值");
             dict.Add("Time", "考核时限");
             dict.Add("Method", "考核方法");
             dict.Add("LowerLimit", "警戒值下线");
             dict.Add("StandValue", "标准值");
             dict.Add("TargetValue", "目标值");
             dict.Add("HighLimit", "警戒值上线");
             dict.Add("Value", "实际值");
             dict.Add("Unit", "单位");
             dict.Add("Point", "考核得分");
             dict.Add("Ratio", "完成率");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }

        /// <summary>
        /// 事务批量保存得分、完成率
        /// </summary>
        /// <param name="Mid"></param>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool SaveScore(string Mid, string Ids)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                if (!string.IsNullOrEmpty(Mid))
                {
                    if (!string.IsNullOrEmpty(Ids))
                    {
                        string strSQL1 = "";
                        string strSQL2 = "";
                        foreach (string str in Ids.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                string[] sArray = str.Split(',');
                                strSQL1 = string.Format("update BIZ_YDJXKHZB set Point={0} where ID='{1}'", Convert.ToDecimal(sArray[1]), sArray[0]);
                                this.SqlExecute(strSQL1, sqlDbTransaction);
                                strSQL1 = string.Format("update BIZ_YDJXKHZB set Ratio=Point/WeightPoint where ID='{0}'",sArray[0]);
                                this.SqlExecute(strSQL1, sqlDbTransaction);
                            }
                        }
                        strSQL2 = string.Format("update BIZ_YDJXKH set TotalPoint=(select SUM(ISNULL(Point,0)) from BIZ_YDJXKHZB where YDJXKH_ID='{0}' and NodeType='Leaf') where ID='{1}'", Mid, Mid);
                        this.SqlExecute(strSQL2, sqlDbTransaction);
                        strSQL2 = string.Format("update BIZ_YDJXKH set AverageRatio=(select AVG(ISNULL(Ratio,0)) from BIZ_YDJXKHZB where YDJXKH_ID='{0}' and NodeType='Leaf') where ID='{1}'", Mid, Mid);
                        this.SqlExecute(strSQL2, sqlDbTransaction);
                    }
                }
                try
                {
                    sqlDbTransaction.Commit();
                    flag = true;
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex.Message,ex);
                    sqlDbTransaction.Rollback();
                    throw;
                }
                finally
                {
                    sqlDbTransaction.Dispose();
                }
            }
            return flag;
        }

    }
}