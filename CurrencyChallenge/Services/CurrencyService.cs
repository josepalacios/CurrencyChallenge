using CurrencyChallenge.Entities;
using CurrencyChallenge.Infrastructure;
using CurrencyChallenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyChallenge.Services
{
    public class CurrencyService
    {
        private readonly DatabaseContext _dbContext;
        private const int DollarId = 1;
        private const int RealId = 2;

        public CurrencyService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Public Methods
        public async Task<DolarExchangeRateModel> GetCurrencyValueById(int currencyId)
        {
            var dollarInformation = await GetDollarCurrentExchangeRate();
            var currencyExchangeValue = new DolarExchangeRateModel();

            if (currencyId == DollarId)
            {
                currencyExchangeValue.PurchasePrice = decimal.Parse(dollarInformation[0]);
                currencyExchangeValue.SalePrice = decimal.Parse(dollarInformation[1]);
            }
            else if (currencyId == RealId)
            {
                currencyExchangeValue.PurchasePrice = Math.Round(decimal.Parse(dollarInformation[0]) / 4, 2);
                currencyExchangeValue.SalePrice = Math.Round(decimal.Parse(dollarInformation[1]) / 4, 2);
            }
            else
            {
                return null;
            }

            return currencyExchangeValue;
        }

        public async Task<ServiceResponse> AddAsync(Currency currency)
        {
            await _dbContext.Currencies.AddAsync(currency);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new ServiceResponse { StatusCode = 200, Message = "Ok" };
            }
            return new ServiceResponse { StatusCode = 400, Message = "Error adding currency" };
        }
        #endregion

        #region Private Methods

        public async Task<List<string>> GetDollarCurrentExchangeRate()
        {
            var dollarExchangeRateValueUrl = "https://www.bancoprovincia.com.ar/Principal/Dolar";
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(dollarExchangeRateValueUrl);
                var dollarInformation = JsonConvert.DeserializeObject<List<string>>(response);
                return await Task.FromResult(dollarInformation.ToList());
            }
        }
        #endregion
    }
}
