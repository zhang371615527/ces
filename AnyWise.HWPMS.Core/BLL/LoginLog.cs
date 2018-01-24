namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class LoginLog : BaseBLL<LoginLogInfo>
    {
        public LoginLog()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void AddLoginLog(UserInfo info, string systemType, string ip, string macAddr, string note)
        {
            if (info != null)
            {
                try
                {
                    LoginLogInfo info2 = new LoginLogInfo {
                        IPAddress = ip,
                        MacAddress = macAddr,
                        LastUpdated = DateTime.Now,
                        Note = note,
                        SystemType_ID = systemType,
                        User_ID = info.ID.ToString(),
                        FullName = info.FullName,
                        LoginName = info.Name,
                        Company_ID = info.Company_ID,
                        CompanyName = info.CompanyName
                    };
                    BLLFactory<LoginLog>.Instance.Insert(info2);
                }
                catch (Exception exception)
                {
                    LogTextHelper.Error(exception);
                }
            }
        }

        public void DeleteMonthLog()
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("LastUpdated", DateTime.Now.AddDays(-30.0), SqlOperator.LessThanOrEqual);
            string str = condition.BuildConditionSql().Replace("Where", "");
            base.baseDal.DeleteByCondition(str);
        }

        public LoginLogInfo GetLastLoginInfo(string userId)
        {
            ILoginLog baseDal = base.baseDal as ILoginLog;
            return baseDal.GetLastLoginInfo(userId);
        }

        public List<LoginLogInfo> GetList(DateTime LastUpdated)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("LastUpdated", LastUpdated, SqlOperator.MoreThanOrEqual);
            string str = condition.BuildConditionSql().Replace("Where", "");
            return this.Find(str);
        }

        public void InsertOrUpdate(List<LoginLogInfo> infoList)
        {
            if ((infoList != null) && (infoList.Count > 0))
            {
                foreach (LoginLogInfo info in infoList)
                {
                    LoginLogInfo info2 = base.baseDal.FindByID(info.ID);
                    if (info2 != null)
                    {
                        if (info2.LastUpdated < info.LastUpdated)
                        {
                            base.baseDal.Update(info, info.ID.ToString());
                        }
                    }
                    else
                    {
                        base.baseDal.Insert(info);
                    }
                }
            }
        }
    }
}

