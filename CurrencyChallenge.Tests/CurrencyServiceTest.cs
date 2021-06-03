using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyChallenge.Entities;
using CurrencyChallenge.Infrastructure;
using CurrencyChallenge.Models;
using CurrencyChallenge.Services;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CurrencyChallenge.Tests
{
    public class CurrencyServiceTest : DbContext
    {
        [Fact]
        public async void GetCurrencyValueById_Returns_Data()
        {
            //Arrange
            int currencyId = 5;
            var ListOfCurrencies = A.Fake<List<string>>();
            var fakeCurrency = A.CollectionOfDummy<DolarExchangeRateModel>(1);
            var currencyMockedService = A.Fake<CurrencyService>();
            A.CallTo(() => currencyMockedService.GetDollarCurrentExchangeRate()).Returns(Task.FromResult(ListOfCurrencies));
            //Act

            var result = await currencyMockedService.GetCurrencyValueById(currencyId);
            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async void AddAsync_Returns_StatusCode200()
        {
            //Arrange
            var fakeServiceResponse = new ServiceResponse { StatusCode = 200, Message = " Success" };
            var fakeCurrency = A.Fake<Currency>();
            var currencyMockedService = A.Fake<CurrencyService>();
            //Act
             var result = await currencyMockedService.AddAsync(fakeCurrency);
            //Assert

            Assert.Equal(result.StatusCode, fakeServiceResponse.StatusCode);
        }
    }
}
