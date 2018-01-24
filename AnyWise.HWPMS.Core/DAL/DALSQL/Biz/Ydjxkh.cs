using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using AnyWise.Pager.Entity;
using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;

namespace AnyWise.HWPMS.DALSQL
{
    /// <summary>
    /// 月度绩效考核表
    /// </summary>
	public class Ydjxkh : BaseDALSQL<YdjxkhInfo>, IYdjxkh
	{
		#region 对象实例及构造函数

		public static Ydjxkh Instance
		{
			get
			{
				return new Ydjxkh();
			}
		}
		public Ydjxkh() : base("BIZ_YDJXKH","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YdjxkhInfo DataReaderToEntity(IDataReader dataReader)
		{
			YdjxkhInfo info = new YdjxkhInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.HosID = reader.GetString("HosID");
			info.Year = reader.GetString("Year");
			info.Month = reader.GetString("Month");
			info.Type = reader.GetString("Type");
			info.Desc = reader.GetString("Desc");
            info.BeginDate = reader.GetDateTimeNullable("BeginDate");
            info.EndDate = reader.GetDateTimeNullable("EndDate");
			info.ResKS_ID = reader.GetString("ResKS_ID");
			info.CheckKS_ID = reader.GetString("CheckKS_ID");
            info.CheckTime = reader.GetDateTimeNullable("CheckTime");
            info.Checker = reader.GetString("Checker");
            info.TotalPoint = reader.GetDecimalNullable("TotalPoint");
            info.AverageRatio = reader.GetDecimalNullable("AverageRatio");
			info.State = reader.GetString("State");
			info.Creator = reader.GetString("Creator");
            info.CreateTime = reader.GetDateTimeNullable("CreateTime");
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
        protected override Hashtable GetHashByEntity(YdjxkhInfo obj)
		{
		    YdjxkhInfo info = obj as YdjxkhInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("HosID", info.HosID);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("Type", info.Type);
 			hash.Add("Desc", info.Desc);
 			hash.Add("BeginDate", info.BeginDate);
 			hash.Add("EndDate", info.EndDate);
 			hash.Add("ResKS_ID", info.ResKS_ID);
 			hash.Add("CheckKS_ID", info.CheckKS_ID);
 			hash.Add("CheckTime", info.CheckTime);
 			hash.Add("Checker", info.Checker);
            hash.Add("TotalPoint", info.TotalPoint);
            hash.Add("AverageRatio", info.AverageRatio);
 			hash.Add("State", info.State);
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
             dict.Add("HosID", "所属医院");
             dict.Add("Year", "年度");
             dict.Add("Month", "月度");
             dict.Add("Type", "类型");
             dict.Add("Desc", "标题");
             dict.Add("BeginDate", "开始日期");
             dict.Add("EndDate", "结束日期");
             dict.Add("ResKS_ID", "责任部门");
             dict.Add("CheckKS_ID", "考核部门");
             dict.Add("CheckTime", "考核时间");
             dict.Add("Checker", "考核人");
             dict.Add("TotalPoint", "总考核得分");
             dict.Add("AverageRatio", "平均完成率");
             dict.Add("State", "状态");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }

        public string GetDeptResNotInOu()
        {
            string strSQL = string.Format(" select distinct a.ResKS_ID as DeptID,b.Name as DeptName from BIZ_KHFLB a inner join T_ACL_OU b on a.ResKS_ID = b.ID and  (b.Deleted = 0) AND (b.Enabled = 0)and  a.ResKS_ID not in (select c.ID from T_ACL_OU c where (c.Deleted = 0) AND (c.Enabled = 0))");
            DataTable dt = this.SqlTable(strSQL);
            string strWhere = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DeptName"] != null) strWhere += "'" + row["DeptName"].ToString() + "'" + ",";
                }
                if (strWhere.Contains(",")) strWhere = strWhere.Substring(0, strWhere.LastIndexOf(','));
            }
            return strWhere;
        }

        public string GetDeptCheckNotInOu()
        {
            string strSQL = string.Format(" select distinct a.CheckKS_ID as DeptID,b.Name as DeptName from BIZ_KHFLB a inner join T_ACL_OU b on a.CheckKS_ID = b.ID and  (b.Deleted = 0) AND (b.Enabled = 0)and  a.CheckKS_ID not in (select c.ID from T_ACL_OU c where (c.Deleted = 0) AND (c.Enabled = 0))");
            DataTable dt = this.SqlTable(strSQL);
            string strWhere = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DeptName"] != null) strWhere += "'" + row["DeptName"].ToString() + "'" + ",";
                }
                if (strWhere.Contains(",")) strWhere = strWhere.Substring(0, strWhere.LastIndexOf(','));
            }
            return strWhere;
        }

        /// <summary>
        /// 当前年月的部门分发，插入主表、插入子表，事务处理
        /// </summary>
        /// <param name="strYear">年度</param>
        /// <param name="strMonth">月度</param>
        /// <returns>True/False</returns>
        public bool InsertMainAndSub(string strYear, string strMonth, string strCreator)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select distinct a.ResKS_ID,b.Name as ResKS_Name,a.CheckKS_ID,c.Name as CheckKS_Name,Sum(a.Weight) as WeightPoint from BIZ_KHFLB a ");
                strSQL.Append("inner join T_ACL_OU b on a.ResKS_ID = b.ID and  (b.Deleted = 0) AND (b.Enabled = 0) ");
                strSQL.Append("inner join T_ACL_OU c on a.CheckKS_ID = c.ID and  (c.Deleted = 0) AND (c.Enabled = 0) ");
                strSQL.Append("Group by a.ResKS_ID,b.Name,a.CheckKS_ID,c.Name");
                DataTable dtDepts = this.SqlTable(strSQL.ToString());
                if (dtDepts != null && dtDepts.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDepts.Rows)
                    {
                        if(row["ResKS_ID"]!=null && row["CheckKS_ID"]!=null)
                        {
                            string strGuid = Guid.NewGuid().ToString();
                            string strTime = DateTime.Now.ToString();
                            StringBuilder strSQL1 = new StringBuilder();
                            strSQL1.Append("INSERT INTO BIZ_YDJXKH (ID,[Year] ,[Month] ,[Desc] ,ResKS_ID ,CheckKS_ID ,TotalPoint ,AverageRatio ,WeightPoint,State ,Creator ,CreateTime) VALUES ('" + strGuid + "','" + strYear + "','" + strMonth + "','" + strYear + "-" + strMonth + "月度考评" + "【" + row["ResKS_Name"].ToString() + "～" + row["CheckKS_Name"].ToString() + "】" + "','" + row["ResKS_ID"].ToString() + "','" + row["CheckKS_ID"].ToString() + "',NULL,NULL," + Convert.ToDecimal(row["WeightPoint"]) + ",'0','" + strCreator + "','" + strTime + "')");
                            this.SqlExecute(strSQL1.ToString(), sqlDbTransaction);
                            StringBuilder strSQL2 = new StringBuilder();
                            strSQL2.Append("INSERT INTO BIZ_YDJXKHZB (ID,YDJXKH_ID,Code,ParentCode,Name,[Content],NodeType,WeightPoint,Time,Method,LowerLimit,StandValue,TargetValue,HighLimit,Value,Unit,Point,Ratio,Note) SELECT newid(),'" + strGuid + "',Code,ParentCode,Name,[Content],NodeType,Weight,Time,Method,LowerLimit,StandValue,TargetValue,HighLimit,Value,Unit,Point,NULL,Note From BIZ_KHFLB where ResKS_ID='" + row["ResKS_ID"].ToString() + "' and CheckKS_ID='" + row["CheckKS_ID"].ToString() + "'");
                            this.SqlExecute(strSQL2.ToString(), sqlDbTransaction);
                        }
                    }
                }

                try
                {
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

        /// <summary>
        /// 考核状态更新
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="State">状态值</param>
        /// <param name="strEditor">操作人</param>
        /// <returns>Ture/False</returns>
        public bool UpdateStateByID(string ID, string State, string strEditor)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("Update " + base.tableName + " set State='" + State + "', Editor='" + strEditor + "', EditTime='"+DateTime.Now.ToString()+"' where ID='"+ID+"'");
            return (this.SqlExecute(strSQL.ToString())) > 0;
        }
    }
}