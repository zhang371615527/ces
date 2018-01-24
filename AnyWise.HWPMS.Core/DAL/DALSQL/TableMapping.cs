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
    /// 编码规则配置表
    /// </summary>
    public class TableMapping : BaseDALSQL<TableMappingInfo>, AnyWise.HWPMS.IDAL.ITableMapping
    {
        #region 对象实例及构造函数

        public static TableMapping Instance
        {
            get
            {
                return new TableMapping();
            }
        }
        public TableMapping()
            : base("TB_TableMapping", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override TableMappingInfo DataReaderToEntity(IDataReader dataReader)
        {
            TableMappingInfo info = new TableMappingInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.TargetTable = reader.GetString("TargetTable");
            info.SourceTable = reader.GetString("SourceTable");
            info.ColYear = reader.GetString("ColYear");
            info.ColMonth = reader.GetString("ColMonth");
            info.ColDataConfig = reader.GetString("ColDataConfig");
            info.Note = reader.GetString("Note");
            info.Creator = reader.GetString("Creator");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.EditTime = reader.GetDateTime("EditTime");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(TableMappingInfo obj)
        {
            TableMappingInfo info = obj as TableMappingInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("TargetTable", info.TargetTable);
            hash.Add("SourceTable", info.SourceTable);
            hash.Add("ColYear", info.ColYear);
            hash.Add("ColMonth", info.ColMonth);
            hash.Add("ColDataConfig", info.ColDataConfig);
            hash.Add("Note", info.Note);
            hash.Add("Creator", info.Creator);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("EditTime", info.EditTime);

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
            dict.Add("ID", "标识码");
            dict.Add("TargetTable", "目标表");
            dict.Add("SourceTable", "源表");
            dict.Add("ColYear", "年列");
            dict.Add("ColMonth", "月列");
            dict.Add("ColDataConfig", "数据配置");
            dict.Add("Note", "备注");
            dict.Add("Creator", "创建人");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            #endregion

            return dict;
        }

    }
}