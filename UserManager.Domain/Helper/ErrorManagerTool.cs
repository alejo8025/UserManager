using System;
using System.Reflection;
using UserManager.Model.Common;

namespace UserManager.Domain.Helper
{
    public class ErrorManagerTool
    {
        public ErrorManagerTool()
        {
        }

        public  Result<T> SetError<T>(Exception error, MethodBase method)
        {
            var result = new Result<T>
            {
                ReturnMessage = error.Message,
                IsSuccess = false
            };
            return result;
        }
    }
}
