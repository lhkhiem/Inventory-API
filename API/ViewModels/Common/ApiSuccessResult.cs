namespace API.ViewModels.Common
{
    public class ApiSuccessResult<T>:ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string message,T resultObj)
        {
            IsSuccessed = true;
            Message = message;
            ResultObj = resultObj;
        }
    }
}
