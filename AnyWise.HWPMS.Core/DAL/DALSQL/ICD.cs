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
    /// 疾病与操作编码表
    /// </summary>
    public class ICD : BaseDALSQL<ICDInfo>, IICD
    {
        #region 对象实例及构造函数

        public static ICD Instance
        {
            get
            {
                return new ICD();
            }
        }
        public ICD()
            : base("TB_ICD", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override ICDInfo DataReaderToEntity(IDataReader dataReader)
        {
            ICDInfo info = new ICDInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Code = reader.GetString("Code");
            info.MinorCode = reader.GetString("MinorCode");
            info.Name = reader.GetString("Name");
            info.PYZJM = reader.GetString("PYZJM");
            info.Type = reader.GetString("Type");
            info.Version = reader.GetString("Version");
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
        protected override Hashtable GetHashByEntity(ICDInfo obj)
        {
            ICDInfo info = obj as ICDInfo;
            Hashtable hash = new Hashtable();
            
            hash.Add("ID", info.ID);
            hash.Add("Code", info.Code);
            hash.Add("MinorCode", info.MinorCode);
            hash.Add("Name", info.Name);
            hash.Add("PYZJM", info.PYZJM);
            hash.Add("Type", info.Type);
            hash.Add("Version", info.Version);
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

            dict.Add("ID", "标识码");
            dict.Add("Code", "编号");
            dict.Add("MinorCode", "副编号");
            dict.Add("Name", "名称");
            dict.Add("PYZJM", "拼音助记码");
            dict.Add("Type", "类型");
            dict.Add("Version", "版本");
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