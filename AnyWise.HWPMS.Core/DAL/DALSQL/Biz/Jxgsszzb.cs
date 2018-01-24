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
    /// 绩效公式设置子表
    /// </summary>
    public class Jxgsszzb : BaseDALSQL<JxgsszzbInfo>, IJxgsszzb
    {
        #region 对象实例及构造函数

        public static Jxgsszzb Instance
        {
            get
            {
                return new Jxgsszzb();
            }
        }
        public Jxgsszzb()
            : base("TB_JXGSSZZB", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override JxgsszzbInfo DataReaderToEntity(IDataReader dataReader)
        {
            JxgsszzbInfo info = new JxgsszzbInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Jxgs_ID = reader.GetString("Jxgs_ID");
            info.LeftOperator = reader.GetString("LeftOperator");
            info.ParamID = reader.GetString("ParamID");
            info.RightOperator = reader.GetString("RightOperator");
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
        protected override Hashtable GetHashByEntity(JxgsszzbInfo obj)
        {
            JxgsszzbInfo info = obj as JxgsszzbInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("Jxgs_ID", info.Jxgs_ID);
            hash.Add("LeftOperator", info.LeftOperator);
            hash.Add("ParamID", info.ParamID);
            hash.Add("RightOperator", info.RightOperator);
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
            dict.Add("Jxgs_ID", "绩效公式设置内码");
            dict.Add("LeftOperator", "左表达式");
            dict.Add("ParamID", "参数内码");
            dict.Add("RightOperator", "右表达式");
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

    }
}