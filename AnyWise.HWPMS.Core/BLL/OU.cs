namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;
    using System.Data.Common;

    public class OU : BaseBLL<OUInfo>
    {
        private IOU iou_0;

        public OU()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iou_0 = base.baseDal as IOU;
        }

        public void AddUser(int userID, int ouID)
        {
            if (this.OUInRole(ouID, "超级管理员"))
            {
                new User().method_0(userID);
            }
            this.iou_0.AddUser(userID, ouID);
        }

        public List<OUInfo> GetOUsByRole(int roleID)
        {
            return this.iou_0.GetOUsByRole(roleID);
        }

        public List<OUInfo> GetOUsByUser(int userID)
        {
            return this.iou_0.GetOUsByUser(userID);
        }

        public bool OUInRole(int ouID, string roleName)
        {
            bool flag = false;
            using (List<RoleInfo>.Enumerator enumerator = new Role().GetRolesByOU(ouID).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    RoleInfo current = enumerator.Current;
                    if (current.Name == roleName)
                    {
                        flag = true;
                    }
                }       
            }
            return flag;
        }

        public void RemoveUser(int userID, int ouID)
        {
            if (this.OUInRole(ouID, "超级管理员"))
            {
                List<SimpleUserInfo> list = new Role().getSimpleUserList();
                if (list.Count == 1)
                {
                    SimpleUserInfo info = list[0];
                    if (userID == info.ID)
                    {
                        throw new MyException("超级管理员角色至少需要包含一个用户！");
                    }
                }
            }
            this.iou_0.RemoveUser(userID, ouID);
        }

        public OUInfo GetTopGroup()
        {
            string str = string.Format("PID=-1 ", new object[0]);
            return this.FindSingle(str);
        }

        public List<OUInfo> GetAllCompany()
        {
            string str = string.Format("Category='公司' ", new object[0]);
            return this.Find(str);
        }

        public List<OUInfo> GetGroupCompany()
        {
            string str = string.Format("Category='公司' or Category='集团' ", new object[0]);
            return this.Find(str);
        }

        public void DeleteByFlag(string IDs, string flag)
        {
            string[] sArray = IDs.Split(new char[] { ',' });
            string vsWhere = "", vsSql = "";
            for (int i = 0; i < sArray.Length; i++)
            {
                vsWhere += "'" + sArray[i] + "'" + ",";
            }
            vsWhere = vsWhere.Substring(0, vsWhere.Length - 1);
            vsWhere = " where ID in (" + vsWhere + ")";

            switch ( flag )
            {
                case "OU":
                    vsSql = "Delete from T_ACL_OU_Error ";
                    break;
                case "RY":
                    vsSql = "Delete from TB_RYZD_error ";
                    break;
                case "GZL":
                    vsSql = "Delete from BIZ_YLJXFLGZL_Error ";
                    break;
                case "CB":
                    vsSql = "Delete from BIZ_CBMXB_Error ";
                    break;
                default:
                    vsSql = "";
                    break;
            }
            if(vsSql=="")
                throw new MyException("参数传递有误，请检查！");
            else
            {
                this.iou_0.SqlExecute(vsSql + vsWhere);
            }
        }

        public void Truncate(string flag)
        {
            string vsSql = "";
            switch (flag)
            {
                case "OU":
                    vsSql = "Truncate table T_ACL_OU_Error ";
                    break;
                case "RY":
                    vsSql = "Truncate table TB_RYZD_error ";
                    break;
                case "GZL":
                    vsSql = "Truncate table BIZ_YLJXFLGZL_Error ";
                    break;
                case "CB":
                    vsSql = "Truncate table BIZ_CBMXB_Error ";
                    break;
                default:
                    vsSql = "";
                    break;
            }
            if (vsSql == "")
                throw new MyException("参数传递有误，请检查！");
            else
            {
                this.iou_0.SqlExecute(vsSql);
            }
        }

        public void SaveGZLData(YljxflgzlInfo info)
        {
            string vsSql = "";
            vsSql = "Update BIZ_YLJXFLGZL_Error set Year = '" + info.Year + "',Month = '" + info.Month + "',Date = '" + info.Date + "',"
                + "Source = '" + info.Source + "',KSZD_ID = '" + info.KszdId + "',KSZD_Name = '" + info.KszdName + "',RYZD_ID = '" + info.RyzdId + "',"
                + "RYZD_Name = '" + info.RyzdName + "',XMLB_ID = '" + info.Xmlbid + "',XMLB_Name = '" + info.XmlbName + "',XMZD_ID = '" + info.XmzdId + "',"
                + "XMZD_Name = '" + info.XmzdName + "',Unit = '" + info.Unit + "',Quantity = " + info.Quantity + ",Value = " + info.Value + ",Note = '" + info.Note + "', "
                + "Editor = '" + info.Editor + "',EditTime = '" + info.EditTime + "' where ID = '" + info.ID + "'";
            this.iou_0.SqlExecute(vsSql);
        }
        public void GZLZH(string IDs)
        {
            string[] sArray = IDs.Split(new char[] { ',' });
            string vsWhere = "", vsInsertSql = "", vsDeleteSql = "";
            for (int i = 0; i < sArray.Length; i++)
            {
                vsWhere += "'" + sArray[i] + "'" + ",";
            }
            vsWhere = vsWhere.Substring(0, vsWhere.Length - 1);
            vsWhere = " where ID in (" + vsWhere + ")";
            DbTransaction sqlDbTransaction = iou_0.CreateTransaction();
            try
            {
                vsInsertSql = "Insert Into BIZ_YLJXFLGZL(ID,GZLID,Year,Month,Date,Source,XMZD_ID,XMZD_Name,XMLB_ID,XMLB_Name,"
                    + " ZXZD_ID,KSZD_ID,KSZD_Name,BQID,RYZD_ID,RYZD_Name,Type,Unit,Quantity,Value,"
                    + " IsDrugIncome,Creator,CreateTime,Editor,EditTime,Note)"
                    + " Select newid(),GZLID,Year,Month,Date,Source,XMZD_ID,XMZD_Name,XMLB_ID,XMLB_Name,"
                    + " ZXZD_ID,KSZD_ID,KSZD_Name,BQID,RYZD_ID,RYZD_Name,Type,Unit,Quantity,Value,"
                    + " IsDrugIncome,Creator,CreateTime,Editor,EditTime,isnull(Note,'')+'找回'"
                    + " From BIZ_YLJXFLGZL_Error ";

                vsDeleteSql = "Delete from BIZ_YLJXFLGZL_Error ";

                this.iou_0.SqlExecute(vsInsertSql + vsWhere, sqlDbTransaction);
                this.iou_0.SqlExecute(vsDeleteSql + vsWhere, sqlDbTransaction);

                sqlDbTransaction.Commit();
            }
            catch
            {
                sqlDbTransaction.Rollback();
                throw;
            }
        }
    }
}

