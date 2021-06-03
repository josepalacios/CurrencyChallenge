using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyChallenge.Services
{
    public class ServiceResponse<T>
    {
        public T Result { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
        public Exception Exception { get; internal set; }
    }

    public class BaseService
    {
        public readonly Infrastructure.DatabaseContext _ctx;

        public BaseService(Infrastructure.DatabaseContext mainDBContext)
        {
            _ctx = mainDBContext;
        }

        protected async Task<ServiceResponse<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> func, int errorCode = 0)
        {
            var response = new ServiceResponse<TResult>();
            try
            {
                response.Result = await func.Invoke();
                response.ErrorCode = errorCode;
                response.HasError = false;
                response.Exception = null;
            }
            catch (Exception ex)
            {

                response.ErrorCode = errorCode;
                response.Result = default(TResult);
                response.HasError = true;
                response.Exception = ex;
            }

            return response;
        }
    }
}
