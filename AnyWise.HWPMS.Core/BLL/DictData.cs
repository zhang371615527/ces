namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Reflection;
    using System.Data.Common;
    using AnyWise.Framework.Commons;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public class DictData : BaseBLL<DictDataInfo>
    {
        public DictData()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }

        public bool InsertBatch(string DictType_ID, string Seq, string Data, string SplitType, string Remark, string UserName)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(DictType_ID) && !string.IsNullOrEmpty(Data))
            {
                string[] strArray2 = Data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                int num = -1;
                int totalWidth = 3;
                string s = Seq;
                if (int.TryParse(s, out num))
                {
                    totalWidth = s.Length;
                }
                if ((strArray2 != null) && (strArray2.Length > 0))
                {
                    DbTransaction transaction = base.CreateTransaction();
                    if (transaction != null)
                    {
                        try
                        {
                            foreach (string strDictTypeName in strArray2)
                            {
                                string strSeq;
                                int num5;
                                if (SplitType.Equals("split", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (!string.IsNullOrWhiteSpace(strDictTypeName))
                                    {
                                        foreach (string strDictTypeNameSub in strDictTypeName.Split(new char[] { ',', '，', ';', '；', '/', '、' }))
                                        {
                                            strSeq = "";
                                            if (num > 0)
                                            {
                                                num5 = num++;
                                                strSeq = num5.ToString().PadLeft(totalWidth, '0');
                                            }
                                            else
                                            {
                                                strSeq = string.Format("{0}{1}", s, num++);
                                            }
                                            this.InsertInfo(DictType_ID, strDictTypeNameSub, strSeq, Remark,UserName, transaction);
                                        }
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(strDictTypeName))
                                {
                                    strSeq = "";
                                    if (num > 0)
                                    {
                                        num5 = num++;
                                        strSeq = num5.ToString().PadLeft(totalWidth, '0');
                                    }
                                    else
                                    {
                                        strSeq = string.Format("{0}{1}", s, num++);
                                    }
                                    this.InsertInfo(DictType_ID, strDictTypeName, strSeq, Remark, UserName, transaction);
                                }
                            }
                            transaction.Commit();
                            result = true;
                        }
                        catch (Exception exception)
                        {
                            transaction.Rollback();
                            LogTextHelper.Error(exception);
                        }
                    }
                }
            }
            return result;
        }

        private void InsertInfo(string strDictTypeID, string strDictTypeName, string strRemark, string strSeq, string UserName, DbTransaction dbTransaction_0)
        {
            if (!string.IsNullOrWhiteSpace(strDictTypeName))
            {
                DictDataInfo info = new DictDataInfo
                {
                    Editor = UserName,
                    LastUpdated = DateTime.Now,
                    DictType_ID = strDictTypeID,
                    Name = strDictTypeName.Trim(),
                    Value = strDictTypeName.Trim(),
                    Remark = strSeq,
                    Seq = strRemark
                };
                base.Insert(info, dbTransaction_0);
            }
        }
    }
}

