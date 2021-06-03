using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace CurrencyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : BaseController
    {
        private readonly Services.CurrencyService _currencyService;

        public CurrencyController(IMapper mapper, ILoggerManager logger, Services.CurrencyService currencyService) : base(mapper, logger)
        {
            _currencyService = currencyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyValueById([FromRoute] int id)
        {
            try
            {
                var serviceresponse = await _currencyService.GetCurrencyValueById(id);

                if (serviceresponse == null)
                {
                    return BadRequest("Currency id is not in the database");
                }
                return Ok(serviceresponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] Models.CurrencyModel currencyModel)
        {
            try
            {
                var currencyEntity = _Mapper.Map<Entities.Currency>(currencyModel);
                var serviceresponse = await _currencyService.AddAsync(currencyEntity);
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
