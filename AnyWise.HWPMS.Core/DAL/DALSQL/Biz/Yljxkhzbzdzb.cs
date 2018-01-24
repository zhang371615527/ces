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
    /// 医疗绩效二次考核指标字典子表
    /// </summary>
    public class Yljxkhzbzdzb : BaseDALSQL<YljxkhzbzdzbInfo>, IYljxkhzbzdzb
    {
        #region 对象实例及构造函数

        public static Yljxkhzbzdzb Instance
        {
            get
            {
                return new Yljxkhzbzdzb();
            }
        }
        public Yljxkhzbzdzb()
            : base("TB_Yljxkhzbzdzb", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override YljxkhzbzdzbInfo DataReaderToEntity(IDataReader dataReader)
        {
            YljxkhzbzdzbInfo info = new YljxkhzbzdzbInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.ZBZD_ID = reader.GetString("ZBZD_ID");
            info.XMBH = reader.GetString("XMBH");
            info.XMMC = reader.GetString("XMMC");
            info.ZBMC = reader.GetString("ZBMC");
            info.Desc = reader.GetString("Desc");
            info.WeightPoint = reader.GetDecimal("WeightPoint");
            info.OrderNo = reader.GetInt32("OrderNo");
            info.Creator = reader.GetString("Creator");
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
        protected override Hashtable GetHashByEntity(YljxkhzbzdzbInfo obj)
        {
            YljxkhzbzdzbInfo info = obj as YljxkhzbzdzbInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("ZBZD_ID", info.ZBZD_ID);
            hash.Add("XMBH", info.XMBH);
            hash.Add("XMMC", info.XMMC);
            hash.Add("ZBMC", info.ZBMC);
            hash.Add("Desc", info.Desc);
            hash.Add("WeightPoint", info.WeightPoint);
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
            dict.Add("ZBZD_ID", "指标字典内码");
            dict.Add("XMBH", "项目编号");
            dict.Add("XMMC", "项目名称");
            dict.Add("ZBMC", "指标名称");
            dict.Add("Desc", "描述");
            dict.Add("WeightPoint", "分数");
            dict.Add("OrderNo", "序号");
            dict.Add("Creator", "创建人");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            dict.Add("Note", "备注");
            #endregion

            return dict;
        }

    }
}