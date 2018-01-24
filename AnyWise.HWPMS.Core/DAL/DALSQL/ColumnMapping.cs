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
    /// 列映射关系表
    /// </summary>
    public class ColumnMapping : BaseDALSQL<ColumnMappingInfo>, AnyWise.HWPMS.IDAL.IColumnMapping
    {
        #region 对象实例及构造函数

        public static ColumnMapping Instance
        {
            get
            {
                return new ColumnMapping();
            }
        }
        public ColumnMapping()
            : base("TB_ColumnMapping", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override ColumnMappingInfo DataReaderToEntity(IDataReader dataReader)
        {
            ColumnMappingInfo info = new ColumnMappingInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.TabMapID = reader.GetString("TabMapID");
            info.TargetCol = reader.GetString("TargetCol");
            info.SourceCol = reader.GetString("SourceCol");
            info.ColType = reader.GetString("ColType");
            info.IsPK = reader.GetString("IsPK");
            info.ItemNote = reader.GetString("ItemNote");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ColumnMappingInfo obj)
        {
            ColumnMappingInfo info = obj as ColumnMappingInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("TabMapID", info.TabMapID);
            hash.Add("TargetCol", info.TargetCol);
            hash.Add("SourceCol", info.SourceCol);
            hash.Add("ColType", info.ColType);
            hash.Add("IsPK", info.IsPK);
            hash.Add("ItemNote", info.ItemNote);

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
            dict.Add("TabMapID", "主表内码");
            dict.Add("TargetCol", "目标列");
            dict.Add("SourceCol", "源列");
            dict.Add("ColType", "列类型");
            dict.Add("IsPK", "是否主键");
            dict.Add("ItemNote", "备注");
            #endregion

            return dict;
        }

    }
}