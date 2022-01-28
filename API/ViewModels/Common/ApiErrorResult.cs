﻿namespace API.ViewModels.Common
{
    public class ApiErrorResult<T>:ApiResult<T>
    {
        public ApiErrorResult()
        {
            IsSuccessed = false;
        }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
    }
}
