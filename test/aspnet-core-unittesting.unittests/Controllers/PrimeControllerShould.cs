using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Xunit;

namespace Aspnet.Core.Unittesting.Controllers
{
    public class PrimeController_Should
    {
        private readonly PrimeController _primeService;
        public PrimeController_Should()
        {
            _primeService = new PrimeController();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = (ObjectResult) _primeService.Get(value);
            var primeResult = (PrimeController.PrimeResult)result.Value;

            Assert.False(primeResult.IsPrime, $"{value} should not be prime");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void ReturnTrueGivenPrimesLessThan10(int value)
        {
            var result = (ObjectResult) _primeService.Get(value);
            var primeResult = (PrimeController.PrimeResult)result.Value;

            Assert.True(primeResult.IsPrime, $"{value} should be prime");
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void ReturnFalseGivenNonPrimesLessThan10(int value)
        {
            var result = (ObjectResult) _primeService.Get(value);
            var primeResult = (PrimeController.PrimeResult)result.Value;

            Assert.False(primeResult.IsPrime, $"{value} should not be prime");
        }
    }
}
