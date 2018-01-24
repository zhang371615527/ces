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
    public class CodeSet : BaseDALSQL<CodeSetInfo>, ICodeSet
    {
        #region 对象实例及构造函数

        public static CodeSet Instance
        {
            get
            {
                return new CodeSet();
            }
        }
        public CodeSet()
            : base("TB_CodeSet", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override CodeSetInfo DataReaderToEntity(IDataReader dataReader)
        {
            CodeSetInfo info = new CodeSetInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.PID = reader.GetString("PID");
            info.Name = reader.GetString("Name");
            info.TableName = reader.GetString("TableName");
            info.FieldName = reader.GetString("FieldName");
            info.HasPrefix = reader.GetBoolean("HasPrefix");
            info.PrefixRule = reader.GetString("PrefixRule");
            info.StrPrefix = reader.GetString("StrPrefix");
            info.LayerNumber = reader.GetInt32("LayerNumber");
            info.LayerLength = reader.GetInt32("layerLength");
            info.LayerStep = reader.GetInt32("LayerStep");
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
        protected override Hashtable GetHashByEntity(CodeSetInfo obj)
        {
            CodeSetInfo info = obj as CodeSetInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("PID", info.PID);
            hash.Add("Name", info.Name);
            hash.Add("TableName", info.TableName);
            hash.Add("FieldName", info.FieldName);
            hash.Add("HasPrefix", info.HasPrefix);
            hash.Add("PrefixRule", info.PrefixRule);
            hash.Add("StrPrefix", info.StrPrefix);
            hash.Add("LayerNumber", info.LayerNumber);
            hash.Add("layerLength", info.LayerLength);
            hash.Add("LayerStep", info.LayerStep);
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
            dict.Add("PID", "父级码");
            dict.Add("Name", "名称");
            dict.Add("TableName", "表名");
            dict.Add("FieldName", "字段名");
            dict.Add("HasPrefix", "是否前缀");
            dict.Add("PrefixRule", "前缀规则"); //（例如"","yyyy","yyyyMM","yyyyMMDD"）
            dict.Add("StrPrefix", "前缀标识");
            dict.Add("LayerNumber", "层数");
            dict.Add("LayerLength", "层长度");
            dict.Add("LayerStep", "每层步数");
            dict.Add("Creator", "创建人");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            #endregion

            return dict;
        }
    }
}