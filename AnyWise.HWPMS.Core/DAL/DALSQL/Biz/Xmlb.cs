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
    /// 项目类别表
    /// </summary>
    public class Xmlb : BaseDALSQL<XmlbInfo>, IXmlb
    {
        #region 对象实例及构造函数

        public static Xmlb Instance
        {
            get
            {
                return new Xmlb();
            }
        }
        public Xmlb()
            : base("TB_Xmlb", "ID")
        {
        }

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
        protected override XmlbInfo DataReaderToEntity(IDataReader dataReader)
		{
            XmlbInfo info = new XmlbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.PID = reader.GetString("PID");
            info.Code = reader.GetString("Code");
            info.Name = reader.GetString("Name");
            info.ZXZD_ID = reader.GetString("ZXZD_ID");
			info.LayerNumber = reader.GetInt32("LayerNumber");
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
        protected override Hashtable GetHashByEntity(XmlbInfo obj)
		{
            XmlbInfo info = obj as XmlbInfo;
			Hashtable hash = new Hashtable(); 
			
            hash.Add("ID", info.ID);
            hash.Add("PID", info.PID);
            hash.Add("Code", info.Code);
            hash.Add("Name", info.Name);
            hash.Add("ZXZD_ID", info.ZXZD_ID);
            hash.Add("LayerNumber", info.LayerNumber);
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
            dict.Add("ID", "内码");
            dict.Add("PID", "父级内码");
            dict.Add("Code", "编号");
            dict.Add("Name", "名称");
            dict.Add("ZXZD_ID", "职系");
            dict.Add("LayerNumber", "层数");
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