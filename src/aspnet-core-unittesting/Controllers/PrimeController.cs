using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace Aspnet.Core.Unittesting.Controllers
{
    [Route("api/[controller]")]
    public class PrimeController : Controller
    {
        public class PrimeResult
        {
            public PrimeResult(int candidate, bool isPrime)
            {
                Candidate = candidate;
                IsPrime = isPrime;
            }

            public int Candidate { get; }

            public bool IsPrime { get; }

            public string Message
                => IsPrime ? $"'{Candidate}' IS a prime number." : $"'{Candidate}' IS NOT a prime number.";
        }

        // GET api/Prime/5
        [HttpGet("{candidate}")]
        [SwaggerResponse(
            HttpStatusCode.OK,
            Type = typeof(PrimeResult),
            Description = "The candidate IS a prime number.")]
        [SwaggerResponse(
            418,
            Type = typeof(PrimeResult),
            Description = "The candidate IS NOT a prime number.")]
        public IActionResult Get(int candidate)
        {
            var result = new PrimeResult(candidate, IsPrime(candidate));

            return result.IsPrime ? Ok(result) : new ObjectResult(result) {StatusCode = 418};
        }

        private static bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            for (int divisor = 2; divisor <= Math.Sqrt(candidate); divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
