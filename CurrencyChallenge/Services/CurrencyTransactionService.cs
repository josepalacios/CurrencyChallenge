using CurrencyChallenge.Entities;
using CurrencyChallenge.Infrastructure;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyChallenge.Services
{
    public class CurrencyTransactionService
    {
        private readonly DatabaseContext _dbContext;
        private readonly CurrencyService _currencyService;

        public CurrencyTransactionService(DatabaseContext dbContext, CurrencyService currencyService)
        {
            _dbContext = dbContext;
            _currencyService = currencyService;
        }

        #region Public Methods
        public async Task<ServiceResponse> AddAsync(CurrencyTransaction currencyTransaction)
        {
            if (!ValidateCurrencyId(currencyTransaction.CurrencyId))
            {
                return new ServiceResponse { StatusCode = 400, Message = "Invalid Currency Id" };
            }
            
            var totalCurrentPurchaseAmount = GetTotalPurchasedAmount(currencyTransaction.PurchasedAmount, currencyTransaction.CurrencyId);
            if (!validatePurchaseAmountByCurrency(currencyTransaction.CurrencyId, totalCurrentPurchaseAmount))
            {
                return new ServiceResponse { StatusCode = 406, Message = "The amount to buy exceeds the limit of this currency" };
            }
            
            
            if (!ValidateTotalPurchaseAmountByUserAndMonth(currencyTransaction, totalCurrentPurchaseAmount))
            {
                return new ServiceResponse { StatusCode = 406, Message = "The amount to buy exceeds the limit of the current month" };
            }

            currencyTransaction.PurchasedAmount = GetTotalPurchasedAmount(currencyTransaction.PurchasedAmount, currencyTransaction.CurrencyId);

            await _dbContext.CurrencyTransactions.AddAsync(currencyTransaction);
            await _dbContext.SaveChangesAsync();
            return new ServiceResponse { StatusCode = 200, Message = "Ok" };
        }
        #endregion

        #region
        private bool ValidateTotalPurchaseAmountByUserAndMonth(CurrencyTransaction currencyTransaction, decimal totalCurrentPurchaseAmount)
        {
            var userPurchaseInformation = GetPurchaseAmountByUserAndMonth(currencyTransaction);
            userPurchaseInformation += totalCurrentPurchaseAmount;

            return validatePurchaseAmountByCurrency(currencyTransaction.CurrencyId, userPurchaseInformation);
        }

        public decimal GetPurchaseAmountByUserAndMonth(CurrencyTransaction currencyTransaction)
        {
            var firstDayOfMonth = new DateTime(currencyTransaction.TransactionDate.Year, currencyTransaction.TransactionDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);


            var test = _dbContext.CurrencyTransactions
                .Where(ct => ct.UserId == currencyTransaction.UserId && ct.CurrencyId == currencyTransaction.CurrencyId &&
                ct.TransactionDate >= firstDayOfMonth && ct.TransactionDate <= lastDayOfMonth).Sum(pa => pa.PurchasedAmount);
            return test;
        }

        private bool validatePurchaseAmountByCurrency(int currencyId, decimal purchaseAmount)
        {
            if (currencyId == 1 && purchaseAmount > 200)
            {
                return false;
            }

            else if (currencyId == 2 && purchaseAmount > 300)
            {
                return false;
            }
            return true;
        }

        private decimal GetTotalPurchasedAmount(decimal purchaseAmount, int currencyId)
        {
            var currentCurrencyValue = _currencyService.GetCurrencyValueById(currencyId);
            return purchaseAmount / currentCurrencyValue.Result.PurchasePrice;
        }

        private bool ValidateCurrencyId(int currencyId)
        {
            if (currencyId == 1 || currencyId == 2)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
