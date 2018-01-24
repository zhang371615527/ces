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
    /// Drgs诊疗分组表
    /// </summary>
    public class DrgsSort : BaseDALSQL<DrgsSortInfo>, IDrgsSort
    {
        #region 对象实例及构造函数

        public static DrgsSort Instance
        {
            get
            {
                return new DrgsSort();
            }
        }
        public DrgsSort()
            : base("TB_DrgsSort", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override DrgsSortInfo DataReaderToEntity(IDataReader dataReader)
        {
            DrgsSortInfo info = new DrgsSortInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Code = reader.GetString("Code");
            info.Name = reader.GetString("Name");
            info.CustomField1 = reader.GetString("CustomField1");
            info.CustomField2 = reader.GetString("CustomField2");
            info.CustomField3 = reader.GetString("CustomField3");
            info.CustomField4 = reader.GetString("CustomField4");
            info.WeightPoint = reader.GetDecimal("WeightPoint");
            info.Price = reader.GetDecimal("Price");
            info.Creator = reader.GetString("Creator");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Enabled = reader.GetString("Enabled");
            info.Note = reader.GetString("Note");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(DrgsSortInfo obj)
        {
            DrgsSortInfo info = obj as DrgsSortInfo;
            Hashtable hash = new Hashtable();
            
            hash.Add("ID", info.ID);
            hash.Add("Code", info.Code);
            hash.Add("Name", info.Name);
            hash.Add("CustomField1", info.CustomField1);
            hash.Add("CustomField2", info.CustomField2);
            hash.Add("CustomField3", info.CustomField3);
            hash.Add("CustomField4", info.CustomField4);
            hash.Add("WeightPoint", info.WeightPoint);
            hash.Add("Price", info.Price);
            hash.Add("Creator", info.Creator);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("EditTime", info.EditTime);
            hash.Add("Enabled", info.Enabled);
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
            dict.Add("ID", "标识码");
            dict.Add("Code", "编号");
            dict.Add("Name", "名称");
            dict.Add("CustomField1", "自定义项1");
            dict.Add("CustomField2", "自定义项2");
            dict.Add("CustomField3", "自定义项3");
            dict.Add("CustomField4", "自定义项4"); //（例如"","yyyy","yyyyMM","yyyyMMDD"）
            dict.Add("WeightPoint", "权重");
            dict.Add("Price", "绩效单价");
            dict.Add("Creator", "创建人");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            dict.Add("Enabled", "是否可用");
            dict.Add("Note", "备注");
            #endregion

            return dict;
        }

    }
}