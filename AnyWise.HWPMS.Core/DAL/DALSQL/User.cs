namespace AnyWise.HWPMS.DALSQL
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class User : BaseDALSQL<UserInfo>, IBaseDAL<UserInfo>, IUser
    {
        public User() : base("T_ACL_User", "ID")
        {
            base.sortField = "SortCode";
            base.isDescending = false;
        }

        protected override UserInfo DataReaderToEntity(IDataReader dataReader)
        {
            UserInfo info = new UserInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.ID = reader.GetInt32("ID");
            info.PID = reader.GetInt32("PID");
            info.HandNo = reader.GetString("HandNo");
            info.Name = reader.GetString("Name");
            info.Password = reader.GetString("Password");
            info.FullName = reader.GetString("FullName");
            info.Nickname = reader.GetString("Nickname");
            info.IsExpire = reader.GetBoolean("IsExpire");
            info.Title = reader.GetString("Title");
            info.IdentityCard = reader.GetString("IdentityCard");
            info.MobilePhone = reader.GetString("MobilePhone");
            info.OfficePhone = reader.GetString("OfficePhone");
            info.HomePhone = reader.GetString("HomePhone");
            info.Email = reader.GetString("Email");
            info.Address = reader.GetString("Address");
            info.WorkAddr = reader.GetString("WorkAddr");
            info.Gender = reader.GetString("Gender");
            info.Birthday = reader.GetDateTime("Birthday");
            info.QQ = reader.GetString("QQ");
            info.Signature = reader.GetString("Signature");
            info.AuditStatus = reader.GetString("AuditStatus");
            info.Portrait = reader.GetBytes("Portrait");
            info.Note = reader.GetString("Note");
            info.CustomField = reader.GetString("CustomField");
            info.Dept_ID = reader.GetString("Dept_ID");
            info.DeptName = reader.GetString("DeptName");
            info.Company_ID = reader.GetString("Company_ID");
            info.CompanyName = reader.GetString("CompanyName");
            info.SortCode = reader.GetString("SortCode");
            info.Creator = reader.GetString("Creator");
            info.Creator_ID = reader.GetString("Creator_ID");
            info.CreateTime = reader.GetDateTime("CreateTime");
            info.Editor = reader.GetString("Editor");
            info.Editor_ID = reader.GetString("Editor_ID");
            info.EditTime = reader.GetDateTime("EditTime");
            info.Deleted = reader.GetInt32("Deleted");
            info.Question = reader.GetString("Question");
            info.Answer = reader.GetString("Answer");
            info.LastLoginIP = reader.GetString("LastLoginIP");
            info.LastLoginTime = reader.GetDateTime("LastLoginTime");
            info.LastMacAddress = reader.GetString("LastMacAddress");
            info.CurrentLoginIP = reader.GetString("CurrentLoginIP");
            info.CurrentLoginTime = reader.GetDateTime("CurrentLoginTime");
            info.CurrentMacAddress = reader.GetString("CurrentMacAddress");
            info.LastPasswordTime = reader.GetDateTime("LastPasswordTime");
            return info;
        }

        public override bool Delete(object key)
        {
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = null;
            DbTransaction transaction = null;
            try
            {
                UserInfo info = this.FindByID(key);
                if (info != null)
                {
                    using (DbConnection connection = database.CreateConnection())
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        string str = string.Format("UPDATE {2} SET PID={0} Where PID={1}", info.PID, key, base.tableName);
                        sqlStringCommand = database.GetSqlStringCommand(str);
                        database.ExecuteNonQuery(sqlStringCommand, transaction);
                        str = string.Format("Delete From {1} Where ID ={0} ", key, base.tableName);
                        sqlStringCommand = database.GetSqlStringCommand(str);
                        database.ExecuteNonQuery(sqlStringCommand, transaction);
                        transaction.Commit();
                    }
                }
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return true;
        }

        protected override Hashtable GetHashByEntity(UserInfo obj)
        {
            UserInfo info = obj;
            Hashtable hash = new Hashtable();

            hash.Add("PID", info.PID);
            hash.Add("HandNo", info.HandNo);
            hash.Add("Name", info.Name);
            hash.Add("Password", info.Password);
            hash.Add("FullName", info.FullName);
            hash.Add("Nickname", info.Nickname);
            hash.Add("IsExpire", info.IsExpire);
            hash.Add("Title", info.Title);
            hash.Add("IdentityCard", info.IdentityCard);
            hash.Add("MobilePhone", info.MobilePhone);
            hash.Add("OfficePhone", info.OfficePhone);
            hash.Add("HomePhone", info.HomePhone);
            hash.Add("Email", info.Email);
            hash.Add("Address", info.Address);
            hash.Add("WorkAddr", info.WorkAddr);
            hash.Add("Gender", info.Gender);
            hash.Add("Birthday", info.Birthday);
            hash.Add("QQ", info.QQ);
            hash.Add("Signature", info.Signature);
            hash.Add("AuditStatus", info.AuditStatus);
            hash.Add("Portrait", info.Portrait);
            hash.Add("Note", info.Note);
            hash.Add("CustomField", info.CustomField);
            hash.Add("Dept_ID", info.Dept_ID);
            hash.Add("DeptName", info.DeptName);
            hash.Add("Company_ID", info.Company_ID);
            hash.Add("CompanyName", info.CompanyName);
            hash.Add("SortCode", info.SortCode);
            hash.Add("Creator", info.Creator);
            hash.Add("Creator_ID", info.Creator_ID);
            hash.Add("CreateTime", info.CreateTime);
            hash.Add("Editor", info.Editor);
            hash.Add("Editor_ID", info.Editor_ID);
            hash.Add("EditTime", info.EditTime);
            hash.Add("Deleted", info.Deleted);
            hash.Add("Question", info.Question);
            hash.Add("Answer", info.Answer);
            hash.Add("LastLoginIP", info.LastLoginIP);
            hash.Add("LastLoginTime", info.LastLoginTime);
            hash.Add("LastMacAddress", info.LastMacAddress);
            hash.Add("CurrentLoginIP", info.CurrentLoginIP);
            hash.Add("CurrentLoginTime", info.CurrentLoginTime);
            hash.Add("CurrentMacAddress", info.CurrentMacAddress);
            hash.Add("LastPasswordTime", info.LastPasswordTime);

            return hash;
        }

        public byte[] GetPersonImageBytes(UserImageType imagetype, int userId)
        {
            string str = this.method_4(imagetype);
            string str2 = string.Format("Select {0} from {1} where Id = {2} ", str, base.tableName, userId);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str2);
            byte[] buffer = null;
            using (IDataReader reader = database.ExecuteReader(sqlStringCommand))
            {
                if (reader.Read())
                {
                    buffer = reader.IsDBNull(reader.GetOrdinal(str)) ? null : ((byte[]) reader[0]);
                }
            }
            return buffer;
        }

        public List<SimpleUserInfo> GetSimpleUsers()
        {
            string str = "Select ID,Name,Password,FullName From " + base.TableName;
            return this.GetSqlList(str);
        }

        public List<SimpleUserInfo> GetSimpleUsers(string userIDs)
        {
            string str = "Select ID,Name,Password,FullName From " + base.TableName + " Where ID In (" + userIDs + ")";
            return this.GetSqlList(str);
        }

        public List<SimpleUserInfo> GetSimpleUsersByOU(int ouID)
        {
            string str = "Select ID,Name,Password,FullName From T_ACL_OU_User Inner Join [T_ACL_User] ON [T_ACL_User].ID=User_ID Where OU_ID = " + ouID;
            return this.GetSqlList(str);
        }

        public List<SimpleUserInfo> GetSimpleUsersByRole(int roleID)
        {
            string str = "Select ID,Name,Password,FullName From [T_ACL_User] INNER JOIN T_ACL_User_Role ON [T_ACL_User].ID=User_ID Where Role_ID = " + roleID;
            return this.GetSqlList(str);
        }

        public List<UserInfo> GetUsersByOU(int ouID)
        {
            string sql = "SELECT * FROM [T_ACL_User] INNER JOIN T_ACL_OU_User On [T_ACL_User].ID=T_ACL_OU_User.User_ID WHERE OU_ID = " + ouID;
            return this.GetList(sql, null);
        }

        public List<UserInfo> GetUsersByRole(int roleID)
        {
            string sql = "SELECT * FROM [T_ACL_User] INNER JOIN T_ACL_User_Role On [T_ACL_User].ID=T_ACL_User_Role.User_ID WHERE Role_ID = " + roleID;
            return this.GetList(sql, null);
        }

        private List<SimpleUserInfo> GetSqlList(string strSQL)
        {
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(strSQL);
            List<SimpleUserInfo> list = new List<SimpleUserInfo>();
            using (IDataReader reader = database.ExecuteReader(sqlStringCommand))
            {
                SmartDataReader reader2 = new SmartDataReader(reader);
                while (reader.Read())
                {
                    SimpleUserInfo item = new SimpleUserInfo {
                        ID = reader2.GetInt32("ID"),
                        Name = reader2.GetString("Name"),
                        Password = reader2.GetString("Password"),
                        FullName = reader2.GetString("FullName")
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        private string method_4(UserImageType userImageType_0)
        {
            switch (userImageType_0)
            {
                case UserImageType.const_0:
                    return "Portrait";

                case UserImageType.const_1:
                    return "IDPhoto1";

                case UserImageType.const_2:
                    return "IDPhoto2";

                case UserImageType.const_3:
                    return "BusinessCard1";

                case UserImageType.const_4:
                    return "BusinessCard2";
            }
            return "Portrait";
        }

        public bool UpdatePersonImageBytes(UserImageType imagetype, int userId, byte[] imageBytes)
        {
            string str = this.method_4(imagetype);
            string str2 = string.Format("update {0} set {1}=@image where Id = {2} ", base.tableName, str, userId);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str2);
            database.AddInParameter(sqlStringCommand, "image", DbType.Binary, imageBytes);
            return (database.ExecuteNonQuery(sqlStringCommand) > 0);
        }

        public bool UpdateUserLoginData(int id, string ip, string macAddr)
        {
            string str = string.Format("Update {0} set LastLoginIP=CurrentLoginIP,LastLoginTime=CurrentLoginTime,LastMacAddress=CurrentMacAddress Where ID={1}", base.tableName, id);
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(str);
            database.ExecuteNonQuery(sqlStringCommand);
            str = string.Format("Update {0} Set CurrentLoginIP='{1}',CurrentMacAddress='{2}', CurrentLoginTime=@CurrentLoginTime Where ID = {3}", new object[] { base.tableName, ip, macAddr, id });
            sqlStringCommand = database.GetSqlStringCommand(str);
            database.AddInParameter(sqlStringCommand, "CurrentLoginTime", DbType.DateTime, DateTime.Now);
            return (database.ExecuteNonQuery(sqlStringCommand) > 0);
        }

        public bool InsertBatch(List<UserInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (UserInfo detail in list)
                    {
                        //detail.Seq = seq++;//增加1
                        /*
                        detail.CreateTime = DateTime.Now;
                        detail.Creator = CurrentUser.ID.ToString();
                        detail.Editor = CurrentUser.ID.ToString();
                        detail.EditTime = DateTime.Now;
                        */
                        this.Insert(detail, sqlDbTransaction);
                    }
                    sqlDbTransaction.Commit();
                    flag = true;
                }
                catch
                {
                    sqlDbTransaction.Rollback();
                    throw;
                }
            }
            return flag;
        }

        public static User Instance
        {
            get
            {
                return new User();
            }
        }
    }
}

