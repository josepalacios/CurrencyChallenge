using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyChallenge.Controllers
{
    public class APIResponse<T>
    {

        public APIResponse()
        {
            HasError = false;
        }

        public bool HasError { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public class BaseController : ControllerBase
    {
        public readonly IMapper _Mapper;
        public readonly ILoggerManager _logger;

        public BaseController(IMapper mapper, ILoggerManager logger)
        {
            this._logger = logger;
            this._Mapper = mapper;
        }
    }
}
