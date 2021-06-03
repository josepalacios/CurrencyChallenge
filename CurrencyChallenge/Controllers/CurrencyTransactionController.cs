using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace CurrencyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyTransactionController : BaseController
    {
        private readonly Services.CurrencyTransactionService _currencyTransactionService;

        public CurrencyTransactionController(IMapper mapper, ILoggerManager logger, Services.CurrencyTransactionService currencyTransactionService) : base(mapper, logger)
        {
            _currencyTransactionService = currencyTransactionService;
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] Models.CurrencyTransactionModel currencyModel)
        {
            try
            {
                var currencyEntity = _Mapper.Map<Entities.CurrencyTransaction>(currencyModel);
                var serviceresponse = await _currencyTransactionService.AddAsync(currencyEntity);
                if (serviceresponse.StatusCode == 200)
                {
                    return Ok(serviceresponse);
                }
                return BadRequest(serviceresponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
            
        }
    }
}
