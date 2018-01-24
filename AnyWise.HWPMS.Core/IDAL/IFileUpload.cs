namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Collections.Generic;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IFileUpload : IBaseDAL<FileUploadInfo>
    {
        List<FileUploadInfo> GetByAttachGUID(string attachmentGUID);
    }
}

