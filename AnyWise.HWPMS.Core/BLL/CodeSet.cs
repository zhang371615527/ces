using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.Commons;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 编码规则配置表
    /// </summary>
	public class CodeSet : BaseBLL<CodeSetInfo>
    {

        private ICodeSet icodeset_0;

        public CodeSet()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.icodeset_0 = base.baseDal as ICodeSet;
        }

        public DataTable GetTableItems()
        {
            List<CListItem> data = new List<CListItem>();
            DataTable dt = base.SqlTable("Select distinct TableName,TableDesc From CodeRuleTableColumn ");
            
            return dt;
        }
        public DataTable GetColumnItems(string TableName)
        {
            List<CListItem> data = new List<CListItem>();
            DataTable dt = new DataTable();
            if (TableName != null && TableName != "")
                dt = base.SqlTable("Select distinct ColumnName,ColumnDesc From CodeRuleTableColumn where TableName = '" + TableName + "' ");
            else
                dt = base.SqlTable("Select distinct ColumnName,ColumnDesc From CodeRuleTableColumn ");

            return dt;
        }
        public string GenerateTreeCode(string strParentCode, string strTableName, string strFieldName, int Layer, string ParentColumn)
        {
            string strCode = "";
            string strPrefix = "";
            try
            {
                if (icodeset_0.IsExistRecord("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "' and LayerNumber = " + Layer + ""))
                {
                    DataTable dt = new DataTable();
                    List<CodeSetInfo> list = icodeset_0.Find("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "' and LayerNumber = " + Layer + "");
                    foreach (CodeSetInfo info in list)
                    {
                        if (info.HasPrefix)
                            strPrefix = info.StrPrefix;
                        if (info.PrefixRule.Trim() == "yyyy")
                            strCode += DateTime.Now.ToString("yyyy");
                        else if (info.PrefixRule.Trim() == "yyyyMM")
                            strCode += DateTime.Now.ToString("yyyyMM");
                        else if (info.PrefixRule.Trim() == "yyyyMMdd")
                            strCode += DateTime.Now.ToString("yyyyMMdd");
                        else if (info.PrefixRule.Trim() == "SN")
                        {
                            string strWhere = "";
                            string strMaxSN = "";
                            if (ParentColumn != null && ParentColumn != "")
                                strWhere = ParentColumn + " ='" + strParentCode + "'";
                            else
                                strWhere = strFieldName + " like '" + strParentCode + strPrefix + strCode + "%" + "' and len(" + strFieldName + ") = " + (strParentCode.Length + info.LayerLength) + "";
                            dt = icodeset_0.SqlTable("Select Max(" + strFieldName + ") as MaxCode From " + strTableName + " where " + strWhere);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string strMaxCode = dt.Rows[0]["MaxCode"].ToString();
                                if (strMaxCode == "")
                                    strMaxCode = "0";
                                if ((strParentCode + strPrefix + strCode) != "")
                                {
                                    //strMaxSN = strMaxCode.Replace(strPrefix + strCode, "");
                                    if (strMaxCode.IndexOf(strParentCode + strPrefix + strCode) > -1)
                                    {
                                        strMaxSN = strMaxCode.Remove(strMaxCode.IndexOf(strParentCode + strPrefix + strCode), (strParentCode + strPrefix + strCode).Length).Insert(strMaxCode.IndexOf(strParentCode + strPrefix + strCode), "");
                                    }
                                    else
                                        strMaxSN = strMaxCode;
                                }
                                else
                                    strMaxSN = strMaxCode;

                                string newValue = Replace(new Regex(@"([^\0-9\s].*?)"), strMaxSN);

                                int intSN = Convert.ToInt32(newValue == "" ? "0" : newValue) + info.LayerStep;
                                strCode += intSN.ToString().PadLeft(info.LayerLength, '0');
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                return "";
            }
            return strParentCode + strPrefix + strCode;
        }

        public string GenerateTreeChildCode(string strParentCode, string strTableName, string strChildName, string strFieldName, int Layer, string ParentColumn)
        {
            string strCode = "";
            string strPrefix = "";
            try
            {
                if (base.IsExistRecord("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "' and LayerNumber = " + Layer + ""))
                {
                    DataTable dt = new DataTable();
                    List<CodeSetInfo> list = base.Find("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "' and LayerNumber = " + Layer + "");
                    foreach (CodeSetInfo info in list)
                    {
                        if (info.HasPrefix)
                            strPrefix = info.StrPrefix;
                        if (info.PrefixRule.Trim() == "yyyy")
                            strCode += DateTime.Now.ToString("yyyy");
                        else if (info.PrefixRule.Trim() == "yyyyMM")
                            strCode += DateTime.Now.ToString("yyyyMM");
                        else if (info.PrefixRule.Trim() == "yyyyMMdd")
                            strCode += DateTime.Now.ToString("yyyyMMdd");
                        else if (info.PrefixRule.Trim() == "SN")
                        {
                            string strWhere = "";
                            string strMaxSN = "";
                            if (ParentColumn != null && ParentColumn != "")
                                strWhere = ParentColumn + " ='" + strParentCode + "'";
                            else
                                strWhere = strFieldName + " like '" + strParentCode + strPrefix + strCode + "%" + "' and len(" + strFieldName + ") = " + (strParentCode.Length + info.LayerLength) + "";
                            dt = icodeset_0.SqlTable("Select Max(" + strFieldName + ") as MaxCode From " + strChildName + " where " + strWhere);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string strMaxCode = dt.Rows[0]["MaxCode"].ToString();
                                if (strMaxCode == "")
                                    strMaxCode = "0";
                                if ((strParentCode + strPrefix + strCode) != "")
                                {
                                    //strMaxSN = strMaxCode.Replace(strPrefix + strCode, "");
                                    if (strMaxCode.IndexOf(strParentCode + strPrefix + strCode) > -1)
                                    {
                                        strMaxSN = strMaxCode.Remove(strMaxCode.IndexOf(strParentCode + strPrefix + strCode), (strParentCode + strPrefix + strCode).Length).Insert(strMaxCode.IndexOf(strParentCode + strPrefix + strCode), "");
                                    }
                                    else
                                        strMaxSN = strMaxCode;
                                }
                                else
                                    strMaxSN = strMaxCode;

                                string newValue = Replace(new Regex(@"([^\0-9\s].*?)"), strMaxSN);

                                int intSN = Convert.ToInt32(newValue == "" ? "0" : newValue) + info.LayerStep;
                                strCode += intSN.ToString().PadLeft(info.LayerLength, '0');
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                return "";
            }
            return strParentCode + strPrefix + strCode;
        }
        public string GenerateCode(string strTableName, string strFieldName, string strType)
        {
            string strCode = "";
            string strPrefix = "";
            try
            {
                if (base.IsExistRecord("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "'"))
                {
                    DataTable dt = new DataTable();
                    List<CodeSetInfo> list = base.Find("TableName = '" + strTableName + "' and FieldName = '" + strFieldName + "'", "Order By LayerNumber");
                    strPrefix = list[0].StrPrefix.Trim();
                    foreach (CodeSetInfo info in list)
                    {
                        if (info.HasPrefix)
                            strPrefix = info.StrPrefix;
                        if (info.PrefixRule.Trim() == "yyyy")
                            strCode += DateTime.Now.ToString("yyyy");
                        else if (info.PrefixRule.Trim() == "yyyyMM")
                            strCode += DateTime.Now.ToString("yyyyMM");
                        else if (info.PrefixRule.Trim() == "yyyyMMdd")
                            strCode += DateTime.Now.ToString("yyyyMMdd");
                        else if (info.PrefixRule.Trim() == "SN")
                        {
                            string strWhere = strFieldName + " like '" + strPrefix + strCode + "%" + "'";
                            string strMaxSN = "";
                            dt = icodeset_0.SqlTable("Select Max(" + strFieldName + ") as MaxCode From " + strTableName + " where " + strWhere);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string strMaxCode = dt.Rows[0]["MaxCode"].ToString();
                                if (strMaxCode == "")
                                    strMaxCode = "0";
                                if ((strPrefix + strCode) != "")
                                {
                                    //strMaxSN = strMaxCode.Replace(strPrefix + strCode, "");
                                    if (strMaxCode.IndexOf(strPrefix + strCode) > -1)
                                    {
                                        strMaxSN = strMaxCode.Remove(strMaxCode.IndexOf(strPrefix + strCode), (strPrefix + strCode).Length).Insert(strMaxCode.IndexOf(strPrefix + strCode), "");
                                    }
                                    else
                                        strMaxSN = strMaxCode;
                                }
                                else
                                    strMaxSN = strMaxCode;

                                string newValue = Replace(new Regex(@"([^\0-9\s].*?)"), strMaxSN);

                                int intSN = Convert.ToInt32(newValue == "" ? "0" : newValue) + info.LayerStep;
                                strCode += intSN.ToString().PadLeft(info.LayerLength, '0');
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Random rad = new Random();
                    if (strType == "DICT")
                        strCode = rad.Next(100, 1000).ToString();
                    else
                        strCode = "SYS" + DateTime.Now.ToString("yyyyMMdd") + rad.Next(1000, 10000).ToString();
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                return "";
            }
            return strPrefix + strCode;
        }
        public string GenerateCodeEx(string strTableName, string strBusType, string strFieldName, string strType)
        {
            string strCode = "";
            string strPrefix = "";
            try
            {
                if (base.IsExistRecord("TableName = '" + strTableName + strBusType + "' and FieldName = '" + strFieldName + "'"))
                {
                    DataTable dt = new DataTable();
                    List<CodeSetInfo> list = base.Find("TableName = '" + strTableName + strBusType + "' and FieldName = '" + strFieldName + "'", "Order By LayerNumber");
                    strPrefix = list[0].StrPrefix.Trim();
                    foreach (CodeSetInfo info in list)
                    {
                        if (info.HasPrefix)
                            strPrefix = info.StrPrefix;
                        if (info.PrefixRule.Trim() == "yyyy")
                            strCode += DateTime.Now.ToString("yyyy");
                        else if (info.PrefixRule.Trim() == "yyyyMM")
                            strCode += DateTime.Now.ToString("yyyyMM");
                        else if (info.PrefixRule.Trim() == "yyyyMMdd")
                            strCode += DateTime.Now.ToString("yyyyMMdd");
                        else if (info.PrefixRule.Trim() == "SN")
                        {
                            string strWhere = strFieldName + " like '" + strPrefix + strCode + "%" + "'";
                            string strMaxSN = "";
                            dt = icodeset_0.SqlTable("Select Max(" + strFieldName + ") as MaxCode From " + strTableName + " where " + strWhere);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string strMaxCode = dt.Rows[0]["MaxCode"].ToString();
                                if (strMaxCode == "")
                                    strMaxCode = "0";
                                if ((strPrefix + strCode) != "")
                                {
                                    //strMaxSN = strMaxCode.Replace(strPrefix + strCode, "");
                                    if (strMaxCode.IndexOf(strPrefix + strCode) > -1)
                                    {
                                        strMaxSN = strMaxCode.Remove(strMaxCode.IndexOf(strPrefix + strCode), (strPrefix + strCode).Length).Insert(strMaxCode.IndexOf(strPrefix + strCode), "");
                                    }
                                    else
                                        strMaxSN = strMaxCode;
                                }
                                else
                                    strMaxSN = strMaxCode;

                                string newValue = Replace(new Regex(@"([^\0-9\s].*?)"), strMaxSN);

                                int intSN = Convert.ToInt32(newValue == "" ? "0" : newValue) + info.LayerStep;
                                strCode += intSN.ToString().PadLeft(info.LayerLength, '0');
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Random rad = new Random();
                    if (strType == "DICT")
                        strCode = rad.Next(100, 1000).ToString();
                    else
                        strCode = "SYS" + DateTime.Now.ToString("yyyyMMdd") + rad.Next(1000, 10000).ToString();
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                return "";
            }
            return strPrefix + strCode;
        }
        public static string Replace(Regex regex, string input)
        {
            string inputReplaced = null;

            inputReplaced = regex.Replace(input, "");

            return inputReplaced;
        }
    }
}
