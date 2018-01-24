using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface ICodeSetService : IBaseService<CodeSetInfo>
    {
        [OperationContract]
        List<CListItem> GetTableItems();
        [OperationContract]
        List<CListItem> GetColumnItems(string TableName);
        [OperationContract]
        string GenerateTreeCode(string strParentCode, string strTableName, string strFieldName, int Layer, string ParentColumn);
        [OperationContract]
        string GenerateTreeChildCode(string strParentCode, string strTableName, string strChildName, string strFieldName, int Layer, string ParentColumn);
        [OperationContract]
        string GenerateCode(string strTableName, string strFieldName, string strType);
        [OperationContract]
        string GenerateCodeEx(string strTableName, string strBusType, string strFieldName, string strType);
    }
}
