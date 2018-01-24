namespace AnyWise.HWPMS.Entity
{
    using System;

    public class MyDenyAccessException : UnauthorizedAccessException
    {
        public MyDenyAccessException(string message) : base(message)
        {
        }
    }
}

