namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class Function : BaseBLL<FunctionInfo>
    {
        private IFunction ifunction_0;

        public Function()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ifunction_0 = base.baseDal as IFunction;
        }
        public List<FunctionInfo> GetAllFunction(string systemType)
        {
            return this.ifunction_0.GetAllFunction(systemType);
        }
        public List<FunctionNodeInfo> GetFunctionNodes(string roleIDs, string typeID)
        {
            if (roleIDs == string.Empty)
            {
                roleIDs = "-1";
            }
            return this.ifunction_0.GetFunctionNodes(roleIDs, typeID);
        }

        public List<FunctionInfo> GetFunctions(string roleIDs, string typeID)
        {
            if (roleIDs == string.Empty)
            {
                roleIDs = "-1";
            }
            return this.ifunction_0.GetFunctions(roleIDs, typeID);
        }

        public List<FunctionInfo> GetFunctionsByRole(int roleID)
        {
            return this.ifunction_0.GetFunctionsByRole(roleID);
        }

        public List<FunctionInfo> GetFunctionsByUser(int userID, string typeID)
        {
            List<RoleInfo> rolesByUser = new Role().GetRolesByUser(userID);
            string str = ",";
            foreach (RoleInfo info in rolesByUser)
            {
                str = str + info.ID + ",";
            }
            str = str.Trim(new char[] { ',' });
            List<FunctionInfo> functions = new List<FunctionInfo>();
            if (!string.IsNullOrEmpty(str))
            {
                functions = this.GetFunctions(str, typeID);
            }
            return functions;
        }

        public List<FunctionNodeInfo> GetTree(string systemType)
        {
            return this.ifunction_0.GetTree(systemType);
        }

        public List<FunctionNodeInfo> GetTreeByID(string mainID)
        {
            return this.ifunction_0.GetTreeByID(mainID);
        }
    }
}

